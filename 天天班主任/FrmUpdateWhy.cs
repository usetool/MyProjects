using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 天天管家
{
    public partial class FrmUpdateWhy : Form
    {
        FrmLongPlan frm = null;
        public FrmUpdateWhy(FrmLongPlan frm)
        {
            InitializeComponent();
            this.frm = frm;
        }
        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text!="")
            {
                frm.whyStr = this.textBox1.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("不能为空！");
            }
           
        }
    }
}
