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
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            Image savedImage;

            imgSampleImage = Image.FromFile(tbSampleImagePath.Text);

            // TODO transformations

            pbResult.Image = imgSampleImage;


            /*
            MessageBox.Show(Path.GetDirectoryName(tbSampleImagePath.Text));
            */

            string firstText = "Hello";
            string secondText = "World";

            PointF firstLocation = new PointF(10f, 10f);
            PointF secondLocation = new PointF(10f, 50f);

            string imageFilePath = Path.GetDirectoryName(tbSampleImagePath.Text) + @"\" +
                tbBatchSeq.Text + "_" + tbItemRef.Text + "_" + tbImageSide.Text + ".tif";
            Bitmap bitmap = (Bitmap)imgSampleImage;//load the image file

            using(Graphics graphics = Graphics.FromImage(bitmap))
            {
                using (Font arialFont =  new Font("Arial", 10))
                {
                    graphics.DrawString(firstText, arialFont, Brushes.Blue, firstLocation);
                    graphics.DrawString(secondText, arialFont, Brushes.Red, secondLocation);
                }
            }

            bitmap.Save(imageFilePath,  System.Drawing.Imaging.ImageFormat.Tiff);

            MessageBox.Show("Complete.");
        }
    }
}
