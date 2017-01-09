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
    public partial class FrmAddQuestion : Form
    {
        List<string> types;
        DataOperation dp = new DataOperation(Config.path, Config.pwd);
        FrmMain main;
        public FrmAddQuestion(List<string> types,FrmMain main)
        {
            InitializeComponent();
            this.types = types;
            this.main=main;
        }

        private void FrmAddQuestion_Load(object sender, EventArgs e)
        {
            this.comboBox1.DataSource = types;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "计划1" || comboBox1.Text == "计划2" || comboBox1.Text == "计划3" || comboBox1.Text == "计划4" || comboBox1.Text == "计划5")
            {
                MessageBox.Show("不能使用这个名字作为类型名！");
                return;
            }
            if (txtA.Text == "" || txtB.Text == "" || txtC.Text == "" || txtD.Text == "" || txtTitle.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("内容不能为空！");
            }
            else
            {
                Plan question = new Plan();
                question.MyPlanType = PlanType.Question;
                question.CreateTime = DateTime.Now;
                //数据的格式是：标题|选项A|选项B|选项C|选项D|正确答案
                string rightStr = "";
                if (rdoA.Checked)
                {
                    rightStr = "A";
                }
                else if (rdoB.Checked)
                {
                    rightStr = "B";
                }
                else if (rdoC.Checked)
                {
                    rightStr = "C";
                }
                else if (rdoD.Checked)
                {
                    rightStr = "D";
                }
                question.PlanContent = txtTitle.Text + "|" + txtA.Text + "|" + txtB.Text + "|" + txtC.Text + "|" + txtD.Text + "|" + rightStr;
                string planName = comboBox1.Text;
                question.PlanName = planName;
                question.PlanWhy = "";
                if (dp.AddPlan(question))
                {
                    MessageBox.Show("添加成功！");
                    txtTitle.Text = "";
                    txtA.Text = "";
                    txtB.Text = "";
                    txtC.Text = "";
                    txtD.Text = "";
                    main.InitialQuestionType();
                }
                else
                {
                    MessageBox.Show("发生错误！添加失败！");
                }
            }
        }
    }
}
