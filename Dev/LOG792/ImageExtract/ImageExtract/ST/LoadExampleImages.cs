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
    public partial class LoadExampleImages : Form
    {
        ISession databaseSession;
        ICriteria queryCriteria;
        IList<CaptureBatch> listSearchResultBatches;
        IList<CaptureBatch> listBatchesForInterface;

        public LoadExampleImages()
        {
            InitializeComponent();

            
        }


        #region events
        private void btnAddSelection_Click(object sender, EventArgs e)
        {
            /*
            this.tbBatchSeqLesserThan.Rows.Add(1319, "20160704", 256800, "Singles", true);
            this.tbBatchSeqLesserThan.Rows.Add(1319, "20160704", 256801, "Multis", true);
            this.tbBatchSeqLesserThan.Rows.Add(1319, "20160705", 256823, "Multis", true);

            this.dataLoadInInterface.Rows.Add(1319, "20160704", 256801, "Multis", true);
            */

            /*
            // Test code for screenshots
            for (int i = 0; i < 50; i++)
            {
                this.dgvImageInclusion.Rows.Add(256001, (100 + i).ToString(), (i * 100).ToString(), (i % 2 == 0 ? "F" : "R"), null);
                ((DataGridViewImageCell)this.dgvImageInclusion.Rows[i].Cells[this.dgvcImageInclusionImage.Name]).Value = img;
            }*/
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (CustomFormValidation.ControlIsValid(this.tlpConditions))
            {
                databaseSession = NHibernateHelper.GetCurrentSession();

                queryCriteria = databaseSession.CreateCriteria<CaptureBatch>();

                //queryCriteria.Add(Restrictions.Eq("Statement_Id", this.vtbStatementIdEquals.Text));

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
                this.dgvLoadInInterface.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoadInInterface_CellValueChanged);
                this.dgvSearchResults.Rows.Clear();

                if (listSearchResultBatches.Count == 0)
                {
                    MessageBox.Show("No batches were found using the search criteria.");
                }
                else
                {
                    foreach (var oneBatch in listSearchResultBatches)
                    {
                        AddBatchInSearchResults(oneBatch);
                    }
                }
                
            }

            if (dgvSearchResults.Rows.Count > 0)
                this.dgvSearchResults.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSearchResults_CellValueChanged);

            if (dgvLoadInInterface.Rows.Count > 0)
                this.dgvLoadInInterface.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoadInInterface_CellValueChanged);

        }

        private void dgvSearchResults_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            // This will call dgvSearchResults_CellValueChanged
            if (e.ColumnIndex == this.dgvcSearchResultsUse.Index && e.RowIndex != -1) this.dgvSearchResults.EndEdit();
        }

        private void dgvSearchResults_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if ((bool)this.dgvSearchResults.Rows[e.RowIndex].Cells[dgvcSearchResultsUse.Index].Value)
            {
                Domain.CaptureBatch clickedBatch = listSearchResultBatches.First(cb => cb.Batch_Seq ==
               Convert.ToInt32(this.dgvSearchResults.Rows[e.RowIndex].Cells[dgvcSearchResultsBatchSeq.Index].Value));
                MessageBox.Show(clickedBatch.ToString());
            }
            //MessageBox.Show(this.dgvSearchResults.Rows[e.RowIndex].Cells[dgvcSearchResultsBatchSeq.Index].Value.ToString());

           
        }

        private void dgvLoadInInterface_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            // This will call dgvLoadInInterface_CellValueChanged
            if (e.ColumnIndex == this.dgvcLoadUse.Index && e.RowIndex != -1) this.dgvLoadInInterface.EndEdit();
        }

        private void dgvLoadInInterface_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("Clickytung");
        }
        #endregion

        

        
        private void AddBatchInSearchResults(CaptureBatch oneBatch)
        {
            this.dgvSearchResults.Rows.Add(
                1319,
                oneBatch.Capture_Date,
                oneBatch.Batch_Seq,
                oneBatch.Capture_Id,
                oneBatch.captureBatchSummary.Tot_Num_Payments + oneBatch.captureBatchSummary.Tot_Num_Statements,
                false);
        }



    }
}
