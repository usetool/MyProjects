using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 乐智知识库
{
    public partial class FrmHelp : Form
    {
        FrmMain frmMain;
        public FrmHelp(FrmMain main)
        {
            this.frmMain = main;
            InitializeComponent();
            frmMain.helpIsOpen = true;
        }

        private void FrmHelp_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMain.helpIsOpen = false;
        }
    }
}
