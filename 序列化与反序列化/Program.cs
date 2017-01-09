using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace 序列化与反序列化
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Person p = new Person();
            //p.Name = "张三";
            ////开始序列化
            //using (FileStream fs = new FileStream(@"C:\Users\Jack\Desktop\object.txt", FileMode.OpenOrCreate, FileAccess.Write))
            //{
            //    BinaryFormatter bf = new BinaryFormatter();
            //    bf.Serialize(fs, p);
            //}
            //Console.WriteLine("序列化成功！");


            Person p = null;
            using (FileStream fs = new FileStream(@"C:\Users\Jack\Desktop\object.txt", FileMode.OpenOrCreate, FileAccess.Read))
            {
                BinaryFormatter bf = new BinaryFormatter();
                //需要将Object类型强转Person类型
                p = (Person)bf.Deserialize(fs);
                Console.WriteLine("反序列化成功！");
                Console.WriteLine(p.Name);
            }

            Console.ReadKey();

        }
    }
    //标识该类可被序列化
    [Serializable]
    public class Person 
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

    }

}
