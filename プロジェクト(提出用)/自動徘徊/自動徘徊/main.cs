using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.ServiceProcess;
using System.Drawing;

namespace 自動徘徊
{
    public partial class main : Form
    {
        private TextBox[] textBoxes;
        MySqlConnection con = new MySqlConnection("server=localhost;user=fsst;password=2455;database=jjdb;");
        Match title1;
        Match title2;
        int title3;
        string title;
        int p = 1;
        static int page;
        string[] ids = new string[15];
        int idx;
        int dts;
        public bool limit_flag = true;
        public int count = 3;
        List<string> listPKey = new List<string>();
        const string syamei = "SOFTWARE\\Loitering_Bashou\\JidouHaikai";
        static int m = 0;

        public main()
        {
            InitializeComponent();
            textBox2.Enter += new EventHandler(textBox1_Enter);
            textBox3.Enter += new EventHandler(textBox1_Enter);
            textBox4.Enter += new EventHandler(textBox1_Enter);
            textBox5.Enter += new EventHandler(textBox1_Enter);
            textBox6.Enter += new EventHandler(textBox1_Enter);
            textBox7.Enter += new EventHandler(textBox1_Enter);
            textBox8.Enter += new EventHandler(textBox1_Enter);
            textBox9.Enter += new EventHandler(textBox1_Enter);
            textBox10.Enter += new EventHandler(textBox1_Enter);
            textBox11.Enter += new EventHandler(textBox1_Enter);
            textBox12.Enter += new EventHandler(textBox1_Enter);
            textBox13.Enter += new EventHandler(textBox1_Enter);
            textBox14.Enter += new EventHandler(textBox1_Enter);
            textBox15.Enter += new EventHandler(textBox1_Enter);
            pageBar.Scroll += new EventHandler(pageBar_ScrollChanged);
            nextButton.BackColor = Color.Gray;
            lastpageButton.BackColor = Color.Gray;
            backButton.BackColor = Color.Gray;
            firstpageButton.BackColor = Color.Gray;
            nextButton.ForeColor = Color.White;
            lastpageButton.ForeColor = Color.White;
            backButton.ForeColor = Color.White;
            firstpageButton.ForeColor = Color.White;
            nextButton.Font = new Font("HGｺﾞｼｯｸM", 10, FontStyle.Bold);
            lastpageButton.Font = new Font("HGｺﾞｼｯｸM", 10, FontStyle.Bold);
            backButton.Font = new Font("HGｺﾞｼｯｸM", 10, FontStyle.Bold);
            firstpageButton.Font = new Font("HGｺﾞｼｯｸM", 10, FontStyle.Bold);
        }

        private void unread_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void main_Load(object sender, EventArgs e)
        {
            backButton.Enabled = false;
            firstpageButton.Enabled = false;
            AutoScroll = true;
            textBoxes = new TextBox[]
              {textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8,
                textBox9, textBox10, textBox11, textBox12, textBox13, textBox14, textBox15};
            con.Open();
            Redisplay();
            var command = new MySqlCommand("select count(*) from news_info inner join url on news_info.url_id = url.id where url.delete_flag = 0;", con);
            if (int.Parse(command.ExecuteScalar().ToString()) < 15)
            {
                nextButton.Enabled = false;
                lastpageButton.Enabled = false;
                pageBar.Maximum = 1;
            }
            pageBar.Maximum = max_check(m);
            pageBar.TickFrequency = 1;
            pageBar.Minimum = 1;
            listPKey.Add("5555555555555555555555555");
            Microsoft.Win32.RegistryKey regkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(syamei, false);
            if (regkey == null) return;
            int intValue = (int)regkey.GetValue("int");
            regkey.Close();
            if (intValue == 1)
            {
                limit_flag = false;
                cmdOpenDlg4.Enabled = false;
            }
        }

        private void pageBar_ScrollChanged(object sender, EventArgs e)
        {
            int check = pageBar.Value;
            if (check > p)
            {
                while (check != p)
                {
                    Next_page();
                }
            }
            else
            {
                while (check != p)
                {
                    Back_page();
                }
            }
        }

        public void Next_page()
        {
            backButton.Enabled = true;
            firstpageButton.Enabled = true;
            p += 1;
            page = (p - 1) * 15;
            Redisplay();
            pageBar.Value = p;
            if (p == max_check(m))
            {
                nextButton.Enabled = false;
                lastpageButton.Enabled = false;
            }
        }

