using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using NAudio;
using NAudio.Wave;

namespace 汤姆猫
{
    public partial class Form1 : Form
    {
        static string rootAnimationsPath = "images/Animations";
        //全局线程类
        Thread th = null;
        //全局文件组
        FileInfo[] images;
        //判断-防止多线程同时进行冲突
        bool isGoNextAni = true;
        //判断是否可以播放音乐
        bool isGoNextMusic = true;
        //判断是否是第一次播放
        bool isFristPlayer = true;
        bool isRecord = false;
        /// <summary>
        /// 饥饿
        /// </summary>
        static DirectoryInfo angry = new DirectoryInfo(rootAnimationsPath + "/angry");

        /// <summary>
        /// 拍锣
        /// </summary>
        static DirectoryInfo cymbal = new DirectoryInfo(rootAnimationsPath + "/cymbal");

        /// <summary>
        /// 喝牛奶
        /// </summary>
        static DirectoryInfo drink = new DirectoryInfo(rootAnimationsPath + "/drink");

        /// <summary>
        /// 吃鸟
        /// </summary>
        static DirectoryInfo eat = new DirectoryInfo(rootAnimationsPath + "/eat");

        /// <summary>
        /// 受安慰
        /// </summary>
        static DirectoryInfo fart = new DirectoryInfo(rootAnimationsPath + "/fart");

        /// <summary>
        /// 抬左脚
        /// </summary>
        static DirectoryInfo foot_left = new DirectoryInfo(rootAnimationsPath + "/foot_left");

        /// <summary>
        /// 抬起右脚
        /// </summary>
        static DirectoryInfo foot_right = new DirectoryInfo(rootAnimationsPath + "/foot_right");

        /// <summary>
        /// 晕倒
        /// </summary>
        static DirectoryInfo knockout = new DirectoryInfo(rootAnimationsPath + "/knockout");

        /// <summary>
        /// 扔纸
        /// </summary>
        static DirectoryInfo pie = new DirectoryInfo(rootAnimationsPath + "/pie");

        /// <summary>
        /// 划屏幕
        /// </summary>
        static DirectoryInfo scratch = new DirectoryInfo(rootAnimationsPath + "/scratch");

        /// <summary>
        /// 抱肚子
        /// </summary>
        static DirectoryInfo stomach = new DirectoryInfo(rootAnimationsPath + "/stomach");

        /// <summary>
        /// 打哈欠
        /// </summary>
        static DirectoryInfo yawn = new DirectoryInfo(rootAnimationsPath + "/yawn");

        /// <summary>
        /// 眨眼
        /// </summary>
        static DirectoryInfo blink = new DirectoryInfo(rootAnimationsPath + "/blink");

        /// <summary>
        /// 打喷嚏
        /// </summary>
        static DirectoryInfo sneeze = new DirectoryInfo(rootAnimationsPath + "/sneeze");

        /// <summary>
        /// 开心-打呼
        /// </summary>
        static DirectoryInfo happy = new DirectoryInfo(rootAnimationsPath + "/happy");

        /// <summary>
        /// 聆听
        /// </summary>
        static DirectoryInfo listen = new DirectoryInfo(rootAnimationsPath + "/listen");

        /// <summary>
        /// talk
        /// </summary>
        static DirectoryInfo talk = new DirectoryInfo(rootAnimationsPath + "/talk");

        WaveFileWriter wfw = null;

        WaveIn wi = null;

        public Form1()
        {
            //录音用的事件
            wi = new WaveIn(WaveCallbackInfo.FunctionCallback());//初始化WaveIn对象
            wi.DataAvailable += new EventHandler<WaveInEventArgs>(wi_DataAvailable);

            //防止闪烁
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            InitializeComponent();
            this.BackgroundImage = Image.FromFile(rootAnimationsPath + "/now.jpg");
        }

        private void pb_pie_Click(object sender, EventArgs e)
        {
            if (!isGoNextMusic && !isFristPlayer)//不是第一次播放,判断是否可以播放
            {
                return;
            }
            images = pie.GetFiles();
            th = new Thread(ForeachAllFiles);
            //设置为后台线程（前台线程结束时，后台线程也结束）
            th.IsBackground = true;
            th.Start();
        }

