using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 汤姆猫
{
    public partial class Frm_About : Form
    {
        public Frm_About()
        {
            InitializeComponent();
        }

        private void Frm_About_Load(object sender, EventArgs e)
        {
            this.axWindowsMediaPlayer1.URL = "Sounds/Bad Apple.mp3";
            this.axWindowsMediaPlayer1.enableContextMenu = false;
            this.axWindowsMediaPlayer1.uiMode = "none";
        }
        /// <summary>
        /// 窗体关闭中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_About_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.axWindowsMediaPlayer1.close();
        }
    }
}
