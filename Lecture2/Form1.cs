using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;


namespace Lecture2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        Mat img = new Mat();

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.RestoreDirectory = true;
            file.CheckFileExists = false;
            if (file.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = file.FileName;
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            //read image
            img = Cv2.ImRead(textBox1.Text);
            //Show image on PictureBox
            pictureBox1.Image = img.ToBitmap();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void btnCvt_Click(object sender, EventArgs e)
        {
            Mat img_gray = new Mat();
            Cv2.CvtColor(img, img_gray, ColorConversionCodes.BGR2GRAY);
            pictureBox2.Image = img_gray.ToBitmap();
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
        }

        Mat[] RGB = new Mat[3];

        private void btnSplit_Click(object sender, EventArgs e)
        {
            
            RGB = Cv2.Split(img);
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton3.Enabled = true;
            radioButton4.Enabled = true;
            pictureBox2.Image = img.ToBitmap();
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            MessageBox.Show("Split Successful");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox2.Image = RGB[0].ToBitmap();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox2.Image = RGB[1].ToBitmap();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox2.Image = RGB[2].ToBitmap();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox2.Image = img.ToBitmap();
        }

        private void btnSobel_Click(object sender, EventArgs e)
        {
            Mat img_graySobel = new Mat();
            Cv2.CvtColor(img, img_graySobel, ColorConversionCodes.BGR2GRAY);
            Mat img_Sobel = new Mat();
            Cv2.Sobel(img_graySobel, img_Sobel, -1, 1, 0);
            pictureBox2.Image = img_Sobel.ToBitmap();
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void btnGauss_Click(object sender, EventArgs e)
        {
            Mat img_grayGauss = new Mat();
            Cv2.CvtColor(img, img_grayGauss, ColorConversionCodes.BGR2GRAY);
            Mat img_Gauss = new Mat();
            Cv2.GaussianBlur(img_grayGauss, img_Gauss, new OpenCvSharp.Size(3, 3), 1);
            pictureBox2.Image = img_Gauss.ToBitmap();
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
        }

        float gamma = 0;

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
        //    label1.Text = trackBar1.Value.ToString();
        //    float value1 = 0.4f;

        }
    }
}
