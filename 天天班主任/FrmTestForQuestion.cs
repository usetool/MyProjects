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
    public partial class FrmTestForQuestion : Form
    {
        string type = "";
        int count = 0;
        string[] all;
        List<Plan> questions = new List<Plan>();
        public FrmTestForQuestion(string type)
        {
            InitializeComponent();
            this.type = type;
        }
        DataOperation dp = new DataOperation(Config.path, Config.pwd);
        private void FrmTestForQuestion_Load(object sender, EventArgs e)
        {
            this.Text = "随机考题练习-" + type;
            questions = dp.GetAllHistoryPlan(PlanType.Question,type);
            NextQuestion();
        }

        private void NextQuestion()
        {
            int randNum = new Random().Next(0, questions.Count);
            all = questions[randNum].PlanContent.Split('|');
            //数据的格式是：标题|选项A|选项B|选项C|选项D|正确答案
            this.textBox1.Text = all[0].ToString() + "\n\r\nA:" + all[1].ToString() + "\n\r\nB:" + all[2].ToString() + "\n\r\nC:" + all[3].ToString() + "\n\r\nD:" + all[4].ToString();
        }

        /// <summary>
        /// 检查
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            string select = "";
            if (rdoA.Checked)
            {
                select = "A";
            }
            else if (rdoB.Checked)
            {
                select = "B";
            }
            else if (rdoC.Checked)
            {
                select = "C";
            }
            else if (rdoD.Checked)
            {
                select = "D";
            }
            if (all[5] == select)
            {
                lblSatu.Text = "上道题答对了！！！";
                lblSatu.BackColor = Color.Red;
            }
            else
            {
                lblSatu.Text = "上道题答错了~~~";
                lblSatu.BackColor = Color.Green;
            }
            NextQuestion();
        }

    }
}
