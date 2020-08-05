﻿using Accord.Video.FFMPEG;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisioForge.Shared.MediaFoundation.OPM;

namespace ScreenRecorder
{
    public partial class Screen : Form
    {
        VideoFileWriter videoFileWriter;
        Bitmap img;
        Graphics graphics;
        string filename = "";
        string path = "H://Capture/";
        string saveFileDir = "";

        //FOR TESTING ONLY
        string selectedfolder = "";
       
        public Screen()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Old fileDIR without picking path
            //saveFileDir = path + filename + ".mp4";

            saveFileDir = selectedfolder + "/" + filename + ".mp4";
            if (fileExists(saveFileDir))
            {
                MessageBox.Show("Filename already exists!, Choose a diffrent name");
            }
            else
            {
                 videoFileWriter = new VideoFileWriter();
                videoFileWriter.Open(saveFileDir, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height, 10, VideoCodec.Default, 1000000);
                 timer1.Start();
            }
            
          

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
            img = new Bitmap(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height);
            graphics = Graphics.FromImage(img);
            graphics.CopyFromScreen(0, 0, 0, 0,img.Size);
            pictureBox1.Image = img;

            videoFileWriter.WriteVideoFrame(img);
        }

        public bool fileExists(string file)
        {
            if (File.Exists(file))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnFolderPicker_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            //fbd.Description = "Custom Description"; //not mandatory

            if (fbd.ShowDialog() == DialogResult.OK)
                selectedfolder = fbd.SelectedPath;
            else
                selectedfolder = string.Empty;

            MessageBox.Show(selectedfolder.ToString());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
