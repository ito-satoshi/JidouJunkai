using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace 自動徘徊
{
    public partial class Time : Form
    {
        MySqlConnection mai;
        private void Time_Load(object sender, EventArgs e)
        {

            comboBox1.Items.Add(1);
            comboBox1.Items.Add(2);
            comboBox1.Items.Add(3);
            comboBox1.Items.Add(4);
            comboBox1.Items.Add(5);
            comboBox1.Items.Add(6);
            comboBox1.Items.Add(7);
            comboBox1.Items.Add(8);
            comboBox1.Items.Add(9);
            comboBox1.Items.Add(10);
            comboBox1.Items.Add(11);
            comboBox1.Items.Add(12);
            button1.Enabled = false;
            mai = ((main)Owner).GetConnection();
            MySqlCommand counter = new MySqlCommand("select count(*) from acquisition_interval;", mai);
            int check = int.Parse(counter.ExecuteScalar().ToString());
            if (check != 0)
            {
                MySqlCommand TM = new MySqlCommand($"select acquisition_interval from acquisition_interval where id = {check};", mai);
                int d = int.Parse(TM.ExecuteScalar().ToString());
                textBox1.Text = d.ToString();
                int i = d / 60;
                comboBox1.SelectedIndex = i - 1;
                if (d % 60 != 0)                            ///int×intではない
                {
                    radioButton2.Checked = true;
                }
            }

        }

        public Time()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //キャンセルﾎﾞｯﾄﾝだよ
            Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            ///これは保存ボタンだゾ

            if (radioButton2.Checked == true)
            {
                int x = int.Parse(textBox1.Text);
                if (x > 59 && x < 721)
                {

                    MySqlCommand TMR = new MySqlCommand("insert into acquisition_interval(acquisition_interval) values (" + textBox1.Text + ");", mai);
                    comboBox1.Items.Add(x / 60);
                    comboBox1.SelectedIndex = 12;
                    textBox1.Refresh();
                    TMR.ExecuteNonQuery();
                    Close();
                }
                else
                {
                    MessageBox.Show("有効な数値を入力してください",
                        "エラー",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error);
                }

            }
            if (radioButton1.Checked == true)
            {
                int oo = int.Parse(comboBox1.Text) * 60;
                textBox1.Text = oo.ToString();
                MySqlCommand TMR = new MySqlCommand("insert into acquisition_interval(acquisition_interval) values (" + textBox1.Text + ");", mai);
                TMR.ExecuteNonQuery();
                Close();
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            double aa = double.Parse(comboBox1.Text) * 60;
            int oo = int.Parse(comboBox1.Text) * 60;
            textBox1.Text = oo.ToString();

        }
    }
}
