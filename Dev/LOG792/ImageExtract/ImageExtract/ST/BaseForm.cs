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

namespace ImageExtract.ST
{
    public partial class BaseForm : Form
    {
        private int NO_CONFIG_SELECTED = -1;

        ISession databaseSession;
        MyComboBoxOrListBoxItem noConfigSelected;

        IList<Domain.ImageExtractConfig> listOfImageExtractConfigs;
        Domain.ImageExtractConfig currentlyDisplayedImageExtractConfig; // used as a pointer to one of the items in listOfImageExtractConfigs

        ImageInclusionTab m_imageInclusionTab;
        ImageSeparationTab m_imageSeparationTab;
        CompanionFileTab m_companionFileTab;
        ImageArchivingTab m_imageArchivingTab;
        OtherOptionsTab m_otherOptionsTab;

        IList<CaptureBatch> batchesShownInPreview = null;

        public BaseForm()
        {
            InitializeComponent();
            this.tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);

            databaseSession = NHibernateHelper.GetCurrentSession();

            ReloadTopSection();

            InitializeTabs();

            //CodeForScreenshots();
        }


        // Called upon a) opening the form, b) deleting an Image Extract Config, or c) choosing not to save a new Image Extract Config
        public void ReloadTopSection()
        {
            listOfImageExtractConfigs = databaseSession.CreateCriteria<Domain.ImageExtractConfig>().List<Domain.ImageExtractConfig>();
            currentlyDisplayedImageExtractConfig = null;

            this.comboChooseImageExtract.Items.Clear();
            this.comboChooseImageExtract.Items.Add(new MyComboBoxOrListBoxItem("(no Image Extract config selected)", NO_CONFIG_SELECTED));
            
            foreach(Domain.ImageExtractConfig iec in listOfImageExtractConfigs)
            {
                this.comboChooseImageExtract.Items.Add(new MyComboBoxOrListBoxItem(iec.Description, iec.ImgExtr_Config_Id));
            }

            this.comboChooseImageExtract.SelectedIndex = 0;
        }


        public void InitializeTabs()
        {
            // Initialize Image Inclusion tab
            m_imageInclusionTab = new ImageInclusionTab();
            this.tabControl1.TabPages[0].Controls.Add(m_imageInclusionTab);
            m_imageInclusionTab.Dock = System.Windows.Forms.DockStyle.Fill;

            m_imageSeparationTab = new ImageSeparationTab();
            this.tabControl1.TabPages[1].Controls.Add(m_imageSeparationTab);
            m_imageSeparationTab.Dock = System.Windows.Forms.DockStyle.Fill;

            // Initialize Companion File tab
            m_companionFileTab = new CompanionFileTab();
            this.tabControl1.TabPages[2].Controls.Add(m_companionFileTab);
            m_companionFileTab.Dock = System.Windows.Forms.DockStyle.Fill;

            // Initialize Image Archiving tab
            m_imageArchivingTab = new ImageArchivingTab();
            this.tabControl1.TabPages[3].Controls.Add(m_imageArchivingTab);
            m_imageArchivingTab.Dock = System.Windows.Forms.DockStyle.Fill;

            // Initialize Other Options tab
            m_otherOptionsTab = new OtherOptionsTab();
            this.tabControl1.TabPages[4].Controls.Add(m_otherOptionsTab);
            m_otherOptionsTab.Dock = System.Windows.Forms.DockStyle.Fill;
        }


        public void CodeForScreenshots()
        {
            // Use case 1: choose Image Extract Config
            this.comboChooseImageExtract.Items.Add(new MyComboBoxOrListBoxItem("first Image Extract", 0));
            this.comboChooseImageExtract.Items.Add(new MyComboBoxOrListBoxItem("second Image Extract", 0));

            //btnDeleteConfig.Enabled = false;

            // Use case 2: delete Image Extract Config
            //ImageInclusionListBoxes iilb = conditionSetListBoxes[0];
        }



        #region events
        private void comboChooseImageExtract_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            bool configFoundInList = false;

            // Tab Control 1, Delete button and Save button are only available if a config is selected
            this.tabControl1.Enabled = this.btnDeleteConfig.Enabled = this.btnSaveConfig.Enabled =
                ((int)(cb.SelectedItem as MyComboBoxOrListBoxItem).Value != NO_CONFIG_SELECTED);

