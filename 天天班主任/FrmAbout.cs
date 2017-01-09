using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 天天管家
{
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
        }

        private void FrmAbout_Load(object sender, EventArgs e)
        {
            this.textBox2.Text = @"版本记录：
2016-2-13:Bate1.02
        修复软件跨天运行不能即时刷新今日计划情况
        添加日记本加密功能
        优化了查看计划
2016-2-7:Bate1.01
        修复初始化Bug，新增了使用指导
2016-2-6:Bate1.0诞生
       主要内容：新建计划包含  大计划填写-可修改(保存修改记录，记录转变历程)(终生目标 十年目标 五年目标 年度目标  月度计划 周计划 日计划)
计划按时提醒
贴边隐藏
日记功能
题库功能
励志语句";
        }
    }
}
