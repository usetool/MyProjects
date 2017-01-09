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
    public partial class FrmAddDiary : Form
    {
        FrmDiary diary;
        public FrmAddDiary(FrmDiary diary)
        {
            InitializeComponent();
            this.diary = diary;
        }
        DataOperation dataOperation = new DataOperation(Config.path, Config.pwd);
        private void label1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Plan plan = new Plan();
            plan.CreateTime = DateTime.Now;
            plan.MyPlanType = PlanType.Diary;
            plan.PlanContent = txtContent.Text;
            plan.PlanName = "";
            plan.PlanWhy = "";
            if (dataOperation.AddPlan(plan))
            {
                MessageBox.Show("添加成功！");
                this.Close();
                diary.UpdateInfo();
            }
        }
    }
}
