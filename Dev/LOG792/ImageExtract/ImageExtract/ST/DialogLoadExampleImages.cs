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
using ImageExtract.ObserverPattern;

using CustomControls;

namespace ImageExtract
{
    public partial class DialogLoadExampleImages : Form
    {
        public const int BATCH_SEQ_COLUMN = 2; // BatchSeq has to have this column index on both DataGridViews

        private ISession databaseSession;
        private ICriteria queryCriteria;
        private IList<CaptureBatch> listOfSearchResultBatches;

        private IList<CaptureBatch> listOfBatchesForInterface { get; set; }
        public IList<CaptureBatch> ListOfBatchesForInterface
        {
            get { return listOfBatchesForInterface; }
            set { listOfBatchesForInterface = value; }
        }

        private MyObservable observableSearchResultList = new MyObservable();
        private MyObservable observableBatchesForInterface = new MyObservable();
        private ListOfBatchesObserver observerSearchResultList = new ListOfBatchesObserver("Search results");
        private ListOfBatchesObserver observerBatchesForInterface = new ListOfBatchesObserver("Batches for interface");

        public DialogLoadExampleImages()
        {
            InitializeComponent();

            this.dgvSearchResults.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSearchResults_CellValueChanged);

            resetBatchesSearchResults();
            resetBatchesLoadInInterface();

            observableSearchResultList.Subscribe(observerSearchResultList);
            observableBatchesForInterface.Subscribe(observerBatchesForInterface);
            observerSearchResultList.dgv = this.dgvSearchResults;
            observerBatchesForInterface.dgv = this.dgvLoadInInterface;

            this.vtbStatementIdEquals.Select();
        }

        private void AddBatchInSearchResultsList(Domain.CaptureBatch oneBatch)
        {
            listOfSearchResultBatches.Add(oneBatch);
            observableSearchResultList.NotifyObservers(new CaptureBatchEvent(oneBatch, CaptureBatchEvent.AddOrRemoveMode.ADD, false));
        }

        private void AddBatchInLoadInterfaceList(Domain.CaptureBatch oneBatch)
        {
            listOfBatchesForInterface.Add(oneBatch);
            observableBatchesForInterface.NotifyObservers(new CaptureBatchEvent(oneBatch, CaptureBatchEvent.AddOrRemoveMode.ADD, true));
            RefreshDgvLoadInterfaceEvents();
        }

        private void RemoveBatchFromLoadInterfaceList(Domain.CaptureBatch oneBatch)
        {
            listOfBatchesForInterface.Remove(oneBatch);
            observableBatchesForInterface.NotifyObservers(new CaptureBatchEvent(oneBatch, CaptureBatchEvent.AddOrRemoveMode.REMOVE));
            RefreshDgvLoadInterfaceEvents();
        }

        private void RefreshDgvLoadInterfaceEvents()
        {
            this.dgvLoadInInterface.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoadInInterface_CellValueChanged);

