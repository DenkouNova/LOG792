using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageExtract
{
    public partial class LoadExampleImages : Form
    {
        public LoadExampleImages()
        {
            InitializeComponent();
        }

        private void dgvBatches_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddSelection_Click(object sender, EventArgs e)
        {
            this.dgvSearchResults.Rows.Add(1319, "20160704", 256800, "Singles", true);
            this.dgvSearchResults.Rows.Add(1319, "20160704", 256801, "Multis", true);
            this.dgvSearchResults.Rows.Add(1319, "20160705", 256823, "Multis", true);

            this.dataLoadInInterface.Rows.Add(1319, "20160704", 256801, "Multis", true);

            /*
            // Test code for screenshots
            for (int i = 0; i < 50; i++)
            {
                this.dgvImageInclusion.Rows.Add(256001, (100 + i).ToString(), (i * 100).ToString(), (i % 2 == 0 ? "F" : "R"), null);
                ((DataGridViewImageCell)this.dgvImageInclusion.Rows[i].Cells[this.dgvcImageInclusionImage.Name]).Value = img;
            }*/
        }
    }
}
