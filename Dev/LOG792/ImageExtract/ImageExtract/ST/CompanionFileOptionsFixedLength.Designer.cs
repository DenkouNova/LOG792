namespace ImageExtract.ST
{
    partial class CompanionFileOptionsFixedLength
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
            this.dgvFixedLengthFields = new System.Windows.Forms.DataGridView();
            this.dgvcCsvFieldsTable = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvcCsvFieldsColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvcPaddingLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcPaddingCharacter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFixedLengthFields)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFixedLengthFields
            // 
            this.dgvFixedLengthFields.AllowUserToResizeColumns = false;
            this.dgvFixedLengthFields.AllowUserToResizeRows = false;
            this.dgvFixedLengthFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFixedLengthFields.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcCsvFieldsTable,
            this.dgvcCsvFieldsColumn,
            this.dgvcPaddingLength,
            this.dgvcPaddingCharacter});
            this.dgvFixedLengthFields.Location = new System.Drawing.Point(14, 47);
            this.dgvFixedLengthFields.Name = "dgvFixedLengthFields";
            this.dgvFixedLengthFields.Size = new System.Drawing.Size(685, 443);
            this.dgvFixedLengthFields.TabIndex = 1;
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
            // dgvcPaddingLength
            // 
            this.dgvcPaddingLength.HeaderText = "Padding length";
            this.dgvcPaddingLength.Name = "dgvcPaddingLength";
            this.dgvcPaddingLength.Width = 120;
            // 
            // dgvcPaddingCharacter
            // 
            this.dgvcPaddingCharacter.HeaderText = "Padding character";
            this.dgvcPaddingCharacter.Name = "dgvcPaddingCharacter";
            this.dgvcPaddingCharacter.Width = 120;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fixed length fields";
            // 
            // CompanionFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvFixedLengthFields);
            this.Name = "CompanionFile";
            this.Size = new System.Drawing.Size(1005, 523);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFixedLengthFields)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFixedLengthFields;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvcCsvFieldsTable;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvcCsvFieldsColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcPaddingLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcPaddingCharacter;
        private System.Windows.Forms.Label label1;
    }
}
