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
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private void Help_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            URLヘルプ dlg = new URLヘルプ();
            dlg.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            再起動ヘルプ dlg = new 再起動ヘルプ();
            dlg.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Helpヘルプ dlg = new Helpヘルプ();
            dlg.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            取得間隔ヘルプ dlg = new 取得間隔ヘルプ();
            dlg.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            検索ヘルプ dlg = new 検索ヘルプ();
            dlg.ShowDialog();
        }
    }
}
