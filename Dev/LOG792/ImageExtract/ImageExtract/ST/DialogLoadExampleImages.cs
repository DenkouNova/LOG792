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
        private ISession databaseSession;
        private ICriteria queryCriteria;
        private IList<CaptureBatch> listSearchResultBatches;
        private IList<CaptureBatch> listBatchesForInterface;

        private MyObservable observableSearchResultList = new MyObservable();
        private MyObservable observableBatchesForInterface = new MyObservable();
        private ListOfBatchesObserver observerSearchResultList = new ListOfBatchesObserver("Search results");
        private ListOfBatchesObserver observerBatchesForInterface = new ListOfBatchesObserver("Batches for interface");

        public DialogLoadExampleImages()
        {
            InitializeComponent();

            this.dgvSearchResults.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellValueChanged);

            // this.dgvSearchResults.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellValueChanged);

            listSearchResultBatches = new List<CaptureBatch>();
            listBatchesForInterface = new List<CaptureBatch>();

            observableSearchResultList.Subscribe(observerSearchResultList);
            observableBatchesForInterface.Subscribe(observerBatchesForInterface);
            observerSearchResultList.dgv = this.dgvSearchResults;
            observerBatchesForInterface.dgv = this.dgvLoadInInterface;
        }

        private void AddBatchInSearchResultsList(Domain.CaptureBatch oneBatch)
        {
            listSearchResultBatches.Add(oneBatch);
            observableSearchResultList.NotifyObservers(new CaptureBatchEvent(oneBatch, CaptureBatchEvent.AddOrRemoveMode.ADD));
        }

        #region events
        private void dgv_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            // This will call dgv_CellValueChanged
            if (e.ColumnIndex == this.dgvcSearchResultsUse.Index && e.RowIndex != -1)
            {
                MessageBox.Show("dgv_CellMouseUp");
                this.dgvSearchResults.EndEdit();
            }
        }

        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            MessageBox.Show("dgv_CellValueChanged");
        }

        private void btnAddSelection_Click(object sender, EventArgs e)
        {

        }

        private void btnResetSelection_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            IList<Domain.CaptureBatch> listOfFoundBatches;

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

            public CaptureBatchEvent(Domain.CaptureBatch p_batch, AddOrRemoveMode p_addOrRemove)
            {
                batch = p_batch;
                addOrRemove = p_addOrRemove;
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
                bool blnUse = false;

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

                        if (addOrRemove == CaptureBatchEvent.AddOrRemoveMode.ADD)
                        {
                            this.dgv.Rows.Add(
                            oneBatch.statement.Statement_Id,
                            oneBatch.Capture_Date,
                            oneBatch.Batch_Seq,
                            oneBatch.Capture_Id,
                            oneBatch.captureBatchSummary.Tot_Num_Payments + oneBatch.captureBatchSummary.Tot_Num_Statements,
                            blnUse);
                        }
                        else if (addOrRemove == CaptureBatchEvent.AddOrRemoveMode.REMOVE)
                        {

                        }
                    }
                }

            }
        }





    }
}
