using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Data.SqlClient;  sqlserver
using MySql.Data.MySqlClient;   //mysql
namespace desj
{
    /// <summary>
    /// 操作类
    /// </summary>
    class Operate
    {
        public string id;//id号码
        public string pwd;//密码 
        private bool isLogin = false;//是否登录
        public DBHelper dber = new DBHelper();
        /// <summary>
        /// 显示主菜单
        /// </summary>
        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("=================================desj-聊天室-公布版=============================");
            Console.WriteLine("-                     重回控制台暗黑经典。 小、快                              -");
            //告示
            try
            {
                DBHelper.conn.Open();
                string sql = "select nickName,noticecont from users inner join notice on users.uid=notice.uid order by publishtime desc limit 1 ";
                MySqlCommand comm = new MySqlCommand(sql, DBHelper.conn);
                MySqlDataReader reader = comm.ExecuteReader();
                if (reader.Read())
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("********************************* ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("公 告");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(" ****************************************");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("管理员： ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(reader["nickName"].ToString());
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" 说：");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("{0}", reader["noticecont"].ToString());
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("暂时没有公告！");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("发生错误!");
                if (ex.Message == "Unable to connect to any of the specified MySQL hosts.")
                {
                    Console.WriteLine("连接服务器失败！");
                }
                else
                {
                    Console.WriteLine("发生了其他的错误！请联系管理员：984137184@qq.com");
                }
                //Console.WriteLine(ex.Message);
                Console.ReadKey(true);
                Environment.Exit(0);
            }
            finally
            {
                DBHelper.conn.Close();
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("********************************************************************************");
            //告示
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("请输入相应数字选择菜单：1.注册\t2.登录\t0.退出");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            string choo = Console.ReadLine();
            switch (choo)
            {
                case "1":
                    //注册
                    Register();
                    ReturnMenu();
                    break;
                case "2":
                    //登录   登录成功则进入聊天室
                    if (Login())
                    {
                        Home();
                    }
                    else
                    {
                        Console.WriteLine("重新试一下？");
                        ReturnMenu();
                    }
                    break;
                case "0":
                    //退出
                    Console.WriteLine("确认退出？");
                    ReturnMenu();
                    return;
                default:
                    Console.WriteLine("输入错误！请重新输入！");
                    ReturnMenu();
                    break;
            }

        }
        /// <summary>
        /// 注册
        /// </summary>
        public bool Register()
        {
            bool flag = false;
            Console.WriteLine("请输入密码：（至少6位）");
            string password = Console.ReadLine();
            Console.WriteLine("请输入昵称：(不能与其他成员冲突)");
            string nickName = Console.ReadLine();
            Console.WriteLine("请输入性别：(男/女)");
            string sex = Console.ReadLine();
            bool isSex = false;
            if (sex == "男" || sex == "女")
            {
                isSex = true;
            }
            bool isPassWord = false;
            bool isNickName = false;
            if (password.Length < 6)
            {
                Console.WriteLine("密码长度至少6位！");
            }
            else
            {
                isPassWord = true;
            }
            DBHelper.conn.Open();
            string sqlstr = string.Format("select COUNT(*) from Users where nickName='{0}'", nickName);
            MySqlCommand comm = new MySqlCommand(sqlstr, DBHelper.conn);
            int result = Convert.ToInt32(comm.ExecuteScalar());
            DBHelper.conn.Close();
            if (result > 0)
            {
                Console.WriteLine("该用户名已被注册，请换个试试！");
            }
            else
            {
                isNickName = true;
            }
            DBHelper.conn.Open();
            if (isPassWord && isNickName && isSex)
            {
                sqlstr = string.Format("insert into Users (pwd,nickName,registerTime,sex,summary) values ('{0}','{1}',concat(curdate(),' ',curtime()),'{2}','还没有签名')", password, nickName, sex);
                comm = new MySqlCommand(sqlstr, DBHelper.conn);
                result = comm.ExecuteNonQuery();
                if (result > 0)
                {
                    sqlstr = string.Format("select uid from Users where pwd='{0}' and nickName='{1}'", password, nickName);
                    comm = new MySqlCommand(sqlstr, DBHelper.conn);
                    MySqlDataReader reader = comm.ExecuteReader();
                    reader.Read();
                    result = (int)reader["uid"];
                    Console.WriteLine("注册成功！您申请的id为{0}", result);
                    DBHelper.conn.Close();
                    //ReturnMenu();
                }
                else
                {
                    Console.WriteLine("请重新填写注册信息！");
                }
            }
            DBHelper.conn.Close();




            return flag;
        }
        /// <summary>
        /// 登录
        /// </summary>
        public bool Login()
        {
            bool flag = false;
            Console.WriteLine("请输入ID：");
            string uid = Console.ReadLine();
            Console.WriteLine("请输入密码：");
            string pwd = Console.ReadLine();
            DBHelper.conn.Open();
            string sql = string.Format("select COUNT(*) from Users where uid={0} and pwd='{1}';", uid, pwd);
            MySqlCommand comm = new MySqlCommand(sql, DBHelper.conn);
            int result = Convert.ToInt32(comm.ExecuteScalar());
            if (result == 1)
            {
                Console.WriteLine("登陆成功！");
                isLogin = true;
                id = uid;
                this.pwd = pwd;
                flag = true;
                //comm.CommandText = string.Format("update users set inline=1 where uid={0}", Convert.ToInt32(uid));
                //int num = comm.ExecuteNonQuery();
                //Console.WriteLine("在线结果是："+num+"uid是："+uid);
            }
            else
            {
                Console.WriteLine("登录失败");
            }
            DBHelper.conn.Close();
            return flag;
        }
        /// <summary>
        /// 聊天功能
        /// </summary>
        public void Chat()
        {
            if (isLogin)
            {
                bool isGoOn = false;
                Console.WriteLine("=======================欢迎进入最炫聊天室=====================");
                Console.WriteLine();
                Console.WriteLine("|   别看我黑黑的，可我是最快最安全的~  |");
                Console.WriteLine();
                do
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("最近10条记录：(最新的消息总会在上面)");
                    Console.WriteLine();
                    Console.WriteLine("-------------------------------------------------------------------------");
                    DBHelper.conn.Open();
                    string sqlstr = @"select nickName,chatTime,chatContent,chat.uid 
                    from chat inner join Users 
                    on chat.uid=Users.uid 
                    order by chatTime desc limit 10";
                    MySqlCommand comm = new MySqlCommand(sqlstr, DBHelper.conn);
                    MySqlDataReader reader = comm.ExecuteReader();
                    int onid = 0;
                    int flagId = 0;
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    while (reader.Read())
                    {
                        Console.WriteLine();
                        string name = reader["nickName"].ToString();
                        string time = reader["chatTime"].ToString();
                        string content = reader["chatContent"].ToString();
                        onid = Convert.ToInt32(reader["uid"]);
                        string onstr = "";
                        //if (online == 1)//在线功能
                        //{
                        //    onstr = "在线";
                        //}
                        //else
                        //{
                        //    onstr = "离线";
                        //}
                        if (onid != flagId)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("-----                                                            -----");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                        }

                        Console.WriteLine("{0}(id:{1}) 在 {3} 说: {4}", name, onid, onstr, time, content);
                        flagId = onid;
                    }
                    reader.Close();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("-------------------------------------------------------------------------");
                    Console.WriteLine("最新的消息总会在最上面↑");
                    Console.WriteLine("\tcmd指令：直接回车刷新聊天内容   直接输入内容回车发送   \n\t   退出直接输入“**”   输入“<<”返回上一级");
                    Console.WriteLine("输入你想说的：");
                    Console.WriteLine("\n");
                    string chatContent = Console.ReadLine();
                    if (chatContent.Length > 0)
                    {
                        if (chatContent.Length >= 2 && chatContent.Substring(0, 2) == "**")
                        {
                            Console.WriteLine("选择了退出");
                            DBHelper.conn.Close();
                            return;
                        }
                        else if (chatContent.Length >= 2 && chatContent.Substring(0, 2) == "<<")
                        {
                            isGoOn = false;
                        }
                        else if (chatContent.Length >= 2 && chatContent.Substring(0, 2) == "@@")
                        {

                        }
                        else
                        {
                            sqlstr = string.Format("insert into chat (uid,chatcontent,chattime) values ({0},'{1}',concat(curdate(),' ',curtime()))", id, chatContent);
                            comm = new MySqlCommand(sqlstr, DBHelper.conn);
                            int result = comm.ExecuteNonQuery();
                            if (result > 0)
                            {
                                Console.WriteLine("发送成功！");
                            }
                            else
                            {
                                Console.WriteLine("发送失败！");
                            }
                            isGoOn = true;
                        }
                    }
                    else
                    {
                        isGoOn = true;
                    }

                    DBHelper.conn.Close();

                } while (isGoOn);
                ReturnMenu();
            }
            else
            {
                Console.WriteLine("登录失败，请重试！");
            }
        }
        /// <summary>
        /// 返回上一级
        /// </summary>
        public void ReturnMenu()
        {
            Console.WriteLine("返回上一级输入r(如果在聊天室使用返回上一级将需要重新登录！)  退出输入e");
            string sele = Console.ReadLine();
            if (sele == "r")
            {
                isLogin = false;
                ShowMenu();
            }
            else if (sele == "e")
            {
                return;
            }
            else
            {
                Console.WriteLine("请重新选择！");
                ReturnMenu();
            }
        }
        /// <summary>
        /// 最先进入个人中心
        /// </summary>
        public void Home()
        {
            Console.Clear();
            bool isgo = false;
            //Console.WriteLine("1.修改资料");
            do
            {
                Console.WriteLine("1.聊天室");
                Console.WriteLine("其他功能请期待更新~~");
                Console.WriteLine("请输入数字选择：");
                string choo = Console.ReadLine();
                switch (choo)
                {
                    case "1":
                        Chat();
                        break;

                    default:
                        Console.WriteLine("输入错误，请选择！");
                        isgo = true;
                        break;
                }
            } while (isgo);
           
        }
        /// <summary>
        /// 修改资料
        /// </summary>
        public void ChangeInfo()
        { }
    }
}
