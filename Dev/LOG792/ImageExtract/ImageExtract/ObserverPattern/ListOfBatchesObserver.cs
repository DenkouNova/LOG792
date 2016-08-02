using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using ImageExtract.ST;
using ImageExtract.Domain;

namespace ImageExtract.ObserverPattern
{
    class ListOfBatchesObserver : MyObserver
    {
        public DataGridView dgv;
            
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
            foreach (ImageExtractCondition oneCondition in VariablesSingleton.GetInstance().ConditionsInIncludeBox)
            {
                if (StatementConformsToCondition(oneItem, oneCondition, p_isFrontItem))
                {
                    itemIsIncludedInConditions = true;
                    break;
                }
            }

            if (itemIsIncludedInConditions)
            {
                foreach (ImageExtractCondition oneCondition in VariablesSingleton.GetInstance().ConditionsInExcludeBox)
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
            foreach (ImageExtractCondition oneCondition in VariablesSingleton.GetInstance().ConditionsInIncludeBox)
            {
                if (PaymentConformsToCondition(oneItem, oneCondition, p_isFrontItem))
                {
                    itemIsIncludedInConditions = true;
                    break;
                }
            }

            if (itemIsIncludedInConditions)
            {
                foreach (ImageExtractCondition oneCondition in VariablesSingleton.GetInstance().ConditionsInExcludeBox)
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
