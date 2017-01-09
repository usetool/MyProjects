using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
namespace 乐智知识库
{
    public partial class FrmMyLove : Form
    {
        FrmMain frmMain;
        public FrmMyLove(FrmMain frmMain)
        {
            InitializeComponent();
            this.frmMain = frmMain;
        }
        
        private void FrmMyLove_Load(object sender, EventArgs e)
        {
            BingData();

        }

        public void BingData()
        {
            if (File.Exists("love.xml"))
            {
                //加载XML文件中的收藏列表
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("love.xml");
                List<Love> loves = new List<Love>();
                foreach (XmlNode item in xmlDoc.GetElementsByTagName("love"))
                {
                    Love love = new Love();
                    love.Name = item.FirstChild.InnerText;
                    love.Path = item.LastChild.InnerText;
                    loves.Add(love);
                }
                this.listBox1.DisplayMember = "Name";
                this.listBox1.ValueMember = "Path";
                this.listBox1.DataSource = new BindingList<Love>(loves);
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.listBox1.SelectedItem != null && this.listBox1.SelectedItems.Count == 1&&this.listBox1.SelectedValue!=null)
            {
                frmMain.OpenFile(this.listBox1.SelectedValue.ToString(),this);
            }
        }
        /// <summary>
        /// 删除收藏列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (File.Exists("love.xml"))
            {
                //加载XML文件中的收藏列表
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("love.xml");
                List<Love> loves = new List<Love>();
                XmlElement root = xmlDoc.DocumentElement;
                foreach (XmlNode item in root.GetElementsByTagName("love"))
                {
                    if (item.FirstChild.InnerText==this.listBox1.Text)
                    {
                        root.RemoveChild(item);
                        xmlDoc.Save("love.xml");
                        this.BingData();
                        MessageBox.Show("删除成功！");
                        return;
                    }
                }

            }
        }
    }
}
