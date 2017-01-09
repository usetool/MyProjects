using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IPlugin;

namespace MyApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            Assembly ass = Assembly.LoadFrom(openFileDialog1.FileName);
            foreach (Type type in ass.GetTypes())
            {
                if (type.GetInterface("IShow")!=null)
                {
                    try
                    {
                        IShow ishow = Activator.CreateInstance(type) as IShow;
                        ishow.Show();
                    }
                    catch (Exception)
                    {
                        
                        throw;
                    }
                }
            }
        }
    }
}
