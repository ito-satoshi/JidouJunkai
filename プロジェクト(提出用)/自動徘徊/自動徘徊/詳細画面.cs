using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace 自動徘徊
{
    public partial class 詳細画面 : Form
    {
        MySqlConnection con;
        int x;
        string id;

        public 詳細画面()
        {
            InitializeComponent();
            webBrowser1.ScriptErrorsSuppressed = true;
        }

        public 詳細画面(int t,string ids) : this()
        {
            x = t;
            id = ids;
        }
        private void 詳細画面_Load(object sender, EventArgs e)
        {
            if (x != 15)
            {
                con = ((main)Owner).GetConnection();
                var command = new MySqlCommand($"select main_text from news_info where id = '{id}';", con);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string str = $"{reader["main_text"]}";
                    webBrowser1.DocumentText = str;
                }
                reader.Close();
                command = new MySqlCommand($"update news_info set alreadyread_flag = true where id = '{id}';",con);
                command.ExecuteNonQuery();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}