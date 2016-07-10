using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace ImageExtract.ST
{
    public partial class ImageInclusionListBoxes : UserControl
    {
        public ImageInclusionListBoxes()
        {
            InitializeComponent();
        }




        public void UnallowRemovalOfConditionSet()
        {
            this.btnRemoveConditionSet.Visible = false;

            // Center the "Add section" button by messing with the margins
            Padding myMargin = btnAddConditionSet.Margin;
            myMargin.Top += btnRemoveConditionSet.Margin.Top + btnRemoveConditionSet.Margin.Bottom + btnRemoveConditionSet.Size.Height / 2;
            this.btnAddConditionSet.Margin = myMargin;
        }

        public void AddToIncludeBox(object o)
        {
            this.lbInclude.Items.Add(o);
        }

        public void AddToAllItemsBox(object o)
        {
            this.lbAllItems.Items.Add(o);
        }

        public void AddToExcludeBox(object o)
        {
            this.lbExclude.Items.Add(o);
        }

        private void btnRemoveAllItems_Click(object sender, EventArgs e)
        {

        }


    }
}
