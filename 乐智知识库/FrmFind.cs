using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 乐智知识库
{
    public partial class FrmFind : Form
    {
        int next = 0;
        int startIndex = 0;
        /// <summary>
        /// 主内容窗体
        /// </summary>
        FrmMain frmMain=new FrmMain();
        public FrmFind(FrmMain frmMain)
        {
            InitializeComponent();
            this.frmMain = frmMain;
            frmMain.findIsOpen = true;
        }

        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFind_Click(object sender, EventArgs e)
        {
            string findWord = this.txtFindContent.Text;
            int findWordLength = findWord.Length;
            int startIndex = frmMain.txtContent.Text.IndexOf(this.txtFindContent.Text);
            if (startIndex <0)
            {
                frmMain.lblPrompt.Text = "没有找到！";
                frmMain.lblPrompt.ForeColor = Color.Red;
            }
            else
            {
                frmMain.lblPrompt.Text = "Is find!";
                frmMain.lblPrompt.ForeColor = Color.Black;
                frmMain.txtContent.Focus();
                frmMain.txtContent.Select(startIndex, findWordLength);
                frmMain.txtContent.ScrollToCaret();
            }
        }
        /// <summary>
        /// 查找下一个
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            frmMain.lblPrompt.Text = "点击帮助查看帮助和使用技巧";
            frmMain.lblPrompt.ForeColor = Color.Black;
            string findWord = this.txtFindContent.Text;
             int findWordLength = findWord.Length;
            next = startIndex;
            next++;
            startIndex = frmMain.txtContent.Text.IndexOf(this.txtFindContent.Text, next);
            if (startIndex<0)
            {
                if (frmMain.txtContent.Text.IndexOf(this.txtFindContent.Text, 0) != -1)
                {
                    startIndex = frmMain.txtContent.Text.IndexOf(this.txtFindContent.Text, 0);
                }
                else
                {
                    frmMain.lblPrompt.Text = "没有找到！";
                    frmMain.lblPrompt.ForeColor = Color.Red;
                    return;
                }
            }
            frmMain.txtContent.Focus();
            frmMain.txtContent.Select(startIndex, findWordLength);
            frmMain.txtContent.ScrollToCaret();
            frmMain.lblPrompt.Text = "Is find!";
            frmMain.lblPrompt.ForeColor = Color.Black;
        }

        private void FrmFind_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMain.findIsOpen = false;
        }

     
    }
}