            // If the chosen option isn't "no config selected", remove the "no config selected" choice.
            // We only need that option when entirely reloading the top section, for example at startup
            if ((int)(cb.SelectedItem as MyComboBoxOrListBoxItem).Value != NO_CONFIG_SELECTED)
            {
                cb.Items.Remove(noConfigSelected);
            }

            for (int i = 0; i < this.listOfImageExtractConfigs.Count && !configFoundInList; i++ )
            {
                if ((listOfImageExtractConfigs[i] as ImageExtractConfig).ImgExtr_Config_Id == 
                    (int)(this.comboChooseImageExtract.SelectedItem as MyComboBoxOrListBoxItem).Value)
                {
                    currentlyDisplayedImageExtractConfig = listOfImageExtractConfigs[i] as ImageExtractConfig;
                }
            }
        }


        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tabControl = (TabControl)sender;

            TabPage currentTab = tabControl.TabPages[e.Index];
            SolidBrush textbrush = (tabControl.Enabled ? new SolidBrush(Color.Black) : new SolidBrush(Color.Gray));
            Rectangle itemrect = tabControl.GetTabRect(e.Index);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            e.Graphics.DrawString(currentTab.Text, e.Font, textbrush, itemrect, sf);

            textbrush.Dispose();
        }

        #endregion

        private void btnDeleteConfig_Click(object sender, EventArgs e)
        {
            MyComboBoxOrListBoxItem boxItem = (MyComboBoxOrListBoxItem)this.comboChooseImageExtract.SelectedItem;
            Button b = (Button)sender;
            DialogResult dr;
            string inputString;

            dr = MessageBox.Show("Are you sure you want to delete Image Extract Config '" + boxItem.Name + "'?",
                "Delete?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                inputString = Microsoft.VisualBasic.Interaction.InputBox(
                    "This operation is not undoable. Are you sure you want to delete?\r\n" +
                    "To confirm your choice, type DELETE below and press OK.", "Really delete?", "",
                    this.Location.X + ((this.Size.Width - 370) / 2), this.Location.Y + ((this.Size.Height - 160) / 2));
                if (inputString == "DELETE")
                {

                    MessageBox.Show("Deleted."); // TODO
                    // TODO delete in database
                    listOfImageExtractConfigs.Remove(currentlyDisplayedImageExtractConfig);
                    ReloadTopSection();
                }
                else
                {
                    MessageBox.Show("Cancelled.");
                }
            }
        }












        private void btnTest_Click(object sender, EventArgs e)
        {
            ICriteria criteria;
            ISession sess;

            TestImageGenerator tig = new TestImageGenerator();
            tig.Show();


            /*
            sess = NHibernateHelper.GetCurrentSession();
            criteria = sess.CreateCriteria<Domain.CaptureBatchSummary>();
            IList<Domain.CaptureBatchSummary> listOfCaptureBatchSummaries = criteria.List<Domain.CaptureBatchSummary>();
            MessageBox.Show("Found " + listOfCaptureBatchSummaries.Count + " capture batch summary/summaries");
            foreach (var oneItem in listOfCaptureBatchSummaries) MessageBox.Show(oneItem.ToString());
            sess.Close();
            */

            /*
            sess = NHibernateHelper.GetCurrentSession();
            criteria = sess.CreateCriteria<Domain.ImageExtractConditionCategory>();
            IList<Domain.ImageExtractConditionCategory> listOfImageExtractConditionCategories = criteria.List<Domain.ImageExtractConditionCategory>();
            MessageBox.Show("Found " + listOfImageExtractConditionCategories.Count + " image extract condition category/categories");
            foreach (var oneItem in listOfImageExtractConditionCategories) MessageBox.Show(oneItem.ToString());
            sess.Close();
            */

            /*
            sess = NHibernateHelper.GetCurrentSession();
            criteria = sess.CreateCriteria<Domain.ImageExtractCondition>();
            IList<Domain.ImageExtractCondition> listOfImageExtractConditions = criteria.List<Domain.ImageExtractCondition>();
            MessageBox.Show("Found " + listOfImageExtractConditions.Count + " image extract condition(s)");
            foreach (var oneItem in listOfImageExtractConditions) MessageBox.Show(oneItem.ToString());
            sess.Close();
            */

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

        }

        private void btnNewConfig_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Saved.");
        }


    }
}
