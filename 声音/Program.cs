using System;
using System.Collections.Generic;
using System.Text;

namespace 声音
{
    class Program
    {
        static void Main(string[] args)
        {
            int re = 0;
            do
            {
                Console.WriteLine("请输入频率");
                re = Convert.ToInt32(Console.ReadLine());
                Console.Beep(27000, 10000);
                Console.WriteLine("播放结束");
            } while (re>0);
            Console.WriteLine("游戏结束");
            Console.ReadKey();
        }
    }
}
