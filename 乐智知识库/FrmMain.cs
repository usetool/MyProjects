using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Xml;
namespace 乐智知识库
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        //增加设置功能
        //1.04
        public bool findIsOpen = false;
        public bool helpIsOpen = false;
        private string encoding = "utf-8";
        /// <summary>
        /// 修改之前的文本
        /// </summary>
        private string beforeContent = "";
        /// <summary>
        /// 修改之后的文本
        /// </summary>
        private string afterContent = "";
        /// <summary>
        /// 文本框双击时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            //双击允许修改   Ctrl+S  保存修改
            txtContent.ReadOnly = false;
            lblMode.Text = "No save!";
            lblMode.ForeColor = Color.Red;
            this.lblPrompt.Text = "Ctrl+S保存修改";
        }
        /// <summary>
        /// 帮助按钮被点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiHelp_Click(object sender, EventArgs e)
        {
            if (!helpIsOpen)
            {
                FrmHelp frmHelp = new FrmHelp(this);
                frmHelp.Show();
            }
        }
        /// <summary>
        /// 设置按钮被点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiSetting_Click(object sender, EventArgs e)
        {
            OpenFrmSetting();
        }
        /// <summary>
        /// 打开设置窗体
        /// </summary>
        private static void OpenFrmSetting()
        {
            FrmSetting setting = new FrmSetting();
            setting.Show();
        }
        /// <summary>
        /// 关于按钮被点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            FrmAbout about = new FrmAbout();
            about.ShowDialog();
        }
        /// <summary>
        /// 查找按钮被点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiFind_Click(object sender, EventArgs e)
        {
            OpenFind();
        }

        private void OpenFind()
        {

            if (!findIsOpen)
            {
                FrmFind frmFind = new FrmFind(this);
                frmFind.Show();
            }
        }
        /// <summary>
        /// 系统热键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            //Ctrl+S保存
            if (e.KeyCode == Keys.S && e.Control)
            {
                SaveContent();
            }
            //查询
            if (e.KeyCode == Keys.F && e.Control)
            {
                OpenFind();
            }
            //刷新目录
            if (e.KeyCode == Keys.R && e.Control)
            {
                BindDirToTree();
                this.txtContent.Text = "";
                this.lblMode.Text = "none";
                this.lblMode.ForeColor = Color.Black;
            }
            //浏览
            if (e.KeyCode == Keys.O && e.Control && e.Shift)
            {
                System.Diagnostics.Process.Start("kb");
            }
            //打开喜爱列表
            if (e.KeyCode == Keys.L && e.Control && e.Shift)
            {
                OpenLove();
            }
            //打开设置Ctrl+Shift+C
            if (e.KeyCode==Keys.C&&e.Control&&e.Shift)
            {
                OpenFrmSetting();
            }
        }
        /// <summary>
        /// 保存修改内容
        /// </summary>
        private void SaveContent()
        {
            afterContent = this.txtContent.Text;
            if (beforeContent != afterContent)
            {
                StreamWriter writer = null;
                try
                {
                    writer = new StreamWriter(this.txtContent.Tag.ToString());
                    writer.Write(afterContent);
                    this.lblMode.Text = "已保存！";
                    this.lblMode.ForeColor = Color.Black;
                    this.txtContent.ReadOnly = true;
                }
                catch (Exception e)
                {
                    MessageBox.Show("写入时发生异常，错误信息：\n" + e.Message);
                    throw;
                }
                finally
                {
                    if (writer != null)
                    {
                        writer.Close();
                    }
                }
            }
            else
            {
                this.lblMode.Text = "已保存！";
                this.lblMode.ForeColor = Color.Black;
                this.txtContent.ReadOnly = true;
            }

        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            BindDirToTree();
            //加载配置
            if (!File.Exists("config.xml"))
            {
                XmlDocument configs = new XmlDocument();
                XmlNode rootNode = configs.CreateNode(XmlNodeType.Element, "configs", null);
                XMLHelper.CreateNode(configs, rootNode, "encode", "UTF-8");
                XMLHelper.CreateNode(configs, rootNode, "color", "default");
                XMLHelper.CreateNode(configs, rootNode, "fontSize", "8");
                XMLHelper.CreateNode(configs, rootNode, "backgroundColor", "215,215,215");
                XMLHelper.CreateXmlFile(configs, "config.xml", rootNode);
            }
            XmlDocument loadConfig = new XmlDocument();
            loadConfig.Load("config.xml");
            XmlElement doc = loadConfig.DocumentElement;
            //获取并设置配置文件字符编码
            this.encoding = doc.GetElementsByTagName("encode")[0].InnerText;
            //显示的字符编码
            this.lblCoding.Text = encoding;
            //在设置里勾选编码
            CheckedSelectCode();
            //获取配置文件字体大小
            float fontSize = Convert.ToInt32(doc.GetElementsByTagName("fontSize")[0].InnerText);
            //重新设置字体大小
            this.txtContent.Font = new Font(txtContent.Font.Name, fontSize);
            //获取编辑器背景颜色并处理
            string[] bgcolor = doc.GetElementsByTagName("backgroundColor")[0].InnerText.Split(',');
            //设定背景颜色
            this.txtContent.BackColor = Color.FromArgb(Convert.ToInt32(bgcolor[0]), Convert.ToInt32(bgcolor[1]), Convert.ToInt32(bgcolor[2]));

        }
        /// <summary>
        /// 在设置里去勾选编码
        /// </summary>
        private void CheckedSelectCode()
        {
            this.gBKToolStripMenuItem.Checked = false;
            this.gB2312ToolStripMenuItem.Checked = false;
            this.uTF16ToolStripMenuItem.Checked = false;
            this.unicodeToolStripMenuItem.Checked = false;
            this.aSCIIToolStripMenuItem.Checked = false;
            this.uTF8ToolStripMenuItem.Checked = false;
            switch (encoding)
            {
                case "GBK":
                    this.gBKToolStripMenuItem.Checked = true;
                    break;
                case "GB2312":
                    this.gB2312ToolStripMenuItem.Checked = true;
                    break;
                case "UTF-16":
                    this.uTF16ToolStripMenuItem.Checked = true;
                    break;
                case "Unicode":
                    this.unicodeToolStripMenuItem.Checked = true;
                    break;
                case "ASCII":
                    this.aSCIIToolStripMenuItem.Checked = true;
                    break;
                case "UTF-8":
                    this.uTF8ToolStripMenuItem.Checked = true;
                    break;
            }
        }

        private void BindDirToTree()
        {

            if (Directory.Exists("kb"))
            {
                this.treeView1.Nodes.Clear();
                DirectoryInfo di = new DirectoryInfo("kb");
                DirectoryInfo[] dis = di.GetDirectories();//获取子目录的所有文件夹
                FileInfo[] fis = di.GetFiles();//获取子目录下的所有文件
                foreach (DirectoryInfo dir in dis)
                {
                    TreeNode node = new TreeNode(dir.Name);
                    node.Tag = dir.FullName;
                    node.ForeColor = Color.Red;
                    this.treeView1.Nodes.Add(node);
                }
                foreach (FileInfo fi in fis)
                {
                    TreeNode node = new TreeNode(fi.Name);
                    node.Tag = fi.FullName;
                    node.ForeColor = Color.Green;
                    this.treeView1.Nodes.Add(node);
                }
            }
            else
            {
                Directory.CreateDirectory("kb");
                MessageBox.Show("kb目录不存在\n这是系统必须依赖的目录，系统已经自动创建目录\n您可以将知识库放到当前的kb目录下", "初次运行或目录丢失!");
            }
        }
        /// <summary>
        /// 窗体关闭时事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("确定要关闭吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        /// <summary>
        /// 一个节点被选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = this.treeView1.SelectedNode;
            node.Nodes.Clear();
            if (node.ForeColor == Color.Red)//目录绑定
            {
                BindNode(node);
            }
            else if (node.ForeColor == Color.Green)//将文件信息显示到文本框
            {
                OpenFile(node.Tag.ToString());
            }
        }
        /// <summary>
        /// 传入要打开的文件路径，同时可选传入收藏信息窗体，便于刷新窗体信息
        /// </summary>
        /// <param name="path"></param>
        /// <param name="love"></param>
        public void OpenFile(string path, FrmMyLove frmLove = null)
        {
            //如果是txt直接显示，world或其他用运行打开
            if (path.Substring(path.Length - 3, 3) == "txt")
            {
                //直接显示到文本框里
                if (File.Exists(path))
                {
                    this.txtContent.Text = "";
                    StreamReader reader = null;
                    try
                    {
                        this.txtContent.Tag = path;
                        reader = new StreamReader(path, Encoding.GetEncoding(encoding));
                        StringBuilder fileContent = new StringBuilder();
                        string temp = "";
                        while ((temp = reader.ReadLine()) != null)
                        {
                            fileContent.AppendLine(temp);
                        }
                        this.txtContent.Text = fileContent.ToString();
                        beforeContent = fileContent.ToString();
                    }
                    catch (Exception ie)
                    {
                        MessageBox.Show("发生错误！错误信息:\n" + ie.Message);
                    }
                    finally
                    {
                        if (reader != null)
                        {
                            reader.Close();
                        }
                    }
                    lblMode.ForeColor = Color.Black;
                    lblMode.Text = "加载完成";
                    this.Text = "乐智知识库 - [" + path + "]";
                }
                else
                {
                    lblMode.ForeColor = Color.Red;
                    lblMode.Text = "文件不存在！";
                    XmlDocument doc = new XmlDocument();
                    doc.Load("love.xml");
                    XmlElement root = doc.DocumentElement;
                    foreach (XmlNode item in root.GetElementsByTagName("love"))
                    {
                        if (item.LastChild.InnerText.Equals(path))
                        {
                            root.RemoveChild(item);
                            doc.Save("love.xml");
                            if (frmLove != null)
                            {
                                frmLove.BingData();
                            }
                            MessageBox.Show("从收藏列表中已经移除", "收藏的文件不存在", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

            }
            else
            {
                //用自动的关联程序打开
                Process.Start(path);
            }
        }

        private void BindNode(TreeNode node)
        {
            DirectoryInfo di = new DirectoryInfo(node.Tag.ToString());
            DirectoryInfo[] dis = di.GetDirectories();//获取子目录的所有文件夹
            FileInfo[] fis = di.GetFiles();//获取子目录下的所有文件
            foreach (DirectoryInfo dir in dis)
            {
                TreeNode temp = new TreeNode(dir.Name);
                temp.Tag = dir.FullName;
                temp.ForeColor = Color.Red;
                node.Nodes.Add(temp);
            }
            foreach (FileInfo fi in fis)
            {
                TreeNode temp = new TreeNode(fi.Name);
                temp.Tag = fi.FullName;
                temp.ForeColor = Color.Green;
                node.Nodes.Add(temp);
            }
        }
        /// <summary>
        /// 选择了utf-8编码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uTF8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            encoding = "UTF-8";
            lblCoding.Text = encoding;
            ChangeCode();
            CheckedSelectCode();
        }
        /// <summary>
        /// 修改读取的编码
        /// </summary>
        private void ChangeCode()
        {
            XmlDocument loadConfig = new XmlDocument();
            loadConfig.Load("config.xml");
            XmlElement doc = loadConfig.DocumentElement;
            //获取并设置配置文件字符编码
            doc.GetElementsByTagName("encode")[0].InnerText = encoding;
            loadConfig.Save("config.xml");
        }

        private void gBKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            encoding = "GBK";
            lblCoding.Text = encoding;
            ChangeCode();
            CheckedSelectCode();
        }

        private void gB2312ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            encoding = "GB2312";
            lblCoding.Text = encoding;
            ChangeCode();
            CheckedSelectCode();
        }

        private void uTF16ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            encoding = "UTF-16";
            lblCoding.Text = encoding;
            ChangeCode();
            CheckedSelectCode();
        }

        private void unicodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            encoding = "Unicode";
            lblCoding.Text = encoding;
            ChangeCode();
            CheckedSelectCode();
        }

        private void aSCIIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            encoding = "ASCII";
            lblCoding.Text = encoding;
            ChangeCode();
            CheckedSelectCode();
        }
        /// <summary>
        /// 单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtContent_Click(object sender, EventArgs e)
        {
            this.lblPrompt.Text = "双击文本框即可修改文本";
        }
        /// <summary>
        /// 打开工作目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiOpenWorkFile_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("kb");
        }
        /// <summary>
        /// 打开收藏列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiMyLove_Click(object sender, EventArgs e)
        {
            OpenLove();
        }

        private void OpenLove()
        {
            FrmMyLove love = new FrmMyLove(this);
            love.Show();
        }

        private void tsmiAddLove_Click(object sender, EventArgs e)
        {
            //添加到收藏列表
            if (this.treeView1.SelectedNode != null && this.treeView1.SelectedNode.ForeColor == Color.Green)
            {
                //创建的xml文档
                XmlDocument xmlDoc = new XmlDocument();
                //创建根节点，
                XmlNode love = xmlDoc.CreateNode(XmlNodeType.Element, "love", null);
                XmlNode rootNode = null;
                if (!File.Exists("love.xml"))
                {
                    rootNode = xmlDoc.CreateNode(XmlNodeType.Element, "loveList", null);
                    XMLHelper.CreateNode(xmlDoc, love, "name", this.treeView1.SelectedNode.Text);
                    XMLHelper.CreateNode(xmlDoc, love, "path", this.treeView1.SelectedNode.Tag.ToString());
                    rootNode.AppendChild(love);
                    XMLHelper.CreateXmlFile(xmlDoc, "love.xml", rootNode);
                    MessageBox.Show("成功加入到收藏列表！");
                }
                else
                {
                    xmlDoc.Load("love.xml");
                    rootNode = xmlDoc.DocumentElement;
                    foreach (XmlNode item in xmlDoc.GetElementsByTagName("love"))
                    {
                        if (item.FirstChild.InnerText == this.treeView1.SelectedNode.Text)
                        {
                            MessageBox.Show("要收藏的文件已经存在！");
                            return;
                        }
                    }
                    XMLHelper.CreateNode(xmlDoc, love, "name", this.treeView1.SelectedNode.Text);
                    XMLHelper.CreateNode(xmlDoc, love, "path", this.treeView1.SelectedNode.Tag.ToString());
                    rootNode.AppendChild(love);
                    XMLHelper.CreateXmlFile(xmlDoc, "love.xml", rootNode);
                    MessageBox.Show("成功加入到收藏列表！");
                }
            }
        }

    }
}
