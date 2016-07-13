﻿using System;
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

        public LoadExampleImages()
        {
            InitializeComponent();
        }


        #region events
        private void dgvBatches_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


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
            ICriteria queryCriteria;

            if (CustomFormValidation.ControlIsValid(this.tlpConditions))
            {
                databaseSession = NHibernateHelper.GetCurrentSession();
                queryCriteria = databaseSession.CreateCriteria<CaptureBatch>();

                queryCriteria.Add(Restrictions.Eq("Statement_Id", this.vtbStatementIdEquals.Text));
                if (!String.IsNullOrEmpty(this.vtbBatchSeqLesserThan.Text))
                    queryCriteria.Add(Restrictions.Lt("Batch_Seq", this.vtbBatchSeqLesserThan.Text));
                if (!String.IsNullOrEmpty(this.vtbBatchSeqGreaterThan.Text))
                    queryCriteria.Add(Restrictions.Gt("Batch_Seq", this.vtbBatchSeqGreaterThan.Text));
                if (!String.IsNullOrEmpty(this.vtbCaptureDateLesserThan.Text))
                    queryCriteria.Add(Restrictions.Lt("Capture_Date", this.vtbCaptureDateLesserThan.Text));
                if (!String.IsNullOrEmpty(this.vtbCaptureDateGreaterThan.Text))
                    queryCriteria.Add(Restrictions.Gt("Capture_Date", this.vtbCaptureDateGreaterThan.Text));

                IList<Domain.CaptureBatch> listOfBatches = queryCriteria.List<Domain.CaptureBatch>();
                MessageBox.Show("Found " + listOfBatches.Count + " batch(es)");
                foreach (var oneBatch in listOfBatches) MessageBox.Show(oneBatch.ToString());
            }
        }
        #endregion

    }
}