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

        public enum DataGridType
        {
            NotInitialized,
            Inclusion,
            Separation
        }

        public DataGridType dgType = DataGridType.NotInitialized;

        public string imageNaming = null;

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
            dgv.Sort(dgv.Columns["HiddenSortColumn"], ListSortDirection.Ascending);

            if (this.dgType == DataGridType.Separation) RecolorCells(dgv);

        } // void OnNext


        public void AddStatementToGrid(DataGridView p_dgv, Domain.ItemStatement oneItem, bool p_isFrontItem)
        {
            bool itemIsIncludedInConditions = false;
            string pathForOneImage = Path.Combine(
                            VariablesSingleton.GetInstance().ImagePath,
                            (p_isFrontItem ? oneItem.Image_File_Front : oneItem.Image_File_Rear) + ".tif");
            Image itemImage = new Bitmap(pathForOneImage);

            if (dgType == DataGridType.Inclusion)
            {
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
            } // dgType == DataGridType.Inclusion
            else if (dgType == DataGridType.Separation)
            {

                // Add lines, but only if they are included in conditions
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

                string imageNamingForThisItem = ReplaceNamingForStatement(this.imageNaming, oneItem, p_isFrontItem);

                if (itemIsIncludedInConditions)
                {
                    dgv.Rows.Add(
                        oneItem.ItemStatementIdentifier.Batch_Seq,
                        oneItem.Matched_Payment_Seq,
                        oneItem.ItemStatementIdentifier.Item_Ref,
                        (p_isFrontItem ? "F" : "R"),
                        itemImage,
                        imageNamingForThisItem + oneItem.ItemStatementIdentifier.Batch_Seq.ToString().PadLeft(10) +
                            oneItem.Matched_Payment_Seq.ToString().PadLeft(10) +
                            oneItem.ItemStatementIdentifier.Item_Ref.ToString().PadLeft(10) +
                            (p_isFrontItem ? "F" : "R"),
                            imageNamingForThisItem);
                }

            } // dgType == DataGridType.Separation
            
        }



        public string ReplaceNamingForStatement(string imageNaming, Domain.ItemStatement oneItem, bool p_isFrontItem)
        {
            string returnValue = imageNaming;

            if (String.IsNullOrEmpty(imageNaming))
            {
                returnValue = "";
            }
            else
            {
                returnValue = imageNaming;
                returnValue = returnValue.Replace("$BATCH_SEQ$", oneItem.ItemStatementIdentifier.Batch_Seq.ToString());
                returnValue = returnValue.Replace("$CAPTURE_DATE$", oneItem.batch.Capture_Date.ToString());
                returnValue = returnValue.Replace("$CAPTURE_SITE$", oneItem.batch.statement.site.Site_Id.ToString());
                returnValue = returnValue.Replace("$IMAGE_SIDE$", (p_isFrontItem ? "F" : "R"));
                returnValue = returnValue.Replace("$ITEM_REF$", oneItem.ItemStatementIdentifier.Item_Ref.ToString());
                returnValue = returnValue.Replace("$ITEM_TYPE$", "STUB");
                returnValue = returnValue.Replace("$STATEMENT_ID$", oneItem.batch.statement.Statement_Id.ToString());
                //imageNaming = imageNaming.Replace("$MATCHED_PAYMENT_SEQ$", oneItem.batch.statement.Statement_Id.ToString());
            }
            
            return returnValue;
        }



        public string ReplaceNamingForPayment(string imageNaming, Domain.ItemPayment oneItem, bool p_isFrontItem)
        {
            string returnValue;
            
            if (String.IsNullOrEmpty(imageNaming))
            {
                returnValue = "";
            }
            else
            {
                returnValue = imageNaming;
                returnValue = returnValue.Replace("$BATCH_SEQ$", oneItem.batch.Batch_Seq.ToString());
                returnValue = returnValue.Replace("$CAPTURE_DATE$", oneItem.batch.Capture_Date.ToString());
                returnValue = returnValue.Replace("$CAPTURE_SITE$", oneItem.batch.statement.site.Site_Id.ToString());
                returnValue = returnValue.Replace("$IMAGE_SIDE$", (p_isFrontItem ? "F" : "R"));
                returnValue = returnValue.Replace("$ITEM_REF$", oneItem.ItemPaymentIdentifier.Item_Ref.ToString());
                returnValue = returnValue.Replace("$ITEM_TYPE$", "STUB");
                returnValue = returnValue.Replace("$STATEMENT_ID$", oneItem.batch.statement.Statement_Id.ToString());
                //imageNaming = imageNaming.Replace("$MATCHED_PAYMENT_SEQ$", oneItem.batch.statement.Statement_Id.ToString());
            }
            
            return returnValue;
        }



        public void AddPaymentToGrid(DataGridView p_dgv, Domain.ItemPayment oneItem, bool p_isFrontItem)
        {
            bool itemIsIncludedInConditions = false;
            string pathForOneImage = Path.Combine(
                            VariablesSingleton.GetInstance().ImagePath,
                            (p_isFrontItem ? oneItem.Image_File_Front : oneItem.Image_File_Rear) + ".tif");
            Image itemImage = new Bitmap(pathForOneImage);

            if (dgType == DataGridType.Inclusion)
            {
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
            } // dgType == DataGridType.Inclusion
            else if (dgType == DataGridType.Separation)
            {
                // Add lines, but only if they are included in conditions
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

                string imageNamingForThisItem = ReplaceNamingForPayment(this.imageNaming, oneItem, p_isFrontItem);

                if (itemIsIncludedInConditions)
                {
                    dgv.Rows.Add(
                        oneItem.ItemPaymentIdentifier.Batch_Seq,
                        oneItem.Matched_Payment_Seq,
                        oneItem.ItemPaymentIdentifier.Item_Ref,
                        (p_isFrontItem ? "F" : "R"),
                        itemImage,
                        imageNamingForThisItem + oneItem.ItemPaymentIdentifier.Batch_Seq.ToString().PadLeft(10) +
                            oneItem.Matched_Payment_Seq.ToString().PadLeft(10) +
                            oneItem.ItemPaymentIdentifier.Item_Ref.ToString().PadLeft(10) +
                            (p_isFrontItem ? "F" : "R"),
                            imageNamingForThisItem
                    );
                }
            } // dgType == DataGridType.Separation

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


        public void RecolorCells(DataGridView p_dgv)
        {
            // Recolor the cells
            // Color first cell white, keep Batch_Seq and MPS values in memory
            // If Batch_Seq and MPS values are different, now color them light gray

            Color[] colorsToUse = new Color[2];
            colorsToUse[0] = Color.White;
            colorsToUse[1] = Color.LightBlue;
            int currentColorIndice = 1;

            string strCurrentImageNaming;
            string strLastImageNaming = "";

            foreach (DataGridViewRow dgvr in p_dgv.Rows)
            {
                strCurrentImageNaming = dgvr.Cells["dgvcImageNaming"].Value.ToString();
                if (strCurrentImageNaming.CompareTo(strLastImageNaming) != 0)
                {
                    currentColorIndice = 1 - currentColorIndice;
                    strLastImageNaming = strCurrentImageNaming;
                }
                dgvr.DefaultCellStyle.BackColor = colorsToUse[currentColorIndice];
            }
        }

    } // class ListOfBatchesObserver
}
