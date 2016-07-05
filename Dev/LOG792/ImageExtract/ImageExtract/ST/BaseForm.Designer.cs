namespace ImageExtract.ST
{
    partial class BaseForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageInclusion = new System.Windows.Forms.TabPage();
            this.tlpImageInclusion = new System.Windows.Forms.TableLayoutPanel();
            this.dgvImageInclusion = new System.Windows.Forms.DataGridView();
            this.BSeq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MPS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IRef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Side = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Image = new System.Windows.Forms.DataGridViewImageColumn();
            this.flpImageInclusionConditionSets = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tlpImageInclusionButtons = new System.Windows.Forms.TableLayoutPanel();
            this.flpLoadExampleBatches = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoadExampleBatches = new System.Windows.Forms.Button();
            this.pImageInclusionConditionCategoryButtons = new System.Windows.Forms.Panel();
            this.tlpImageInclusionConditionCategoryButtons = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.flpLoadConditionsButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnConditionCategoryExample = new System.Windows.Forms.Button();
            this.tabPageSeparation = new System.Windows.Forms.TabPage();
            this.tabPageAccompanying = new System.Windows.Forms.TabPage();
            this.tabPageArchive = new System.Windows.Forms.TabPage();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.flpChooseImageExtractConfig = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.comboChooseImageExtract = new System.Windows.Forms.ComboBox();
            this.btnNewConfig = new System.Windows.Forms.Button();
            this.btnDeleteConfig = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageInclusion.SuspendLayout();
            this.tlpImageInclusion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImageInclusion)).BeginInit();
            this.flpImageInclusionConditionSets.SuspendLayout();
            this.tlpImageInclusionButtons.SuspendLayout();
            this.flpLoadExampleBatches.SuspendLayout();
            this.pImageInclusionConditionCategoryButtons.SuspendLayout();
            this.tlpImageInclusionConditionCategoryButtons.SuspendLayout();
            this.flpLoadConditionsButtons.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.flpChooseImageExtractConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageInclusion);
            this.tabControl1.Controls.Add(this.tabPageSeparation);
            this.tabControl1.Controls.Add(this.tabPageAccompanying);
            this.tabControl1.Controls.Add(this.tabPageArchive);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(3, 45);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1292, 620);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // tabPageInclusion
            // 
            this.tabPageInclusion.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageInclusion.Controls.Add(this.tlpImageInclusion);
            this.tabPageInclusion.Location = new System.Drawing.Point(4, 22);
            this.tabPageInclusion.Name = "tabPageInclusion";
            this.tabPageInclusion.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInclusion.Size = new System.Drawing.Size(1284, 594);
            this.tabPageInclusion.TabIndex = 0;
            this.tabPageInclusion.Text = "Image inclusion";
            // 
            // tlpImageInclusion
            // 
            this.tlpImageInclusion.BackColor = System.Drawing.SystemColors.Control;
            this.tlpImageInclusion.ColumnCount = 3;
            this.tlpImageInclusion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tlpImageInclusion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpImageInclusion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpImageInclusion.Controls.Add(this.dgvImageInclusion, 0, 0);
            this.tlpImageInclusion.Controls.Add(this.flpImageInclusionConditionSets, 2, 1);
            this.tlpImageInclusion.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tlpImageInclusion.Controls.Add(this.tlpImageInclusionButtons, 2, 0);
            this.tlpImageInclusion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpImageInclusion.Location = new System.Drawing.Point(3, 3);
            this.tlpImageInclusion.Name = "tlpImageInclusion";
            this.tlpImageInclusion.RowCount = 2;
            this.tlpImageInclusion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tlpImageInclusion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpImageInclusion.Size = new System.Drawing.Size(1278, 588);
            this.tlpImageInclusion.TabIndex = 0;
            // 
            // dgvImageInclusion
            // 
            this.dgvImageInclusion.AllowUserToAddRows = false;
            this.dgvImageInclusion.AllowUserToDeleteRows = false;
            this.dgvImageInclusion.AllowUserToResizeColumns = false;
            this.dgvImageInclusion.AllowUserToResizeRows = false;
            this.dgvImageInclusion.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvImageInclusion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvImageInclusion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImageInclusion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BSeq,
            this.MPS,
            this.IRef,
            this.Side,
            this.Image});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvImageInclusion.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvImageInclusion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvImageInclusion.EnableHeadersVisualStyles = false;
            this.dgvImageInclusion.Location = new System.Drawing.Point(3, 3);
            this.dgvImageInclusion.Name = "dgvImageInclusion";
            this.dgvImageInclusion.RowHeadersVisible = false;
            this.tlpImageInclusion.SetRowSpan(this.dgvImageInclusion, 2);
            this.dgvImageInclusion.RowTemplate.Height = 100;
            this.dgvImageInclusion.RowTemplate.ReadOnly = true;
            this.dgvImageInclusion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvImageInclusion.Size = new System.Drawing.Size(394, 582);
            this.dgvImageInclusion.TabIndex = 0;
            this.dgvImageInclusion.Paint += new System.Windows.Forms.PaintEventHandler(this.dgvImageInclusion_Paint);
            // 
            // BSeq
            // 
            this.BSeq.HeaderText = "BSeq";
            this.BSeq.Name = "BSeq";
            this.BSeq.Width = 46;
            // 
            // MPS
            // 
            this.MPS.HeaderText = "MPS";
            this.MPS.Name = "MPS";
            this.MPS.Width = 35;
            // 
            // IRef
            // 
            this.IRef.HeaderText = "IRef";
            this.IRef.Name = "IRef";
            this.IRef.Width = 35;
            // 
            // Side
            // 
            this.Side.HeaderText = "S";
            this.Side.Name = "Side";
            this.Side.Width = 22;
            // 
            // Image
            // 
            this.Image.HeaderText = "Image";
            this.Image.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Image.Name = "Image";
            this.Image.Width = 200;
            // 
            // flpImageInclusionConditionSets
            // 
            this.flpImageInclusionConditionSets.AutoScroll = true;
            this.flpImageInclusionConditionSets.BackColor = System.Drawing.SystemColors.Control;
            this.flpImageInclusionConditionSets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpImageInclusionConditionSets.Controls.Add(this.label4);
            this.flpImageInclusionConditionSets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpImageInclusionConditionSets.Location = new System.Drawing.Point(416, 116);
            this.flpImageInclusionConditionSets.Margin = new System.Windows.Forms.Padding(6);
            this.flpImageInclusionConditionSets.Name = "flpImageInclusionConditionSets";
            this.flpImageInclusionConditionSets.Size = new System.Drawing.Size(856, 466);
            this.flpImageInclusionConditionSets.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Image condition sets";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(403, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.tlpImageInclusion.SetRowSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(4, 582);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // tlpImageInclusionButtons
            // 
            this.tlpImageInclusionButtons.ColumnCount = 3;
            this.tlpImageInclusionButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpImageInclusionButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpImageInclusionButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpImageInclusionButtons.Controls.Add(this.flpLoadExampleBatches, 0, 0);
            this.tlpImageInclusionButtons.Controls.Add(this.pImageInclusionConditionCategoryButtons, 2, 0);
            this.tlpImageInclusionButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpImageInclusionButtons.Location = new System.Drawing.Point(413, 3);
            this.tlpImageInclusionButtons.Name = "tlpImageInclusionButtons";
            this.tlpImageInclusionButtons.RowCount = 1;
            this.tlpImageInclusionButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpImageInclusionButtons.Size = new System.Drawing.Size(862, 104);
            this.tlpImageInclusionButtons.TabIndex = 4;
            // 
            // flpLoadExampleBatches
            // 
            this.flpLoadExampleBatches.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpLoadExampleBatches.Controls.Add(this.label1);
            this.flpLoadExampleBatches.Controls.Add(this.btnLoadExampleBatches);
            this.flpLoadExampleBatches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpLoadExampleBatches.Location = new System.Drawing.Point(3, 3);
            this.flpLoadExampleBatches.Name = "flpLoadExampleBatches";
            this.flpLoadExampleBatches.Size = new System.Drawing.Size(114, 98);
            this.flpLoadExampleBatches.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Image list options";
            // 
            // btnLoadExampleBatches
            // 
            this.btnLoadExampleBatches.Location = new System.Drawing.Point(3, 26);
            this.btnLoadExampleBatches.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.btnLoadExampleBatches.Name = "btnLoadExampleBatches";
            this.btnLoadExampleBatches.Size = new System.Drawing.Size(106, 50);
            this.btnLoadExampleBatches.TabIndex = 1;
            this.btnLoadExampleBatches.Text = "Load example images";
            this.btnLoadExampleBatches.UseVisualStyleBackColor = true;
            // 
            // pImageInclusionConditionCategoryButtons
            // 
            this.pImageInclusionConditionCategoryButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pImageInclusionConditionCategoryButtons.Controls.Add(this.tlpImageInclusionConditionCategoryButtons);
            this.pImageInclusionConditionCategoryButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pImageInclusionConditionCategoryButtons.Location = new System.Drawing.Point(138, 3);
            this.pImageInclusionConditionCategoryButtons.Name = "pImageInclusionConditionCategoryButtons";
            this.pImageInclusionConditionCategoryButtons.Size = new System.Drawing.Size(721, 98);
            this.pImageInclusionConditionCategoryButtons.TabIndex = 1;
            // 
            // tlpImageInclusionConditionCategoryButtons
            // 
            this.tlpImageInclusionConditionCategoryButtons.ColumnCount = 1;
            this.tlpImageInclusionConditionCategoryButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpImageInclusionConditionCategoryButtons.Controls.Add(this.label2, 0, 0);
            this.tlpImageInclusionConditionCategoryButtons.Controls.Add(this.flpLoadConditionsButtons, 0, 1);
            this.tlpImageInclusionConditionCategoryButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpImageInclusionConditionCategoryButtons.Location = new System.Drawing.Point(0, 0);
            this.tlpImageInclusionConditionCategoryButtons.Name = "tlpImageInclusionConditionCategoryButtons";
            this.tlpImageInclusionConditionCategoryButtons.RowCount = 2;
            this.tlpImageInclusionConditionCategoryButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tlpImageInclusionConditionCategoryButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpImageInclusionConditionCategoryButtons.Size = new System.Drawing.Size(719, 96);
            this.tlpImageInclusionConditionCategoryButtons.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Load conditions";
            // 
            // flpLoadConditionsButtons
            // 
            this.flpLoadConditionsButtons.Controls.Add(this.btnConditionCategoryExample);
            this.flpLoadConditionsButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpLoadConditionsButtons.Location = new System.Drawing.Point(3, 19);
            this.flpLoadConditionsButtons.Name = "flpLoadConditionsButtons";
            this.flpLoadConditionsButtons.Size = new System.Drawing.Size(713, 74);
            this.flpLoadConditionsButtons.TabIndex = 3;
            // 
            // btnConditionCategoryExample
            // 
            this.btnConditionCategoryExample.Location = new System.Drawing.Point(3, 3);
            this.btnConditionCategoryExample.Name = "btnConditionCategoryExample";
            this.btnConditionCategoryExample.Size = new System.Drawing.Size(84, 34);
            this.btnConditionCategoryExample.TabIndex = 0;
            this.btnConditionCategoryExample.Text = "Transaction status";
            this.btnConditionCategoryExample.UseVisualStyleBackColor = true;
            // 
            // tabPageSeparation
            // 
            this.tabPageSeparation.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageSeparation.Location = new System.Drawing.Point(4, 22);
            this.tabPageSeparation.Name = "tabPageSeparation";
            this.tabPageSeparation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSeparation.Size = new System.Drawing.Size(1284, 594);
            this.tabPageSeparation.TabIndex = 1;
            this.tabPageSeparation.Text = "Image separation";
            // 
            // tabPageAccompanying
            // 
            this.tabPageAccompanying.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageAccompanying.Location = new System.Drawing.Point(4, 22);
            this.tabPageAccompanying.Name = "tabPageAccompanying";
            this.tabPageAccompanying.Size = new System.Drawing.Size(1284, 594);
            this.tabPageAccompanying.TabIndex = 2;
            this.tabPageAccompanying.Text = "Accompanying file";
            // 
            // tabPageArchive
            // 
            this.tabPageArchive.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageArchive.Location = new System.Drawing.Point(4, 22);
            this.tabPageArchive.Name = "tabPageArchive";
            this.tabPageArchive.Size = new System.Drawing.Size(1284, 594);
            this.tabPageArchive.TabIndex = 3;
            this.tabPageArchive.Text = "Archive regrouping";
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.flpChooseImageExtractConfig, 0, 0);
            this.tlpMain.Controls.Add(this.tabControl1, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1298, 668);
            this.tlpMain.TabIndex = 1;
            // 
            // flpChooseImageExtractConfig
            // 
            this.flpChooseImageExtractConfig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpChooseImageExtractConfig.Controls.Add(this.label3);
            this.flpChooseImageExtractConfig.Controls.Add(this.comboChooseImageExtract);
            this.flpChooseImageExtractConfig.Controls.Add(this.btnNewConfig);
            this.flpChooseImageExtractConfig.Controls.Add(this.btnDeleteConfig);
            this.flpChooseImageExtractConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpChooseImageExtractConfig.Location = new System.Drawing.Point(1, 1);
            this.flpChooseImageExtractConfig.Margin = new System.Windows.Forms.Padding(1);
            this.flpChooseImageExtractConfig.Name = "flpChooseImageExtractConfig";
            this.flpChooseImageExtractConfig.Size = new System.Drawing.Size(1296, 40);
            this.flpChooseImageExtractConfig.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "Choose Image Extract config";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboChooseImageExtract
            // 
            this.comboChooseImageExtract.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboChooseImageExtract.FormattingEnabled = true;
            this.comboChooseImageExtract.Location = new System.Drawing.Point(170, 8);
            this.comboChooseImageExtract.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.comboChooseImageExtract.Name = "comboChooseImageExtract";
            this.comboChooseImageExtract.Size = new System.Drawing.Size(231, 21);
            this.comboChooseImageExtract.TabIndex = 0;
            this.comboChooseImageExtract.SelectedIndexChanged += new System.EventHandler(this.comboChooseImageExtract_SelectedIndexChanged);
            // 
            // btnNewConfig
            // 
            this.btnNewConfig.Location = new System.Drawing.Point(407, 3);
            this.btnNewConfig.Name = "btnNewConfig";
            this.btnNewConfig.Size = new System.Drawing.Size(93, 32);
            this.btnNewConfig.TabIndex = 1;
            this.btnNewConfig.Text = "New IE config";
            this.btnNewConfig.UseVisualStyleBackColor = true;
            // 
            // btnDeleteConfig
            // 
            this.btnDeleteConfig.Location = new System.Drawing.Point(506, 3);
            this.btnDeleteConfig.Name = "btnDeleteConfig";
            this.btnDeleteConfig.Size = new System.Drawing.Size(91, 32);
            this.btnDeleteConfig.TabIndex = 2;
            this.btnDeleteConfig.Text = "Delete IE config";
            this.btnDeleteConfig.UseVisualStyleBackColor = true;
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 668);
            this.Controls.Add(this.tlpMain);
            this.Name = "BaseForm";
            this.Text = "Configuration d\'Extraction d\'Image";
            this.tabControl1.ResumeLayout(false);
            this.tabPageInclusion.ResumeLayout(false);
            this.tlpImageInclusion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvImageInclusion)).EndInit();
            this.flpImageInclusionConditionSets.ResumeLayout(false);
            this.flpImageInclusionConditionSets.PerformLayout();
            this.tlpImageInclusionButtons.ResumeLayout(false);
            this.flpLoadExampleBatches.ResumeLayout(false);
            this.flpLoadExampleBatches.PerformLayout();
            this.pImageInclusionConditionCategoryButtons.ResumeLayout(false);
            this.tlpImageInclusionConditionCategoryButtons.ResumeLayout(false);
            this.tlpImageInclusionConditionCategoryButtons.PerformLayout();
            this.flpLoadConditionsButtons.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.flpChooseImageExtractConfig.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageInclusion;
        private System.Windows.Forms.TabPage tabPageSeparation;
        private System.Windows.Forms.TabPage tabPageAccompanying;
        private System.Windows.Forms.TabPage tabPageArchive;
        private System.Windows.Forms.TableLayoutPanel tlpImageInclusion;
        private System.Windows.Forms.DataGridView dgvImageInclusion;
        private System.Windows.Forms.DataGridViewTextBoxColumn BSeq;
        private System.Windows.Forms.DataGridViewTextBoxColumn MPS;
        private System.Windows.Forms.DataGridViewTextBoxColumn IRef;
        private System.Windows.Forms.DataGridViewTextBoxColumn Side;
        private System.Windows.Forms.DataGridViewImageColumn Image;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flpImageInclusionConditionSets;
        private System.Windows.Forms.TableLayoutPanel tlpImageInclusionButtons;
        private System.Windows.Forms.FlowLayoutPanel flpLoadExampleBatches;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoadExampleBatches;
        private System.Windows.Forms.TableLayoutPanel tlpImageInclusionConditionCategoryButtons;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flpLoadConditionsButtons;
        private System.Windows.Forms.Button btnConditionCategoryExample;
        private System.Windows.Forms.Panel pImageInclusionConditionCategoryButtons;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.FlowLayoutPanel flpChooseImageExtractConfig;
        private System.Windows.Forms.ComboBox comboChooseImageExtract;
        private System.Windows.Forms.Button btnNewConfig;
        private System.Windows.Forms.Button btnDeleteConfig;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}