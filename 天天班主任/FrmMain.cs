using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;
using 天天管家.Operation;
using 天天管家.Entity;
namespace 天天管家
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        DataOperation dp = new DataOperation(Config.path, Config.pwd);
        Boolean todayPlanIsCreate = false;
        /// <summary>
        /// 保存试题类型的集合
        /// </summary>
        List<string> questionTypes;
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            //窗体加载时检测数据库文件是否存在，存在->读取信息 ，不存在->提示新建计划
            //bin目录用于存放配置文件
            if (!Directory.Exists("bin"))
            {
                Directory.CreateDirectory("bin");
                this.btnTodayPlan.Text = "未设立";
                this.btnTodayPlan.Enabled = true;
                //初次运行
                FrmFirstInfo first = new FrmFirstInfo();
                //first.ShowDialog();
                if (!File.Exists("bin/plan.db"))
                {
                    DataOperation.CreateDB(Config.path, Config.pwd);
                }
                first.ShowDialog();
                DialogResult result = MessageBox.Show("系统检测到您还没有计划信息，是否要创建？", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    //打开创建计划窗口
                    FrmLongPlan frm = new FrmLongPlan();
                    frm.ShowDialog();
                }
            }
            else
            {
                InitialQuestionType();
                this.timerOfTime.Start();
                //每次运行时展示励志句子
                List<Plan> sentence = dp.GetAllHistoryPlan(PlanType.Sentence);
                if (sentence.Count > 0)
                {
                    int rand = new Random().Next(0, sentence.Count);
                    FrmShowInfo showInfo = new FrmShowInfo(sentence[rand].PlanContent, PlanType.Sentence);
                    showInfo.Show();
                }
                ProgressInitial();
                if (!todayPlanIsCreate)
                {
                    this.btnTodayPlan.Text = "未设立";
                    this.btnTodayPlan.Enabled = true;
                    MessageBox.Show("今日计划还没有规划呢！快去做计划吧", "提示！");
                    FrmDayPlan frm = new FrmDayPlan();
                    frm.ShowDialog();
                }
                else
                {
                    timerOfOneHour.Start();
                }
            }
        }
        /// <summary>
        /// 进度条初始化
        /// </summary>
        private void ProgressInitial()
        {
            DateTime now = DateTime.Now;//当前时间
            DateTime startTime=dp.GetSrartTime();
            TimeSpan rightDay = now - startTime;//从开始到现在的时间间隔 单位/天
            //如果最近的日计划创建时间大于今天凌晨是今天创建的，否则今天还未创建
            DateTime dayCreateTime = dp.GetMaxPlanCreateTimeByType(PlanType.DayPlan);
            if (dayCreateTime >= DateTime.Today)
            {
                todayPlanIsCreate = true;
                this.btnTodayPlan.Text = "已设立";
                this.btnTodayPlan.Enabled = false;
            }
            else
            {
                this.btnTodayPlan.Text = "未设立";
                this.btnTodayPlan.Enabled = true;
            }
            int daysNum = Convert.ToInt32(dp.GetDaysNum(PlanType.DayPlan));//获取实际天数
            int breakDay = 0;
            if (rightDay.Days - daysNum > 0)
            {
                breakDay = rightDay.Days - daysNum;//计算中断天数
            }
            this.lblRunningDays.Text = daysNum.ToString();//绑定实际签到天数
            this.lblBreakDays.Text = breakDay.ToString();
            DateTime fivePlanCreateTime = dp.GetMaxPlanCreateTimeByType(PlanType.FiveYearPlan);

            DateTime yearPlanCreateTime = dp.GetMaxPlanCreateTimeByType(PlanType.YearPlan);
            DateTime monthPlanCreateTime = dp.GetMaxPlanCreateTimeByType(PlanType.MonthPlan);
            DateTime weekPlanCreateTime = dp.GetMaxPlanCreateTimeByType(PlanType.WeekPlan);
            //显示距下次指定计划的天数
            if (fivePlanCreateTime == new DateTime(1900, 1, 1))
            {
                lblFiveDaysNum.Text = "0";
            }
            else
            {
                lblFiveDaysNum.Text = (fivePlanCreateTime.AddYears(5) - DateTime.Now).Days.ToString();
            }
            if (monthPlanCreateTime == new DateTime(1900, 1, 1))
            {
                lblMonthDaysNum.Text = "0";
            }
            else
            {
                lblMonthDaysNum.Text = (monthPlanCreateTime.AddMonths(1) - DateTime.Now).Days.ToString();
            }
            if (weekPlanCreateTime == new DateTime(1900, 1, 1))
            {
                lblWeekDaysNum.Text = "0";
            }
            else
            {
                lblWeekDaysNum.Text = (weekPlanCreateTime.AddDays(7) - DateTime.Now).Days.ToString();
            }
            if (yearPlanCreateTime == new DateTime(1900, 1, 1))
            {
                lblYearDaysNum.Text = "0";
            }
            else
            {
                lblYearDaysNum.Text = (yearPlanCreateTime.AddYears(1) - DateTime.Now).Days.ToString();
            }
            //进度条初始化,公历运行进度
            pbDay.Value = now.Hour;
            //pbFive.Value = rightDay.Days;
            //pbLong.Value = rightDay.Days;
            pbMonth.Value = now.Day;
            pbWeek.Value = Convert.ToInt32(now.DayOfWeek);
            pbYear.Value = now.DayOfYear;
            //遵守度
            pbDayPro.Value = dp.GetDaysNum(PlanType.DayPlan, now);
            pbLongPro.Value = daysNum % 31025;

            pbWeekPro.Value = dp.GetCountByStartTimeAndType(weekPlanCreateTime, PlanType.DayPlan);
            pbFivePro.Value = dp.GetCountByStartTimeAndType(fivePlanCreateTime, PlanType.DayPlan);//获取上次设立5年计划的时间至今的日签到次数
            pbMonthPro.Value = dp.GetCountByStartTimeAndType(monthPlanCreateTime, PlanType.DayPlan);
            pbYearPro.Value = dp.GetCountByStartTimeAndType(yearPlanCreateTime, PlanType.DayPlan);
            //初始化最精确的最大值
            pbFivePro.Maximum = (fivePlanCreateTime.AddYears(5) - fivePlanCreateTime).Days;
            pbMonthPro.Maximum = (monthPlanCreateTime.AddMonths(1) - monthPlanCreateTime).Days;
            pbYearPro.Maximum = (yearPlanCreateTime.AddYears(1) - yearPlanCreateTime).Days;
            pbFive.Maximum = pbFivePro.Maximum;
            pbMonth.Maximum = pbMonthPro.Maximum;
            pbYear.Maximum = pbYearPro.Maximum;


            //初始化题库数量
            lblQuestionCount.Text = dp.GetDaysNum(PlanType.Question).ToString();
            lblQuestionTypeCount.Text = this.treeView1.Nodes.Count.ToString();
        }

        public void InitialQuestionType()
        {
            //加载题库类型
            this.treeView1.Nodes.Clear();
            List<Plan> questions = dp.GetAllHistoryPlan(PlanType.Question);
            questionTypes = new List<string>();
            foreach (Plan item in questions)
            {
                if (!questionTypes.Contains(item.PlanName))
                {
                    this.treeView1.Nodes.Add(new TreeNode(item.PlanName));
                    questionTypes.Add(item.PlanName);
                }
            }
        }
        /// <summary>
        /// 窗体关闭提示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("确定要退出吗？", "提示！", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        /// <summary>
        /// 今日计划设定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTodayPlan_Click(object sender, EventArgs e)
        {
            if (btnTodayPlan.Text == "未设立")
            {
                FrmDayPlan day = new FrmDayPlan();
                day.ShowDialog();
            }
        }
        /// <summary>
        /// 每日计划单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbDay_Click(object sender, EventArgs e)
        {
            FrmDayPlan day = new FrmDayPlan();
            day.ShowDialog();
        }
        /// <summary>
        /// 长期计划单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbLong_Click(object sender, EventArgs e)
        {
            FrmLongPlan longPlan = new FrmLongPlan();
            longPlan.ShowDialog();
        }
        /// <summary>
        /// 每月计划单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbMonth_Click(object sender, EventArgs e)
        {
            FrmMonthPlan month = new FrmMonthPlan();
            month.ShowDialog();
        }
        /// <summary>
        /// 年度计划单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbYear_Click(object sender, EventArgs e)
        {
            FrmYearPlan year = new FrmYearPlan();
            year.ShowDialog();
        }
        /// <summary>
        /// 五年计划单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbFive_Click(object sender, EventArgs e)
        {
            FrmFiveYearPlan plan = new FrmFiveYearPlan();
            plan.ShowDialog();
        }
        /// <summary>
        /// 每周计划单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbWeek_Click(object sender, EventArgs e)
        {
            FrmWeekPlan plan = new FrmWeekPlan();
            plan.ShowDialog();
        }
        /// <summary>
        /// 开机自启被点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiStartingUpRun_Click(object sender, EventArgs e)
        {
            FrmSetRun frmSetRun = new FrmSetRun();
            frmSetRun.ShowDialog();
        }
        /// <summary>
        /// 关于按钮被单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            FrmAbout about = new FrmAbout();
            about.ShowDialog();
        }
        /// <summary>
        /// 窗体靠边隐藏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerCheckBorder_Tick(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
            {
                int ScreenWidth = Screen.PrimaryScreen.WorkingArea.Width;  //屏幕宽度 
                int ScreenRight = Screen.PrimaryScreen.WorkingArea.Right; //屏幕高度 
                int MouseX = Control.MousePosition.X; //鼠标X位置 
                int MouseY = Control.MousePosition.Y;//鼠标垂直位置 
                if (this.Left < 0 && this.Top < 0)
                {
                    this.Left = 0;
                    this.Top = 1;
                }
                if (this.Left >= ScreenWidth - this.Right && this.Top < 0) //如果自己的左边是否在屏幕的边缘 
                {
                    this.Left = ScreenWidth;
                    this.Top = 0;
                }
                if (this.Top < 0 && MouseX > this.Left && MouseX < this.Left + this.Width && MouseY < 3)
                {
                    this.Top = 0;
                }
                if (this.Top <= 0 && this.Left > 0 && this.Left < ScreenWidth - this.Width)
                {
                    if (MouseX < this.Left || MouseX > this.Left + this.Width || MouseY > this.Top + this.Right)
                    {
                        this.Top = 3 - this.Right;
                    }
                }
                if (this.Left < 0 && MouseY > this.Top && MouseY < this.Top + this.Width && MouseX < 3)
                {
                    this.Left = 0;
                }
                if (this.Left <= 0 && this.Top > 0 && this.Top < ScreenRight - this.Right)
                {
                    if (MouseY < this.Top || MouseY > this.Top + this.Right || MouseX > this.Width)
                    {
                        this.Left = 3 - this.Width;
                    }
                }


                if (this.Left >= ScreenWidth - this.Width && this.Top > 0 && this.Top < ScreenRight - this.Width)
                {
                    if (MouseY < this.Top || MouseY > this.Top + this.Right || MouseX < ScreenWidth - this.Width)
                    {
                        this.Left = ScreenWidth - 3;
                    }
                }

                if (this.Left > ScreenWidth - 5)　//判断自己的左边是否隐藏了 
                {
                    if (MouseX > ScreenWidth - 5)  //如果隐藏了  判断鼠标是不在屏幕的边缘 
                    {
                        this.Left = ScreenWidth - this.Width;
                    }
                }
            }
        }
        /// <summary>
        /// 双击小图标显示效果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.TopMost = true;
            this.TopMost = false;
        }

        private void timerOfTime_Tick(object sender, EventArgs e)
        {
            ProgressInitial();
        }
        /// <summary>
        /// 打开日记
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 日记ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dp.GetPwd() != null)
            {
                FrmTallMePass tall = new FrmTallMePass(dp.GetPwd());
                tall.Show();
            }
            else
            {
                FrmDiary frmdiary = new FrmDiary();
                frmdiary.Show();

            }
        }
        /// <summary>
        /// 添加与查看励志语句
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 励志语库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSentence sentence = new FrmSentence();
            sentence.Show();
        }

        private void timerOfOneHour_Tick(object sender, EventArgs e)
        {
            string info = "";
            List<Plan> plans = dp.GetAllNowPlan();
            foreach (Plan item in plans)
            {
                if (item.MyPlanType == PlanType.DayPlan)
                {
                    string[] contents = item.PlanContent.Split('|');
                    foreach (string str in contents)
                    {
                        info += str + "\n";
                    }
                }
            }
            FrmShowInfo showInfo = new FrmShowInfo(info, PlanType.DayPlan);
            showInfo.Show();
            InitialQuestionType();
        }
        /// <summary>
        /// 选中类型事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void 添加试题ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddQuestion addQuestion = new FrmAddQuestion(questionTypes, this);
            addQuestion.Show();
        }

        private void 做题ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.treeView1.SelectedNode != null)
            {
                string type = this.treeView1.SelectedNode.Text;
                //根据类型打开习题库
                FrmTestForQuestion testForQuestion = new FrmTestForQuestion(type);
                testForQuestion.Show();
            }


        }
    }
}
