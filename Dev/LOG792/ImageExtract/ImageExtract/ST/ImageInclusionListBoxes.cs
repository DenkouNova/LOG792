using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace ImageExtract.ST
{
    public partial class ImageInclusionListBoxes : UserControl
    {

        private HashSet<Domain.ImageExtractCondition> allConditionsInInterface = new HashSet<Domain.ImageExtractCondition>();
        private HashSet<Domain.ImageExtractCondition> conditionsInIncludeBox = new HashSet<Domain.ImageExtractCondition>();
        private HashSet<Domain.ImageExtractCondition> conditionsInUnusedBox = new HashSet<Domain.ImageExtractCondition>();
        private HashSet<Domain.ImageExtractCondition> conditionsInExcludeBox = new HashSet<Domain.ImageExtractCondition>();

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
            AddToBox(oneCondition, this.conditionsInIncludeBox, this.lbInclude);
        }

        public void AddToUnusedBox(Domain.ImageExtractCondition oneCondition)
        {
            AddToBox(oneCondition, this.conditionsInUnusedBox, this.lbUnused);
        }

        public void AddToExcludeBox(Domain.ImageExtractCondition oneCondition)
        {
            AddToBox(oneCondition, this.conditionsInExcludeBox, this.lbExclude);
        }

        private void AddToBox(Domain.ImageExtractCondition p_oneCondition, HashSet<Domain.ImageExtractCondition> p_SetOfConditions, ListBox p_listBoxForAdding)
        {
            if (!this.allConditionsInInterface.Contains(p_oneCondition))
            {
                this.allConditionsInInterface.Add(p_oneCondition);
                p_SetOfConditions.Add(p_oneCondition);
                p_listBoxForAdding.Items.Add(new MyComboBoxOrListBoxItem(p_oneCondition.Description, p_oneCondition));
            }
        }

        private void MoveListOfConditions(ListBox sourceListBox, ListBox destinationListBox, 
            HashSet<Domain.ImageExtractCondition> sourceListOfConditions, HashSet<Domain.ImageExtractCondition> destinationListOfConditions)
        {
            List<MyComboBoxOrListBoxItem> listOfSelectedItems = new List<MyComboBoxOrListBoxItem>();

            foreach (MyComboBoxOrListBoxItem oneItem in sourceListBox.SelectedItems)
                listOfSelectedItems.Add(oneItem);

            foreach (MyComboBoxOrListBoxItem listItem in listOfSelectedItems)
            {
                sourceListBox.Items.Remove(listItem);
                sourceListOfConditions.Remove((Domain.ImageExtractCondition)listItem.Value);

                destinationListBox.Items.Add(listItem);
                destinationListOfConditions.Add((Domain.ImageExtractCondition)listItem.Value);
            }
        }

        private void btnUnusedToInclude_Click(object sender, EventArgs e)
        {
            MoveListOfConditions(this.lbUnused, this.lbInclude, conditionsInUnusedBox, conditionsInIncludeBox);
        }

        private void btnIncludeToUnused_Click(object sender, EventArgs e)
        {
            MoveListOfConditions(this.lbInclude, this.lbUnused, conditionsInIncludeBox, conditionsInUnusedBox);
        }

        private void btnUnusedToExclude_Click(object sender, EventArgs e)
        {
            MoveListOfConditions(this.lbUnused, this.lbExclude, conditionsInUnusedBox, conditionsInExcludeBox);
        }

        private void btnExcludeToUnused_Click(object sender, EventArgs e)
        {
            MoveListOfConditions(this.lbExclude, this.lbUnused, conditionsInExcludeBox, conditionsInUnusedBox);
        }

        private void btnRemoveCondition_Click(object sender, EventArgs e)
        {
            HashSet<MyComboBoxOrListBoxItem> setOfItemsToRemove = new HashSet<MyComboBoxOrListBoxItem>();

            foreach (MyComboBoxOrListBoxItem listItem in this.lbInclude.SelectedItems) setOfItemsToRemove.Add(listItem);
            foreach (MyComboBoxOrListBoxItem listItem in this.lbUnused.SelectedItems) setOfItemsToRemove.Add(listItem);
            foreach (MyComboBoxOrListBoxItem listItem in this.lbExclude.SelectedItems) setOfItemsToRemove.Add(listItem);

            foreach (MyComboBoxOrListBoxItem oneItemToRemove in setOfItemsToRemove)
            {
                this.lbInclude.Items.Remove(oneItemToRemove);
                this.conditionsInIncludeBox.Remove((Domain.ImageExtractCondition)oneItemToRemove.Value);
                this.lbUnused.Items.Remove(oneItemToRemove);
                this.conditionsInUnusedBox.Remove((Domain.ImageExtractCondition)oneItemToRemove.Value);
                this.lbExclude.Items.Remove(oneItemToRemove);
                this.conditionsInExcludeBox.Remove((Domain.ImageExtractCondition)oneItemToRemove.Value);
                this.allConditionsInInterface.Remove((Domain.ImageExtractCondition)oneItemToRemove.Value);
            }
            
        }

    }
}
