namespace ImageExtract.ST
{
    partial class CompanionFileOptionsCSV
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvCsvFields = new System.Windows.Forms.DataGridView();
            this.dgvcCsvFieldsTable = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvcCsvFieldsColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvcHeaderText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCsvSeparator = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCsvFields)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCsvFields
            // 
            this.dgvCsvFields.AllowUserToResizeColumns = false;
            this.dgvCsvFields.AllowUserToResizeRows = false;
            this.dgvCsvFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCsvFields.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcCsvFieldsTable,
            this.dgvcCsvFieldsColumn,
            this.dgvcHeaderText});
            this.dgvCsvFields.Location = new System.Drawing.Point(14, 47);
            this.dgvCsvFields.Name = "dgvCsvFields";
            this.dgvCsvFields.Size = new System.Drawing.Size(747, 443);
            this.dgvCsvFields.TabIndex = 0;
            // 
            // dgvcCsvFieldsTable
            // 
            this.dgvcCsvFieldsTable.HeaderText = "Table";
            this.dgvcCsvFieldsTable.Name = "dgvcCsvFieldsTable";
            this.dgvcCsvFieldsTable.ReadOnly = true;
            this.dgvcCsvFieldsTable.Width = 200;
            // 
            // dgvcCsvFieldsColumn
            // 
            this.dgvcCsvFieldsColumn.HeaderText = "Column";
            this.dgvcCsvFieldsColumn.Name = "dgvcCsvFieldsColumn";
            this.dgvcCsvFieldsColumn.ReadOnly = true;
            this.dgvcCsvFieldsColumn.Width = 200;
            // 
            // dgvcHeaderText
            // 
            this.dgvcHeaderText.HeaderText = "Header text";
            this.dgvcHeaderText.Name = "dgvcHeaderText";
            this.dgvcHeaderText.Width = 300;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "CSV Fields";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(779, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "CSV Separator Character";
            // 
            // cbCsvSeparator
            // 
            this.cbCsvSeparator.FormattingEnabled = true;
            this.cbCsvSeparator.Location = new System.Drawing.Point(782, 47);
            this.cbCsvSeparator.Name = "cbCsvSeparator";
            this.cbCsvSeparator.Size = new System.Drawing.Size(204, 21);
            this.cbCsvSeparator.TabIndex = 3;
            // 
            // CompanionFileOptionsCSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbCsvSeparator);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvCsvFields);
            this.Name = "CompanionFileOptionsCSV";
            this.Size = new System.Drawing.Size(1005, 523);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCsvFields)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCsvFields;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvcCsvFieldsTable;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvcCsvFieldsColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcHeaderText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbCsvSeparator;
    }
}
