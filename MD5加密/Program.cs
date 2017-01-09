using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MD5加密
{
    class Program
    {
        static void Main(string[] args)
        {
            //得到其静态方法创建的MD5对象
            MD5 md5 = MD5.Create();
            //要加密的字符串
            string str="123";
            //字节数组
            byte[] strbuffer = Encoding.Default.GetBytes(str);
            //加密并返回字节数组
            strbuffer= md5.ComputeHash(strbuffer);
            string strNew = "";
            foreach (byte item in strbuffer)
            {
                //对字节数组中元素格式化后拼接
                strNew+=item.ToString("x2");
            }
            Console.WriteLine(strNew);


            Console.ReadKey();
        }
    }
}
