using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace 乐智知识库
{
    class XMLHelper
    {
       /// <summary>
        /// 保存xml文档
       /// </summary>
       /// <param name="path">路径及文件名</param>
       /// <param name="xmlDoc">要保存根节点对象</param>
        public static void CreateXmlFile( XmlDocument xmlDoc,string path,XmlNode rootNode)
        {
            //创建类型声明节点  
            XmlNode node = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "");
            try
            {
                xmlDoc.AppendChild(node);
            }
            catch (Exception)
            {
                
            }
            xmlDoc.AppendChild(rootNode);
            try
            {
                xmlDoc.Save(path);
            }
            catch (Exception e)
            {
                //显示错误信息  
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>    
        /// 创建节点    
        /// </summary>    
        /// <param name="xmldoc"></param>  xml文档  
        /// <param name="parentnode"></param>父节点    
        /// <param name="name"></param>  节点名  
        /// <param name="value"></param>  节点值  
        ///   
        public static void CreateNode(XmlDocument xmlDoc, XmlNode parentNode, string name, string value)
        {
            XmlNode node = xmlDoc.CreateNode(XmlNodeType.Element, name, null);
            node.InnerText = value;
            parentNode.AppendChild(node);
        }
    }
}
