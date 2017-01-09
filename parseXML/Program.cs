using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace parseXML
{
    class Program
    {
        public static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Address.xml");




            //获取根节点，也就是街道
            XmlElement root=doc.DocumentElement;
            Street street = new Street();
            //设置街道的名字
            street.Name=root.GetAttribute("name");
            //获取街道下面的居委会
            XmlNodeList list =root.ChildNodes;
            Console.WriteLine(street.Name);
            foreach (XmlNode item in list)
            {
                JuWei juwei = new JuWei();
                //设置居委会的名字
                juwei.Name = item.Attributes["name"].Value;
                Console.WriteLine("\t" + juwei.Name);
                foreach (XmlNode louItem in item.ChildNodes)
                {
                   
                    Lou lou = new Lou();
                    lou.Name = louItem.Attributes["name"].Value;
                    lou.Simd =Convert.ToInt32( louItem.Attributes["smid"].Value);
                    Console.WriteLine("\t\t" + lou.Name);
                    //设置楼下面的room
                    foreach (XmlNode roomItem in louItem)
                    {
                        lou.Rooms.Add(roomItem.InnerText);
                        Console.WriteLine("\t\t\t"+roomItem.InnerText);
                    }
                    //将楼添加到居委会
                    juwei.Lous.Add(lou);
                }
            }
            
          

            Console.ReadKey();
              
        }
    }
}
