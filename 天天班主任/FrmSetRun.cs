using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 天天管家
{
    public partial class FrmSetRun : Form
    {
        public FrmSetRun()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 允许开机启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIsRun_Click(object sender, EventArgs e)
        {
            //需要管理员权限
          
            string path = Application.ExecutablePath;
            RegistryKey rk = null;
            RegistryKey rk2 = null;
            try
            {
                rk = Registry.LocalMachine;
                rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                rk2.SetValue("天天管家", path);
            }
            catch (Exception)
            {
                MessageBox.Show("请以管理员身份运行！");
                return;
            }
            finally
            {
                if(rk!=null){
                    rk.Close();
                }
                if (rk2 != null)
                {
                    rk2.Close();
                }
            }
            MessageBox.Show("开启成功！", "提示");
           
            
        }
        /// <summary>
        /// 禁止开启启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNoRun_Click(object sender, EventArgs e)
        {
            
            string path = Application.ExecutablePath;
            RegistryKey rk = null;
            RegistryKey rk2 = null;
            try
            {
                rk = Registry.LocalMachine;
                rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                rk2.DeleteValue("天天管家", false);
            }
            catch (Exception)
            {
                MessageBox.Show("请以管理员身份运行！");
                return;
            }
            finally
            {
                if (rk2 != null)
                {
                    rk2.Close();
                }
                if (rk != null)
                {
                    rk.Close();
                }
            }
            MessageBox.Show("禁止成功！", "提示");
        }
    }
}