        public void Back_page()
        {
            nextButton.Enabled = true;
            lastpageButton.Enabled = true;
            p -= 1;
            page = (p - 1) * 15;
            Redisplay();
            pageBar.Value = p;
            if (p == 1)
            {
                backButton.Enabled = false;
                firstpageButton.Enabled = false;
            }
        }

        public int max_check(int m)
        {
            int max = 0;
            if (m != 0)
            {
                if (m % 15 == 0)
                {
                    max = m / 15;
                }
                else
                {
                    max = (m / 15) + 1;
                }
            }
            else
            {
                max = 1;
            }
            return max;
        }

        private void urlchangecombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmdOpenDlg2_Click(object sender, EventArgs e)
        {
            using (ServiceController sc = new ServiceController("JidouJunkaiService"))
            {
                sc.Refresh();
                if (sc.Status == ServiceControllerStatus.Running)
                {
                    sc.Stop();
                }
                if (sc.Status == ServiceControllerStatus.Stopped)
                {
                    sc.Start();
                }
                Redisplay();
            }
        }

        private void app_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            con.Close();
        }

        private void cmdOpenDlg1_Click(object sender, EventArgs e)
        {
            DialogURL dlg = new DialogURL();
            dlg.ShowDialog(this);
            using (ServiceController sc = new ServiceController("JidouJunkaiService"))
            {
                sc.Refresh();
                if (sc.Status == ServiceControllerStatus.Running)
                {
                    sc.Stop();
                }
                if (sc.Status == ServiceControllerStatus.Stopped)
                {
                    sc.Start();
                }
                Redisplay();
            }
        }

        private void cmdOpenDlg3_Click(object sender, EventArgs e)
        {
            Help dlg = new Help();
            dlg.ShowDialog();
        }

