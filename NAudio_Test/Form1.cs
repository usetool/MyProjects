using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NAudio.CoreAudioApi;
using System.Threading;
namespace NAudio_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            wi = new WaveIn(WaveCallbackInfo.FunctionCallback());//初始化WaveIn对象
            wi.DataAvailable += new EventHandler<WaveInEventArgs>(wi_DataAvailable);
            InitializeComponent();
            //第二步
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            //第三步
            CaptureDevices = enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active).ToArray();
            //MMDevice defaultDevice = enumerator.GetDefaultAudioEndpoint(DataFlow.Capture, Role.Console);
            //第四步
            selectedDevice = CaptureDevices.FirstOrDefault();
            //c => c.ID == defaultDevice.ID

        }
        public bool isNoPlay = true;

        public MMDevice selectedDevice;
        //第一步
        public IEnumerable<MMDevice> CaptureDevices { get; private set; }

        //录音用的事件
        //wi.DataAvailable += new EventHandler<WaveInEventArgs>(wi_DataAvailable);
        //wi = new WaveIn(WaveCallbackInfo.FunctionCallback());//初始化WaveIn对象
        WaveFileWriter wfw = null;
        WaveIn wi = null;
        /// <summary>
        /// 录音按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            wfw = new WaveFileWriter(@"test.wav", wi.WaveFormat);
            // Thread.SpinWait(100);
            Console.WriteLine("test");
            //从这开始影响的设备
            wi.StartRecording();
            this.Text = "开始录音";
        }


        /// <summary>
        /// 播放一个音频
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (isNoPlay)
            {
                Thread th = new Thread(PlaySound);
                th.IsBackground = true;
                th.Start();
                isNoPlay = false;
            }
        }

        private static void PlaySound()
        {
            using (var ms = File.OpenRead(@"E:\kugou\【数码宝贝】Butterfly-乐队Cover+被选中的八个女子.mp3"))
            using (var rdr = new Mp3FileReader(ms))
            using (var wavStream = WaveFormatConversionStream.CreatePcmStream(rdr))
            using (var baStream = new BlockAlignReductionStream(wavStream))
            using (var waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
            {
                waveOut.Init(baStream);
                waveOut.Play();
                while (waveOut.PlaybackState == PlaybackState.Playing)
                {
                    Thread.Sleep(10);
                }
            }
        }
        /// <summary>
        /// 停止录音
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {

            wi.StopRecording();//停止记录
            //  wi.Dispose();
            wfw.Close();//关闭记录器
            this.Text = "已经停止录音";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void wi_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (wfw == null)
            {
                wfw = new WaveFileWriter(@"test.wav", wi.WaveFormat);
            }
            wfw.Write(e.Buffer, 0, e.BytesRecorded);
            try
            {
                int num = (int)(selectedDevice.AudioMeterInformation.MasterPeakValue * 100);
                this.progressBar1.Value = num;
                Console.WriteLine("音量值：" + num);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File.Exists("test.wav"))
            {
                
            File.Delete("test.wav");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //UserControl1 ui = new UserControl1();
            //ui.Visibility = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        
    }
}
