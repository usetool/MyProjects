using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using 天天管家.Operation;
using 天天管家.Entity;
namespace 天天管家
{
    public partial class FrmSentence : Form
    {
        public FrmSentence()
        {
            InitializeComponent();
        }
        DataOperation dp = new DataOperation(Config.path, Config.pwd);
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "")
            {
                MessageBox.Show("要添加的内容不能空！");
            }
            else
            {
                string[] sentences = this.textBox1.Text.Split('|');
                int count = 0;
                foreach (string item in sentences)
                {
                    if (item != "")
                    {
                        Plan plan = new Plan();
                        plan.CreateTime = DateTime.Now;
                        plan.MyPlanType = PlanType.Sentence;
                        plan.PlanContent = item;
                        plan.PlanName = "";
                        plan.PlanWhy = "";
                        if (dp.AddPlan(plan))
                        {
                            count++;
                        }
                    }
                }
                MessageBox.Show("成功添加了 " + count + " 条！");
                InitialStatu();
            }
        }

        private void FrmSentence_Load(object sender, EventArgs e)
        {
            InitialStatu();
        }

        private void InitialStatu()
        {
            this.textBox1.Text = "";
            this.lblcount.Text = dp.GetDaysNum(PlanType.Sentence).ToString();
        }
    }
}
