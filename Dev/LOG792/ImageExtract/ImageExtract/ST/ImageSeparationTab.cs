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
    public partial class ImageSeparationTab : UserControl
    {
        public ImageSeparationTab()
        {
            InitializeComponent();
            InitializeImageSeparationDataGrid();
            InitializeImageNamingDataGrid();
            AddSplitOnColumns();
        }




        public void InitializeImageSeparationDataGrid()
        {
            // Set image last column to width
            this.dgvImageSeparation.Columns[this.dgvcImage.Name].Width =
                this.dgvImageSeparation.Width - 20 -
                this.dgvImageSeparation.Columns[this.dgvcSide.Name].Width -
                this.dgvImageSeparation.Columns[this.dgvcRef.Name].Width -
                this.dgvImageSeparation.Columns[this.dgvcMPS.Name].Width -
                this.dgvImageSeparation.Columns[this.dgvcBSeq.Name].Width - 
                this.dgvImageSeparation.Columns[this.dgvcImageNaming.Name].Width;

            // CodeForScreenshots();            
        }



        public void CodeForScreenshots()
        {
            Image img = new Bitmap(TestConstants.ExampleImagePath);
            for (int i = 0; i < 50; i++)
            {
                this.dgvImageSeparation.Rows.Add(256001, (100 + i).ToString(), (i * 100).ToString(), (i % 2 == 0 ? "F" : "R"), null);
                ((DataGridViewImageCell)this.dgvImageSeparation.Rows[i].Cells[this.dgvcImage.Name]).Value = img;
            }
        }


        public void InitializeImageNamingDataGrid()
        {
            // dgvNamingTags

            dgvNamingTags.Rows.Add("Batch Seq", "Capture Date", "Capture Site");
            dgvNamingTags.Rows.Add("Client Batch Ref", "Custom Batch Number", "Image Side");
            dgvNamingTags.Rows.Add("Item Ref", "Matched Payment Seq", "Statement ID");

            this.dgvNamingTags.BorderStyle = BorderStyle.None;

            if (dgvNamingTags.RowCount > 0 && dgvNamingTags.ColumnCount > 0)
            {
                dgvNamingTags.CurrentCell = this.dgvNamingTags[0, 0];
                this.dgvNamingTags.CurrentCell.Selected = false;
            } 
        }


        public void AddSplitOnColumns()
        {
            dgvSplitOn.Rows.Add("Batch", "");
            dgvSplitOn.Rows.Add("Capture Date", "");
            dgvSplitOn.Rows.Add("Capture Site", "");
            dgvSplitOn.Rows.Add("Every image", "");
            dgvSplitOn.Rows.Add("Image Side", "");
            dgvSplitOn.Rows.Add("Item", "");
            dgvSplitOn.Rows.Add("Item Type (stub/pay)", "");
            dgvSplitOn.Rows.Add("Statement ID", "");
            dgvSplitOn.Rows.Add("Transaction", "");

            if (dgvSplitOn.RowCount > 0 && dgvSplitOn.ColumnCount > 0)
            {
                dgvSplitOn.CurrentCell = this.dgvSplitOn[0, 0];
                this.dgvSplitOn.CurrentCell.Selected = false;
            } 
        }





        public void RefreshPreviewGrid()
        {
            //observableBatchList.NotifyObservers(VariablesSingleton.GetInstance().PreviewBatches);
        }




        #region events
        private void dgvImageSeparation_Paint(object sender, PaintEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // Important: changing font color requires dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = (dgv.Enabled ? Color.Black : Color.Gray);
            foreach (DataGridViewRow dgvr in dgv.Rows) dgvr.Visible = dgv.Enabled;
        }
        #endregion

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvSplitBy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }



    }
}
