using System;
using System.Collections.Generic;
using System.Text;

namespace 飞行棋
{
    /// <summary>
    /// 未修正，还有bug  2015-7-23 8：27 玩家B胜利未提示
    /// </summary>
    class Program
    {
        static int[] playFlag={0,0};//玩家是否暂停的标记
        static int[] player = new int[2];//[0]代表玩家A  [1]代表玩家B
        static int[] maps = new int[100];//地图
        static bool aWin;//玩家A胜利
        static bool bWin;//玩家B胜利
        static string[] playerName = new string[2];//两个玩家的名字
        static int[] playerPos = new int[2];//两个玩家的坐标
        static int playId;
        static void Main(string[] args)
        {
            ShowGameHead();
            InputName();
            InitialMap();
            PalyGame();
            if (aWin)
            {
                Console.WriteLine("玩家{0}胜利！！", playerName[0]);
            }
            else if (bWin)
            {
                Console.WriteLine("玩家{0}胜利！！", playerName[1]);
            }
            Console.ReadKey();
        }
        /// <summary>
        /// 游戏调用主方法
        /// </summary>
        public static void PalyGame()
        {
            do
            {
                if (playFlag[0]==0)
                {
                    DrawMap();
                    Run(0);
                    Console.Clear();
                }
                else
                {
                    playFlag[0] = 0;
                }
                if (playerPos[0]>=99)
                {
                    Console.WriteLine("玩家 {0} 无耻的赢了",playerName[0]);
                    break;
                }
                if (playFlag[1]==0)
                {
                    DrawMap();
                    Run(1);
                    Console.Clear();
                }
                else
                {
                    playFlag[1] = 0;
                }
                if (playerPos[1]>=99)
                {
                    Console.WriteLine("玩家 {0} 无耻的赢了", playerName[1]);
                    break;
                }
               

            } while (playerPos[playId] >= 0 && playerPos[playId] < 99);
        }
        /// <summary>
        /// 玩家的动作
        /// </summary>
        public static void Run(int playid)
        {
            playId = playid;
            Console.WriteLine("玩家 {0} 按任意键开始掷骰子", playerName[playid]);
            Console.ReadKey(true);
            Random ran = new Random();
            int dianShu = ran.Next(1,7);//这里是骰子点数
            playerPos[playid] += dianShu;
            Console.WriteLine("玩家 {0} 掷出了{1} 点", playerName[playid], dianShu);
            Console.ReadKey(true);
            Console.WriteLine("玩家 {0} 按任意键开始行动", playerName[playid]);
            Console.ReadKey(true);
            //对关卡进行判断
            if (playerPos[playid] == playerPos[1 - playid])
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("玩家 {0} 踩到了玩家 {1} ", playerName[playid], playerName[1 - playid]);
                playerPos[1 - playid] = 0;
                Console.WriteLine("对方回到了原点");
            }
            else
            {
                if (playerPos[playid] > 99)
                {
                    Console.WriteLine("玩家{0}到达了终点！", playerName[playid]);
                    playerPos[playid] = 99;
                    if (playid == 0)
                    {
                        aWin = true;
                    }
                    else if(playid==1)
                    {
                        bWin = true;
                    }
                }
                //遇到的关卡事件
                switch (maps[playerPos[playid]])
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("玩家 {0} 踩到了方块，什么都没有发生！", playerName[playid]);
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("玩家 {0} 踩到了幸运轮盘  选择： 1交换位置  2 轰炸对方 (使对方退6格)", playerName[playid]);
                        bool isgo = false;
                        do
                        {
                            string result = Console.ReadLine();
                            switch (result)
                            {
                                case "1":
                                    int temp = playerPos[playid];
                                    playerPos[playid] = playerPos[1 - playid];
                                    playerPos[1 - playid] = temp;
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("交换位置成功！");
                                    Console.ReadKey(true);
                                    //break;
                                    return;
                                case "2":
                                    PlayerMinusSix(ref playerPos, 1 - playid, 6);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("使对方退了6格！");
                                    Console.ReadKey(true);
                                    //break;
                                    return;
                                default:
                                    Console.WriteLine("输入错误！请重新输入！");
                                    isgo = true;
                                    break;
                            }
                        } while (isgo);
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("玩家 {0} 踩到了地雷 退6格", playerName[playid]);
                        PlayerMinusSix(ref playerPos, playid, 6);
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("玩家 {0} 踩到了暂停，暂停一回合", playerName[playid]);
                        //暂停一回合
                        playFlag[playid] = 1;
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("玩家 {0} 踩到了时空隧道，前进6格", playerName[playid]);
                        PlayerAddSix(ref playerPos, playid, 6);
                        break;
                    default:
                        Console.WriteLine("进这来了！！！");
                        break;
                }
            }
            Console.ReadKey(true);
            Console.WriteLine("=============");
            //执行刷新坐标
        }
        /// <summary>
        /// 输入玩家姓名
        /// </summary>
        static void InputName()
        {
            Console.WriteLine("请输入玩家A的姓名");
            playerName[0] = Console.ReadLine();
            while (playerName[0] == "")
            {
                Console.WriteLine("玩家A的姓名不能为空");
                playerName[0] = Console.ReadLine();
            }
            Console.WriteLine("请输入玩家B的姓名");
            playerName[1] = Console.ReadLine();
            while (playerName[1] == "" || playerName[1] == playerName[0])
            {
                if (playerName[1] == playerName[0])
                {
                    Console.WriteLine("玩家B的姓名不能和玩家A的姓名相同");
                }
                if (playerName[1] == "")
                {
                    Console.WriteLine("玩家B的名字不能为空");
                }
                playerName[1] = Console.ReadLine();
            }
        }
        /// <summary>
        /// 画游戏头
        /// </summary>
        public static void ShowGameHead()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("***********************");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("***********************");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("***********************");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("***     飞行棋      ***");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("***********************");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("***   ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(".");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("太后专用版");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(".");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("  ***");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("***********************");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        }

        /// <summary>
        /// 初始化地图
        /// </summary>
        public static void InitialMap()
        {
            //0代表方块 1代表幸运转盘  2代表地雷  3代表暂停一回合  4代表时空隧道
            //我用0表示普通,显示给用户就是 □
            //....1...幸运轮盘,显示组用户就◎ 
            //....2...地雷,显示给用户就是 ☆
            //....3...暂停,显示给用户就是 ▲
            //....4...时空隧道,显示组用户就 卐

            int[] luckyturn = { 6, 23, 40, 55, 69, 83 };//幸运轮盘◎
            //载入幸运转盘的坐标
            for (int i = 0; i < luckyturn.Length; i++)
            {
                int index = luckyturn[i];
                maps[index] = 1;
            }

            int[] landMine = { 5, 13, 17, 33, 38, 50, 64, 80, 94 };//地雷☆
            //载入地雷的坐标
            for (int i = 0; i < landMine.Length; i++)
            {
                int index = landMine[i];
                maps[index] = 2;
            }

            int[] pause = { 9, 27, 60, 93 };//暂停▲
            //载入暂停的坐标
            for (int i = 0; i < pause.Length; i++)
            {
                int index = pause[i];
                maps[index] = 3;
            }
            int[] timeTunnel = { 20, 25, 45, 63, 72, 88, 90 };//时空隧道卐
            //载入时空隧道的坐标
            for (int i = 0; i < timeTunnel.Length; i++)
            {
                int index = timeTunnel[i];
                maps[index] = 4;
            }
        }

        /// <summary>
        /// 画游戏地图
        /// </summary>
        public static void DrawMap()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("图例:幸运轮盘:◎   地雷:☆   暂停:▲   时空隧道:卐");
            #region 画地图第一行
            for (int i = 0; i < 30; i++)
            {
                Console.Write(ReturnMapChar(i));
            }
            Console.WriteLine();
            #endregion
            #region 画地图竖行
            for (int i = 30; i < 35; i++)
            {
                for (int j = 0; j < 29; j++)
                {
                    Console.Write("  ");
                }
                Console.Write(ReturnMapChar(i));
                Console.WriteLine();
            }
            #endregion
            #region 画地图第三行
            for (int i = 64; i >= 35; i--)
            {
                Console.Write(ReturnMapChar(i));
            }
            Console.WriteLine();
            #endregion
            #region 第四 竖行
            for (int i = 65; i <= 69; i++)
            {
                Console.WriteLine(ReturnMapChar(i));
            }
            #endregion
            #region 最后一行
            for (int i = 70; i < 100; i++)
            {
                Console.Write(ReturnMapChar(i));
            }
            Console.WriteLine();
            #endregion
        }

        /// <summary>
        /// 根据地图坐标返回关卡
        /// </summary>
        /// <param name="i">坐标</param>
        /// <returns>关卡的字符</returns>
        public static string ReturnMapChar(int i)
        {
            string str = "";
            if (playerPos[0] == playerPos[1] && playerPos[0] == i)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                str = "<>";
            }
            else if (playerPos[0] == i)
            {
                Console.ForegroundColor = ConsoleColor.White;
                str = "Ａ";
            }
            else if (playerPos[1] == i)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                str = "Ｂ";
            }
            else
            {
                switch (maps[i])
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        str = "□";
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        str = "◎";
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Red;
                        str = "☆";
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        str = "▲";
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Green;
                        str = "卐";
                        break;
                    default:
                        break;
                }
            }
            return str;
        }
        /// <summary>
        /// 玩家的坐标加点数
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="playerId"></param>
        public static void PlayerAddSix(ref int[] pos, int playerId, int dianShu)
        {
            if (pos[playerId] >= 0 && pos[playerId] + dianShu < 99)
            {
                pos[playerId] += dianShu;
            }
        }
        /// <summary>
        /// 玩家的坐标减点数
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="playerId"></param>
        public static void PlayerMinusSix(ref int[] pos, int playerId, int dianShu)
        {
            if (pos[playerId] != 99 && pos[playerId] - dianShu > 0)
            {
                pos[playerId] -= dianShu;
            }
            else
            {
                pos[playerId] = 0;
            }
        }
    }
}

