using MySql.Data.MySqlClient;
using System;
using System.Net;
using System.Windows.Forms;

namespace 自動徘徊
{
    

    public partial class DialogURL : Form
    {
        MySqlConnection mai;
        bool limit;
        int count;
        int[] c;        // 配列 url_id共
        public DialogURL()

        {
            InitializeComponent();
        }
    

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
        
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void 追加_Click(object sender, EventArgs e)
        {
            while (textBox1.Text.Substring(textBox1.Text.Length - 1, 1) == "/" || textBox1.Text.Substring(textBox1.Text.Length - 1, 1) == " ")
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);

            }
            
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(textBox1.Text);       ///WebRequestのcreate castしている
                req.Proxy = null;
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                if (((int)res.StatusCode)>=400)
                {
                    // メッセージを出力

                    MessageBox.Show("エラーが発生しましたよ！！" + res.StatusCode.ToString(),
                   "エラー",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
  
                    return;
                }
            }
            catch (WebException)                      ///WebException が発生したら
            {
                MessageBox.Show("そのURLは無効です。" ,
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            catch (UriFormatException)
            {
                MessageBox.Show("適切なURLを入力してください!!" ,
                     "エラー",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
                return;
            }
            MySqlCommand cnt = new MySqlCommand("select count(*)  from url where url = '" + textBox1.Text + "';", mai);
            cnt.ExecuteScalar();
            int  vit = int.Parse(cnt.ExecuteScalar().ToString());
            
            if (vit > 0)
            {
                {
                    MySqlCommand dx = new MySqlCommand("select delete_flag  from url where url = '" + textBox1.Text + "';", mai);
                    dx.ExecuteNonQuery();
                    int d = listBox1.Items.Count;
                    if (d == count)
                    {
                        MessageBox.Show("続きは課金してからな！",
                    "エラー",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error);
                    }
                    else
                    {
                        bool ztooo = bool.Parse(dx.ExecuteScalar().ToString());
                        if (ztooo == true)
                        {
                            MySqlCommand upd = new MySqlCommand("update url set update_date = now(),delete_flag = false where url  ='" + textBox1.Text + "'; ", mai);
                            upd.ExecuteNonQuery();
                            Array.Resize(ref c, c.Length + 1);
                            syutoku();
                        }
                        else
                        {
                            MessageBox.Show("そのURLは既に登録されています。違うURLを登録してください",                 ///共通の処理
                    "エラー",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error);

                        }
                    }
                    
                }
            }
           else
            {
                if (追加.Text == "変更")
                {
                    MySqlCommand up = new MySqlCommand("update url set update_date = now(),url  ='" + textBox1.Text + "'where url = '" + listBox1.SelectedItem.ToString() + "'; ", mai);
                    up.ExecuteNonQuery();
                    syutoku();
                }
                else
                {
                    int d = listBox1.Items.Count;
                    if (d == count)
                    {
                        MessageBox.Show("続きは課金してからな！",
                    "エラー",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error);
                    }
                    else
                    {
                        MySqlCommand ins = new MySqlCommand("insert into url(url,create_date,update_date,delete_flag) values ('" + textBox1.Text + "',now(),now(),false);", mai);
                        ins.ExecuteNonQuery();
                        Array.Resize(ref c, c.Length + 1);
                        syutoku();
                    }
                    
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.ResetText();
            int a = listBox1.SelectedIndex;
            MySqlCommand com = new MySqlCommand("update url set delete_flag = true ,update_date = now() where id = " + c[listBox1.SelectedIndex] + ";", mai);
            listBox1.Items.RemoveAt(a);
            for (int i = a; i < c.Length - 1; i++)
            {
                c[i] = c[i + 1];
            }
            Array.Resize(ref c, c.Length - 1);
             com.ExecuteNonQuery();
        }
        private void syutoku()
        {
            listBox1.Items.Clear();
            int j = new int();
            MySqlCommand command = new MySqlCommand("select id,url,create_date,update_date from url where delete_flag = 'false'", mai);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                c[j] = int.Parse(reader["id"].ToString());
                listBox1.Items.Add(reader["url"].ToString());
                j++;
            }
            reader.Close();
        }
       

        
        private void DialogURL_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            追加.Enabled = false;
            button2.Enabled = false;
            mai = ((main)Owner).GetConnection();
            MySqlCommand conmai = new MySqlCommand("select count(*)  from url where delete_flag = 'false'", mai);
            int d = int.Parse(conmai.ExecuteScalar().ToString());///18
            Array.Resize(ref c, d);
            limit = ((main)Owner).Getlimit_flag();
            count = ((main)Owner).GetURLCount();
            syutoku();
        }
           

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.ResetText();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                button2.Enabled = false;
                追加.Enabled = false;
                追加.Text = "追加";
                button1.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
                追加.Enabled = true;
            }
        }

        private void DialogURL_Load_1(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                textBox1.ResetText();
            }
            else
            {
                textBox1.Text = listBox1.SelectedItem.ToString();
                追加.Text = "変更";
                button1.Enabled = true;
            
            }
            ///94行if vit の後に追加
            /*if (追加.Text == "追加")
                {
                    MySqlCommand sink = new MySqlCommand("update url set delete_flag = false ,update_date = now() where url = '" + textBox1.Text + "';", mai);
                    sink.ExecuteNonQuery();
                    Array.Resize(ref c, c.Length + 1);
                    syutoku();
                }
                else
            */

        }
    }
}
