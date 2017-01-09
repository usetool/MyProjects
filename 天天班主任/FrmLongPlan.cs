using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using 天天管家.Entity;
using 天天管家.Operation;

namespace 天天管家
{
    public partial class FrmLongPlan : Form
    {
        public FrmLongPlan()
        {
            InitializeComponent();
        }
        DataOperation dataOperation = new DataOperation(Config.path, Config.pwd);
        /// <summary>
        /// 当前计划
        /// </summary>
        List<Plan> nowPlan = null;
        /// <summary>
        /// 计划修改历史
        /// </summary>
        List<Plan> planHistory = null;
        /// <summary>
        /// 理由
        /// </summary>
        public string whyStr;
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCreatePlan_Load(object sender, EventArgs e)
        {
            UpdatePlan();

        }
        /// <summary>
        /// 更新数据
        /// </summary>
        private void UpdatePlan()
        {
            //加载历史记录
            planHistory = dataOperation.GetAllHistoryPlan(PlanType.LongPlan);
            if (planHistory != null)
            {
                this.dataGridView1.DataSource = new BindingList<Plan>(planHistory);
            }
            //加载计划
            nowPlan = dataOperation.GetAllNowLongPlan();
            if (nowPlan != null)
            {
                //遍历当前计划并展示到窗体
                foreach (Plan item in nowPlan)
                {
                    if (PlanType.LongPlan == item.MyPlanType)
                    {
                        switch (item.PlanName)
                        {
                            case "计划1":
                                if (item.PlanContent != "")
                                {
                                    txtPlan1.Text = item.PlanContent;
                                    btnPlan1Update.Text = "修改";
                                }
                                break;
                            case "计划2":
                                if (item.PlanContent != "")
                                {
                                    txtPlan2.Text = item.PlanContent;
                                    btnPlan2Update.Text = "修改";
                                }
                                break;
                            case "计划3":
                                if (item.PlanContent != "")
                                {
                                    txtPlan3.Text = item.PlanContent;
                                    btnPlan3Update.Text = "修改";
                                }
                                break;
                            case "计划4":
                                if (item.PlanContent != "")
                                {
                                    txtPlan4.Text = item.PlanContent;
                                    btnPlan4Update.Text = "修改";
                                }
                                break;
                            case "计划5":
                                if (item.PlanContent != "")
                                {
                                    txtPlan5.Text = item.PlanContent;
                                    btnPlan5Update.Text = "修改";
                                }
                                break;
                        }
                    }
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 右键菜单-查看详细被点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiDetail_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 修改计划1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlan1Update_Click(object sender, EventArgs e)
        {
            if (btnPlan1Update.Text == "修改")
            {
                txtPlan1.ReadOnly = false;
                btnPlan1Update.Text = "确定修改";
            }
            else if (btnPlan1Update.Text == "添加")
            {
                txtPlan1.ReadOnly = false;
                btnPlan1Update.Text = "确定添加";
            }
            else if (btnPlan1Update.Text == "确定修改" || btnPlan1Update.Text == "确定添加")//执行添加
            {
                FrmUpdateWhy frm = new FrmUpdateWhy(this);
                frm.ShowDialog();
                txtPlan1.ReadOnly = true;
                Plan plan = new Plan();
                plan.CreateTime = DateTime.Now;
                plan.MyPlanType = PlanType.LongPlan;
                plan.PlanContent = txtPlan1.Text;
                plan.PlanName = "计划1";
                plan.PlanWhy = whyStr;
                if (dataOperation.AddPlan(plan))
                {
                    MessageBox.Show("修改成功！");
                    UpdatePlan();
                }
                else
                {
                    MessageBox.Show("修改失败！");
                }
            }
          
        }
        /// <summary>
        /// 修改计划2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlan2Update_Click(object sender, EventArgs e)
        {
            if (btnPlan2Update.Text == "修改")
            {
                txtPlan2.ReadOnly = false;
                btnPlan2Update.Text = "确定修改";
            }
            else if (btnPlan2Update.Text == "添加")
            {
                txtPlan2.ReadOnly = false;
                btnPlan2Update.Text = "确定添加";
            }
            else if (btnPlan2Update.Text == "确定修改" || btnPlan2Update.Text == "确定添加")//执行添加
            {
                FrmUpdateWhy frm = new FrmUpdateWhy(this);
                frm.ShowDialog();
                txtPlan2.ReadOnly = true;
                Plan plan = new Plan();
                plan.CreateTime = DateTime.Now;
                plan.MyPlanType = PlanType.LongPlan;
                plan.PlanContent = txtPlan2.Text;
                plan.PlanName = "计划2";
                plan.PlanWhy = whyStr;
                if (dataOperation.AddPlan(plan))
                {
                    MessageBox.Show("修改成功！");
                    UpdatePlan();
                }
                else
                {
                    MessageBox.Show("修改失败！");
                }
            }
        }
        /// <summary>
        /// 修改计划3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlan3Update_Click(object sender, EventArgs e)
        {
            if (btnPlan3Update.Text == "修改")
            {
                txtPlan3.ReadOnly = false;
                btnPlan3Update.Text = "确定修改";
            }
            else if (btnPlan3Update.Text == "添加")
            {
                txtPlan3.ReadOnly = false;
                btnPlan3Update.Text = "确定添加";
            }
            else if (btnPlan3Update.Text == "确定修改" || btnPlan3Update.Text == "确定添加")//执行添加
            {
                FrmUpdateWhy frm = new FrmUpdateWhy(this);
                frm.ShowDialog();
                txtPlan3.ReadOnly = true;
                Plan plan = new Plan();
                plan.CreateTime = DateTime.Now;
                plan.MyPlanType = PlanType.LongPlan;
                plan.PlanContent = txtPlan3.Text;
                plan.PlanName = "计划3";
                plan.PlanWhy = whyStr;
                if (dataOperation.AddPlan(plan))
                {
                    MessageBox.Show("修改成功！");
                    UpdatePlan();
                }
                else
                {
                    MessageBox.Show("修改失败！");
                }
            }
        }
        /// <summary>
        /// 修改计划4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlan4Update_Click(object sender, EventArgs e)
        {
            if (btnPlan4Update.Text == "修改")
            {
                txtPlan4.ReadOnly = false;
                btnPlan4Update.Text = "确定修改";
            }
            else if (btnPlan4Update.Text == "添加")
            {
                txtPlan4.ReadOnly = false;
                btnPlan4Update.Text = "确定添加";
            }
            else if (btnPlan4Update.Text == "确定修改" || btnPlan4Update.Text == "确定添加")//执行添加
            {
                FrmUpdateWhy frm = new FrmUpdateWhy(this);
                frm.ShowDialog();
                txtPlan4.ReadOnly = true;
                Plan plan = new Plan();
                plan.CreateTime = DateTime.Now;
                plan.MyPlanType = PlanType.LongPlan;
                plan.PlanContent = txtPlan4.Text;
                plan.PlanName = "计划4";
                plan.PlanWhy = whyStr;
                if (dataOperation.AddPlan(plan))
                {
                    MessageBox.Show("修改成功！");
                    UpdatePlan();
                }
                else
                {
                    MessageBox.Show("修改失败！");
                }
            }
        }
        /// <summary>
        /// 修改计划5
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlan5Update_Click(object sender, EventArgs e)
        {
            if (btnPlan5Update.Text == "修改")
            {
                txtPlan5.ReadOnly = false;
                btnPlan1Update.Text = "确定修改";
            }
            else if (btnPlan5Update.Text == "添加")
            {
                txtPlan5.ReadOnly = false;
                btnPlan5Update.Text = "确定添加";
            }
            else if (btnPlan5Update.Text == "确定修改" || btnPlan5Update.Text == "确定添加")//执行添加
            {
                FrmUpdateWhy frm = new FrmUpdateWhy(this);
                frm.ShowDialog();
                txtPlan5.ReadOnly = true;
                Plan plan = new Plan();
                plan.CreateTime = DateTime.Now;
                plan.MyPlanType = PlanType.LongPlan;
                plan.PlanContent = txtPlan5.Text;
                plan.PlanName = "计划5";
                plan.PlanWhy = whyStr;
                if (dataOperation.AddPlan(plan))
                {
                    MessageBox.Show("修改成功！");
                    UpdatePlan();
                }
                else
                {
                    MessageBox.Show("修改失败！");
                }
            }
        }
        /// <summary>
        /// 计划筛选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //加载历史记录
            DataOperation dataOperation = new DataOperation(Config.path, Config.pwd);
            if (this.comboBox1.SelectedIndex == 0)
            {
                planHistory = dataOperation.GetAllHistoryPlan();
            }
            else
            {
                planHistory = dataOperation.GetAllHistoryPlan(this.comboBox1.SelectedIndex);
            }
            if (planHistory != null)
            {
                this.dataGridView1.DataSource = new BindingList<Plan>(planHistory);
            }
        }
        /// <summary>
        /// 窗体单击获得焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLongPlan_Click(object sender, EventArgs e)
        {
            this.Focus();
        }
        /// <summary>
        /// 点击pannel获得焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_Click(object sender, EventArgs e)
        {
            panel1.Focus();
        }
    }
}
