using System;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Collections.Generic;

namespace desj
{
    class Program
    {
        static void Main(string[] args)
        {
            Operate op = new Operate();
            op.ShowMenu();
        }
    }
}
