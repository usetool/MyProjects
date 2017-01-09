using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using 天天管家.Entity;
using System.Data;
using System.Windows.Forms;

namespace 天天管家.Operation
{
    /// <summary>
    /// SQLite数据库操作类
    /// </summary>
    class DataOperation
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">创建对象时需要传入数据库的路径及文件名</param>
        public DataOperation(string path, string pwd)
        {
            DbHelperSQLite.connectionString = "Data Source=" + path + ";Version=3;Password=" + pwd;
            this.pwd = pwd;
        }
        /// <summary>
        /// 数据库的密码
        /// </summary>
        private string pwd;
        /// <summary>
        /// 获取所有当前的计划
        /// </summary>
        /// <returns></returns>
        public List<Plan> GetAllNowPlan()
        {
            string sql = @"select id,planName,plan.planType,planContent,planWhy,plan.createTime from plan 
            inner join (select planType,max(createTime) as tt from plan group by planType) as t 
            on plan.createTime=t.tt and plan.planType=t.planType";
            DataSet set = null;
            List<Plan> plans = new List<Plan>();
            try
            {
                set = DbHelperSQLite.Query(sql);
                //遍历一个表多行多列
                foreach (DataRow dr in set.Tables[0].Rows)
                {
                    Plan plan = new Plan();
                    plan.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
                    plan.Id = Convert.ToInt32(dr["id"]);
                    int enumIndex = Convert.ToInt32(dr["planType"].ToString());
                    plan.MyPlanType = (PlanType)enumIndex;
                    plan.PlanContent = dr["PlanContent"].ToString();
                    plan.PlanName = dr["PlanName"].ToString();
                    plan.PlanWhy = dr["PlanWhy"].ToString();
                    plans.Add(plan);
                }
            }
            catch (Exception)
            {
                return null;
                throw;//测试时
            }
            return plans;
        }
        /// <summary>
        /// 获取所有长期的现在计划
        /// </summary>
        /// <returns></returns>
        public List<Plan> GetAllNowLongPlan()
        {
            string sql = @"select id,plan.planName,plan.planType,planContent,planWhy,plan.createTime from plan 
            inner join (select plan.planName,max(createTime) as tt from plan group by planName) as t 
            on plan.createTime=t.tt and plan.planName=t.planName where planType=1";
            DataSet set = null;
            List<Plan> plans = new List<Plan>();
            try
            {
                set = DbHelperSQLite.Query(sql);
                foreach (DataRow dr in set.Tables[0].Rows)
                {
                    Plan plan = new Plan();
                    plan.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
                    plan.Id = Convert.ToInt32(dr["id"]);
                    int enumIndex = Convert.ToInt32(dr["planType"].ToString());
                    plan.MyPlanType = (PlanType)enumIndex;
                    plan.PlanContent = dr["PlanContent"].ToString();
                    plan.PlanName = dr["PlanName"].ToString();
                    plan.PlanWhy = dr["PlanWhy"].ToString();
                    plans.Add(plan);
                }
            }
            catch (Exception)
            {
                return null;
                throw;//测试时
            }
            return plans;
        }
        /// <summary>
        /// 获取所有的历史计划
        /// </summary>
        /// <returns></returns>
        public List<Plan> GetAllHistoryPlan()
        {
            List<Plan> history = new List<Plan>();
            string sql = "select id,planName,planType,planContent,planWhy,createTime from plan";
            try
            {
                DataSet ds = DbHelperSQLite.Query(sql);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Plan plan = new Plan();
                    plan.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
                    plan.Id = Convert.ToInt32(dr["id"]);
                    int enumIndex = Convert.ToInt32(dr["planType"].ToString());
                    plan.MyPlanType = (PlanType)enumIndex;
                    plan.PlanContent = dr["PlanContent"].ToString();
                    plan.PlanName = dr["PlanName"].ToString();
                    plan.PlanWhy = dr["PlanWhy"].ToString();
                    history.Add(plan);
                }
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            return history;
        }
        /// <summary>
        /// 根据计划类型获取历史计划
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<Plan> GetAllHistoryPlan(PlanType type)
        {
            List<Plan> history = new List<Plan>();
            string sql = "select id,planName,planType,planContent,planWhy,createTime from plan where planType="+Convert.ToInt32(type);
            try
            {
                DataSet ds = DbHelperSQLite.Query(sql);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Plan plan = new Plan();
                    plan.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
                    plan.Id = Convert.ToInt32(dr["id"]);
                    int enumIndex = Convert.ToInt32(dr["planType"].ToString());
                    plan.MyPlanType = (PlanType)enumIndex;
                    plan.PlanContent = dr["PlanContent"].ToString();
                    plan.PlanName = dr["PlanName"].ToString();
                    plan.PlanWhy = dr["PlanWhy"].ToString();
                    history.Add(plan);
                }
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            return history;
        }
        /// <summary>
        /// 根据计划类型和计划名称获取所有历史记录
        /// </summary>
        /// <param name="type"></param>
        /// <param name="planName"></param>
        /// <returns></returns>
        public List<Plan> GetAllHistoryPlan(PlanType type,string planName)
        {
            List<Plan> history = new List<Plan>();
            string sql = "select id,planName,planType,planContent,planWhy,createTime from plan where planType=" + Convert.ToInt32(type) + " and planName='" + planName+"'";
            try
            {
                DataSet ds = DbHelperSQLite.Query(sql);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Plan plan = new Plan();
                    plan.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
                    plan.Id = Convert.ToInt32(dr["id"]);
                    int enumIndex = Convert.ToInt32(dr["planType"].ToString());
                    plan.MyPlanType = (PlanType)enumIndex;
                    plan.PlanContent = dr["PlanContent"].ToString();
                    plan.PlanName = dr["PlanName"].ToString();
                    plan.PlanWhy = dr["PlanWhy"].ToString();
                    history.Add(plan);
                }
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            return history;
        }
        /// <summary>
        /// 根据指定类型和时间获取计划
        /// </summary>
        /// <param name="type"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public List<Plan> GetAllHistoryPlan(PlanType type,DateTime time)
        {
            List<Plan> history = new List<Plan>();
            string sql = "select id,planName,planType,planContent,planWhy,createTime from plan where planType=" + Convert.ToInt32(type) + " and createTime>'" + time.Date + "' and createTime<'"+time.AddDays(1).Date+"'";
            try
            {
                DataSet ds = DbHelperSQLite.Query(sql);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Plan plan = new Plan();
                    plan.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
                    plan.Id = Convert.ToInt32(dr["id"]);
                    int enumIndex = Convert.ToInt32(dr["planType"].ToString());
                    plan.MyPlanType = (PlanType)enumIndex;
                    plan.PlanContent = dr["PlanContent"].ToString();
                    plan.PlanName = dr["PlanName"].ToString();
                    plan.PlanWhy = dr["PlanWhy"].ToString();
                    history.Add(plan);
                }
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            return history;
        }
        /// <summary>
        /// 获取密码
        /// </summary>
        /// <returns></returns>
        public Plan GetPwd()
        {
            Plan plan = null;
            string sql = "select id,planName,planType,planContent,planWhy,createTime from plan where planType=" + Convert.ToInt32(PlanType.Diary) + " and planName='pwd'";
            try
            {
                DataSet ds = DbHelperSQLite.Query(sql);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    plan = new Plan();
                    plan.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
                    plan.Id = Convert.ToInt32(dr["id"]);
                    int enumIndex = Convert.ToInt32(dr["planType"].ToString());
                    plan.MyPlanType = (PlanType)enumIndex;
                    plan.PlanContent = dr["PlanContent"].ToString();
                    plan.PlanName = dr["PlanName"].ToString();
                    plan.PlanWhy = dr["PlanWhy"].ToString();
                }
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            return plan;
        }
        /// <summary>
        /// 根据开始时间和结束时间和指定计划类型获取计划
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<Plan> GetAllHistoryPlan(PlanType type, DateTime startTime, DateTime endTime)
        {
            List<Plan> history = new List<Plan>();
            string sql = "select id,planName,planType,planContent,planWhy,createTime from plan where planType=" + Convert.ToInt32(type) + " and createTime>='" + startTime.Date + "' and createTime<='" + endTime + "'";
            try
            {
                DataSet ds = DbHelperSQLite.Query(sql);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Plan plan = new Plan();
                    plan.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
                    plan.Id = Convert.ToInt32(dr["id"]);
                    int enumIndex = Convert.ToInt32(dr["planType"].ToString());
                    plan.MyPlanType = (PlanType)enumIndex;
                    plan.PlanContent = dr["PlanContent"].ToString();
                    plan.PlanName = dr["PlanName"].ToString();
                    plan.PlanWhy = dr["PlanWhy"].ToString();
                    history.Add(plan);
                }
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            return history;
        }
        /// <summary>
        /// 获取所有的历史计划；根据计划筛选
        /// </summary>
        /// <param name="id">计划编号</param>
        /// <returns></returns>
        public List<Plan> GetAllHistoryPlan(int id)
        {
            List<Plan> history = new List<Plan>();
            string sql = "select id,planName,planType,planContent,planWhy,createTime from plan where planName='计划" + id + "'";
            try
            {
                DataSet ds = DbHelperSQLite.Query(sql);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Plan plan = new Plan();
                    plan.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
                    plan.Id = Convert.ToInt32(dr["id"]);
                    int enumIndex = Convert.ToInt32(dr["planType"].ToString());
                    plan.MyPlanType = (PlanType)enumIndex;
                    plan.PlanContent = dr["PlanContent"].ToString();
                    plan.PlanName = dr["PlanName"].ToString();
                    plan.PlanWhy = dr["PlanWhy"].ToString();
                    history.Add(plan);
                }
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            return history;
        }

