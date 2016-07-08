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
    public partial class ImageInclusionTab : UserControl
    {
        List<ImageInclusionListBoxes> conditionSetListBoxes = new List<ImageInclusionListBoxes>();
        public List<ImageInclusionListBoxes> ConditionSetListBoxes
        {
            get { return conditionSetListBoxes; }
            set { conditionSetListBoxes = value; }
        }        

        public ImageInclusionTab()
        {
            InitializeComponent();
            InitializeImageInclusionDataGrid();
            AddConditionSetListBox(false);
            AddConditionSetListBox();

            //this.listBox1.Items.Add(new MyComboBoxOrListBoxItem("brax", -1));
            //conditionSetListBoxes[0].AddToIncludeBox(new MyComboBoxOrListBoxItem("Singles", 0));
            conditionSetListBoxes[0].AddToAllItemsBox(new MyComboBoxOrListBoxItem("Singles", 0));
            conditionSetListBoxes[0].AddToAllItemsBox(new MyComboBoxOrListBoxItem("Multiples", 0));
            conditionSetListBoxes[0].AddToAllItemsBox(new MyComboBoxOrListBoxItem("Check Only", 0));
            conditionSetListBoxes[0].AddToAllItemsBox(new MyComboBoxOrListBoxItem("Check Skirt", 0));
            //conditionSetListBoxes[0].AddToExcludeBox(new MyComboBoxOrListBoxItem("Check Skirt", 0));
        }



        public void InitializeImageInclusionDataGrid()
        {
            Image img = new Bitmap(@"D:\Cossins\Documents\ETS\LOG792\Images\cheque.tif");

            // Set image last column to width
            this.dgvImageInclusion.Columns[this.dgvcImageInclusionImage.Name].Width =
                this.dgvImageInclusion.Width - 20 -
                this.dgvImageInclusion.Columns[this.dgvcImageInclusionSide.Name].Width -
                this.dgvImageInclusion.Columns[this.dgvcImageInclusionIRef.Name].Width -
                this.dgvImageInclusion.Columns[this.dgvcImageInclusionMPS.Name].Width -
                this.dgvImageInclusion.Columns[this.dgvcImageInclusionBSeq.Name].Width;


            for (int i = 0; i < 50; i++)
            {
                this.dgvImageInclusion.Rows.Add(256001, (100 + i).ToString(), (i * 100).ToString(), (i % 2 == 0 ? "F" : "R"), null);
                ((DataGridViewImageCell)this.dgvImageInclusion.Rows[i].Cells[this.dgvcImageInclusionImage.Name]).Value = img;
            }
        }


        public void AddConditionSetListBox()
        {
            AddConditionSetListBox(true);
        }

        public void AddConditionSetListBox(bool blnAllowRemovalOfConditionSet)
        {
            ImageInclusionListBoxes oneConditionSet = new ImageInclusionListBoxes();
            if (!blnAllowRemovalOfConditionSet) oneConditionSet.UnallowRemovalOfConditionSet();
            conditionSetListBoxes.Add(oneConditionSet);
            this.flpImageInclusionConditionSets.Controls.Add(oneConditionSet);
        }

        #region events
        private void dgvImageInclusion_Paint(object sender, PaintEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // Important: changing font color requires dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = (dgv.Enabled ? Color.Black : Color.Gray);

            foreach (DataGridViewRow dgvr in dgv.Rows)
            {
                dgvr.Visible = dgv.Enabled;
            }
        }

        private void btnLoadExampleBatches_Click(object sender, EventArgs e)
        {
            new LoadExampleImages().Show();
        }
        #endregion





    }
}
