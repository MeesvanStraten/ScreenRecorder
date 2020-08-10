using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xabe.FFmpeg;


namespace ScreenRecorder
{
    public partial class Screen : Form
    {
        Stopwatch stopwatch = new Stopwatch();
        Bitmap img;
        Bitmap imgOld;
        Graphics graphics;
        string filename = "";
        string saveFileDir = "";
        

        //FOR TESTING ONLY
        string selectedfolder = "";


        public Screen()
        {
            InitializeComponent();

        }

        void testRec()
        {
           

           
        }

        

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Old fileDIR without picking path
            //saveFileDir = path + filename + ".mp4";

            if (selectedfolder.Equals(""))
            {
                selectedfolder = "H://Capture";
                saveFileDir = selectedfolder + "/" + filename + ".mp4";
            }
            else
            {
                saveFileDir = selectedfolder + "/" + filename + ".mp4";
            }

            if (fileExists(saveFileDir))
            {
                MessageBox.Show("Filename already exists!, Choose a diffrent name");
            }
            else
            {
                stopwatch.Start();
                timer1.Start();
            }
            
          

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            stopwatch.Stop();
            stopwatch.Reset();
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
        private void setButtonStyle()
        {
            var c = from controls in Controls.OfType<Button>()
                    select controls;
            foreach (var control in c)
            {
                control.FlatStyle = FlatStyle.Flat;
                control.BackColor = Color.Red;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Newrecordvideo();
            /* img = new Bitmap(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height);
             imgOld = img;
             graphics = Graphics.FromImage(imgOld);
             graphics.CopyFromScreen(0, 0, 0, 0,imgOld.Size);
             pictureBox1.Image = imgOld;

             lblTime.Text = stopwatch.Elapsed.ToString();

             videoFileWriter.WriteVideoFrame(imgOld);
            */
            //memory fix from here

            

            

        }

        void Newrecordvideo()
        {
            using (Bitmap bitmap = new Bitmap(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    //Add screen to bitmap:
                    g.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
                }
                //Save screenshot:
                //Dispose of bitmap:
                bitmap.Dispose();
            }
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
            fbd.Description = "Select folder to save video";

            if (fbd.ShowDialog() == DialogResult.OK)
                selectedfolder = fbd.SelectedPath;
            else
                selectedfolder = string.Empty;

            MessageBox.Show(selectedfolder.ToString());
        }
    }
}
