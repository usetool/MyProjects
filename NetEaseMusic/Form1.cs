using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NetDimension.NanUI;
using NetDimension.NanUI.ChromiumCore;
using Chromium.Remote;

namespace NetEaseMusic
{
    public partial class Form1 : HtmlUIForm
    {
        public Form1() : base("embedded://www/index.html")
        {
            InitializeComponent();
            GlobalObject.Add("Host", new MusicJSObject(this));
        }
        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            //this.Visible = true;
            this.Show();
            this.TopMost = true;
            this.TopMost = false;

        }
        /// <summary>
        /// 退出网易云音乐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiExit_Click(object sender, EventArgs e)
        {
            DialogResult result=MessageBox.Show("确定要退出吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result==DialogResult.Yes)
            {
                Application.Exit();
            }

        }
    }
}
