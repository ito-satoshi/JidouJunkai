using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using MySql.Data.MySqlClient;
using System.Net.Http;

namespace 自動徘徊サービス
{
    /*
    class 巡回クラス
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user=fsst;password=2455;database=jjdb;");
        static string text;
        static string[] url;
        static int j;
        static Timer timer;

        public 巡回クラス()
        {
            con.Open();
            var command = new MySqlCommand("select count(*) from url where delete_flag = 0;", con);
            object o = command.ExecuteScalar();
            Array.Resize(ref url, int.Parse(o.ToString()));
            command = new MySqlCommand("select url from url where delete_flag = 0;", con);
            var reader = command.ExecuteReader();
            while(reader.Read())
            {
                url[j] = $"{reader["url"]}";
                j += 1;
            }
            reader.Close();
            Console.ReadLine();
        }

        public void OnElapsed_TimersTimer(object sender, ElapsedEventArgs e)
        {
            News_check();
        }

        public void News_check()
        {
            for (int t = 1; j > t; t++)
            {
                var command = new MySqlCommand($"select main_text from news_info where url_id = {t} order by acquisition_date desc limit 1;",con);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    text = $"{reader["main_text"]}";
                }
                reader.Close();
                string htmlString = GetWebPageAsync(url[t]).ToString();
                if (htmlString != text)
                {
                    command = new MySqlCommand($"insert into news_info (acquisition_date,url_id,main_text,alreadyread_flag) values (now(),'{t}','{htmlString}',0)",con);
                    command.ExecuteNonQuery();
                    Console.WriteLine("\n更新");
                }
            }
        }
        static async Task<string> GetWebPageAsync(string url)
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
                    return await client.GetStringAsync(new Uri(url));
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

        public void Run()
        {
            News_check();
            var command = new MySqlCommand("select acquisition_interval from acquisition_interval;", con);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                //timer.Interval = int.Parse(reader["acquisition_interval"].ToString());
                timer = new Timer(int.Parse(reader["acquisition_interval"].ToString()));
            }
            timer.Elapsed += OnElapsed_TimersTimer;
            //timer.Elapsed += new ElapsedEventHandler(OnElapsed_TimersTimer);
            reader.Close();
            timer.AutoReset = true;
            timer.Enabled = true;
        }

    }
    */
}