            if (dgvLoadInInterface.Rows.Count > 0)
                this.dgvLoadInInterface.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoadInInterface_CellValueChanged);
        }

        private void resetBatchesSearchResults()
        {
            listOfSearchResultBatches = new List<CaptureBatch>();
            this.dgvSearchResults.Rows.Clear();
        }

        private void resetBatchesLoadInInterface()
        {
            listOfBatchesForInterface = new List<CaptureBatch>();
            this.dgvLoadInInterface.Rows.Clear();
        }





        #region events
        private void dgvSearchResults_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            // if the cell clicked is the "Use" column of the search DataGridView, we will call dgvSearchResults_CellValueChanged
            if (e.ColumnIndex == this.dgvcSearchResultsUse.Index && e.RowIndex != -1) this.dgvSearchResults.EndEdit();
        }

        private void dgvLoadInInterface_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            // if the cell clicked is the "Use" column of the search results DataGridView, we will call dgvLoadInInterface_CellValueChanged
            if (e.ColumnIndex == this.dgvcLoadUse.Index && e.RowIndex != -1) this.dgvLoadInInterface.EndEdit();
        }

        private void dgvSearchResults_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Domain.CaptureBatch clickedBatch = listOfSearchResultBatches.First(cb => cb.Batch_Seq ==
                  Convert.ToInt32(this.dgvSearchResults.Rows[e.RowIndex].Cells[dgvcSearchResultsBatchSeq.Index].Value));

            if ((bool)this.dgvSearchResults.Rows[e.RowIndex].Cells[dgvcSearchResultsUse.Index].Value)
                AddBatchInLoadInterfaceList(clickedBatch);
            else
                RemoveBatchFromLoadInterfaceList(clickedBatch);

            this.dgvSearchResults.CurrentCell = null; // unselect the current row
        }

        private void dgvLoadInInterface_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Domain.CaptureBatch clickedBatch = listOfBatchesForInterface.First(cb => cb.Batch_Seq ==
                  Convert.ToInt32(this.dgvLoadInInterface.Rows[e.RowIndex].Cells[this.dgvcLoadBatchSeq.Index].Value));

            // Note: the boolean we are checking here is the boolean _after_ the user click.
            if ((bool)this.dgvLoadInInterface.Rows[e.RowIndex].Cells[dgvcSearchResultsUse.Index].Value)
            {
                throw new Exception("ERROR: We should never have rows in the loaded Data Grid View that have Use = false before a user click.");
            }
            else
            {
                // Remove the "use" check from the search results
                for (int i = 0; i < dgvSearchResults.Rows.Count; i++)
                {
                    //MessageBox.Show(i + "");
                    if (Convert.ToInt32(dgvSearchResults.Rows[i].Cells[dgvcSearchResultsBatchSeq.Index].Value) == clickedBatch.Batch_Seq)
                    {
                        this.dgvSearchResults.Rows[i].Cells[this.dgvcSearchResultsUse.Index].Value = false;
                    }
                }
            }
        }

        private void btnAddSelection_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvr in this.dgvSearchResults.Rows)
            {
                // Only add the batches which are selected and are not used yet
                if (dgvr.Selected && !(bool)dgvr.Cells[dgvcSearchResultsUse.Index].Value)
                {
                    // This calls the dgvSearchResults_CellValueChanged event which will take care of the adding
                    dgvr.Cells[this.dgvcSearchResultsUse.Index].Value = true;
                }
            }
        }

        private void btnResetSelection_Click(object sender, EventArgs e)
        {
            // This doesn't need to use the Observer pattern, since we're removing all rows, or changing the value for all rows
            this.dgvSearchResults.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSearchResults_CellValueChanged);
            resetBatchesLoadInInterface();
            foreach(DataGridViewRow dgvr in this.dgvSearchResults.Rows)
            {
                dgvr.Cells[this.dgvcSearchResultsUse.Index].Value = false;
            }
            this.dgvSearchResults.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSearchResults_CellValueChanged);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.listOfBatchesForInterface = new List<CaptureBatch>();
            this.Hide();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            IList<Domain.CaptureBatch> listOfFoundBatches;

            if (CustomFormValidation.ControlIsValid(this.tlpConditions))
            {
                resetBatchesSearchResults();

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

                listOfFoundBatches = queryCriteria.List<Domain.CaptureBatch>();

                if (listOfFoundBatches.Count == 0)
                {
                    MessageBox.Show("No batches were found using the search criteria.");
                }
                else
                {
                    foreach (Domain.CaptureBatch oneBatch in listOfFoundBatches)
                    {
                        AddBatchInSearchResultsList(oneBatch);
                    }

                    // Add the "use" check on the batches in the search Results that are already in the LoadInInterface section
                    this.dgvSearchResults.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSearchResults_CellValueChanged);
                    foreach (Domain.CaptureBatch oneBatch in listOfBatchesForInterface)
                    {
                        foreach (DataGridViewRow dgvr in this.dgvSearchResults.Rows)
                        {
                            if (Convert.ToInt32(dgvr.Cells[BATCH_SEQ_COLUMN].Value) == oneBatch.Batch_Seq)
                            {
                                dgvr.Cells[this.dgvcSearchResultsUse.Index].Value = true;
                            }
                        }
                    }
                    this.dgvSearchResults.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSearchResults_CellValueChanged);
                }
            }

        }

        #endregion















        class CaptureBatchEvent
        {
            public enum AddOrRemoveMode
            {
                ADD,
                REMOVE
            }

            public Domain.CaptureBatch batch;
            public AddOrRemoveMode addOrRemove;
            public bool blnDefaultUseCheck = false;

            public CaptureBatchEvent(Domain.CaptureBatch p_batch, AddOrRemoveMode p_addOrRemove)
            {
                batch = p_batch;
                addOrRemove = p_addOrRemove;
            }

            public CaptureBatchEvent(Domain.CaptureBatch p_batch, AddOrRemoveMode p_addOrRemove, bool p_blnDefaultUseCheck)
            {
                batch = p_batch;
                addOrRemove = p_addOrRemove;
                blnDefaultUseCheck = p_blnDefaultUseCheck;
            }
        }


        class ListOfBatchesObserver : MyObserver
        {
            public DataGridView dgv;

            public ListOfBatchesObserver(string name)
                : base(name) { }

            public override void OnNext(object value)
            {
                CaptureBatchEvent batchEvent;
                Domain.CaptureBatch oneBatch;
                CaptureBatchEvent.AddOrRemoveMode addOrRemove;
                bool blnUse;

                if (dgv == null)
                {
                    throw new Exception("DataGridView was not initialized in observer '" + this.Name + "'.");
                }
                else
                {
                    batchEvent = value as CaptureBatchEvent;
                    if (batchEvent == null)
                    {
                        throw new Exception("Observer '" + this.Name + "' received an invalid object, should be a CaptureBatchEvent.");
                    }
                    else
                    {
                        oneBatch = batchEvent.batch;
                        addOrRemove = batchEvent.addOrRemove;
                        blnUse = batchEvent.blnDefaultUseCheck;

                        if (addOrRemove == CaptureBatchEvent.AddOrRemoveMode.ADD)
                        {
                            dgv.Rows.Add(
                                oneBatch.statement.Statement_Id,
                                oneBatch.Capture_Date,
                                oneBatch.Batch_Seq,
                                oneBatch.Capture_Id,
                                oneBatch.captureBatchSummary.Tot_Num_Payments + oneBatch.captureBatchSummary.Tot_Num_Statements,
                                blnUse);
                        }
                        else if (addOrRemove == CaptureBatchEvent.AddOrRemoveMode.REMOVE)
                        {
                            DataGridViewRow rowToRemove = null;

                            // Locate the batch in the interface dgv
                            for (int i = 0; i < dgv.Rows.Count && rowToRemove == null; i++)
                            {
                                if (Convert.ToInt32(dgv.Rows[i].Cells[BATCH_SEQ_COLUMN].Value) == oneBatch.Batch_Seq)
                                { 
                                    rowToRemove = dgv.Rows[i];
                                    dgv.Rows.Remove(rowToRemove);
                                }
                            }

                        } // addOrRemove
                    } // if (batchEvent == null) - else
                } // if (dgv == null)

            } // void OnNext

        } // class ListOfBatchesObserver







    }
}
