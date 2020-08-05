using Accord.Video.FFMPEG;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisioForge.Shared.MediaFoundation.OPM;

namespace ScreenRecorder
{
    public partial class Form1 : Form
    {
        VideoFileWriter videoFileWriter;
        Bitmap img;
        Graphics graphics;
        string filename = "";
        string path = "H://Capture/";
        
       
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            path += filename + ".mp4";
            videoFileWriter = new VideoFileWriter();
            videoFileWriter.Open(path, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, 10,VideoCodec.Default,1000000);
            timer1.Start();
          

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            videoFileWriter.Close();
        }

        private void textOutputName_TextChanged(object sender, EventArgs e)
        {
            filename = textOutputName.Text;
        }

      

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Timer timer1 = new Timer();
            timer1.Interval = 10;
            timer1.Tick += timer1_Tick;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            img = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            graphics = Graphics.FromImage(img);
            graphics.CopyFromScreen(0, 0, 0, 0,img.Size);
            pictureBox1.Image = img;

            videoFileWriter.WriteVideoFrame(img);
        }
    }
}
