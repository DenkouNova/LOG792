using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace ImageExtract
{
    public partial class TestImageGenerator : Form
    {
        Image imgSampleImage;

        public TestImageGenerator()
        {
            InitializeComponent();

            this.tbSampleImageFolderPath.Text = @"J:\LOG792\Images";
            // this.tbSampleImagePath.Text = @"D:\Cossins\Documents\ETS\LOG792\Images";
            this.tbSampleImageName.Text = "cheque";
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            Image savedImage;

            string fullImagePath = tbSampleImageFolderPath.Text + @"\" + tbSampleImageName.Text + ".jpg";

            imgSampleImage = Image.FromFile(fullImagePath);

            pbResult.Image = imgSampleImage;

            string firstText = this.tbStatementID.Text + " " + this.tbBatchSeq.Text;
            string secondText = tbMatchedPaymentSeq.Text + " " + this.tbItemRef.Text + " " + 
                (this.tbImageSide.Text == "F" ? "Front" : "Rear") +
                (this.cbNFD.Checked ? " (NFD)" : "");

            PointF firstLocation = new PointF(50f, 50f);
            PointF secondLocation = new PointF(50f, 130f);

            string imageFilePath = tbSampleImageFolderPath.Text + @"\" +
                tbBatchSeq.Text + "_" + tbItemRef.Text + "_" + tbImageSide.Text + ".tif";
            Bitmap bitmap = (Bitmap)imgSampleImage;//load the image file

            using(Graphics graphics = Graphics.FromImage(bitmap))
            {
                using (Font arialFont =  new Font("Arial", 60, FontStyle.Bold))
                {
                    graphics.DrawString(firstText, arialFont, Brushes.Black, firstLocation);
                    graphics.DrawString(secondText, arialFont, Brushes.Black, secondLocation);
                }
            }

            bitmap.Save(imageFilePath,  System.Drawing.Imaging.ImageFormat.Tiff);

            MessageBox.Show("Complete.");
        }
    }
}
