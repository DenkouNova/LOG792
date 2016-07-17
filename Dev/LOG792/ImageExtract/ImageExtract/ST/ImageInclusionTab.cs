using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Tool.hbm2ddl;

using ImageExtract.ST;
using ImageExtract.Domain;

namespace ImageExtract.ST
{
    public partial class ImageInclusionTab : UserControl
    {
        ISession databaseSession;

        List<ImageInclusionListBoxes> conditionSetListBoxes = new List<ImageInclusionListBoxes>();
        public List<ImageInclusionListBoxes> ConditionSetListBoxes
        {
            get { return conditionSetListBoxes; }
            set { conditionSetListBoxes = value; }
        }        

        public ImageInclusionTab()
        {
            InitializeComponent();
            databaseSession = NHibernateHelper.GetCurrentSession();

            LoadConditionCategoryButtons();

            // CodeForScreenshots();
        }


        // Condition categories are system-wide and need not be saved. Just load them upon opening the program and that's it
        public void LoadConditionCategoryButtons()
        {
            Button currentButton;

            foreach (ImageExtractCondCategory oneCategory in databaseSession.CreateCriteria<Domain.ImageExtractCondCategory>().
                List<Domain.ImageExtractCondCategory>())
            {
                currentButton = new Button();
                currentButton.Font = this.btnExampleConditionCategoryButton.Font;
                currentButton.Size = this.btnExampleConditionCategoryButton.Size;
                currentButton.Text = oneCategory.Description;
                currentButton.Tag = oneCategory;
                this.flpLoadConditionsButtons.Controls.Add(currentButton);
                currentButton.Click += new System.EventHandler(this.ConditionCategoryButtons_Click);
            }
            btnExampleConditionCategoryButton.Visible = false;
        }


        public void CodeForScreenshots()
        {
            AddConditionSetListBox(false);
            AddConditionSetListBox();

            conditionSetListBoxes[0].AddToAllItemsBox(new MyComboBoxOrListBoxItem("Singles", 0));
            conditionSetListBoxes[0].AddToAllItemsBox(new MyComboBoxOrListBoxItem("Multiples", 0));
            conditionSetListBoxes[0].AddToAllItemsBox(new MyComboBoxOrListBoxItem("Check Only", 0));
            conditionSetListBoxes[0].AddToAllItemsBox(new MyComboBoxOrListBoxItem("Check Skirt", 0));

            // Initialize Image Inclusion Datagrid
            Image img = new Bitmap(TestConstants.ExampleImagePath);

            // Set image last column to width
            this.dgvPreviewGrid.Columns[this.dgvcImageInclusionImage.Name].Width =
                this.dgvPreviewGrid.Width - 20 -
                this.dgvPreviewGrid.Columns[this.dgvcImageInclusionSide.Name].Width -
                this.dgvPreviewGrid.Columns[this.dgvcImageInclusionIRef.Name].Width -
                this.dgvPreviewGrid.Columns[this.dgvcImageInclusionMPS.Name].Width -
                this.dgvPreviewGrid.Columns[this.dgvcImageInclusionBSeq.Name].Width;


            for (int i = 0; i < 50; i++)
            {
                this.dgvPreviewGrid.Rows.Add(256001, (100 + i).ToString(), (i * 100).ToString(), (i % 2 == 0 ? "F" : "R"), null);
                ((DataGridViewImageCell)this.dgvPreviewGrid.Rows[i].Cells[this.dgvcImageInclusionImage.Name]).Value = img;
            }
        }

                public void AddConditionSetListBox()
        {
            AddConditionSetListBox(true);
        }

        private void AddOneBatchInPreviewGrid(Domain.CaptureBatch oneBatch)
        {

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
            foreach (DataGridViewRow dgvr in dgv.Rows) dgvr.Visible = dgv.Enabled;

        }

        private void btnLoadExampleBatches_Click(object sender, EventArgs e)
        {
            DialogLoadExampleImages exampleImages = new DialogLoadExampleImages();
            IList<CaptureBatch> selectedBatches;

            exampleImages.ShowDialog();
            
            // brax selectedBatches = exampleImages.GetBatchesForInterface();
        }

        private void ConditionCategoryButtons_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            ImageExtractCondCategory category = (ImageExtractCondCategory)b.Tag;
            MessageBox.Show("ID " + category.Cond_Category_Id +", Description = '" + category.Description + "'");
        }
        #endregion

        





    }
}
