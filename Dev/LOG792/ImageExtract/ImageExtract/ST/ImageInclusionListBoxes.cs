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

        private Dictionary<int, Domain.ImageExtractCondition> allConditionsInInterface;
        private Dictionary<int, Domain.ImageExtractCondition> conditionsInIncludeBox;
        private Dictionary<int, Domain.ImageExtractCondition> conditionsInAllItemsBox;
        private Dictionary<int, Domain.ImageExtractCondition> conditionsInExcludeBox;

        // Currently not used
        // We will need something like this if we want more than one ImageInclusionListBox

        /*
        private bool selected = false;

        public bool Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                this.BackColor = (selected ? System.Drawing.SystemColors.Control : System.Drawing.SystemColors.Highlight);
            }
        }
        */

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

        public void AddToIncludeBox(Domain.ImageExtractCondition oneCondition)
        {
            AddToIncludeBox(new MyComboBoxOrListBoxItem(oneCondition.Description, oneCondition.Condition_Id));
        }

        public void AddToIncludeBox(MyComboBoxOrListBoxItem oneConditionItem)
        {
            AddToBox(oneConditionItem, this.conditionsInIncludeBox, this.lbInclude);
        }

        public void AddToAllItemsBox(Domain.ImageExtractCondition oneCondition)
        {
            AddToAllItemsBox(new MyComboBoxOrListBoxItem(oneCondition.Description, oneCondition.Condition_Id));
        }

        public void AddToAllItemsBox(MyComboBoxOrListBoxItem oneConditionItem)
        {
            AddToBox(oneConditionItem, this.conditionsInAllItemsBox, this.lbAllItems);
        }

        public void AddToExcludeBox(Domain.ImageExtractCondition oneCondition)
        {
            AddToExcludeBox(new MyComboBoxOrListBoxItem(oneCondition.Description, oneCondition.Condition_Id));
        }

        public void AddToExcludeBox(MyComboBoxOrListBoxItem oneConditionItem)
        {
            AddToBox(oneConditionItem, this.conditionsInExcludeBox, this.lbExclude);
        }

        private void AddToBox(MyComboBoxOrListBoxItem p_oneConditionItem, Dictionary<int, Domain.ImageExtractCondition> p_SetOfConditions, ListBox p_listBoxForAdding)
        {
            /*
            if (!this.allConditionsInInterface.ContainsKey(p_oneConditionItem.Value)
            {
                this.allConditionsInInterface.Add(p_oneConditionItem.Value, p_oneConditionItem.);
                p_SetOfConditions.Add(p_oneCondition);
                p_listBoxForAdding.Items.Add(p_oneCondition.Description);
            }
            */
        }

        private void btnUnusedToInclude_Click(object sender, EventArgs e)
        {

        }

        private void btnIncludeToUnused_Click(object sender, EventArgs e)
        {

        }

        private void btnUnusedToExclude_Click(object sender, EventArgs e)
        {

        }

        private void btnExcludeToUnused_Click(object sender, EventArgs e)
        {

        }


    }
}
