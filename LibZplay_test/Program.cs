using System;
using System.Collections.Generic;
using System.Text;
using libZPlay;
namespace LibZplay_test
{
    class Program
    {
        static void Main(string[] args)
        {
            ZPlay play = new ZPlay();
            play.OpenFile(@"E:\kugou【数码宝贝】Butterfly-乐队Cover+被选中的八个女子.mp3", TStreamFormat.sfAutodetect);
            play.StartPlayback();
        }
    }
}
