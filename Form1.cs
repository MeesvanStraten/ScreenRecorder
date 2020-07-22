using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisioForge.Types.OutputFormat;

namespace ScreenRecorder
{
    public partial class Form1 : Form
    {
        private String fileName = "DefaultName";
        private bool recordSound = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            videoCapture1.Screen_Capture_Source = new VisioForge.Types.Sources.ScreenCaptureSourceSettings() { FullScreen = true };
            videoCapture1.Audio_PlayAudio = videoCapture1.Audio_RecordAudio = false;
            videoCapture1.Output_Format = new VFMP4v8v10Output();
            videoCapture1.Output_Filename = Environment.GetFolderPath( Environment.SpecialFolder.MyVideos) +"\\"+fileName + ".mp4";
            videoCapture1.Mode = VisioForge.Types.VFVideoCaptureMode.ScreenCapture;

            videoCapture1.Start();

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            videoCapture1.Stop();
            fileName = "DefaultName";
        }

        private void textOutputName_TextChanged(object sender, EventArgs e)
        {
            fileName = textOutputName.Text;
        }

      

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState.Equals(true))
            {
                recordSound = true;
                Console.WriteLine(recordSound);
            }
            else
            {
                recordSound = false;
                Console.WriteLine(recordSound);

            }

        }
    }
}
