using System;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Timers;
using MySql.Data.MySqlClient;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace JidouJunkai_Service
{
    public partial class JidouJunkaiService : ServiceBase
    {
        static MySqlConnection con = new MySqlConnection("server=localhost;user=fsst;password=2455;database=jjdb;");
        static string text;
        static string[] url;
        static string[] id;
        static int j;
        static Timer timer;

        public JidouJunkaiService()
        {
            InitializeComponent();
        }

        public static void OnElapsed_TimersTimer(object sender, ElapsedEventArgs e)
        {
            News_check();
        }

        public static void News_check()
        {
            for (int t = 0; j != t && url[0] != ""; t++)
            {
                var command = new MySqlCommand($"select main_text from news_info where url_id = {id[t]} order by id desc limit 1;", con);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    text = $"{reader["main_text"]}";
                }
                reader.Close();
                Uri webUri = new Uri(url[t]);
                Task<string> webTask = GetWebPageAsync(webUri);
                webTask.Wait();
                string result = webTask.Result;
                if (result != null)
                {
                    Regex reg1 = new Regex("csrf", RegexOptions.IgnoreCase);
                    Match csrf1 = reg1.Match(result);
                    if (csrf1.Success == true)
                    {
                        Regex reg2 = new Regex("<", RegexOptions.RightToLeft);
                        Match csrf2 = reg2.Match(result, csrf1.Index);
                        Regex reg3 = new Regex(">");
                        Match csrf3 = reg3.Match(result, csrf1.Index);
                        string text2 = result.Substring(0, csrf2.Index);
                        text2 += result.Substring(csrf3.Index + 1, result.Length - csrf3.Index - 1);
                        result = text2;
                    }
                    string filePath = $"C:/Users/satoshi/Desktop/Projects/{t}before.text";
                    System.Text.Encoding enc = System.Text.Encoding.GetEncoding("shift_jis");
                    System.IO.File.WriteAllText(filePath, text, enc);
                    string filePath2 = $"C:/Users/satoshi/Desktop/Projects/{t}after.text";
                    System.Text.Encoding enc2 = System.Text.Encoding.GetEncoding("shift_jis");
                    System.IO.File.WriteAllText(filePath2, result, enc2);
                    if (result != text)
                    {
                        result = result.Replace("\\", "\\\\");
                        result = result.Replace("\"", "\\\"");
                        result = result.Replace("\'", "\\\'");
                        DateTime dt = DateTime.Now;
                        string date = dt.ToString("yyyy-MM-dd-hh-mm-ss");
                        command = new MySqlCommand($"insert into news_info (acquisition_date,url_id,main_text,alreadyread_flag) values ('{date}','{id[t]}','{result}',0);", con);
                        command.ExecuteNonQuery();
                        Console.WriteLine($"{date}");
                        Console.WriteLine("更新しました");
                    }
                    else
                    {
                        Console.WriteLine("最新の状態です");
                    }
                }
            }
        }

        static async Task<string> GetWebPageAsync(Uri uri)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(
                    "User-Agent",
                    "Mozilla/5.0 (Windows NT 6.3; Trident/7.0; rv:11.0) like Gecko");
                client.DefaultRequestHeaders.Add("Accept-Language", "ja-JP");
                client.Timeout = TimeSpan.FromSeconds(10.0);

                try
                {
                    return await client.GetStringAsync(uri);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\n例外発生");
                    Exception ex = e;
                    while (ex != null)
                    {
                        Console.WriteLine("例外メッセージ: {0} ", ex.Message);
                        ex = ex.InnerException;
                    }
                }
                catch (TaskCanceledException e)
                {
                    Console.WriteLine("\nタイムアウト");
                    Console.WriteLine("例外メッセージ: {0} ", e.Message);
                }
                return null;
            }
        }


        public static void Run()
        {
            News_check();
            var command = new MySqlCommand("select acquisition_interval from acquisition_interval;", con);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                timer = new Timer(int.Parse(reader["acquisition_interval"].ToString()));
            }
            timer.Elapsed += OnElapsed_TimersTimer;
            reader.Close();
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        protected override void OnStart(string[] args)
        {
            con.Open();
            var command = new MySqlCommand("select count(*) from url where delete_flag = 0;", con);
            int o = int.Parse(command.ExecuteScalar().ToString());
            Array.Resize(ref url, o);
            Array.Resize(ref id, o);
            if (o != 0)
            {
                command = new MySqlCommand("select id,url from url where delete_flag = 0;", con);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    url[j] = $"{reader["url"]}";
                    id[j] = $"{reader["id"]}";
                    j += 1;
                }
                reader.Close();
            }
            Run();
            Console.ReadLine();
            timer.Stop();
            timer.Dispose();
        }

        protected override void OnStop()
        {
            timer.Enabled = false;
            timer.Dispose();
            j = 0;
        }
    }
}
