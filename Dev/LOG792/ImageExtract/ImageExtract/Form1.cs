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

namespace ImageExtract
{
    public partial class Form1 : Form
    {
        ICriteria criteria;
        ISession sess;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            try
            {
                /*
                sess = NHibernateHelper.GetCurrentSession();
                criteria = sess.CreateCriteria<Domain.ImageExtractConditionCategory>();
                IList<Domain.ImageExtractConditionCategory> listOfImageExtractConditionCategories = criteria.List<Domain.ImageExtractConditionCategory>();
                MessageBox.Show("Found " + listOfImageExtractConditionCategories.Count + " image extract condition category/categories");
                foreach (var oneItem in listOfImageExtractConditionCategories) MessageBox.Show(oneItem.ToString());
                sess.Close();
                */

                sess = NHibernateHelper.GetCurrentSession();
                criteria = sess.CreateCriteria<Domain.ImageExtractCondition>();
                IList<Domain.ImageExtractCondition> listOfImageExtractConditions = criteria.List<Domain.ImageExtractCondition>();
                MessageBox.Show("Found " + listOfImageExtractConditions.Count + " image extract condition(s)");
                foreach (var oneItem in listOfImageExtractConditions) MessageBox.Show(oneItem.ToString());
                sess.Close();

                /*
                sess = NHibernateHelper.GetCurrentSession();
                criteria = sess.CreateCriteria<Domain.ImageExtractCondSet>();
                IList<Domain.ImageExtractCondSet> listOfImageExtractConditionSets = criteria.List<Domain.ImageExtractCondSet>();
                MessageBox.Show("Found " + listOfImageExtractConditionSets.Count + " image extract condition set(s)");
                foreach (var oneItem in listOfImageExtractConditionSets) MessageBox.Show(oneItem.ToString());
                sess.Close();
                */

                /*
                sess = NHibernateHelper.GetCurrentSession();
                criteria = sess.CreateCriteria<Domain.ImageExtractArchive>();
                IList<Domain.ImageExtractArchive> listOfImageExtractsArchives = criteria.List<Domain.ImageExtractArchive>();
                MessageBox.Show("Found " + listOfImageExtractsArchives.Count + " image extract archive(s)");
                foreach (var oneItem in listOfImageExtractsArchives) MessageBox.Show(oneItem.ToString());
                sess.Close();
                */

                /*
                sess = NHibernateHelper.GetCurrentSession();
                criteria = sess.CreateCriteria<Domain.ImageExtractConfig>();
                IList<Domain.ImageExtractConfig> listOfImageExtracts = criteria.List<Domain.ImageExtractConfig>();
                MessageBox.Show("Found " + listOfImageExtracts.Count + " image extract(s)");
                foreach (var oneItem in listOfImageExtracts) MessageBox.Show(oneItem.ToString());
                sess.Close();
                */

                /*
                sess = NHibernateHelper.GetCurrentSession();
                criteria = sess.CreateCriteria<ItemStatement>();
                IList<ItemStatement> listOfStatements = criteria.List<ItemStatement>();
                MessageBox.Show("Found " + listOfStatements.Count + " statement(s)");
                foreach (var oneItem in listOfStatements) MessageBox.Show(oneItem.ToString());
                sess.Close();
                */

                /*
                sess = NHibernateHelper.GetCurrentSession();
                criteria = sess.CreateCriteria<ItemPayment>();
                IList<ItemPayment> listOfPayments = criteria.List<ItemPayment>();
                MessageBox.Show("Found " + listOfPayments.Count + " payment(s)");
                foreach (var onePayment in listOfPayments) MessageBox.Show(onePayment.ToString());
                sess.Close();
                */

                /*
                sess = NHibernateHelper.GetCurrentSession();
                criteria = sess.CreateCriteria<MatchedPayment>();
                IList<MatchedPayment> listOfMps = criteria.List<MatchedPayment>();
                MessageBox.Show("Found " + listOfMps.Count + " matched payment(s)");
                foreach (var oneMatchedPayment in listOfMps) MessageBox.Show(oneMatchedPayment.ToString());
                sess.Close();
                */
                
                /*
                sess = NHibernateHelper.GetCurrentSession();
                criteria = sess.CreateCriteria<CaptureSiteDefinition>();
                IList<CaptureSiteDefinition> listOfSites = criteria.List<CaptureSiteDefinition>();
                MessageBox.Show("Found " + listOfSites.Count + " site(s)");
                foreach (var oneSite in listOfSites) MessageBox.Show(oneSite.ToString());
                sess.Close();
                */

                /*
                sess = NHibernateHelper.GetCurrentSession();
                criteria = sess.CreateCriteria<StatementDefinition>();
                IList<StatementDefinition> listOfStatements = criteria.List<StatementDefinition>();
                MessageBox.Show("Found " + listOfStatements.Count + " statement(s)");
                foreach (var oneStatement in listOfStatements) MessageBox.Show(oneStatement.ToString());
                sess.Close();
                */

                /*
                sess = NHibernateHelper.GetCurrentSession();
                criteria = sess.CreateCriteria<CaptureBatch>().Add(Restrictions.Eq("Batch_Seq", 256001));
                IList<CaptureBatch> listOfBatches = criteria.List<CaptureBatch>();
                MessageBox.Show("Found " + listOfBatches.Count + " batch(es)");
                foreach (var oneBatch in listOfBatches) MessageBox.Show(oneBatch.ToString());
                sess.Close();
                */

                Application.Exit();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                if (ex.InnerException != null)
                {
                    Debug.WriteLine(ex.InnerException.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BaseForm myForm = new BaseForm();
            myForm.Show();
        }



    }
}
