using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageExtract.ST
{
    public partial class OtherOptionsTab : UserControl
    {
        public OtherOptionsTab()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Once this Image Extract configuration is actived, Image Extracts will start being automatically generated for this client." +
                    "\r\n\r\nWould you like to continue?",
                "Activate this configuration?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            MessageBox.Show(
                "Once this Image Extract configuration is disactived, Image Extracts will no longer be automatically generated for this client." +
                    "\r\n\r\nWould you like to continue?",
                "Disactivate this configuration?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }
    }
}
