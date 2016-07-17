namespace ImageExtract
{
    partial class DialogLoadExampleImages
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.dgvLoadInInterface = new System.Windows.Forms.DataGridView();
            this.dgvcLoadStatementId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcLoadCaptureDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcLoadBatchSeq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcLoadBatchType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcLoadNumberOfItems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcLoadUse = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tlpConditions = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.vtbCaptureDateLesserThan = new CustomControls.ValidatedTextBox();
            this.vtbBatchSeqLesserThan = new CustomControls.ValidatedTextBox();
            this.vtbStatementIdEquals = new CustomControls.ValidatedTextBox();
            this.vtbCaptureDateGreaterThan = new CustomControls.ValidatedTextBox();
            this.vtbBatchSeqGreaterThan = new CustomControls.ValidatedTextBox();
            this.dgvSearchResults = new System.Windows.Forms.DataGridView();
            this.dgvcSearchResultsStatementId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcSearchResultsCaptureDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcSearchResultsBatchSeq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcSearchResultsCaptureId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcSearchResultsNumberOfItems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcSearchResultsUse = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddSelection = new System.Windows.Forms.Button();
            this.btnResetSelection = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoadInInterface)).BeginInit();
            this.tlpConditions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchResults)).BeginInit();
            this.tlpButtons.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.dgvLoadInInterface, 0, 5);
            this.tlpMain.Controls.Add(this.tlpConditions, 0, 0);
            this.tlpMain.Controls.Add(this.dgvSearchResults, 0, 2);
            this.tlpMain.Controls.Add(this.tlpButtons, 0, 6);
            this.tlpMain.Controls.Add(this.label5, 0, 1);
            this.tlpMain.Controls.Add(this.label6, 0, 4);
            this.tlpMain.Controls.Add(this.tableLayoutPanel1, 0, 3);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 7;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpMain.Size = new System.Drawing.Size(482, 628);
            this.tlpMain.TabIndex = 0;
            // 
            // dgvLoadInInterface
            // 
            this.dgvLoadInInterface.AllowUserToAddRows = false;
            this.dgvLoadInInterface.AllowUserToDeleteRows = false;
            this.dgvLoadInInterface.AllowUserToResizeColumns = false;
            this.dgvLoadInInterface.AllowUserToResizeRows = false;
            this.dgvLoadInInterface.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLoadInInterface.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcLoadStatementId,
            this.dgvcLoadCaptureDate,
            this.dgvcLoadBatchSeq,
            this.dgvcLoadBatchType,
            this.dgvcLoadNumberOfItems,
            this.dgvcLoadUse});
            this.dgvLoadInInterface.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLoadInInterface.Location = new System.Drawing.Point(3, 436);
            this.dgvLoadInInterface.Name = "dgvLoadInInterface";
            this.dgvLoadInInterface.RowHeadersVisible = false;
            this.dgvLoadInInterface.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoadInInterface.Size = new System.Drawing.Size(476, 128);
            this.dgvLoadInInterface.TabIndex = 7;
            this.dgvLoadInInterface.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_CellMouseUp);
            // 
            // dgvcLoadStatementId
            // 
            this.dgvcLoadStatementId.HeaderText = "Statement ID";
            this.dgvcLoadStatementId.Name = "dgvcLoadStatementId";
            this.dgvcLoadStatementId.Width = 80;
            // 
            // dgvcLoadCaptureDate
            // 
            this.dgvcLoadCaptureDate.HeaderText = "Capture Date";
            this.dgvcLoadCaptureDate.Name = "dgvcLoadCaptureDate";
            this.dgvcLoadCaptureDate.Width = 80;
            // 
            // dgvcLoadBatchSeq
            // 
            this.dgvcLoadBatchSeq.HeaderText = "Batch Seq";
            this.dgvcLoadBatchSeq.Name = "dgvcLoadBatchSeq";
            this.dgvcLoadBatchSeq.Width = 70;
            // 
            // dgvcLoadBatchType
            // 
            this.dgvcLoadBatchType.HeaderText = "Batch Type";
            this.dgvcLoadBatchType.Name = "dgvcLoadBatchType";
            this.dgvcLoadBatchType.Width = 120;
            // 
            // dgvcLoadNumberOfItems
            // 
            this.dgvcLoadNumberOfItems.HeaderText = "Num. of items";
            this.dgvcLoadNumberOfItems.Name = "dgvcLoadNumberOfItems";
            this.dgvcLoadNumberOfItems.Width = 80;
            // 
            // dgvcLoadUse
            // 
            this.dgvcLoadUse.HeaderText = "Use";
            this.dgvcLoadUse.Name = "dgvcLoadUse";
            this.dgvcLoadUse.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcLoadUse.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvcLoadUse.Width = 40;
            // 
            // tlpConditions
            // 
            this.tlpConditions.ColumnCount = 4;
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpConditions.Controls.Add(this.label7, 0, 2);
            this.tlpConditions.Controls.Add(this.label2, 2, 0);
            this.tlpConditions.Controls.Add(this.label1, 0, 0);
            this.tlpConditions.Controls.Add(this.label4, 0, 1);
            this.tlpConditions.Controls.Add(this.label3, 2, 1);
            this.tlpConditions.Controls.Add(this.btnSearch, 2, 2);
            this.tlpConditions.Controls.Add(this.vtbCaptureDateLesserThan, 1, 0);
            this.tlpConditions.Controls.Add(this.vtbBatchSeqLesserThan, 1, 1);
            this.tlpConditions.Controls.Add(this.vtbStatementIdEquals, 1, 2);
            this.tlpConditions.Controls.Add(this.vtbCaptureDateGreaterThan, 3, 0);
            this.tlpConditions.Controls.Add(this.vtbBatchSeqGreaterThan, 3, 1);
            this.tlpConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpConditions.Location = new System.Drawing.Point(3, 3);
            this.tlpConditions.Name = "tlpConditions";
            this.tlpConditions.RowCount = 3;
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpConditions.Size = new System.Drawing.Size(476, 89);
            this.tlpConditions.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 64);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = "Statement ID =";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(241, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Capture Date >=";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Capture Date <=";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 35);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Batch Seq <=";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(241, 35);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Batch Seq >=";
            // 
            // btnSearch
            // 
            this.tlpConditions.SetColumnSpan(this.btnSearch, 2);
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.Location = new System.Drawing.Point(316, 58);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(78, 0, 78, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(82, 31);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // vtbCaptureDateLesserThan
            // 
            this.vtbCaptureDateLesserThan.CanBeEmpty = true;
            this.vtbCaptureDateLesserThan.DataType = CustomControls.ValidatedTextBox.StTextBoxDataType.DateFormatYYYYMMDD;
            this.vtbCaptureDateLesserThan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vtbCaptureDateLesserThan.ErrorMessage = "";
            this.vtbCaptureDateLesserThan.Location = new System.Drawing.Point(98, 3);
            this.vtbCaptureDateLesserThan.Name = "vtbCaptureDateLesserThan";
            this.vtbCaptureDateLesserThan.Size = new System.Drawing.Size(137, 20);
            this.vtbCaptureDateLesserThan.TabIndex = 8;
            this.vtbCaptureDateLesserThan.TextBoxName = "Capture Date <";
            // 
            // vtbBatchSeqLesserThan
            // 
            this.vtbBatchSeqLesserThan.CanBeEmpty = true;
            this.vtbBatchSeqLesserThan.DataType = CustomControls.ValidatedTextBox.StTextBoxDataType.PositiveNumeric;
            this.vtbBatchSeqLesserThan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vtbBatchSeqLesserThan.ErrorMessage = "";
            this.vtbBatchSeqLesserThan.Location = new System.Drawing.Point(98, 32);
            this.vtbBatchSeqLesserThan.Name = "vtbBatchSeqLesserThan";
            this.vtbBatchSeqLesserThan.Size = new System.Drawing.Size(137, 20);
            this.vtbBatchSeqLesserThan.TabIndex = 9;
            this.vtbBatchSeqLesserThan.TextBoxName = "Batch Seq <";
            // 
            // vtbStatementIdEquals
            // 
            this.vtbStatementIdEquals.CanBeEmpty = false;
            this.vtbStatementIdEquals.DataType = CustomControls.ValidatedTextBox.StTextBoxDataType.PositiveNumeric;
            this.vtbStatementIdEquals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vtbStatementIdEquals.ErrorMessage = "";
            this.vtbStatementIdEquals.Location = new System.Drawing.Point(98, 61);
            this.vtbStatementIdEquals.Name = "vtbStatementIdEquals";
            this.vtbStatementIdEquals.Size = new System.Drawing.Size(137, 20);
            this.vtbStatementIdEquals.TabIndex = 10;
            this.vtbStatementIdEquals.TextBoxName = "Statement ID =";
            // 
            // vtbCaptureDateGreaterThan
            // 
            this.vtbCaptureDateGreaterThan.CanBeEmpty = true;
            this.vtbCaptureDateGreaterThan.DataType = CustomControls.ValidatedTextBox.StTextBoxDataType.DateFormatYYYYMMDD;
            this.vtbCaptureDateGreaterThan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vtbCaptureDateGreaterThan.ErrorMessage = "";
            this.vtbCaptureDateGreaterThan.Location = new System.Drawing.Point(336, 3);
            this.vtbCaptureDateGreaterThan.Name = "vtbCaptureDateGreaterThan";
            this.vtbCaptureDateGreaterThan.Size = new System.Drawing.Size(137, 20);
            this.vtbCaptureDateGreaterThan.TabIndex = 11;
            this.vtbCaptureDateGreaterThan.TextBoxName = "Capture Date >";
            // 
            // vtbBatchSeqGreaterThan
            // 
            this.vtbBatchSeqGreaterThan.CanBeEmpty = true;
            this.vtbBatchSeqGreaterThan.DataType = CustomControls.ValidatedTextBox.StTextBoxDataType.PositiveNumeric;
            this.vtbBatchSeqGreaterThan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vtbBatchSeqGreaterThan.ErrorMessage = "";
            this.vtbBatchSeqGreaterThan.Location = new System.Drawing.Point(336, 32);
            this.vtbBatchSeqGreaterThan.Name = "vtbBatchSeqGreaterThan";
            this.vtbBatchSeqGreaterThan.Size = new System.Drawing.Size(137, 20);
            this.vtbBatchSeqGreaterThan.TabIndex = 12;
            this.vtbBatchSeqGreaterThan.TextBoxName = "Batch Seq >";
            // 
            // dgvSearchResults
            // 
            this.dgvSearchResults.AllowUserToAddRows = false;
            this.dgvSearchResults.AllowUserToDeleteRows = false;
            this.dgvSearchResults.AllowUserToResizeColumns = false;
            this.dgvSearchResults.AllowUserToResizeRows = false;
            this.dgvSearchResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSearchResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcSearchResultsStatementId,
            this.dgvcSearchResultsCaptureDate,
            this.dgvcSearchResultsBatchSeq,
            this.dgvcSearchResultsCaptureId,
            this.dgvcSearchResultsNumberOfItems,
            this.dgvcSearchResultsUse});
            this.dgvSearchResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSearchResults.Location = new System.Drawing.Point(3, 118);
            this.dgvSearchResults.Name = "dgvSearchResults";
            this.dgvSearchResults.RowHeadersVisible = false;
            this.dgvSearchResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSearchResults.Size = new System.Drawing.Size(476, 244);
            this.dgvSearchResults.TabIndex = 2;
            this.dgvSearchResults.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_CellMouseUp);
            // 
            // dgvcSearchResultsStatementId
            // 
            this.dgvcSearchResultsStatementId.HeaderText = "Statement ID";
            this.dgvcSearchResultsStatementId.Name = "dgvcSearchResultsStatementId";
            this.dgvcSearchResultsStatementId.Width = 80;
            // 
            // dgvcSearchResultsCaptureDate
            // 
            this.dgvcSearchResultsCaptureDate.HeaderText = "Capture Date";
            this.dgvcSearchResultsCaptureDate.Name = "dgvcSearchResultsCaptureDate";
            this.dgvcSearchResultsCaptureDate.Width = 80;
            // 
            // dgvcSearchResultsBatchSeq
            // 
            this.dgvcSearchResultsBatchSeq.HeaderText = "Batch Seq";
            this.dgvcSearchResultsBatchSeq.Name = "dgvcSearchResultsBatchSeq";
            this.dgvcSearchResultsBatchSeq.Width = 70;
            // 
            // dgvcSearchResultsCaptureId
            // 
            this.dgvcSearchResultsCaptureId.HeaderText = "Capture ID";
            this.dgvcSearchResultsCaptureId.Name = "dgvcSearchResultsCaptureId";
            this.dgvcSearchResultsCaptureId.Width = 120;
            // 
            // dgvcSearchResultsNumberOfItems
            // 
            this.dgvcSearchResultsNumberOfItems.HeaderText = "Num. of items";
            this.dgvcSearchResultsNumberOfItems.Name = "dgvcSearchResultsNumberOfItems";
            this.dgvcSearchResultsNumberOfItems.Width = 80;
            // 
            // dgvcSearchResultsUse
            // 
            this.dgvcSearchResultsUse.HeaderText = "Use";
            this.dgvcSearchResultsUse.Name = "dgvcSearchResultsUse";
            this.dgvcSearchResultsUse.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcSearchResultsUse.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvcSearchResultsUse.Width = 40;
            // 
            // tlpButtons
            // 
            this.tlpButtons.ColumnCount = 5;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpButtons.Controls.Add(this.btnOK, 1, 0);
            this.tlpButtons.Controls.Add(this.btnCancel, 3, 0);
            this.tlpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButtons.Location = new System.Drawing.Point(3, 570);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 1;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.Size = new System.Drawing.Size(476, 55);
            this.tlpButtons.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(153, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(72, 48);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(251, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 48);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 100);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Search results:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 418);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(342, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "The following batch images will be loaded in the interface: ";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnAddSelection, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnResetSelection, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 366);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(480, 46);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // btnAddSelection
            // 
            this.btnAddSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddSelection.Location = new System.Drawing.Point(147, 3);
            this.btnAddSelection.Name = "btnAddSelection";
            this.btnAddSelection.Size = new System.Drawing.Size(72, 40);
            this.btnAddSelection.TabIndex = 1;
            this.btnAddSelection.Text = "Add selection";
            this.btnAddSelection.UseVisualStyleBackColor = true;
            this.btnAddSelection.Click += new System.EventHandler(this.btnAddSelection_Click);
            // 
            // btnResetSelection
            // 
            this.btnResetSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnResetSelection.Location = new System.Drawing.Point(260, 3);
            this.btnResetSelection.Name = "btnResetSelection";
            this.btnResetSelection.Size = new System.Drawing.Size(72, 40);
            this.btnResetSelection.TabIndex = 0;
            this.btnResetSelection.Text = "Reset selection";
            this.btnResetSelection.UseCompatibleTextRendering = true;
            this.btnResetSelection.UseVisualStyleBackColor = true;
            this.btnResetSelection.Click += new System.EventHandler(this.btnResetSelection_Click);
            // 
            // DialogLoadExampleImages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 628);
            this.Controls.Add(this.tlpMain);
            this.Name = "DialogLoadExampleImages";
            this.Text = "Load example images";
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoadInInterface)).EndInit();
            this.tlpConditions.ResumeLayout(false);
            this.tlpConditions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchResults)).EndInit();
            this.tlpButtons.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpConditions;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvSearchResults;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.Button btnResetSelection;
        private System.Windows.Forms.Button btnAddSelection;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvLoadInInterface;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch;
        private CustomControls.ValidatedTextBox vtbCaptureDateLesserThan;
        private CustomControls.ValidatedTextBox vtbBatchSeqLesserThan;
        private CustomControls.ValidatedTextBox vtbStatementIdEquals;
        private CustomControls.ValidatedTextBox vtbCaptureDateGreaterThan;
        private CustomControls.ValidatedTextBox vtbBatchSeqGreaterThan;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcSearchResultsStatementId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcSearchResultsCaptureDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcSearchResultsBatchSeq;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcSearchResultsCaptureId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcSearchResultsNumberOfItems;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvcSearchResultsUse;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcLoadStatementId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcLoadCaptureDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcLoadBatchSeq;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcLoadBatchType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcLoadNumberOfItems;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvcLoadUse;
    }
}