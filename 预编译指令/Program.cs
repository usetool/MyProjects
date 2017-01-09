using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
namespace 预编译指令
{
    class Program
    {
        static void Main(string[] args)
        {
            int a=0;
         //   test(a);


            //while (true)
            //{
            //    Console.WriteLine("请选择参数[1.生成100万随机数]");
            //    string sele = Console.ReadLine();
            //    switch (sele)
            //    {
            //        case "1":
            //            Get10000Nums("nums.txt");
            //            break;
            //    }
            //}
            Console.ReadKey();
        }
        /// <summary>
        /// 获取1万个0和1
        /// </summary>
        private static void Get10000Nums(string filename)
        {
            DateTime start = DateTime.Now;
            Random random = new Random();
            StreamWriter writer = new StreamWriter(filename);
            //获取0或1随机1000个数
            for (int i = 0; i < 1000000; i++)
            {

                if (i % 8 == 0)
                {
                    Console.WriteLine();
                    writer.WriteLine();
                }

                int x = random.Next(0, 2);
                writer.Write(x);
                Console.Write(x);
            }
            writer.Close();
            DateTime end = DateTime.Now;
            Console.WriteLine();
            Console.WriteLine(end - start);
        }
        public static void test(ref int s) { }
    }
}