        private void pb_drink_Click(object sender, EventArgs e)
        {
            if (!isGoNextMusic && !isFristPlayer)//不是第一次播放,判断是否可以播放
            {
                return;
            }
            isGoNextMusic = false;//禁止其他线程播放
            images = drink.GetFiles();
            this.axWindowsMediaPlayer1.URL = "";
            th = new Thread(ForeachAllFiles);
            //设置为后台线程（前台线程结束时，后台线程也结束）
            th.IsBackground = true;
            th.Start();
        }

        private void pb_eat_Click(object sender, EventArgs e)
        {
            if (!isGoNextMusic && !isFristPlayer)//不是第一次播放,判断是否可以播放
            {
                return;
            }

            isGoNextMusic = false;//禁止其他线程播放

            this.axWindowsMediaPlayer1.URL = "Sounds/p_eat.wav";
            images = eat.GetFiles();
            th = new Thread(ForeachAllFiles);
            //设置为后台线程（前台线程结束时，后台线程也结束）
            th.IsBackground = true;
            th.Start();
        }

        private void pb_fart_Click(object sender, EventArgs e)
        {
            if (!isGoNextMusic && !isFristPlayer)//不是第一次播放,判断是否可以播放
            {
                return;
            }
            isGoNextMusic = false;//禁止其他线程播放
            this.axWindowsMediaPlayer1.URL = "Sounds/fart001_11025.wav";
            images = fart.GetFiles();
            th = new Thread(ForeachAllFiles);
            //设置为后台线程（前台线程结束时，后台线程也结束）
            th.IsBackground = true;
            th.Start();
        }

        private void pb_scrath_Click(object sender, EventArgs e)
        {
            if (!isGoNextMusic && !isFristPlayer)//不是第一次播放,判断是否可以播放
            {
                return;
            }
            isGoNextMusic = false;//禁止其他线程播放
            //this.axWindowsMediaPlayer1.URL = "Sounds/scratch_kratzen.wav";
            images = scratch.GetFiles();
            th = new Thread(ForeachAllFiles);
            //设置为后台线程（前台线程结束时，后台线程也结束）
            th.IsBackground = true;
            th.Start();
        }

