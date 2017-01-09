using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parseXML
{
    /// <summary>
    /// 楼类
    /// </summary>
    public class Lou
    {
        private int simd;
        private string name;
        private List<String> rooms = new List<string>();
        /// <summary>
        /// 楼的所有的房间
        /// </summary>
        public List<String> Rooms
        {
            get { return rooms; }
            set { rooms = value; }
        }
        /// <summary>
        /// 楼的名字
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// 楼的编号
        /// </summary>
        public int Simd
        {
            get { return simd; }
            set { simd = value; }
        }
    }
}
