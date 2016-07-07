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
        List<ImageInclusionListBoxes> conditionSetListBoxes = new List<ImageInclusionListBoxes>();

        ISession databaseSession;
        MyComboBoxOrListBoxItem noConfigSelected;

        public BaseForm()
        {
            InitializeComponent();

            InitializeImageInclusionTab();

            noConfigSelected = new MyComboBoxOrListBoxItem("(no Image Extract config selected)", -1);
            this.comboChooseImageExtract.Items.Add(noConfigSelected);

            CodeForTakingScreenshots();

            this.comboChooseImageExtract.SelectedIndex = 0;
            //this.comboChooseImageExtract.SelectedIndex = 1;

            this.tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            foreach (TabPage tp in this.tabControl1.TabPages)
            {
                tp.Tag = new TabPageTag();
            }
        }

        public void CodeForTakingScreenshots()
        {
            // Use case 1: choose Image Extract Config
            this.comboChooseImageExtract.Items.Add(new MyComboBoxOrListBoxItem("first Image Extract", 0));
            this.comboChooseImageExtract.Items.Add(new MyComboBoxOrListBoxItem("second Image Extract", 0));

            //btnDeleteConfig.Enabled = false;

            // Use case 2: delete Image Extract Config
            //ImageInclusionListBoxes iilb = conditionSetListBoxes[0];

            //this.listBox1.Items.Add(new MyComboBoxOrListBoxItem("brax", -1));
            conditionSetListBoxes[0].AddToIncludeBox(new MyComboBoxOrListBoxItem("Singles", 0));
        }


        public void InitializeImageInclusionTab()
        {
            // disabled for taking screenshots
            InitializeImageInclusionDataGrid();

            AddOneConditionSet();
            //AddOneConditionSet();
        }

        public void InitializeImageInclusionDataGrid()
        {
            Image img = new Bitmap(@"D:\Cossins\Documents\ETS\LOG792\Images\cheque.tif");

            // Set image last column to width
            this.dgvImageInclusion.Columns[this.dgvcImageInclusionImage.Name].Width =
                this.dgvImageInclusion.Width - 20 -
                this.dgvImageInclusion.Columns[this.dgvcImageInclusionSide.Name].Width -
                this.dgvImageInclusion.Columns[this.dgvcImageInclusionIRef.Name].Width -
                this.dgvImageInclusion.Columns[this.dgvcImageInclusionMPS.Name].Width -
                this.dgvImageInclusion.Columns[this.dgvcImageInclusionBSeq.Name].Width;

            /*
            for (int i = 0; i < 50; i++)
            {
                this.dgvImageInclusion.Rows.Add(256001, (100 + i).ToString(), (i * 100).ToString(), (i % 2 == 0 ? "F" : "R"), null);
                ((DataGridViewImageCell)this.dgvImageInclusion.Rows[i].Cells[this.dgvcImageInclusionImage.Name]).Value = img;
            }*/
        }



        public void AddOneConditionSet()
        {
            ImageInclusionListBoxes oneConditionSet = new ImageInclusionListBoxes();
            conditionSetListBoxes.Add(oneConditionSet);
            this.flpImageInclusionConditionSets.Controls.Add(oneConditionSet);
        }


        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tabControl = (TabControl)sender;

            /*
            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                TabPage currentTab = tabControl.TabPages[i];
                TabPageTag currentTabTag = (TabPageTag)currentTab.Tag;
                if (currentTabTag.mustRepaint)
                {
                    SolidBrush textbrush = (tabControl.Enabled ? new SolidBrush(Color.Black) : new SolidBrush(Color.Gray));
                    Rectangle itemrect = tabControl.GetTabRect(i);
                    StringFormat sf = new StringFormat();
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;

                    e.Graphics.DrawString(currentTab.Text, currentTab.Font, textbrush, itemrect, sf);

                    textbrush.Dispose();

                    currentTabTag.mustRepaint = false;
                }
                
            }
            */

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


        private void dgvImageInclusion_Paint(object sender, PaintEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // Important: changing font color requires dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = (dgv.Enabled ? Color.Black : Color.Gray);

            foreach (DataGridViewRow dgvr in dgv.Rows)
            {
                dgvr.Visible = dgv.Enabled;
            }
        }











        private class MyComboBoxOrListBoxItem
        {
            public string Name;
            public int Value;
            public MyComboBoxOrListBoxItem(string name, int value)
            {
                Name = name; Value = value;
            }
            public override string ToString()
            {
                // Generates the text shown in the combo box
                return Name;
            }
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

            foreach(TabPage tp in this.tabControl1.TabPages)
            {
                tp.Focus();
            }

            tabControl1.SelectedIndex = currentTabIndex;

        }






        private class TabPageTag
        {
            public bool mustRepaint = false;
            public bool containsUnsavedChanges = false;
            public bool validated = true;
        }

        private void cbEnableImageExtractConfiguration_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Once this Image Extract configuration is actived, Image Extracts will start being automatically generated for this client." +
                    "\r\n\r\nWould you like to continue?",
                "Activate this configuration?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            MessageBox.Show(
                "Once this Image Extract configuration is disactived, Image Extracts will no longer be automatically generated for this client." +
                    "\r\n\r\nWould you like to continue?",
                "Disactivate this configuration?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }

        private void btnLoadExampleBatches_Click(object sender, EventArgs e)
        {
            new LoadExampleImages().Show();
        }



    }
}
