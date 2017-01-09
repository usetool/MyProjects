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
    public partial class FrmDayPlan : Form
    {
        public FrmDayPlan()
        {
            InitializeComponent();
        }
        DataOperation dp = new DataOperation(Config.path, Config.pwd);
        private void FrmDayPlan_Load(object sender, EventArgs e)
        {
            //日计划失效不按照整数制，按照公制
            DateTime createTime = dp.GetMaxPlanCreateTimeByType(PlanType.DayPlan);
            if (createTime>=DateTime.Today)
            {
                List<Plan> plans = dp.GetAllNowPlan();
                foreach (Plan item in plans)
                {
                    if (item.MyPlanType == PlanType.DayPlan)
                    {
                        this.btnAddPlan.Text = "想修改每日计划？问问开发者吧";
                        this.btnAddPlan.Enabled = false;
                        string[] contents = item.PlanContent.Split('|');
                        if (contents.Length==4)
                        {
                            txt1.Text = contents[0];
                            txt2.Text = contents[1];
                            txt3.Text = contents[2];
                            txt4.Text = contents[3];
                        }
                    }
                }
            }
        }

        private void btnAddPlan_Click(object sender, EventArgs e)
        {
            if (txt1.Text==""||txt2.Text==""||txt3.Text==""||txt4.Text=="")
            {
                MessageBox.Show("内容不能为空，均要填写！");
                return;
            }
            DialogResult result = MessageBox.Show("每日计划创建后是不能修改的，确定这样创建吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Plan plan = new Plan();
                plan.CreateTime = DateTime.Now;
                plan.MyPlanType = PlanType.DayPlan;
                plan.PlanContent = txt1.Text + "|" + txt2.Text + "|" + txt3.Text + "|" + txt4.Text;
                plan.PlanName = "";
                plan.PlanWhy = "";
                if (dp.AddPlan(plan))
                {
                    MessageBox.Show("创建成功！");
                    btnAddPlan.Enabled = false;
                    btnAddPlan.Text = "想修改每日计划？问问开发者吧";
                }
                else
                {
                    MessageBox.Show("发生错误！创建失败！");
                }
            }
        }
    }
}
