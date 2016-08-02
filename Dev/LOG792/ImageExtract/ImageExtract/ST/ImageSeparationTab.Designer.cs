namespace ImageExtract.ST
{
    partial class ImageSeparationTab
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvImageSeparation = new System.Windows.Forms.DataGridView();
            this.dgvcBSeq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcMPS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcRef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcSide = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.HiddenSortColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcImageNaming = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRefreshFilenames = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNamingPattern = new System.Windows.Forms.TextBox();
            this.dgvSplitOn = new System.Windows.Forms.DataGridView();
            this.dgvcSplitOnColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcSplitUse = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.HiddenString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbTiffBinaryConcat = new System.Windows.Forms.RadioButton();
            this.rbTiffFormatStandard = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImageSeparation)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSplitOn)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvImageSeparation
            // 
            this.dgvImageSeparation.AllowUserToAddRows = false;
            this.dgvImageSeparation.AllowUserToDeleteRows = false;
            this.dgvImageSeparation.AllowUserToResizeColumns = false;
            this.dgvImageSeparation.AllowUserToResizeRows = false;
            this.dgvImageSeparation.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvImageSeparation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvImageSeparation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImageSeparation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcBSeq,
            this.dgvcMPS,
            this.dgvcRef,
            this.dgvcSide,
            this.dgvcImage,
            this.HiddenSortColumn,
            this.dgvcImageNaming});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvImageSeparation.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvImageSeparation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvImageSeparation.EnableHeadersVisualStyles = false;
            this.dgvImageSeparation.Location = new System.Drawing.Point(3, 3);
            this.dgvImageSeparation.Name = "dgvImageSeparation";
            this.dgvImageSeparation.RowHeadersVisible = false;
            this.dgvImageSeparation.RowTemplate.Height = 100;
            this.dgvImageSeparation.RowTemplate.ReadOnly = true;
            this.dgvImageSeparation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvImageSeparation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvImageSeparation.Size = new System.Drawing.Size(594, 582);
            this.dgvImageSeparation.TabIndex = 1;
            this.dgvImageSeparation.Paint += new System.Windows.Forms.PaintEventHandler(this.dgvImageSeparation_Paint);
            // 
            // dgvcBSeq
            // 
            this.dgvcBSeq.HeaderText = "BSeq";
            this.dgvcBSeq.Name = "dgvcBSeq";
            this.dgvcBSeq.Width = 46;
            // 
            // dgvcMPS
            // 
            this.dgvcMPS.HeaderText = "MPS";
            this.dgvcMPS.Name = "dgvcMPS";
            this.dgvcMPS.Width = 35;
            // 
            // dgvcRef
            // 
            this.dgvcRef.HeaderText = "IRef";
            this.dgvcRef.Name = "dgvcRef";
            this.dgvcRef.Width = 35;
            // 
            // dgvcSide
            // 
            this.dgvcSide.HeaderText = "S";
            this.dgvcSide.Name = "dgvcSide";
            this.dgvcSide.Width = 22;
            // 
            // dgvcImage
            // 
            this.dgvcImage.HeaderText = "Image";
            this.dgvcImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dgvcImage.Name = "dgvcImage";
            this.dgvcImage.Width = 200;
            // 
            // HiddenSortColumn
            // 
            this.HiddenSortColumn.HeaderText = "HiddenSortColumn";
            this.HiddenSortColumn.Name = "HiddenSortColumn";
            this.HiddenSortColumn.Visible = false;
            // 
            // dgvcImageNaming
            // 
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcImageNaming.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvcImageNaming.HeaderText = "Image Naming";
            this.dgvcImageNaming.Name = "dgvcImageNaming";
            this.dgvcImageNaming.Width = 200;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 600F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvImageSeparation, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1278, 588);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnRefreshFilenames);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbNamingPattern);
            this.panel1.Controls.Add(this.dgvSplitOn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(613, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(662, 582);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Example result: Image_F_256801.tif";
            // 
            // btnRefreshFilenames
            // 
            this.btnRefreshFilenames.Location = new System.Drawing.Point(398, 22);
            this.btnRefreshFilenames.Name = "btnRefreshFilenames";
            this.btnRefreshFilenames.Size = new System.Drawing.Size(101, 37);
            this.btnRefreshFilenames.TabIndex = 16;
            this.btnRefreshFilenames.Text = "Refresh naming";
            this.btnRefreshFilenames.UseVisualStyleBackColor = true;
            this.btnRefreshFilenames.Click += new System.EventHandler(this.btnRefreshFilenames_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(369, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Example naming: Image_($IMAGE_SIDE, F, 1, R, 2, 3)_($BATCH_SEQ, 8).tif";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Naming pattern";
            // 
            // tbNamingPattern
            // 
            this.tbNamingPattern.Location = new System.Drawing.Point(16, 31);
            this.tbNamingPattern.Name = "tbNamingPattern";
            this.tbNamingPattern.Size = new System.Drawing.Size(366, 20);
            this.tbNamingPattern.TabIndex = 11;
            // 
            // dgvSplitOn
            // 
            this.dgvSplitOn.AllowUserToAddRows = false;
            this.dgvSplitOn.AllowUserToDeleteRows = false;
            this.dgvSplitOn.AllowUserToResizeColumns = false;
            this.dgvSplitOn.AllowUserToResizeRows = false;
            this.dgvSplitOn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSplitOn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcSplitOnColumn,
            this.dgvcSplitUse,
            this.HiddenString});
            this.dgvSplitOn.Location = new System.Drawing.Point(16, 126);
            this.dgvSplitOn.Name = "dgvSplitOn";
            this.dgvSplitOn.RowHeadersVisible = false;
            this.dgvSplitOn.Size = new System.Drawing.Size(179, 222);
            this.dgvSplitOn.TabIndex = 10;
            this.dgvSplitOn.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSplitOn_CellContentClick);
            this.dgvSplitOn.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSplitOn_CellMouseUp);
            this.dgvSplitOn.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSplitOn_CellValueChanged);
            // 
            // dgvcSplitOnColumn
            // 
            this.dgvcSplitOnColumn.HeaderText = "Split on";
            this.dgvcSplitOnColumn.Name = "dgvcSplitOnColumn";
            this.dgvcSplitOnColumn.ReadOnly = true;
            this.dgvcSplitOnColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcSplitOnColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvcSplitOnColumn.Width = 125;
            // 
            // dgvcSplitUse
            // 
            this.dgvcSplitUse.HeaderText = "Use";
            this.dgvcSplitUse.Name = "dgvcSplitUse";
            this.dgvcSplitUse.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcSplitUse.Width = 50;
            // 
            // HiddenString
            // 
            this.HiddenString.HeaderText = "HiddenString";
            this.HiddenString.Name = "HiddenString";
            this.HiddenString.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rbTiffBinaryConcat);
            this.panel2.Controls.Add(this.rbTiffFormatStandard);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(226, 126);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(194, 95);
            this.panel2.TabIndex = 18;
            // 
            // rbTiffBinaryConcat
            // 
            this.rbTiffBinaryConcat.AutoSize = true;
            this.rbTiffBinaryConcat.Location = new System.Drawing.Point(18, 59);
            this.rbTiffBinaryConcat.Name = "rbTiffBinaryConcat";
            this.rbTiffBinaryConcat.Size = new System.Drawing.Size(149, 17);
            this.rbTiffBinaryConcat.TabIndex = 3;
            this.rbTiffBinaryConcat.Text = "TIFF binary concatenation";
            this.rbTiffBinaryConcat.UseVisualStyleBackColor = true;
            // 
            // rbTiffFormatStandard
            // 
            this.rbTiffFormatStandard.AutoSize = true;
            this.rbTiffFormatStandard.Checked = true;
            this.rbTiffFormatStandard.Location = new System.Drawing.Point(18, 36);
            this.rbTiffFormatStandard.Name = "rbTiffFormatStandard";
            this.rbTiffFormatStandard.Size = new System.Drawing.Size(123, 17);
            this.rbTiffFormatStandard.TabIndex = 2;
            this.rbTiffFormatStandard.TabStop = true;
            this.rbTiffFormatStandard.Text = "TIFF format standard";
            this.rbTiffFormatStandard.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Image format";
            // 
            // ImageSeparationTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ImageSeparationTab";
            this.Size = new System.Drawing.Size(1278, 588);
            ((System.ComponentModel.ISupportInitialize)(this.dgvImageSeparation)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSplitOn)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvImageSeparation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNamingPattern;
        private System.Windows.Forms.DataGridView dgvSplitOn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRefreshFilenames;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcBSeq;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcMPS;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcRef;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcSide;
        private System.Windows.Forms.DataGridViewImageColumn dgvcImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn HiddenSortColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcImageNaming;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcSplitOnColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvcSplitUse;
        private System.Windows.Forms.DataGridViewTextBoxColumn HiddenString;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbTiffBinaryConcat;
        private System.Windows.Forms.RadioButton rbTiffFormatStandard;
        private System.Windows.Forms.Label label1;

    }
}
