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
    public partial class ImageArchivingTab : UserControl
    {
        public ImageArchivingTab()
        {
            InitializeComponent();
            InitializeImageArchivingDataGrid();
            InitializeArchiveNamingDataGrid();
            AddRegroupByColumns();
        }




        public void InitializeImageArchivingDataGrid()
        {
            Image img = new Bitmap(@"D:\Cossins\Documents\ETS\LOG792\Images\cheque.tif");

            // Set image last column to width
            this.dgvImageSeparation.Columns[this.dgvcImageInclusionImage.Name].Width =
                this.dgvImageSeparation.Width - 20 -
                this.dgvImageSeparation.Columns[this.dgvcImageInclusionSide.Name].Width -
                this.dgvImageSeparation.Columns[this.dgvcImageInclusionIRef.Name].Width -
                this.dgvImageSeparation.Columns[this.dgvcImageInclusionMPS.Name].Width -
                this.dgvImageSeparation.Columns[this.dgvcImageInclusionBSeq.Name].Width;


            for (int i = 0; i < 50; i++)
            {
                this.dgvImageSeparation.Rows.Add(256001, (100 + i).ToString(), (i * 100).ToString(), (i % 2 == 0 ? "F" : "R"), null);
                ((DataGridViewImageCell)this.dgvImageSeparation.Rows[i].Cells[this.dgvcImageInclusionImage.Name]).Value = img;
            }
        }


        public void InitializeArchiveNamingDataGrid()
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


        public void AddRegroupByColumns()
        {
            dgvRegroupBy.Rows.Add("Batch", "");
            dgvRegroupBy.Rows.Add("Capture Date", "");
            dgvRegroupBy.Rows.Add("Capture Site", "");
            dgvRegroupBy.Rows.Add("Every image", "");
            dgvRegroupBy.Rows.Add("Image Side", "");
            dgvRegroupBy.Rows.Add("Item", "");
            dgvRegroupBy.Rows.Add("Item Type (stub/pay)", "");
            dgvRegroupBy.Rows.Add("Statement ID", "");
            dgvRegroupBy.Rows.Add("Transaction", "");

            if (dgvRegroupBy.RowCount > 0 && dgvRegroupBy.ColumnCount > 0)
            {
                dgvRegroupBy.CurrentCell = this.dgvRegroupBy[0, 0];
                this.dgvRegroupBy.CurrentCell.Selected = false;
            } 
        }



    }
}
