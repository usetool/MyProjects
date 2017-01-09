using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NetDimension.NanUI;
namespace NetEaseMusic
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (HtmlUILauncher.InitializeChromium((args) =>
            {
                args.Settings.LogSeverity = Chromium.CfxLogSeverity.Verbose;
            }, settings =>
            {

            }))
            {
                HtmlUILauncher.RegisterEmbeddedScheme(System.Reflection.Assembly.GetExecutingAssembly());

                Application.Run(new Form1());
            }
        }
    }
}
