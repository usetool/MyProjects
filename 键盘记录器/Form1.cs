using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.IO;
using System.Xml;
namespace 键盘记录器
{
    public partial class Form1 : Form
    {
        GlobalHook hook;
        long dayKeyDown = 0;
        DateTime day = new DateTime();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Initial();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        private void Initial()
        {
            //this.TransparencyKey = this.BackColor;
            //初始化钩子对象
            if (!File.Exists("system.config"))
            {
                Console.WriteLine("创建文件");
                XmlDocument xmlDoc = new XmlDocument();
                //创建类型声明节点  
                XmlNode node = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "");
                xmlDoc.AppendChild(node);
                //创建根节点  
                XmlNode root = xmlDoc.CreateElement("System");
                xmlDoc.AppendChild(root);
                this.CreateNode(xmlDoc, root, "count", "0");
                this.CreateNode(xmlDoc, root, "days", "0");
                this.CreateNode(xmlDoc, root, "startTime", DateTime.Now.ToString());
                try
                {
                    xmlDoc.Save("system.config");
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                //读取今日的记录
                XmlDocument doc = new XmlDocument();
                doc.Load("system.config");

                XmlElement rootElem = doc.DocumentElement;   //获取根节点  
                XmlNodeList personNodes = rootElem.GetElementsByTagName("person"); //获取person子节点集合  
                foreach (XmlNode node in personNodes)
                {
                    string strName = ((XmlElement)node).GetAttribute("name");   //获取name属性值  
                    Console.WriteLine(strName);
                    XmlNodeList subAgeNodes = ((XmlElement)node).GetElementsByTagName("age");  //获取age子XmlElement集合  
                    if (subAgeNodes.Count == 1)
                    {
                        string strAge = subAgeNodes[0].InnerText;
                        Console.WriteLine(strAge);
                    }
                }

                // bool isToday=DateTime.Now.ToString()==
            }
            if (hook == null)
            {
                hook = new GlobalHook();
                hook.KeyDown += new KeyEventHandler(hook_KeyDown);
                hook.Start();
            }
        }

        private void hook_KeyDown(object sender, KeyEventArgs e)
        {
            //只记录A-Z 0-9
            if (e.KeyValue < 91 && e.KeyValue > 64 || e.KeyValue < 106 && e.KeyValue > 94)
            {
                dayKeyDown++;
                this.lbltoday.Text = dayKeyDown.ToString();
                this.progressBar1.Value += 1;
            }
        }
        /// <summary>    
        /// 创建节点    
        /// </summary>    
        /// <param name="xmldoc"></param>  xml文档  
        /// <param name="parentnode"></param>父节点    
        /// <param name="name"></param>  节点名  
        /// <param name="value"></param>  节点值  
        ///   
        public void CreateNode(XmlDocument xmlDoc, XmlNode parentNode, string name, string value)
        {
            XmlNode node = xmlDoc.CreateNode(XmlNodeType.Element, name, null);
            node.InnerText = value;
            parentNode.AppendChild(node);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            hook.Stop();
            //保存记录，判断时间

        }

        #region 窗体拖动

        Point mouseOff;//鼠标移动位置变量
        bool leftFlag;//标记是否为左键
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y); //得到变量的值
                leftFlag = true;                  //点击左键按下时标注为true;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);  //设置移动后的位置
                Location = mouseSet;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;//释放鼠标后标注为false;
            }
        }
        #endregion

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("关闭了就没办法记录敲击记录了!", "确定要关闭吗？", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void tsmiSeting_Click(object sender, EventArgs e)
        {

        }

        private void tsmiHistry_Click(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }


    }
}