        /// <summary>
        /// 添加一个计划(也可能是修改计划，但是为了保存历史记录)
        /// </summary>
        /// <param name="plan">计划对象</param>
        /// <returns>成功返回true失败返回false</returns>
        public bool AddPlan(Plan plan)
        {
            string sql = "INSERT INTO plan (planName,planType,planContent,planWhy,createTime) VALUES ('" + plan.PlanName + "','" + Convert.ToInt32(plan.MyPlanType) + "','" + plan.PlanContent + "','" + plan.PlanWhy + "','" + plan.CreateTime + "')";
            int result = 0;
            try
            {
                result = DbHelperSQLite.ExecuteSql(sql);
                if (result == 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="plan"></param>
        /// <returns></returns>
        public bool UpdatePwd(Plan plan)
        {
            string sql = "update plan set planName='" + plan.PlanName + "',planType='" + Convert.ToInt32(plan.MyPlanType) + "',planContent='" + plan.PlanContent + "',planWhy='" + plan.PlanWhy + "',createTime='" + plan.CreateTime + "' where id="+plan.Id;
            int result = 0;
            try
            {
                result = DbHelperSQLite.ExecuteSql(sql);
                if (result == 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        /// <summary>
        /// 根据类型获取记录总数
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int GetDaysNum(PlanType type)
        {
            string sql = "select count(id) from plan where  planType=" + Convert.ToInt32(type);
            int result = 0;
            DataSet ds = DbHelperSQLite.Query(sql);
            DataRow dr = ds.Tables[0].Rows[0];
            result = Convert.ToInt32(dr[0]);
            return result;
        }
        /// <summary>
        /// 根据最近的创建时间获取计划
        /// </summary>
        /// <returns></returns>
        public Plan GetPlanByMaxCreateTime()
        {
            Plan plan = null;
            string sql = @"select id,planName,planType,planContent,planWhy,createTime from plan where createTime=(select max(createTime) from plan where planType=6)";
            try
            {
                DataSet ds = DbHelperSQLite.Query(sql);
                plan = new Plan();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    plan.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
                    plan.Id = Convert.ToInt32(dr["id"]);
                    int enumIndex = Convert.ToInt32(dr["planType"].ToString());
                    plan.MyPlanType = (PlanType)enumIndex;
                    plan.PlanContent = dr["PlanContent"].ToString();
                    plan.PlanName = dr["PlanName"].ToString();
                    plan.PlanWhy = dr["PlanWhy"].ToString();
                }
                plan.CreateTime = new DateTime(1900, 01, 01);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            return plan;
        }
        /// <summary>
        /// 根据id获取计划
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Plan GetPlanById(int id)
        {
            Plan plan = null;
            string sql = @"select id,planName,planType,planContent,planWhy,createTime from plan where id="+id;
            try
            {
                DataSet ds = DbHelperSQLite.Query(sql);
                plan = new Plan();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    plan.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
                    plan.Id = Convert.ToInt32(dr["id"]);
                    int enumIndex = Convert.ToInt32(dr["planType"].ToString());
                    plan.MyPlanType = (PlanType)enumIndex;
                    plan.PlanContent = dr["PlanContent"].ToString();
                    plan.PlanName = dr["PlanName"].ToString();
                    plan.PlanWhy = dr["PlanWhy"].ToString();
                }
                plan.CreateTime = new DateTime(1900, 01, 01);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            return plan;
        }
        /// <summary>
        /// 根据开始时间和计划类型获取实际签到次数
        /// </summary>
        /// <param name="time"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int GetCountByStartTimeAndType(DateTime time, PlanType type)
        {
            int result = 0;
            string sql = "select count(id) from plan where createTime>='" + time.Date + "' and planType=" + Convert.ToInt32(type);
            DataSet ds = DbHelperSQLite.Query(sql);
            if (ds.Tables[0] != null)
            {
                result = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            }
            return result;
        }
        /// <summary>
        /// 获取最近一次给定计划类型的创建时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetMaxPlanCreateTimeByType(PlanType type)
        {
            DateTime time = new DateTime();
            string sql = "select max(createTime) from plan where planType=" + Convert.ToInt32(type);
            DataSet ds = DbHelperSQLite.Query(sql);
            if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0][0].ToString() != "")
            {
                time = Convert.ToDateTime(ds.Tables[0].Rows[0][0]);
            }
            else
            {
                    time = new DateTime(1900, 1, 1);
               
            }
            return time;
        }
        /// <summary>
        /// 获取今天的完成情况
        /// </summary>
        /// <param name="type"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public int GetDaysNum(PlanType type, DateTime time)
        {
            string sql = "select count(id) from plan where  planType=" + Convert.ToInt32(type) + " and createTime ='" + time.Date + "'";
            int result = 0;
            DataSet ds = DbHelperSQLite.Query(sql);
            DataRow dr = ds.Tables[0].Rows[0];
            result = Convert.ToInt32(dr[0]);
            return result;
        }
        public DateTime GetSrartTime()
        {
            DateTime time = new DateTime();
            string sql = "select max(createTime) from plan";
            DataSet ds = DbHelperSQLite.Query(sql);
            DataRow dr = ds.Tables[0].Rows[0];
            if (dr[0].ToString() == "")
            {
                time = DateTime.Now;
            }
            else
            {
                time = Convert.ToDateTime(dr[0].ToString());
            }
            return time;
        }
        /// <summary>
        /// 创建数据库文件
        /// </summary>
        /// <param name="path">路径及文件名</param>
        /// <param name="dbPwd">数据库的访问密码</param>
        public static void CreateDB(string path, string dbPwd)
        {
            SQLiteConnection conn = null;
            try
            {
                conn = new SQLiteConnection();
                //创建一个数据库文件
                SQLiteConnection.CreateFile(path);
                string sql = "CREATE TABLE plan(id INTEGER PRIMARY KEY AUTOINCREMENT,planName TEXT NOT NULL,planType INTEGER NOT NULL,planContent text NOT NULL,planWhy text NOT NULL,createTime text NOT NULL)";
                SQLiteConnectionStringBuilder connstr = new SQLiteConnectionStringBuilder();
                connstr.DataSource = path;
                connstr.Password = dbPwd;//设置数据密码
                conn.ConnectionString = connstr.ToString();
                conn.Open();
                //创建表
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;//仅是调试时
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }




    }
}
