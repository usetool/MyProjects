using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parseXML
{
    /// <summary>
    /// 街道类
    /// </summary>
    public class Street
    {
        private string name;
        private List<JuWei> juWeis = new List<JuWei>();
        /// <summary>
        /// 所拥有的居委
        /// </summary>
        public List<JuWei> JuWeis
        {
            get { return juWeis; }
            set { juWeis = value; }
        }

        /// <summary>
        /// 街道名字
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
