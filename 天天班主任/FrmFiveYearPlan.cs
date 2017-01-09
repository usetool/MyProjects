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
    public partial class FrmFiveYearPlan : Form
    {
        public FrmFiveYearPlan()
        {
            InitializeComponent();
        }
        DataOperation dp = new DataOperation(Config.path, Config.pwd);
        private void FrmFiveYearPlan_Load(object sender, EventArgs e)
        {
            DateTime createTime=dp.GetMaxPlanCreateTimeByType(PlanType.FiveYearPlan);
            //现在的时间-创建的时间=创建过去的天数，小于，创建的时间+5年-创建的时间=5年的天数
            if ((DateTime.Now - createTime).Days < (createTime.AddYears(5)-createTime).Days)
            {
                List<Plan> plans=dp.GetAllNowPlan();
                foreach (Plan item in plans)
                {
                    if (item.MyPlanType==PlanType.FiveYearPlan)
                    {
                        this.btnAddPlan.Text = "想修改5年计划？问问开发者吧";
                        this.btnAddPlan.Enabled = false;
                        this.textBox1.Text = item.PlanContent;
                        this.lblCreateTime.Text = item.CreateTime.ToString();
                        this.lblToDate.Text = item.CreateTime.AddYears(5).ToString();
                        this.lblDays.Text = (item.CreateTime.AddYears(5) - DateTime.Now).Days.ToString();
                    }
                }
            }
            
        }
        /// <summary>
        /// 添加计划
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPlan_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("五年计划创建后是不能修改的，确定这样创建吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result==DialogResult.Yes)
            {
                Plan plan = new Plan();
                plan.CreateTime = DateTime.Now;
                plan.MyPlanType = PlanType.FiveYearPlan;
                plan.PlanContent = this.textBox1.Text;
                plan.PlanName = "";
                plan.PlanWhy = "";
                if (dp.AddPlan(plan))
                {
                    MessageBox.Show("创建成功！");
                    btnAddPlan.Enabled = false;
                    btnAddPlan.Text = "想修改5年计划？问问开发者吧";
                }
                else
                {
                    MessageBox.Show("发生错误！创建失败！");
                }
            }
        }
    }
}
