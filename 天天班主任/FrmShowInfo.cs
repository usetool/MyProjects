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
    public partial class FrmShowInfo : Form
    {
        string info = "";
        PlanType type;
        public FrmShowInfo(String info, PlanType type)
        {
            InitializeComponent();
            this.info = info;
            this.type = type;
        }

        private void FrmShowInfo_Load(object sender, EventArgs e)
        {
            //信息展示窗体，展示的信息包括：每日提示、励志语句、每日计划中的时段信息提示。
            if (type == PlanType.DayPlan)
            {
                string[] str=info.Split('|');
                this.textBox1.Text = "★★★★：" + str[3] + "\n\r\n★★★：" + str[2] + "\n\r\n★★：" + str[1] + "\n\r\n★：" + str[0];
            }
            else
            {
                this.textBox1.Text = info;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
