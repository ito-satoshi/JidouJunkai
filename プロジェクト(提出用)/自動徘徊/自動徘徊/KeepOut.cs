using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 自動徘徊
{
    public partial class KeepOut : Form
    {
        public KeepOut()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (((main)Owner).IsContainPKey(textBox1.Text + textBox2.Text + textBox3.Text + textBox4.Text + textBox5.Text) != true)
            {
                MessageBox.Show("入力されたプロダクトキーは不正です。深呼吸をして打ち直せ",
                   "エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
            else
            {
                ///((main)Owner).limit_flag = false;
                MessageBox.Show("制限解除されました。素敵な徘徊ライフをお楽しみください",
                   "制限解除しました",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                DialogResult = DialogResult.OK;
                Close();
                
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void KeepOut_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.MaxLength = 5;
            textBox1.CharacterCasing = CharacterCasing.Upper;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.MaxLength = 5;
            textBox2.CharacterCasing = CharacterCasing.Upper;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.MaxLength = 5;
            textBox3.CharacterCasing = CharacterCasing.Upper;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.MaxLength = 5;
            textBox4.CharacterCasing = CharacterCasing.Upper;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.MaxLength = 5;
            textBox5.CharacterCasing = CharacterCasing.Upper;
            button1.Enabled = true;

        }

    }
}
