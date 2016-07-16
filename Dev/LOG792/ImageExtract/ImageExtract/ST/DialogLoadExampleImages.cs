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

using CustomControls;

namespace ImageExtract
{
    public partial class DialogLoadExampleImages : Form
    {
        private ISession databaseSession;
        private ICriteria queryCriteria;
        private IList<CaptureBatch> listSearchResultBatches;
        private IList<CaptureBatch> listBatchesForInterface;

        public DialogLoadExampleImages()
        {
            InitializeComponent();

            listBatchesForInterface = new List<CaptureBatch>();
        }

        #region events
        private void btnAddSelection_Click(object sender, EventArgs e)
        {
            Domain.CaptureBatch clickedBatch; 
            
            foreach (DataGridViewRow oneRow in this.dgvSearchResults.Rows)
            {
                clickedBatch = listSearchResultBatches.First(cb => cb.Batch_Seq == Convert.ToInt32(oneRow.Cells[dgvcSearchResultsBatchSeq.Index].Value));
                AddBatchInLoadInterface(clickedBatch);
            }
        }

        private void btnResetSelection_Click(object sender, EventArgs e)
        {
            this.dgvLoadInInterface.Rows.Clear();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.listBatchesForInterface = new List<CaptureBatch>();
            this.Hide();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (CustomFormValidation.ControlIsValid(this.tlpConditions))
            {
                databaseSession = NHibernateHelper.GetCurrentSession();

                queryCriteria = databaseSession.CreateCriteria<CaptureBatch>();

                queryCriteria.CreateAlias("statement", "statement").
                    Add(Restrictions.Eq("statement.Statement_Id", Convert.ToInt32(this.vtbStatementIdEquals.Text)));
                if (!String.IsNullOrEmpty(this.vtbBatchSeqLesserThan.Text))
                    queryCriteria.Add(Restrictions.Lt("Batch_Seq", Convert.ToInt32(this.vtbBatchSeqLesserThan.Text)));
                if (!String.IsNullOrEmpty(this.vtbBatchSeqGreaterThan.Text))
                    queryCriteria.Add(Restrictions.Gt("Batch_Seq", Convert.ToInt32(this.vtbBatchSeqGreaterThan.Text)));
                if (!String.IsNullOrEmpty(this.vtbCaptureDateLesserThan.Text))
                    queryCriteria.Add(Restrictions.Lt("Capture_Date", this.vtbCaptureDateLesserThan.Text));
                if (!String.IsNullOrEmpty(this.vtbCaptureDateGreaterThan.Text))
                    queryCriteria.Add(Restrictions.Gt("Capture_Date", this.vtbCaptureDateGreaterThan.Text));

                listSearchResultBatches = queryCriteria.List<Domain.CaptureBatch>();

                this.dgvSearchResults.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSearchResults_CellValueChanged);
                this.dgvSearchResults.Rows.Clear();

                if (listSearchResultBatches.Count == 0)
                {
                    MessageBox.Show("No batches were found using the search criteria.");
                }
                else
                {
                    foreach (Domain.CaptureBatch oneBatch in listSearchResultBatches)
                    {
                        AddBatchInSearchResults(oneBatch);
                    }
                }
                
            }

