using NetDimension.NanUI.ChromiumCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chromium.Remote.Event;
using NetDimension.NanUI;
using System.Windows.Forms;

namespace NetEaseMusic
{
    /// <summary>
    /// js事件与C#操作类
    /// </summary>
    public class MusicJSObject : JSObject
    {
        Form1 Host;
        public MusicJSObject(Form1 form)
        {
            Host = form;
            AddFunction("ShowMessageBox").Execute += ShowMessageBox;//将js与C#事件绑定
            AddFunction("CloseForm").Execute += CloseForm;
            AddFunction("MiniMal").Execute += MiniMal;
            AddFunction("MaxMal").Execute += MaxMal;
        }
        /// <summary>
        /// 最大化程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaxMal(object sender, CfrV8HandlerExecuteEventArgs e)
        {
            if(Host.WindowState == FormWindowState.Maximized)
            {
                //Host.MinimumSize = new System.Drawing.Size(1022, 670);
                Host.WindowState = FormWindowState.Normal;
            }
            else if (Host.WindowState==FormWindowState.Normal)
            {
                Host.WindowState = FormWindowState.Maximized;
            }

        }

        /// <summary>
        /// 最小化程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiniMal(object sender, CfrV8HandlerExecuteEventArgs e)
        {
            Host.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// 关闭程序，结束主进程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseForm(object sender, CfrV8HandlerExecuteEventArgs e)
        {
            //DialogResult result= MessageBox.Show("确定要关闭？","提示",MessageBoxButtons.YesNo);
            //if (result==DialogResult.Yes)
            //{
            //    Application.Exit();
            //}
            Host.Visible = false;//隐藏
        }
        /// <summary>
        /// 展示提示信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowMessageBox(object sender, CfrV8HandlerExecuteEventArgs e)
        {
            var stringArg = e.Arguments.FirstOrDefault(p => p.IsString)?.StringValue;

            if (!string.IsNullOrEmpty(stringArg))
            {
                Host.UpdateUI(() =>
                {
                    MessageBox.Show(Host, stringArg);
                });
            }
        }
    }
}