        private void pb_cym_Click(object sender, EventArgs e)
        {
            if (!isGoNextMusic && !isFristPlayer)//不是第一次播放,判断是否可以播放
            {
                return;
            }
            isGoNextMusic = false;//禁止其他线程播放
            //播放声音
            this.axWindowsMediaPlayer1.URL = "Sounds/cymbal.wav";
            images = cymbal.GetFiles();
            th = new Thread(ForeachAllFiles);
            //设置为后台线程（前台线程结束时，后台线程也结束）
            th.IsBackground = true;
            th.Start();
        }
        /// <summary>
        /// 遍历所有的文件
        /// </summary>
        /// <param name="images"></param>
        private void ForeachAllFiles()
        {
            isFristPlayer = false;//不是第一次播放了-放在这确保时效性
            //判断是否可以执行动画
            if (!isGoNextAni)
            {
                return;
            }
            isGoNextAni = false;//禁止其他线程执行动画
            int i = 0;
            foreach (FileInfo img in images)
            {
                this.BackgroundImage = Image.FromFile(img.FullName);
                Thread.Sleep(70);
                if (i == 21 && img.FullName.IndexOf("scratch") > -1)
                {//判断是划屏幕
                    this.axWindowsMediaPlayer1.URL = "Sounds/scratch_kratzen.wav";
                }
                if (i == 13 && img.FullName.IndexOf("pie") > -1)
                {//判断是扔球
                    this.axWindowsMediaPlayer1.URL = "Sounds/fall.wav";
                }
                if (i == 17 && img.FullName.IndexOf("drink") > -1)
                {//判断是倒牛奶
                    this.axWindowsMediaPlayer1.URL = "Sounds/pour_milk.wav";
                }
                if (i == 35 && img.FullName.IndexOf("drink") > -1)
                {//判断是喝牛奶
                    this.axWindowsMediaPlayer1.URL = "Sounds/p_drink_milk.wav";
                }
                if (i == 19 && img.FullName.IndexOf("knockout") > -1)
                {//判断是喝牛奶
                    this.axWindowsMediaPlayer1.URL = "Sounds/p_stars2s.wav";
                }
                i++;
                this.Update();
            }
            isGoNextAni = true;//动画播放状态切换
            isGoNextMusic = true;//切换音乐播放状态

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //开启跨线程
            Control.CheckForIllegalCrossThreadCalls = false;
            //文件检测
            if (!Directory.Exists("images") || !Directory.Exists("Sounds"))
            {
                MessageBox.Show("系统资源文件丢失！停止运行！", "发生错误");
                Application.Exit();
            }
            else if (!Directory.Exists("record"))
            {
                Directory.CreateDirectory("record");
            }

        }
        /// <summary>
        /// 左脚点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_foot_left_Click(object sender, EventArgs e)
        {
            if (!isGoNextMusic && !isFristPlayer)//不是第一次播放,判断是否可以播放
            {
                return;
            }
            isGoNextMusic = false;//禁止其他线程播放
            this.axWindowsMediaPlayer1.URL = "Sounds/p_foot4.wav";
            images = foot_left.GetFiles();
            th = new Thread(ForeachAllFiles);
            //设置为后台线程（前台线程结束时，后台线程也结束）
            th.IsBackground = true;
            th.Start();
        }
        /// <summary>
        /// 右脚点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_foot_right_Click(object sender, EventArgs e)
        {
            if (!isGoNextMusic && !isFristPlayer)//不是第一次播放,判断是否可以播放
            {
                return;
            }
            isGoNextMusic = false;//禁止其他线程播放
            this.axWindowsMediaPlayer1.URL = "Sounds/p_foot3.wav";
            images = foot_right.GetFiles();
            th = new Thread(ForeachAllFiles);
            //设置为后台线程（前台线程结束时，后台线程也结束）
            th.IsBackground = true;
            th.Start();
        }
        /// <summary>
        /// 脸被点击事件-击昏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_knockout_Click(object sender, EventArgs e)
        {
            if (!isGoNextMusic && !isFristPlayer)//不是第一次播放,判断是否可以播放
            {
                return;
            }
            isGoNextMusic = false;//禁止其他线程播放
            this.axWindowsMediaPlayer1.URL = "Sounds/slap4.wav";

            images = knockout.GetFiles();
            th = new Thread(ForeachAllFiles);
            //设置为后台线程（前台线程结束时，后台线程也结束）
            th.IsBackground = true;
            th.Start();
        }
        /// <summary>
        /// 肚子被点击事件-哎呦
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_stomach_Click(object sender, EventArgs e)
        {
            if (!isGoNextMusic && !isFristPlayer)//不是第一次播放,判断是否可以播放
            {
                return;
            }
            isGoNextMusic = false;//禁止其他线程播放
            this.axWindowsMediaPlayer1.URL = "Sounds/p_meuu.wav";
            images = stomach.GetFiles();
            th = new Thread(ForeachAllFiles);
            //设置为后台线程（前台线程结束时，后台线程也结束）
            th.IsBackground = true;
            th.Start();
        }
        /// <summary>
        /// 点击左边耳朵打哈欠
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_yawn_Click(object sender, EventArgs e)
        {
            if (!isGoNextMusic && !isFristPlayer)//不是第一次播放,判断是否可以播放
            {
                return;
            }
            isGoNextMusic = false;//禁止其他线程播放
            this.axWindowsMediaPlayer1.URL = "Sounds/p_yawn3_11a.wav";
            images = yawn.GetFiles();
            th = new Thread(ForeachAllFiles);
            //设置为后台线程（前台线程结束时，后台线程也结束）
            th.IsBackground = true;
            th.Start();
        }
        /// <summary>
        /// 使用timer控制的每隔4s眨眼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!isGoNextMusic && !isFristPlayer)//不是第一次播放,判断是否可以播放
            {
                return;
            }
            isGoNextMusic = false;//禁止其他线程播放
            images = blink.GetFiles();
            th = new Thread(ForeachAllFiles);
            //设置为后台线程（前台线程结束时，后台线程也结束）
            th.IsBackground = true;
            th.Start();
        }
        /// <summary>
        /// 眨眼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_eye_MouseEnter(object sender, EventArgs e)
        {
            if (!isGoNextMusic && !isFristPlayer)//不是第一次播放,判断是否可以播放
            {
                return;
            }
            isGoNextMusic = false;//禁止其他线程播放
            images = blink.GetFiles();
            th = new Thread(ForeachAllFiles);
            //设置为后台线程（前台线程结束时，后台线程也结束）
            th.IsBackground = true;
            th.Start();
        }
        /// <summary>
        /// 开心-打呼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_happy_Click(object sender, EventArgs e)
        {
            if (!isGoNextMusic && !isFristPlayer)//不是第一次播放,判断是否可以播放
            {
                return;
            }
            isGoNextMusic = false;//禁止其他线程播放
            this.axWindowsMediaPlayer1.URL = "Sounds/purr.wav";
            images = happy.GetFiles();
            th = new Thread(ForeachAllFiles);
            //设置为后台线程（前台线程结束时，后台线程也结束）
            th.IsBackground = true;
            th.Start();
        }
        /// <summary>
        /// 打喷嚏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_sneeze_Click(object sender, EventArgs e)
        {
            if (!isGoNextMusic && !isFristPlayer)//不是第一次播放,判断是否可以播放
            {
                return;
            }
            isGoNextMusic = false;//禁止其他线程播放
            this.axWindowsMediaPlayer1.URL = "Sounds/p_sneeze.wav";
            images = sneeze.GetFiles();
            th = new Thread(ForeachAllFiles);
            //设置为后台线程（前台线程结束时，后台线程也结束）
            th.IsBackground = true;
            th.Start();
        }
        /// <summary>
        /// 关于信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_about_Click(object sender, EventArgs e)
        {
            Frm_About about = new Frm_About();
            about.ShowDialog();
        }
        /// <summary>
        /// 聆听事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_listen_Click(object sender, EventArgs e)
        {
            isFristPlayer = false;//不是第一次播放了-放在这确保时效性
            if (!isGoNextMusic && !isFristPlayer)//不是第一次播放,判断是否可以播放
            {
                return;
            }
            isGoNextMusic = false;//禁止其他线程播放
            this.BackgroundImage = Image.FromFile(listen.GetFiles()[0].FullName);
            //开始录音
            wfw = new WaveFileWriter(@"record/temp.wav", wi.WaveFormat);

            wi.StartRecording();
            isRecord = true;
        }
        /// <summary>
        /// 快捷键绑定Ctrl+P
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P && e.Control)
            {
                //判断是否记录
                if (!isRecord)
                {
                    MessageBox.Show("还没有开始录音");
                    return;
                }
                isGoNextMusic = false;//禁止其他线程播放和动画
                isRecord = false;//没有记录
                //停止录音
                wi.StopRecording();//停止记录
                wfw.Close();//关闭记录器
                wfw.Dispose();
                //播放声音说话动画
                Thread th = new Thread(PlaySound);
                //设置为后台线程（前台线程结束时，后台线程也结束）
                th.IsBackground = true;
                th.Start();


            }
        }
        /// <summary>
        /// 播放声音
        /// </summary>
        private void PlaySound()
        {
            using (var ms = File.OpenRead("record/temp.wav"))
            using (var rdr = new WaveFileReader(ms))
            using (var wavStream = WaveFormatConversionStream.CreatePcmStream(rdr))
            using (var baStream = new BlockAlignReductionStream(wavStream))
            using (var waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
            {
                waveOut.Init(baStream);
                waveOut.Play();
                int i = 0;
                while (waveOut.PlaybackState == PlaybackState.Playing)
                {
                    Thread.Sleep(100);
                    //动画展示
                    images = talk.GetFiles();
                    if (i == images.Length-8)
                    {
                        i = 0;
                    }
                    this.BackgroundImage = Image.FromFile(images[i].FullName);
                    i++;
                }
            }
            isGoNextAni = true;
            isGoNextMusic = true;
        }
        /// <summary>
        /// 录音必须的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void wi_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (wfw == null)
            {
                wfw = new WaveFileWriter(@"record/temp.wav", wi.WaveFormat);
            }
            wfw.Write(e.Buffer, 0, e.BytesRecorded);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileRest();
        }

        private static void FileRest()
        {
            if (File.Exists("record/temp.wav"))
            {
                File.Delete("record/temp.wav");
            }
        }


    }
}
