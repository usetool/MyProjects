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
    public partial class FrmSetting : Form
    {
        public FrmSetting()
        {
            InitializeComponent();
        }

        private void cboFont_DropDown(object sender, EventArgs e)
        {
            if (this.fontDialog1.ShowDialog() == DialogResult.OK)
            {
                this.cboFont.Text = this.fontDialog1.Font.Name + "," + this.fontDialog1.Font.Size+"pt";
            }
        }

        private void cboBackGroundColor_DropDown(object sender, EventArgs e)
        {

        }

        private void cboEncode_DropDown(object sender, EventArgs e)
        {

        }

    }
}
