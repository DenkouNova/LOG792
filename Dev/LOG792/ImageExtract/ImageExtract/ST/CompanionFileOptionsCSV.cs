using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageExtract.ST
{
    public partial class CompanionFileOptionsCSV : UserControl
    {
        public CompanionFileOptionsCSV()
        {
            InitializeComponent();

            ComboBox cb1 = new ComboBox();
            cb1.Items.Add("CAPTURE_BATCH");
            cb1.Items.Add("ITEM_STATEMENT");
            cb1.Items.Add("ITEM_STATEMENT");

            ComboBox cb2 = new ComboBox();
            cb2.Items.Add("Batch_Seq");
            cb2.Items.Add("Item_Ref");
            cb2.Items.Add("Amount");

            ((DataGridViewComboBoxColumn)this.dgvCsvFields.Columns["dgvcCsvFieldsTable"]).DataSource = cb1.Items;
            ((DataGridViewComboBoxColumn)this.dgvCsvFields.Columns["dgvcCsvFieldsColumn"]).DataSource = cb2.Items;
            
        }
    }
}
