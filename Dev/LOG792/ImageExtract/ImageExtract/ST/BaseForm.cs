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
        MyComboBoxItem noConfigSelected;

        public BaseForm()
        {
            InitializeComponent();

            InitializeImageInclusionTab();

            noConfigSelected = new MyComboBoxItem("(no Image Extract config selected)", -1);
            this.comboChooseImageExtract.Items.Add(noConfigSelected);

            CodeForTakingScreenshots();

            this.comboChooseImageExtract.SelectedIndex = 0;

            this.comboChooseImageExtract.Text = "blah";
            //MessageBox.Show(comboChooseImageExtract.SelectedIndex + "");

                // Combox1.SelectedIndex = Combox1.FindStringExact("test1")
        }

        public void CodeForTakingScreenshots()
        {
            // Use case 1: choose Image Extract Config
            this.comboChooseImageExtract.Items.Add(new MyComboBoxItem("first Image Extract", 0));
            this.comboChooseImageExtract.Items.Add(new MyComboBoxItem("second Image Extract", 0));

            //btnDeleteConfig.Enabled = false;


        }


        public void InitializeImageInclusionTab()
        {
            // disabled for taking screenshots
            //InitializeImageInclusionDataGrid();

            AddOneConditionSet();
            //AddOneConditionSet();
        }

        public void InitializeImageInclusionDataGrid()
        {
            Image img = new Bitmap(@"D:\Cossins\Documents\ETS\LOG792\Images\cheque.tif");

            // Set image last column to width
            this.dgvImageInclusion.Columns["Image"].Width =
                this.dgvImageInclusion.Width - 20 -
                this.dgvImageInclusion.Columns["Side"].Width -
                this.dgvImageInclusion.Columns["IRef"].Width -
                this.dgvImageInclusion.Columns["MPS"].Width -
                this.dgvImageInclusion.Columns["BSeq"].Width;

            for (int i = 0; i < 50; i++)
            {
                this.dgvImageInclusion.Rows.Add(256001, (100 + i).ToString(), (i * 100).ToString(), (i % 2 == 0 ? "F" : "R"), null);
                ((DataGridViewImageCell)this.dgvImageInclusion.Rows[i].Cells["Image"]).Value = img;
            }

            // note: default row height is 22, it is now 100
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
            TabPage currentab = tabControl.TabPages[e.Index];
            SolidBrush textbrush = (tabControl.Enabled ? new SolidBrush(Color.Black) : new SolidBrush(Color.Gray));
            Rectangle itemrect = tabControl.GetTabRect(e.Index);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            e.Graphics.DrawString(currentab.Text, e.Font, textbrush, itemrect, sf);

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











        private class MyComboBoxItem
        {
            public string Name;
            public int Value;
            public MyComboBoxItem(string name, int value)
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
            this.tabControl1.Enabled = ((cb.SelectedItem as MyComboBoxItem).Value != -1);

            if ((cb.SelectedItem as MyComboBoxItem).Value != -1)
            {
                cb.Items.Remove(noConfigSelected);
            }
        }



    }
}
