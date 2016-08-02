using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ImageExtract.ObserverPattern;

namespace ImageExtract.ST
{
    public partial class ImageSeparationTab : UserControl
    {
        private ListOfBatchesObserver observerBatchList;

        public ImageSeparationTab()
        {
            InitializeComponent();
            InitializeImageSeparationDataGrid();
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

            observerBatchList = new ListOfBatchesObserver("Batches shown in Image Separation Tab");
            observerBatchList.dgv = this.dgvImageSeparation;
            observerBatchList.dgType = ListOfBatchesObserver.DataGridType.Separation;
            VariablesSingleton.GetInstance().observableBatchList.Subscribe(observerBatchList);

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


        public void AddSplitOnColumns()
        {
            dgvSplitOn.Rows.Add("Batch", false, "$BATCH_SEQ$");
            dgvSplitOn.Rows.Add("Capture Date", false, "$CAPTURE_DATE$");
            dgvSplitOn.Rows.Add("Capture Site", false, "$CAPTURE_SITE$");
            dgvSplitOn.Rows.Add("Image Side", false, "$IMAGE_SIDE$");
            dgvSplitOn.Rows.Add("Item", false, "$ITEM_REF$");
            dgvSplitOn.Rows.Add("Item Type (stub/pay)", false, "$ITEM_TYPE$");
            dgvSplitOn.Rows.Add("Statement ID", false, "$STATEMENT_ID$");
            dgvSplitOn.Rows.Add("Transaction", false, "$MATCHED_PAYMENT_SEQ$");

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

        private void btnRefreshFilenames_Click(object sender, EventArgs e)
        {
            observerBatchList.imageNaming = this.tbNamingPattern.Text;
            VariablesSingleton.GetInstance().observableBatchList.NotifyObservers(VariablesSingleton.GetInstance().PreviewBatches);

            this.dgvSplitOn.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSplitOn_CellValueChanged);
            foreach (DataGridViewRow dgvr in this.dgvSplitOn.Rows)
            {
                dgvr.Cells[dgvcSplitUse.Index].Value = this.tbNamingPattern.Text.Contains(dgvr.Cells[HiddenString.Index].Value.ToString());
            }
            this.dgvSplitOn.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSplitOn_CellValueChanged);
        }

        private void dgvSplitOn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvSplitOn_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            // if the cell clicked is the "Use" column of the search DataGridView, we will call dgvSearchResults_CellValueChanged
            if (e.ColumnIndex == this.dgvcSplitUse.Index && e.RowIndex != -1) this.dgvSplitOn.EndEdit();
        }





        private void dgvSplitOn_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvr;

            if (e.RowIndex > -1)
            {
                dgvr = this.dgvSplitOn.Rows[e.RowIndex];
                if ((bool)dgvr.Cells[dgvcSplitUse.Index].Value)
                {
                    this.tbNamingPattern.Text = this.tbNamingPattern.Text + dgvr.Cells[HiddenString.Index].Value.ToString();
                }
                else
                {
                    this.tbNamingPattern.Text = this.tbNamingPattern.Text.Replace(dgvr.Cells[HiddenString.Index].Value.ToString(), "");
                }
            }
            

        }






    }
}
