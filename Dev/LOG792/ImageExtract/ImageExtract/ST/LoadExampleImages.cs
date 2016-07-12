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
            if (CustomFormValidation.ControlIsValid(this.tlpConditions))
            {
                MessageBox.Show("valid");
            }
        }
        #endregion

    }
}
