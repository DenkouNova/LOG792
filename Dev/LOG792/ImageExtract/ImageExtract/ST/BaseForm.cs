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
        ISession databaseSession;
        MyComboBoxOrListBoxItem noConfigSelected;

        ImageInclusionTab m_imageInclusionTab;
        // Initialize Image Separation tab
        // Initialize Accompanying File tab
        // Initialize Image Archiving tab
        OtherOptionsTab m_otherOptionsTab;


        public BaseForm()
        {
            InitializeComponent();

            noConfigSelected = new MyComboBoxOrListBoxItem("(no Image Extract config selected)", -1);
            this.comboChooseImageExtract.Items.Add(noConfigSelected);

            this.comboChooseImageExtract.SelectedIndex = 0;

            this.tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            foreach (TabPage tp in this.tabControl1.TabPages)
            {
                tp.Tag = new TabPageTag();
            }

            InitializeTopSection();

            InitializeTabs();
        }



        public void InitializeTopSection()
        {

            // Use case 1: choose Image Extract Config
            this.comboChooseImageExtract.Items.Add(new MyComboBoxOrListBoxItem("first Image Extract", 0));
            this.comboChooseImageExtract.Items.Add(new MyComboBoxOrListBoxItem("second Image Extract", 0));

            //btnDeleteConfig.Enabled = false;

            // Use case 2: delete Image Extract Config
            //ImageInclusionListBoxes iilb = conditionSetListBoxes[0];

            
        }


        public void InitializeTabs()
        {
            m_imageInclusionTab = new ImageInclusionTab();
            this.tabControl1.TabPages[0].Controls.Add(m_imageInclusionTab);
            m_imageInclusionTab.Dock = System.Windows.Forms.DockStyle.Fill;
            // Initialize Image Separation tab

            // Initialize Accompanying File tab

            // Initialize Image Archiving tab

            // Initialize Other Options tab
            m_otherOptionsTab = new OtherOptionsTab();
            this.tabControl1.TabPages[4].Controls.Add(m_otherOptionsTab);
        }





        private void comboChooseImageExtract_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            this.tabControl1.Enabled = ((cb.SelectedItem as MyComboBoxOrListBoxItem).Value != -1);

            if ((cb.SelectedItem as MyComboBoxOrListBoxItem).Value != -1)
            {
                cb.Items.Remove(noConfigSelected);
            }

            int currentTabIndex = this.tabControl1.SelectedIndex;

            foreach (TabPage tp in this.tabControl1.TabPages)
            {
                tp.Focus();
            }

            tabControl1.SelectedIndex = currentTabIndex;

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

            Debug.WriteLine(e.Index);

            textbrush.Dispose();
        }





        private class TabPageTag
        {
            public bool mustRepaint = false;
            public bool containsUnsavedChanges = false;
            public bool validated = true;
        }


    }
}