            if (dgvSearchResults.Rows.Count > 0)
                this.dgvSearchResults.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSearchResults_CellValueChanged);
        }

        private void dgvSearchResults_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            // This will call dgvSearchResults_CellValueChanged
            if (e.ColumnIndex == this.dgvcSearchResultsUse.Index && e.RowIndex != -1) this.dgvSearchResults.EndEdit();
        }

        private void dgvSearchResults_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Domain.CaptureBatch clickedBatch = listSearchResultBatches.First(cb => cb.Batch_Seq ==
                  Convert.ToInt32(this.dgvSearchResults.Rows[e.RowIndex].Cells[dgvcSearchResultsBatchSeq.Index].Value));

            if ((bool)this.dgvSearchResults.Rows[e.RowIndex].Cells[dgvcSearchResultsUse.Index].Value)
            {
                AddBatchInLoadInterface(clickedBatch);
            }
            else
            {
                RemoveBatchFromLoadInterface(clickedBatch);
            }
        }

        private void dgvLoadInInterface_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            // This will call dgvLoadInInterface_CellValueChanged
            if (e.ColumnIndex == this.dgvcLoadUse.Index && e.RowIndex != -1) this.dgvLoadInInterface.EndEdit();
        }

        private void dgvLoadInInterface_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Domain.CaptureBatch clickedBatch = listBatchesForInterface.First(cb => cb.Batch_Seq ==
                  Convert.ToInt32(this.dgvLoadInInterface.Rows[e.RowIndex].Cells[this.dgvcLoadBatchSeq.Index].Value));

            if ((bool)this.dgvLoadInInterface.Rows[e.RowIndex].Cells[dgvcSearchResultsUse.Index].Value)
            {
                // This part should never happen, as you can guess
                throw new Exception("ERROR: We should never have rows in the loaded Data Grid View that have Use = false.");
            }
            else
            {
                RemoveBatchFromLoadInterface(clickedBatch);

                // Remove the "use" check from the search results
                for (int i = 0; i < dgvSearchResults.Rows.Count; i++)
                {
                    //MessageBox.Show(i + "");
                    if (Convert.ToInt32(dgvSearchResults.Rows[i].Cells[dgvcSearchResultsBatchSeq.Index].Value) == clickedBatch.Batch_Seq)
                    {
                        //MessageBox.Show(clickedBatch.Batch_Seq + "");
                       this.dgvSearchResults.Rows[i].Cells[this.dgvcSearchResultsUse.Index].Value = false;
                    }
                }          
            }
        }
        #endregion

        public IList<CaptureBatch> GetBatchesForInterface()
        {
            if (listBatchesForInterface == null) listBatchesForInterface = new List<CaptureBatch>();

            return listBatchesForInterface;
        }
       
        private void AddBatchInSearchResults(CaptureBatch oneBatch)
        {
            this.dgvSearchResults.Rows.Add(
                oneBatch.statement.Statement_Id,
                oneBatch.Capture_Date,
                oneBatch.Batch_Seq,
                oneBatch.Capture_Id,
                oneBatch.captureBatchSummary.Tot_Num_Payments + oneBatch.captureBatchSummary.Tot_Num_Statements,
                false);
        }

        private void AddBatchInLoadInterface(CaptureBatch oneBatch)
        {
            if (!listBatchesForInterface.Contains(oneBatch))
            {
                listBatchesForInterface.Add(oneBatch);
                this.dgvLoadInInterface.Rows.Add(
                    oneBatch.statement.Statement_Id,
                    oneBatch.Capture_Date,
                    oneBatch.Batch_Seq,
                    oneBatch.Capture_Id,
                    oneBatch.captureBatchSummary.Tot_Num_Payments + oneBatch.captureBatchSummary.Tot_Num_Statements,
                    true);

                RefreshDgvLoadInterfaceEvents();
            }
        }

        private void RemoveBatchFromLoadInterface(CaptureBatch oneBatch)
        {
            DataGridViewRow rowToRemove = null;

            // Locate the batch in the interface dgv
            for (int i = 0; i < dgvLoadInInterface.Rows.Count && rowToRemove == null; i++)
                if (Convert.ToInt32(dgvLoadInInterface.Rows[i].Cells[dgvcLoadBatchSeq.Index].Value) == oneBatch.Batch_Seq)
                    rowToRemove = dgvLoadInInterface.Rows[i];

            // Remove the batch from the datagrid and the List
            if (rowToRemove != null)
            {
                listBatchesForInterface.Remove(oneBatch);
                dgvLoadInInterface.Rows.Remove(rowToRemove);
            }

            RefreshDgvLoadInterfaceEvents();
        }

        private void RefreshDgvLoadInterfaceEvents()
        {
            this.dgvLoadInInterface.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoadInInterface_CellValueChanged);

            if (dgvLoadInInterface.Rows.Count > 0)
                this.dgvLoadInInterface.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoadInInterface_CellValueChanged);
        }



    }
}
