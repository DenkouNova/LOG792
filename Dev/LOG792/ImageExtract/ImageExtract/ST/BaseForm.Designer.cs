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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageInclusion = new System.Windows.Forms.TabPage();
            this.tabPageSeparation = new System.Windows.Forms.TabPage();
            this.tabPageCompanion = new System.Windows.Forms.TabPage();
            this.tabPageArchive = new System.Windows.Forms.TabPage();
            this.tabPageOtherOptions = new System.Windows.Forms.TabPage();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.flpChooseImageExtractConfig = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.comboChooseImageExtract = new System.Windows.Forms.ComboBox();
            this.btnNewConfig = new System.Windows.Forms.Button();
            this.btnDeleteConfig = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.flpChooseImageExtractConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageInclusion);
            this.tabControl1.Controls.Add(this.tabPageSeparation);
            this.tabControl1.Controls.Add(this.tabPageCompanion);
            this.tabControl1.Controls.Add(this.tabPageArchive);
            this.tabControl1.Controls.Add(this.tabPageOtherOptions);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(3, 45);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1292, 620);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageInclusion
            // 
            this.tabPageInclusion.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageInclusion.Location = new System.Drawing.Point(4, 22);
            this.tabPageInclusion.Name = "tabPageInclusion";
            this.tabPageInclusion.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInclusion.Size = new System.Drawing.Size(1284, 594);
            this.tabPageInclusion.TabIndex = 0;
            this.tabPageInclusion.Text = "Image inclusion";
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
            // tabPageCompanion
            // 
            this.tabPageCompanion.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageCompanion.Location = new System.Drawing.Point(4, 22);
            this.tabPageCompanion.Name = "tabPageCompanion";
            this.tabPageCompanion.Size = new System.Drawing.Size(1284, 594);
            this.tabPageCompanion.TabIndex = 2;
            this.tabPageCompanion.Text = "Companion file";
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
            // tabPageOtherOptions
            // 
            this.tabPageOtherOptions.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageOtherOptions.Location = new System.Drawing.Point(4, 22);
            this.tabPageOtherOptions.Name = "tabPageOtherOptions";
            this.tabPageOtherOptions.Size = new System.Drawing.Size(1284, 594);
            this.tabPageOtherOptions.TabIndex = 4;
            this.tabPageOtherOptions.Text = "Other options";
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
            this.flpChooseImageExtractConfig.Controls.Add(this.panel1);
            this.flpChooseImageExtractConfig.Controls.Add(this.btnSaveConfig);
            this.flpChooseImageExtractConfig.Controls.Add(this.btnTest);
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
            this.btnNewConfig.Click += new System.EventHandler(this.btnNewConfig_Click);
            // 
            // btnDeleteConfig
            // 
            this.btnDeleteConfig.Location = new System.Drawing.Point(506, 3);
            this.btnDeleteConfig.Name = "btnDeleteConfig";
            this.btnDeleteConfig.Size = new System.Drawing.Size(91, 32);
            this.btnDeleteConfig.TabIndex = 2;
            this.btnDeleteConfig.Text = "Delete IE config";
            this.btnDeleteConfig.UseVisualStyleBackColor = true;
            this.btnDeleteConfig.Click += new System.EventHandler(this.btnDeleteConfig_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(603, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(107, 32);
            this.panel1.TabIndex = 3;
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Location = new System.Drawing.Point(716, 3);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(91, 32);
            this.btnSaveConfig.TabIndex = 4;
            this.btnSaveConfig.Text = "Save IE config";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(813, 3);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(91, 32);
            this.btnTest.TabIndex = 5;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Visible = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 668);
            this.Controls.Add(this.tlpMain);
            this.Name = "BaseForm";
            this.Text = "Image Extract Configuration";
            this.tabControl1.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.flpChooseImageExtractConfig.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageInclusion;
        private System.Windows.Forms.TabPage tabPageSeparation;
        private System.Windows.Forms.TabPage tabPageCompanion;
        private System.Windows.Forms.TabPage tabPageArchive;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.FlowLayoutPanel flpChooseImageExtractConfig;
        private System.Windows.Forms.ComboBox comboChooseImageExtract;
        private System.Windows.Forms.Button btnNewConfig;
        private System.Windows.Forms.Button btnDeleteConfig;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPageOtherOptions;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.Button btnTest;
    }
}