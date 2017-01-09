using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 送给你的惊喜
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            //窗体的宽度
            int x = this.ClientSize.Width - btnExit.Width;
            int y = this.ClientSize.Height - btnExit.Height;
            Random r = new Random();

            btnExit.Location = new Point(r.Next(0, x + 1), r.Next(0, y + 1));
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("就不退出");
        }

        private void btnKeng_Click(object sender, EventArgs e)
        {
            MessageBox.Show("你的系统不支持此控件，请使用结束。", "警告！",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
        }
    }
}
