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

            /* TODO
            // Initialize Image Separation tab
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
            */
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
                ((cb.SelectedItem as MyComboBoxOrListBoxItem).Value != NO_CONFIG_SELECTED);

            // If the chosen option isn't "no config selected", remove the "no config selected" choice.
            // We only need that option when entirely reloading the top section, for example at startup
            if ((cb.SelectedItem as MyComboBoxOrListBoxItem).Value != NO_CONFIG_SELECTED)
            {
                cb.Items.Remove(noConfigSelected);
            }

            for (int i = 0; i < this.listOfImageExtractConfigs.Count && !configFoundInList; i++ )
            {
                if ((listOfImageExtractConfigs[i] as ImageExtractConfig).ImgExtr_Config_Id == 
                    (this.comboChooseImageExtract.SelectedItem as MyComboBoxOrListBoxItem).Value)
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


    }
}
