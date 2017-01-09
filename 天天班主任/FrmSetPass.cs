using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using 天天管家.Entity;
using 天天管家.Operation;

namespace 天天管家
{
    public partial class FrmSetPass : Form
    {
        DataOperation dp = new DataOperation(Config.path, Config.pwd);
        public FrmSetPass()
        {
            InitializeComponent();
            
            if (dp.GetPwd() != null)
            {
                this.Text = "修改密码";
            }
            else
            {
                this.Text = "设置密码";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text!=textBox2.Text)
            {
                MessageBox.Show("第一次密码必须和第二次密码一致！");
                return;
            }
            if (textBox1.Text!=""&&textBox2.Text!=""&&textBox3.Text!="")
            {
                Plan plan = new Plan();
                plan.MyPlanType = PlanType.Diary;
                plan.PlanName = "pwd";
                plan.PlanContent = textBox2.Text;
                plan.PlanWhy = textBox3.Text;
                plan.CreateTime = DateTime.Now;
              
                if (this.Text=="设置密码")
                {
                   if(dp.AddPlan(plan)){
                       MessageBox.Show("设置成功！");
                   }
                   else
                   {
                       MessageBox.Show("设置失败！");
                   }
                }
                else if (this.Text=="修改密码")
                {
                    plan.Id = dp.GetPwd().Id;
                    if (dp.UpdatePwd(plan))
                    {
                        MessageBox.Show("修改成功！");
                    }
                    else
                    {
                        MessageBox.Show("发生错误，修改失败");
                    }
                }
            }
            else
            {
                MessageBox.Show("内容不能有空！");
            }
        }
    }
}
