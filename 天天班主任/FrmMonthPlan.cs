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
    public partial class FrmMonthPlan : Form
    {
        public FrmMonthPlan()
        {
            InitializeComponent();
        }
        DataOperation dp = new DataOperation(Config.path, Config.pwd);
        /// <summary>
        /// 创建计划
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPlan_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("月度计划创建后是不能修改的，确定这样创建吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Plan plan = new Plan();
                plan.CreateTime = DateTime.Now;
                plan.MyPlanType = PlanType.MonthPlan;
                plan.PlanContent = this.textBox1.Text;
                plan.PlanName = "";
                plan.PlanWhy = "";
                if (dp.AddPlan(plan))
                {
                    MessageBox.Show("创建成功！");
                    btnAddPlan.Enabled = false;
                    btnAddPlan.Text = "想修改月度计划？问问开发者吧";
                }
                else
                {
                    MessageBox.Show("发生错误！创建失败！");
                }
            }
        }

        private void FrmMonthPlan_Load(object sender, EventArgs e)
        {
            DateTime createTime = dp.GetMaxPlanCreateTimeByType(PlanType.MonthPlan);
            if ((DateTime.Now - createTime).Days < (createTime.AddMonths(1)-createTime).Days)
            {
                List<Plan> plans = dp.GetAllNowPlan();
                foreach (Plan item in plans)
                {
                    if (item.MyPlanType == PlanType.MonthPlan)
                    {
                        this.btnAddPlan.Text = "想修改月度计划？问问开发者吧";
                        this.btnAddPlan.Enabled = false;
                        this.textBox1.Text = item.PlanContent;
                        this.lblCreateTime.Text = item.CreateTime.ToString();
                        this.lblToDate.Text = item.CreateTime.AddMonths(1).ToString();
                        this.lblDays.Text = (item.CreateTime.AddMonths(1) - DateTime.Now).Days.ToString();
                    }
                }
            }
           
        }
    }
}