        private void cmdOpenDlg4_Click(object sender, EventArgs e)
        {
            KeepOut dlg = new KeepOut();
            DialogResult dr = dlg.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                limit_flag = false;
                Microsoft.Win32.RegistryKey regkey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(syamei);
                regkey.SetValue("int", 1);
                cmdOpenDlg4.Enabled = false;
            }
        }

        private void cmdOpenDlg5_Click(object sender, EventArgs e)
        {
            Time dlg = new Time();
            dlg.ShowDialog(this);
        }

        public MySqlConnection GetConnection()
        {
            return con;
        }

        public bool Getlimit_flag()
        {
            return limit_flag;
        }

        public int GetURLCount()
        {
            if (limit_flag == true)
            {
                return count;
            }
            else
            {
                return -1;
            }

        }

        public bool IsContainPKey(string PK)
        {
            for (int i = 0; i < listPKey.Count; i++)
            {
                if (PK == listPKey[i])
                {
                    return true;
                }
            }
            return false;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            int t;
            t = int.Parse(((TextBox)sender).Tag.ToString());
            if (textBoxes[t].Text != "")
            {
                詳細画面 dlg = new 詳細画面(t, ids[t]);
                dlg.ShowDialog(this);
                ActiveControl = null;
            }
            else
            {
                t = 15;
                詳細画面 dlg = new 詳細画面(t, ids[0]);
                dlg.ShowDialog(this);
                ActiveControl = null;
            }
            Redisplay();
        }

        public void Redisplay()
        {
            int j = 0;
            while (j != 15)
            {
                textBoxes[j].Text = "";
                j += 1;
            }
            j = 0;
            string a = urlchangecombo.Text;
            string b = datecombo.Text;
            string c = wordtext.Text;
            string url = "";
            string date = "";
            string word = "";
            string h = "";
            string d = "";
            string g = "";
            string f = "";
            if (a != "" && a != "　　　　　　　　　　　URL")
            {
                url = $" url = '{a}'";
            }
            if (b != "")
            {
                date = $" acquisition_date = '{b}'";
            }
            if (c != "")
            {
                word = $" main_text like '%{c}%'";
            }
            string read = "";
            if (radioButton1.Checked == true)
            {
                read = " alreadyread_flag = 1";
            }
            else if (radioButton2.Checked == true)
            {
                read = " alreadyread_flag = 0";
            }
            else
            {
                read = "";
            }
            if (date != "" || url != "")
            {
                d = "and";
            }
            if (word != "" && (url != "" || date != ""))
            {
                g = "and";
            }
            if (read != "" && (url != "" || date != "" || word != ""))
            {
                f = "and";
            }
            if (url != "" || date != "" || word != "" || read != "")
            {
                h = "and";
            }
            var command = new MySqlCommand($"select news_info.id,acquisition_date,url.url,main_text,alreadyread_flag from news_info inner join url on news_info.url_id = url.id where {url} {d} {date} {g} {word} {f} {read} {h} url.delete_flag = 0 order by id desc limit {page}, 15;", con);
            var reader = command.ExecuteReader();
            while (reader.Read() && j != 15)
            {
                textBoxes[j].Text = Convert.ToDateTime(reader["acquisition_date"]).ToString("yyyy/MM/dd");
                ids[j] = $"{reader["id"]}";
                if (Convert.ToBoolean(reader["alreadyread_flag"]) == true)
                {
                    textBoxes[j].Text += "\t 既読\r\n";
                    textBoxes[j].BackColor = Color.LimeGreen;
                }
                else
                {
                    textBoxes[j].Text += "\t 未読\r\n";
                    textBoxes[j].BackColor = Color.Lime;
                }
                textBoxes[j].Text += $"{reader["url"]}\r\n";
                Regex reg1 = new Regex("<title>", RegexOptions.IgnoreCase);
                title1 = reg1.Match(reader["main_text"].ToString());
                if (title1.Success == true)
                {
                    Regex reg2 = new Regex("</title>", RegexOptions.IgnoreCase);
                    title2 = reg2.Match(reader["main_text"].ToString());
                    title3 = title2.Index - title1.Index;
                    title = reader["main_text"].ToString().Substring(title1.Index + 7, title3 - 7);
                    textBoxes[j].Text += $"{title}";
                }
                else
                {
                    textBoxes[j].Text += "タイトルが見つかりませんでした。";
                }
                j += 1;
            }
            reader.Close();
            command = new MySqlCommand($"select count(*) from news_info inner join url on news_info.url_id = url.id where {url} {d} {date} {g} {word} {f} {read} {h} url.delete_flag = 0", con);
            m = int.Parse(command.ExecuteScalar().ToString());
            if (j == 0 && m != 0)
            {
                firstpage_back();
            }
            if (max_check(m) > p)
            {
                nextButton.Enabled = true;
                lastpageButton.Enabled = true;
            }
            pageBar.Maximum = max_check(m);
            if (1 == max_check(m))
            {
                nextButton.Enabled = false;
                lastpageButton.Enabled = false;
            }
            url = ""; word = ""; date = ""; read = ""; a = ""; b = ""; c = ""; d = ""; g = ""; f = ""; h = "";
            command = new MySqlCommand("select acquisition_date,url.url from news_info inner join url on news_info.url_id = url.id where url.delete_flag = 0;", con);
            reader = command.ExecuteReader();
            urlchangecombo.Items.Clear();
            datecombo.Items.Clear();
            while (reader.Read())
            {
                idx = urlchangecombo.Items.IndexOf(reader["url"]);
                if (idx == -1)
                {
                    urlchangecombo.Items.Add(reader["url"]);
                }
                dts = datecombo.Items.IndexOf(reader["acquisition_date"]);
                if (dts == -1)
                {
                    datecombo.Items.Add(reader["acquisition_date"]);
                }
            }
            reader.Close();
        }

        private void redisplaybutton_Click(object sender, EventArgs e)
        {
            Redisplay();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void nextButton_Click(object sender, EventArgs e)
        {
            Next_page();
        }
        private void backButton_Click(object sender, EventArgs e)
        {
            Back_page();
        }

        private void lastpageButton_Click(object sender, EventArgs e)
        {
            backButton.Enabled = true;
            firstpageButton.Enabled = true;
            p = max_check(m);
            page = (p - 1) * 15;
            Redisplay();
            pageBar.Value = max_check(m);
            nextButton.Enabled = false;
            lastpageButton.Enabled = false;
        }

        private void firstpageButton_Click(object sender, EventArgs e)
        {
            firstpage_back();
        }
        public void firstpage_back()
        {
            nextButton.Enabled = true;
            lastpageButton.Enabled = true;
            p = 1;
            page = (p - 1) * 15;
            Redisplay();
            pageBar.Value = p;
            backButton.Enabled = false;
            firstpageButton.Enabled = false;
        }

    }
}