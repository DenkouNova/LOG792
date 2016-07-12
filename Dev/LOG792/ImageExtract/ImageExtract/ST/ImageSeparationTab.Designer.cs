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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvImageSeparation = new System.Windows.Forms.DataGridView();
            this.dgvcImageInclusionBSeq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcImageInclusionMPS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcImageInclusionIRef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcImageInclusionSide = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcImageInclusionImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dgvSplitOn = new System.Windows.Forms.DataGridView();
            this.dgvcSplitOnColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcSplitOnOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbArchiveFormatTarGz = new System.Windows.Forms.RadioButton();
            this.rbArchiveFormatTar = new System.Windows.Forms.RadioButton();
            this.rbArchiveFormatZip = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvNamingTags = new System.Windows.Forms.DataGridView();
            this.dgvcNamingTagsNameTags1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dgvcNamingTagsNameTags2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dgvcNamingTagsNameTags3 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImageSeparation)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSplitOn)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNamingTags)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvImageSeparation
            // 
            this.dgvImageSeparation.AllowUserToAddRows = false;
            this.dgvImageSeparation.AllowUserToDeleteRows = false;
            this.dgvImageSeparation.AllowUserToResizeColumns = false;
            this.dgvImageSeparation.AllowUserToResizeRows = false;
            this.dgvImageSeparation.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvImageSeparation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvImageSeparation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImageSeparation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcImageInclusionBSeq,
            this.dgvcImageInclusionMPS,
            this.dgvcImageInclusionIRef,
            this.dgvcImageInclusionSide,
            this.dgvcImageInclusionImage});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvImageSeparation.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvImageSeparation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvImageSeparation.Location = new System.Drawing.Point(3, 3);
            this.dgvImageSeparation.Name = "dgvImageSeparation";
            this.dgvImageSeparation.RowHeadersVisible = false;
            this.dgvImageSeparation.RowTemplate.Height = 100;
            this.dgvImageSeparation.RowTemplate.ReadOnly = true;
            this.dgvImageSeparation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvImageSeparation.Size = new System.Drawing.Size(394, 582);
            this.dgvImageSeparation.TabIndex = 1;
            this.dgvImageSeparation.Paint += new System.Windows.Forms.PaintEventHandler(this.dgvImageSeparation_Paint);
            // 
            // dgvcImageInclusionBSeq
            // 
            this.dgvcImageInclusionBSeq.HeaderText = "BSeq";
            this.dgvcImageInclusionBSeq.Name = "dgvcImageInclusionBSeq";
            this.dgvcImageInclusionBSeq.Width = 46;
            // 
            // dgvcImageInclusionMPS
            // 
            this.dgvcImageInclusionMPS.HeaderText = "MPS";
            this.dgvcImageInclusionMPS.Name = "dgvcImageInclusionMPS";
            this.dgvcImageInclusionMPS.Width = 35;
            // 
            // dgvcImageInclusionIRef
            // 
            this.dgvcImageInclusionIRef.HeaderText = "IRef";
            this.dgvcImageInclusionIRef.Name = "dgvcImageInclusionIRef";
            this.dgvcImageInclusionIRef.Width = 35;
            // 
            // dgvcImageInclusionSide
            // 
            this.dgvcImageInclusionSide.HeaderText = "S";
            this.dgvcImageInclusionSide.Name = "dgvcImageInclusionSide";
            this.dgvcImageInclusionSide.Width = 22;
            // 
            // dgvcImageInclusionImage
            // 
            this.dgvcImageInclusionImage.HeaderText = "Image";
            this.dgvcImageInclusionImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dgvcImageInclusionImage.Name = "dgvcImageInclusionImage";
            this.dgvcImageInclusionImage.Width = 200;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvImageSeparation, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1278, 588);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.dgvSplitOn);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dgvNamingTags);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(413, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(862, 582);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(208, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Example naming: Image_001_00256801.tif";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Naming pattern";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Naming tags";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 173);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(453, 20);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "Image_($IMAGE_SIDE, F, 1, R, 2, 3)_($BATCH_SEQ, 8).tif";
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
            this.dgvcSplitOnOrder});
            this.dgvSplitOn.Location = new System.Drawing.Point(16, 271);
            this.dgvSplitOn.Name = "dgvSplitOn";
            this.dgvSplitOn.RowHeadersVisible = false;
            this.dgvSplitOn.Size = new System.Drawing.Size(179, 222);
            this.dgvSplitOn.TabIndex = 10;
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
            // dgvcSplitOnOrder
            // 
            this.dgvcSplitOnOrder.HeaderText = "Order";
            this.dgvcSplitOnOrder.Name = "dgvcSplitOnOrder";
            this.dgvcSplitOnOrder.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcSplitOnOrder.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvcSplitOnOrder.Width = 50;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rbArchiveFormatTarGz);
            this.panel2.Controls.Add(this.rbArchiveFormatTar);
            this.panel2.Controls.Add(this.rbArchiveFormatZip);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(218, 271);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(149, 120);
            this.panel2.TabIndex = 9;
            // 
            // rbArchiveFormatTarGz
            // 
            this.rbArchiveFormatTarGz.AutoSize = true;
            this.rbArchiveFormatTarGz.Location = new System.Drawing.Point(18, 82);
            this.rbArchiveFormatTarGz.Name = "rbArchiveFormatTarGz";
            this.rbArchiveFormatTarGz.Size = new System.Drawing.Size(51, 17);
            this.rbArchiveFormatTarGz.TabIndex = 4;
            this.rbArchiveFormatTarGz.Text = "tar.gz";
            this.rbArchiveFormatTarGz.UseVisualStyleBackColor = true;
            // 
            // rbArchiveFormatTar
            // 
            this.rbArchiveFormatTar.AutoSize = true;
            this.rbArchiveFormatTar.Location = new System.Drawing.Point(18, 59);
            this.rbArchiveFormatTar.Name = "rbArchiveFormatTar";
            this.rbArchiveFormatTar.Size = new System.Drawing.Size(37, 17);
            this.rbArchiveFormatTar.TabIndex = 3;
            this.rbArchiveFormatTar.Text = "tar";
            this.rbArchiveFormatTar.UseVisualStyleBackColor = true;
            // 
            // rbArchiveFormatZip
            // 
            this.rbArchiveFormatZip.AutoSize = true;
            this.rbArchiveFormatZip.Checked = true;
            this.rbArchiveFormatZip.Location = new System.Drawing.Point(18, 36);
            this.rbArchiveFormatZip.Name = "rbArchiveFormatZip";
            this.rbArchiveFormatZip.Size = new System.Drawing.Size(38, 17);
            this.rbArchiveFormatZip.TabIndex = 2;
            this.rbArchiveFormatZip.TabStop = true;
            this.rbArchiveFormatZip.Text = "zip";
            this.rbArchiveFormatZip.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Archive format";
            // 
            // dgvNamingTags
            // 
            this.dgvNamingTags.AllowUserToAddRows = false;
            this.dgvNamingTags.AllowUserToDeleteRows = false;
            this.dgvNamingTags.AllowUserToResizeColumns = false;
            this.dgvNamingTags.AllowUserToResizeRows = false;
            this.dgvNamingTags.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvNamingTags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNamingTags.ColumnHeadersVisible = false;
            this.dgvNamingTags.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcNamingTagsNameTags1,
            this.dgvcNamingTagsNameTags2,
            this.dgvcNamingTagsNameTags3});
            this.dgvNamingTags.Location = new System.Drawing.Point(16, 75);
            this.dgvNamingTags.Name = "dgvNamingTags";
            this.dgvNamingTags.ReadOnly = true;
            this.dgvNamingTags.RowHeadersVisible = false;
            this.dgvNamingTags.Size = new System.Drawing.Size(453, 69);
            this.dgvNamingTags.TabIndex = 8;
            // 
            // dgvcNamingTagsNameTags1
            // 
            this.dgvcNamingTagsNameTags1.HeaderText = "NameTags1";
            this.dgvcNamingTagsNameTags1.Name = "dgvcNamingTagsNameTags1";
            this.dgvcNamingTagsNameTags1.ReadOnly = true;
            this.dgvcNamingTagsNameTags1.Width = 150;
            // 
            // dgvcNamingTagsNameTags2
            // 
            this.dgvcNamingTagsNameTags2.HeaderText = "NameTags2";
            this.dgvcNamingTagsNameTags2.Name = "dgvcNamingTagsNameTags2";
            this.dgvcNamingTagsNameTags2.ReadOnly = true;
            this.dgvcNamingTagsNameTags2.Width = 150;
            // 
            // dgvcNamingTagsNameTags3
            // 
            this.dgvcNamingTagsNameTags3.HeaderText = "NameTags3";
            this.dgvcNamingTagsNameTags3.Name = "dgvcNamingTagsNameTags3";
            this.dgvcNamingTagsNameTags3.ReadOnly = true;
            this.dgvcNamingTagsNameTags3.Width = 150;
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvNamingTags)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvImageSeparation;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcImageInclusionBSeq;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcImageInclusionMPS;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcImageInclusionIRef;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcImageInclusionSide;
        private System.Windows.Forms.DataGridViewImageColumn dgvcImageInclusionImage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dgvSplitOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcSplitOnColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcSplitOnOrder;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbArchiveFormatTar;
        private System.Windows.Forms.RadioButton rbArchiveFormatZip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvNamingTags;
        private System.Windows.Forms.DataGridViewButtonColumn dgvcNamingTagsNameTags1;
        private System.Windows.Forms.DataGridViewButtonColumn dgvcNamingTagsNameTags2;
        private System.Windows.Forms.DataGridViewButtonColumn dgvcNamingTagsNameTags3;
        private System.Windows.Forms.RadioButton rbArchiveFormatTarGz;
        private System.Windows.Forms.Label label5;

    }
}
