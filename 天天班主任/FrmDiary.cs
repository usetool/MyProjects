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
    public partial class FrmDiary : Form
    {
        public FrmDiary()
        {
            InitializeComponent();
        }
        DataOperation dataOperation = new DataOperation(Config.path, Config.pwd);
        private void FrmDiary_Load(object sender, EventArgs e)
        {
            UpdateInfo();
        }

        public void UpdateInfo()
        {
            this.dataGridView1.AutoGenerateColumns = false;
            //加载历史记录
            List<Plan> planHistory = dataOperation.GetAllHistoryPlan(PlanType.Diary);
            if (planHistory != null)
            {
                this.dataGridView1.DataSource = new BindingList<Plan>(planHistory);
            }
            int count = dataOperation.GetDaysNum(PlanType.Diary);
            this.lblCount.Text = count.ToString();
        }
        /// <summary>
        /// 写日记
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateDiary_Click(object sender, EventArgs e)
        {
            FrmAddDiary addDiary = new FrmAddDiary(this);
            addDiary.ShowDialog();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime time = this.dateTimePicker1.Value;
            //加载历史记录
            List<Plan> planHistory = dataOperation.GetAllHistoryPlan(PlanType.Diary, time);
            if (planHistory != null)
            {
                this.dataGridView1.DataSource = new BindingList<Plan>(planHistory);
            }
            int count = dataOperation.GetDaysNum(PlanType.Diary);
            this.lblCount.Text = count.ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime startTime = this.startTime.Value;
            DateTime endTime = this.endTime.Value;
            //加载历史记录
            List<Plan> planHistory = dataOperation.GetAllHistoryPlan(PlanType.Diary, startTime, endTime);
            if (planHistory != null)
            {
                this.dataGridView1.DataSource = new BindingList<Plan>(planHistory);
            }
            int count = dataOperation.GetDaysNum(PlanType.Diary);
            this.lblCount.Text = count.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmSetPass set = new FrmSetPass();
            set.Show();
        }
    }
}
