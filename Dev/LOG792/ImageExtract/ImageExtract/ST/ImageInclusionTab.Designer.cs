﻿namespace ImageExtract.ST
{
    partial class ImageInclusionTab
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpImageInclusion = new System.Windows.Forms.TableLayoutPanel();
            this.dgvImageInclusion = new System.Windows.Forms.DataGridView();
            this.dgvcImageInclusionBSeq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcImageInclusionMPS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcImageInclusionIRef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcImageInclusionSide = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcImageInclusionImage = new System.Windows.Forms.DataGridViewImageColumn();
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
            this.btnConditionCategory1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tlpImageInclusion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImageInclusion)).BeginInit();
            this.flpImageInclusionConditionSets.SuspendLayout();
            this.tlpImageInclusionButtons.SuspendLayout();
            this.flpLoadExampleBatches.SuspendLayout();
            this.pImageInclusionConditionCategoryButtons.SuspendLayout();
            this.tlpImageInclusionConditionCategoryButtons.SuspendLayout();
            this.flpLoadConditionsButtons.SuspendLayout();
            this.SuspendLayout();
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
            this.tlpImageInclusion.Location = new System.Drawing.Point(0, 0);
            this.tlpImageInclusion.Name = "tlpImageInclusion";
            this.tlpImageInclusion.RowCount = 2;
            this.tlpImageInclusion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tlpImageInclusion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpImageInclusion.Size = new System.Drawing.Size(1278, 588);
            this.tlpImageInclusion.TabIndex = 1;
            // 
            // dgvImageInclusion
            // 
            this.dgvImageInclusion.AllowUserToAddRows = false;
            this.dgvImageInclusion.AllowUserToDeleteRows = false;
            this.dgvImageInclusion.AllowUserToResizeColumns = false;
            this.dgvImageInclusion.AllowUserToResizeRows = false;
            this.dgvImageInclusion.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvImageInclusion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvImageInclusion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImageInclusion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcImageInclusionBSeq,
            this.dgvcImageInclusionMPS,
            this.dgvcImageInclusionIRef,
            this.dgvcImageInclusionSide,
            this.dgvcImageInclusionImage});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvImageInclusion.DefaultCellStyle = dataGridViewCellStyle4;
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
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(830, 19);
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
            this.btnLoadExampleBatches.Click += new System.EventHandler(this.btnLoadExampleBatches_Click);
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
            this.flpLoadConditionsButtons.Controls.Add(this.btnConditionCategory1);
            this.flpLoadConditionsButtons.Controls.Add(this.button2);
            this.flpLoadConditionsButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpLoadConditionsButtons.Location = new System.Drawing.Point(3, 19);
            this.flpLoadConditionsButtons.Name = "flpLoadConditionsButtons";
            this.flpLoadConditionsButtons.Size = new System.Drawing.Size(713, 74);
            this.flpLoadConditionsButtons.TabIndex = 3;
            // 
            // btnConditionCategory1
            // 
            this.btnConditionCategory1.Location = new System.Drawing.Point(3, 3);
            this.btnConditionCategory1.Name = "btnConditionCategory1";
            this.btnConditionCategory1.Size = new System.Drawing.Size(84, 34);
            this.btnConditionCategory1.TabIndex = 0;
            this.btnConditionCategory1.Text = "Transaction status";
            this.btnConditionCategory1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(93, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 34);
            this.button2.TabIndex = 1;
            this.button2.Text = "Batch Type";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ImageInclusionTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpImageInclusion);
            this.Name = "ImageInclusionTab";
            this.Size = new System.Drawing.Size(1278, 588);
            this.tlpImageInclusion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvImageInclusion)).EndInit();
            this.flpImageInclusionConditionSets.ResumeLayout(false);
            this.tlpImageInclusionButtons.ResumeLayout(false);
            this.flpLoadExampleBatches.ResumeLayout(false);
            this.flpLoadExampleBatches.PerformLayout();
            this.pImageInclusionConditionCategoryButtons.ResumeLayout(false);
            this.tlpImageInclusionConditionCategoryButtons.ResumeLayout(false);
            this.tlpImageInclusionConditionCategoryButtons.PerformLayout();
            this.flpLoadConditionsButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpImageInclusion;
        private System.Windows.Forms.DataGridView dgvImageInclusion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcImageInclusionBSeq;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcImageInclusionMPS;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcImageInclusionIRef;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcImageInclusionSide;
        private System.Windows.Forms.DataGridViewImageColumn dgvcImageInclusionImage;
        private System.Windows.Forms.FlowLayoutPanel flpImageInclusionConditionSets;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tlpImageInclusionButtons;
        private System.Windows.Forms.FlowLayoutPanel flpLoadExampleBatches;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoadExampleBatches;
        private System.Windows.Forms.Panel pImageInclusionConditionCategoryButtons;
        private System.Windows.Forms.TableLayoutPanel tlpImageInclusionConditionCategoryButtons;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flpLoadConditionsButtons;
        private System.Windows.Forms.Button btnConditionCategory1;
        private System.Windows.Forms.Button button2;
    }
}