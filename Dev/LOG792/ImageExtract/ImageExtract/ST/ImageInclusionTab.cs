using System;
using System.IO;
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
using ImageExtract.ObserverPattern;

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

        private MyObservable observableBatchList = new MyObservable();
        private ListOfBatchesObserver observerBatchList = new ListOfBatchesObserver("Batches shown in Image Inclusion Tab");

        public ImageInclusionTab()
        {
            InitializeComponent();
            databaseSession = NHibernateHelper.GetCurrentSession();

            LoadConditionCategoryButtons();

            this.dgvPreviewGrid.Columns[this.dgvcImageInclusionImage.Name].Width =
                this.dgvPreviewGrid.Width - 20 -
                this.dgvPreviewGrid.Columns[this.dgvcImageInclusionSide.Name].Width -
                this.dgvPreviewGrid.Columns[this.dgvcImageInclusionIRef.Name].Width -
                this.dgvPreviewGrid.Columns[this.dgvcImageInclusionMPS.Name].Width -
                this.dgvPreviewGrid.Columns[this.dgvcImageInclusionBSeq.Name].Width;

            
            observableBatchList.Subscribe(observerBatchList);
            observerBatchList.dgv = this.dgvPreviewGrid;
            observerBatchList.imageTab = this;
            
            //CodeForScreenshots();

            AddConditionSetListBox(false);
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


        /*
        public void CodeForScreenshots()
        {
            AddConditionSetListBox(false);
            AddConditionSetListBox();

            conditionSetListBoxes[0].AddToAllItemsBox(new MyComboBoxOrListBoxItem("Singles", new integer(0)));
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
        */

        public void AddConditionSetListBox()
        {
            AddConditionSetListBox(true);
        }

        public void RefreshPreviewGrid()
        {
            observableBatchList.NotifyObservers(VariablesSingleton.GetInstance().PreviewBatches);
        }

        public void AddConditionSetListBox(bool blnAllowRemovalOfConditionSet)
        {
            ImageInclusionListBoxes oneConditionSet = new ImageInclusionListBoxes(this);
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
            exampleImages.ShowDialog();
            VariablesSingleton.GetInstance().PreviewBatches = exampleImages.ListOfBatchesForInterface;
            RefreshPreviewGrid();
        }

        private void ConditionCategoryButtons_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            ImageExtractCondCategory category = (ImageExtractCondCategory)b.Tag;
            foreach(Domain.ImageExtractCondition oneCondition in category.ImageExtractConditions)
            {
                this.conditionSetListBoxes[0].AddToUnusedBox(oneCondition);
            }
        }
        #endregion

    } // public partial class ImageInclusionTab





    class ListOfBatchesObserver : MyObserver
    {
        public DataGridView dgv;
        public ImageInclusionTab imageTab;

        private int ROW_HEIGHT_ITEM_INCLUDED = 100;
        private int ROW_HEIGHT_ITEM_NOT_INCLUDED = 50;

        public ListOfBatchesObserver(string name)
            : base(name) { }

        public override void OnNext(object value)
        {
            List<CaptureBatch> shownBatches = value as List<Domain.CaptureBatch>;
            VariablesSingleton.GetInstance().PreviewBatches = shownBatches;

            dgv.Rows.Clear();

            // Add all the statements and payments
            foreach (CaptureBatch oneBatch in shownBatches)
            {
                foreach (ItemStatement oneItem in oneBatch.ItemStatements)
                {
                    AddStatementToGrid(dgv, oneItem, true);
                    AddStatementToGrid(dgv, oneItem, false);
                }

                foreach (ItemPayment oneItem in oneBatch.ItemPayments)
                {
                    AddPaymentToGrid(dgv, oneItem, true);
                    AddPaymentToGrid(dgv, oneItem, false);
                }
            }

            // Sort according to a sort key
            // The sort column is just a concatenation of Batch_Seq, MPS, Item Ref and Image Side columns
            // it's pretty bad, but...
            dgv.Sort(dgv.Columns["dgvcImageInclusionImageSortColumn"], ListSortDirection.Ascending);

            // RecolorCells(dgv);

        } // void OnNext


        public void AddStatementToGrid(DataGridView p_dgv, Domain.ItemStatement oneItem, bool p_isFrontItem)
        {
            bool itemIsIncludedInConditions = false;
            string pathForOneImage = Path.Combine(
                            VariablesSingleton.GetInstance().ImagePath,
                            (p_isFrontItem ? oneItem.Image_File_Front : oneItem.Image_File_Rear) + ".tif");
            Image itemImage = new Bitmap(pathForOneImage);
            dgv.Rows.Add(
                oneItem.ItemStatementIdentifier.Batch_Seq,
                oneItem.Matched_Payment_Seq,
                oneItem.ItemStatementIdentifier.Item_Ref,
                (p_isFrontItem ? "F" : "R"),
                itemImage,
                oneItem.ItemStatementIdentifier.Batch_Seq.ToString().PadLeft(10) +
                    oneItem.Matched_Payment_Seq.ToString().PadLeft(10) +
                    oneItem.ItemStatementIdentifier.Item_Ref.ToString().PadLeft(10) +
                    (p_isFrontItem ? "F" : "R"));


            // Change cell coloring depending on whether or not we have a condition
            foreach (ImageExtractCondition oneCondition in imageTab.ConditionSetListBoxes[0].ConditionsInIncludeBox)
            {
                if (StatementConformsToCondition(oneItem, oneCondition, p_isFrontItem))
                {
                    itemIsIncludedInConditions = true;
                    break;
                }
            }

            if (itemIsIncludedInConditions)
            {
                foreach (ImageExtractCondition oneCondition in imageTab.ConditionSetListBoxes[0].ConditionsInExcludeBox)
                {
                    if (StatementConformsToCondition(oneItem, oneCondition, p_isFrontItem))
                    {
                        itemIsIncludedInConditions = false;
                        break;
                    }
                }
            }

            dgv.Rows[dgv.Rows.Count - 1].DefaultCellStyle.BackColor = (itemIsIncludedInConditions ? Color.White : Color.LightCoral);
            dgv.Rows[dgv.Rows.Count - 1].Height = (itemIsIncludedInConditions ? ROW_HEIGHT_ITEM_INCLUDED : ROW_HEIGHT_ITEM_NOT_INCLUDED);
        }

        public void AddPaymentToGrid(DataGridView p_dgv, Domain.ItemPayment oneItem, bool p_isFrontItem)
        {
            bool itemIsIncludedInConditions = false;
            string pathForOneImage = Path.Combine(
                            VariablesSingleton.GetInstance().ImagePath,
                            (p_isFrontItem ? oneItem.Image_File_Front : oneItem.Image_File_Rear) + ".tif");
            Image itemImage = new Bitmap(pathForOneImage);
            dgv.Rows.Add(
                oneItem.ItemPaymentIdentifier.Batch_Seq,
                oneItem.Matched_Payment_Seq,
                oneItem.ItemPaymentIdentifier.Item_Ref,
                (p_isFrontItem ? "F" : "R"),
                itemImage,
                oneItem.ItemPaymentIdentifier.Batch_Seq.ToString().PadLeft(10) +
                    oneItem.Matched_Payment_Seq.ToString().PadLeft(10) +
                    oneItem.ItemPaymentIdentifier.Item_Ref.ToString().PadLeft(10) +
                    (p_isFrontItem ? "F" : "R")
                );

            // Change cell coloring depending on whether or not we have a condition
            foreach (ImageExtractCondition oneCondition in imageTab.ConditionSetListBoxes[0].ConditionsInIncludeBox)
            {
                if (PaymentConformsToCondition(oneItem, oneCondition, p_isFrontItem))
                {
                    itemIsIncludedInConditions = true;
                    break;
                }
            }

            if (itemIsIncludedInConditions)
            {
                foreach (ImageExtractCondition oneCondition in imageTab.ConditionSetListBoxes[0].ConditionsInExcludeBox)
                {
                    if (PaymentConformsToCondition(oneItem, oneCondition, p_isFrontItem))
                    {
                        itemIsIncludedInConditions = false;
                        break;
                    }
                }
            }

            dgv.Rows[dgv.Rows.Count - 1].DefaultCellStyle.BackColor = (itemIsIncludedInConditions ? Color.White : Color.LightCoral);
            dgv.Rows[dgv.Rows.Count - 1].Height = (itemIsIncludedInConditions ? ROW_HEIGHT_ITEM_INCLUDED : ROW_HEIGHT_ITEM_NOT_INCLUDED);
        }

        public bool StatementConformsToCondition(ItemStatement item, ImageExtractCondition iec, bool p_isFrontItem)
        {
            bool returnedValue = false;
            string tableName, symbol, columnName, comparisonValue;

            if (String.IsNullOrEmpty(iec.Where_Clause))
            {
                returnedValue = true;
            }
            else if (iec.Where_Clause == "%FRONT_ONLY%")
            {
                returnedValue = p_isFrontItem;
            }
            else if (iec.Where_Clause == "%REAR_ONLY%")
            {
                returnedValue = !p_isFrontItem;
            }
            else
            {
                tableName = iec.Where_Clause.Substring(0, iec.Where_Clause.IndexOf("."));
                symbol = iec.Where_Clause.Contains(">") ? ">" : "=";
                columnName = iec.Where_Clause.Substring(iec.Where_Clause.IndexOf(".") + 1, iec.Where_Clause.IndexOf(symbol) - iec.Where_Clause.IndexOf(".") - 1).Trim();
                comparisonValue = iec.Where_Clause.Substring(iec.Where_Clause.IndexOf(symbol) + 1).Trim();

                /*
                MessageBox.Show("tableName = '" + tableName + "', columnName = '" + columnName + "', symbol = '" + symbol + "', comparisonValue = '" + comparisonValue + "'");
                */

                if (tableName == "Capture_Batch" && columnName == "Capture_Type_Item" && symbol == "=")
                    returnedValue = item.batch.Capture_Type_Item.Equals(comparisonValue);
                else if (tableName == "Item_Statement" && columnName == "Item_Source" && symbol == "=")
                    returnedValue = item.Item_Source.Equals(comparisonValue);
                // Matched_Payment isn't implemented
            }

            return returnedValue;
        }


        public bool PaymentConformsToCondition(ItemPayment item, ImageExtractCondition iec, bool p_isFrontItem)
        {
            bool returnedValue = false;
            string tableName, symbol, columnName, comparisonValue;

            if (String.IsNullOrEmpty(iec.Where_Clause))
            {
                returnedValue = true;
            }
            else if (iec.Where_Clause == "%FRONT_ONLY%")
            {
                returnedValue = p_isFrontItem;
            }
            else if (iec.Where_Clause == "%REAR_ONLY%")
            {
                returnedValue = !p_isFrontItem;
            }
            else
            {
                tableName = iec.Where_Clause.Substring(0, iec.Where_Clause.IndexOf("."));
                symbol = iec.Where_Clause.Contains(">") ? ">" : "=";
                columnName = iec.Where_Clause.Substring(iec.Where_Clause.IndexOf(".") + 1, iec.Where_Clause.IndexOf(symbol) - iec.Where_Clause.IndexOf(".") - 1).Trim();
                comparisonValue = iec.Where_Clause.Substring(iec.Where_Clause.IndexOf(symbol) + 1).Trim();

                /*
                MessageBox.Show("tableName = '" + tableName + "', columnName = '" + columnName + "', symbol = '" + symbol + "', comparisonValue = '" + comparisonValue + "'");
                */

                if (tableName == "Capture_Batch" && columnName == "Capture_Type_Item" && symbol == "=")
                    returnedValue = item.batch.Capture_Type_Item.Equals(comparisonValue);
                else if (tableName == "Item_Statement" && columnName == "Item_Source" && symbol == "=")
                    returnedValue = item.Item_Source.Equals(comparisonValue);
                // Matched_Payment isn't implemented
            }

            return returnedValue;
        }


        /*
        public void RecolorCells(DataGridView p_dgv)
        {
            // Recolor the cells
            // Color first cell white, keep Batch_Seq and MPS values in memory
            // If Batch_Seq and MPS values are different, now color them light gray

            Color[] colorsToUse = new Color[2];
            colorsToUse[0] = Color.White;
            colorsToUse[1] = Color.LightBlue;
            int currentColorIndice = 1;

            string strCurrentBatchSeq, strCurrentMatchedPaymentSeq;
            string strLastBatchSeq = "";
            string strLastMatchedPaymentSeq = "";

            foreach (DataGridViewRow dgvr in p_dgv.Rows)
            {
                strCurrentBatchSeq = dgvr.Cells[0].Value.ToString();
                strCurrentMatchedPaymentSeq = dgvr.Cells[1].Value.ToString();
                if (strCurrentMatchedPaymentSeq.CompareTo(strLastMatchedPaymentSeq) != 0 || strCurrentBatchSeq.CompareTo(strLastBatchSeq) != 0)
                {
                    currentColorIndice = 1 - currentColorIndice;
                    strLastMatchedPaymentSeq = strCurrentMatchedPaymentSeq;
                    strLastBatchSeq = strCurrentBatchSeq;
                }
                dgvr.DefaultCellStyle.BackColor = colorsToUse[currentColorIndice];
            }
        }
        */

    } // class ListOfBatchesObserver



}
