using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 我的工具定时提醒器
{
    public partial class FrmMain : Form
    {
        /// <summary>
        /// 剩余分钟数
        /// </summary>
        int overPlusMinute = 0;
        /// <summary>
        /// 剩余秒数
        /// </summary>
        int overPlusSecond = 0;
        int overhour = 0;
        int overminute = 0;
        int oversecond = 0;

        public FrmMain()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 帮助
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiHelp_Click(object sender, EventArgs e)
        {
            string info = @"本工具是在用户设定的时间达到时弹出提醒框提醒用户
时间到了后用户得到提醒，点击确定继续按设定时间提醒
修改提醒事件只需点击 停止当前提醒 然后重新修改时间即可
最小提醒时间1分钟，最大提醒时间6小时
点击后台运行后程序最小化到托盘
适用于周期性提醒";
            MessageBox.Show(info);
        }
        /// <summary>
        /// 关于
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            About abou = new About();
            abou.ShowDialog();
        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        /// <summary>
        /// 更新当前时间的时钟
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            string hour = DateTime.Now.Hour.ToString();
            string minute = DateTime.Now.Minute.ToString();
            string second = DateTime.Now.Second.ToString();
            this.lblNowTime.Text = hour + ":" + minute + ":" + second;

            this.lblOverPlusTime.Text = overhour + "小时" + overminute + "分" + oversecond + "秒";

        }
        /// <summary>
        /// 倒计时的时钟
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer2_Tick(object sender, EventArgs e)
        {
            --overPlusSecond;

            //如果大于1小时
            if (overPlusSecond > 60 * 60)
            {
                overhour = overPlusSecond / 3600;
                overminute = (overPlusSecond / 60) - (overhour * 60);
                oversecond = overPlusSecond % 60;
            }
            //如果大于1分钟
            else if (overPlusSecond > 60)
            {
                overhour = 0;
                overminute = overPlusSecond / 60;
                oversecond = overPlusSecond % 60;
            }
            else
            {
                overhour = 0;
                overminute = 0;
                oversecond = overPlusSecond;
            }
            //时间到了
            if (overPlusSecond == 0)
            {
                this.timer2.Stop();
                //重置时间
                overPlusSecond = overPlusMinute * 60;
                DialogResult result = MessageBox.Show(this.txtContent.Text + "\n点击确定继续下一个提醒周期", "时间到了", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    this.timer2.Start();
                }
            }
        }
        /// <summary>
        /// 开始计时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboOverPlusMinute.SelectedItem == null)
                {
                    overPlusMinute = Convert.ToInt32(cboOverPlusMinute.Text);
                }
                else
                {
                    overPlusMinute = Convert.ToInt32(cboOverPlusMinute.SelectedItem.ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("请输入合法的数字；范围1-3600之间");
                return;
            }
            if (overPlusMinute > 60 * 6)
            {
                MessageBox.Show("建议的最大提醒时间是6个小时哦！");
                return;
            }
            if (overPlusMinute <= 0)
            {
                MessageBox.Show("小于1分钟都是不行的");
                return;
            }
            overPlusSecond = overPlusMinute * 60;
            this.timer2.Start();
            this.btnStart.Enabled = false;
            this.btnStop.Enabled = true;
        }
        /// <summary>
        /// 停止当前提醒事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            this.timer2.Stop();
            this.btnStart.Enabled = true;
            this.btnStop.Enabled = false;
            overPlusSecond = 0;
            overhour = 0;
            overminute = 0;
            oversecond = 0;
        }
        /// <summary>
        /// 后台运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.notifyIcon1.Visible = true;
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.notifyIcon1.ShowBalloonTip(2000);
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.ShowInTaskbar = true;
        }
    }
}
