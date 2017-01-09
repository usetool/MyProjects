using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parseXML
{
    /// <summary>
    /// 居委会类
    /// </summary>
    public class JuWei
    {
        private string name;
        private List<Lou> lous = new List<Lou>();




        /// <summary>
        /// 居委会所拥有的楼
        /// </summary>
        public List<Lou> Lous
        {
            get { return lous; }
            set { lous = value; }
        }
        
      
        /// <summary>
        /// 居委会名字
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
