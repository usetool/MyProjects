using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using 天天管家.Entity;

namespace 天天管家
{
    public partial class FrmTallMePass : Form
    {
        Plan plan;
        public FrmTallMePass(Plan plan)
        {
            InitializeComponent();
            this.plan = plan;
            this.lblPassTall.Text = plan.PlanWhy;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text=="")
            {
                MessageBox.Show("密码不能为空！");
                return;
            }
            if (this.textBox1.Text==plan.PlanContent)
            {
                FrmDiary diary = new FrmDiary();
                diary.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("密码错误！");
            }
        }

        private void FrmTallMePass_Load(object sender, EventArgs e)
        {

        }
    }
}
