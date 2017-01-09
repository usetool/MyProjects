using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Do_you_love_me
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLo_Click(object sender, EventArgs e)
        {
          DialogResult result =MessageBox.Show("谢谢你对TA的支持！", "提示", MessageBoxButtons.OK);
           if (result==DialogResult.OK)
           {
               Application.Exit();
           }
        }
        private void btnNoLo_MouseEnter(object sender, EventArgs e)
        {
            //窗体的宽度
            int x = this.ClientSize.Width-btnNoLo.Width;
            int y = this.ClientSize.Height-btnNoLo.Height;
            Random r = new Random();

            btnNoLo.Location = new Point(r.Next(0,x+1),r.Next(0,y+1));
        }

        private void btnNoLo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("唉~还是被你点到了");
        }
    }
}
