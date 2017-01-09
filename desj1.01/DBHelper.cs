using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Data.SqlClient;
using MySql.Data.MySqlClient;   //MySQL
namespace desj
{
    /// <summary>
    /// 数据库连接类
    /// </summary>
    public class DBHelper
    {
        //服务器
        private static string constr = "Database=XueSheStudy;Data Source=182.92.215.126;User Id=xueshe;Password=BDQNXueShe2015";//连接字符串
        //虚拟机
        //private static string constr = "Database=desj;Data Source=192.168.56.1;User Id=root;Password=1234";//连接字符
        //本地
        //private static string constr = "Database=desj;Data Source=127.0.0.1;User Id=root;Password=1234";//连接字符串


        public static MySqlConnection conn = new MySqlConnection(constr);

    }
}
