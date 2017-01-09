using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace TestForMysql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateInfo();
        }

        private void UpdateInfo()
        {
            string sql = "select id,name,age from user";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, DbHelperMySQL.GetConnection());
            DataSet ds = new DataSet();
            adapter.Fill(ds, "user");
            this.dataGridView1.DataSource = ds.Tables["user"];
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string sql = "delete from user where id=" + id;
            int result = DbHelperMySQL.ExecuteSql(sql);
            if (result == 1)
            {
                MessageBox.Show("删除成功！");
                UpdateInfo();
            }
            else
            {
                MessageBox.Show("删除失败！");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddInfo();

        }

        private void AddInfo()
        {
            if (this.txtage.Text == "" || this.txtname.Text == "")
            {
                MessageBox.Show("内容不能为空");
                return;
            }
            string sql = "insert into user(name,age) values ('" + txtname.Text + "'," + txtage.Text + ")";
            int result = DbHelperMySQL.ExecuteSql(sql);
            if (result == 1)
            {
                MessageBox.Show("添加成功！");
                UpdateInfo();
            }
            else
            {
                MessageBox.Show("添加失败！");
            }
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.button1.Text = "修改";
            this.txtname.Text = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            this.txtname.Tag = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            this.txtage.Text = this.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        private void UpdateUser()
        {
            if (this.txtage.Text == "" || this.txtname.Text == "")
            {
                MessageBox.Show("内容不能为空");
                return;
            }
            string sql = "update user set name='" + txtname.Text + "',age=" + txtage.Text + " where id=" + Convert.ToInt32(txtname.Tag);
            int result = DbHelperMySQL.ExecuteSql(sql);
            if (result == 1)
            {
                MessageBox.Show("修改成功！");
                UpdateInfo();
            }
            else
            {
                MessageBox.Show("修改失败！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateUser();
        }
    }
}
