namespace ImageExtract.ST
{
    partial class CompanionFileTab
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbCustomFile = new System.Windows.Forms.RadioButton();
            this.rbFixedLengthFieldsFile = new System.Windows.Forms.RadioButton();
            this.rbCSVFile = new System.Windows.Forms.RadioButton();
            this.rbNoAccompanyingFile = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbCustomFile);
            this.panel1.Controls.Add(this.rbFixedLengthFieldsFile);
            this.panel1.Controls.Add(this.rbCSVFile);
            this.panel1.Controls.Add(this.rbNoAccompanyingFile);
            this.panel1.Location = new System.Drawing.Point(13, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(222, 114);
            this.panel1.TabIndex = 0;
            // 
            // rbCustomFile
            // 
            this.rbCustomFile.AutoSize = true;
            this.rbCustomFile.Location = new System.Drawing.Point(18, 82);
            this.rbCustomFile.Name = "rbCustomFile";
            this.rbCustomFile.Size = new System.Drawing.Size(76, 17);
            this.rbCustomFile.TabIndex = 4;
            this.rbCustomFile.Text = "Custom file";
            this.rbCustomFile.UseVisualStyleBackColor = true;
            this.rbCustomFile.CheckedChanged += new System.EventHandler(this.CompanionFileType_CheckedChanged);
            // 
            // rbFixedLengthFieldsFile
            // 
            this.rbFixedLengthFieldsFile.AutoSize = true;
            this.rbFixedLengthFieldsFile.Location = new System.Drawing.Point(18, 59);
            this.rbFixedLengthFieldsFile.Name = "rbFixedLengthFieldsFile";
            this.rbFixedLengthFieldsFile.Size = new System.Drawing.Size(125, 17);
            this.rbFixedLengthFieldsFile.TabIndex = 3;
            this.rbFixedLengthFieldsFile.Text = "Fixed length fields file";
            this.rbFixedLengthFieldsFile.UseVisualStyleBackColor = true;
            this.rbFixedLengthFieldsFile.CheckedChanged += new System.EventHandler(this.CompanionFileType_CheckedChanged);
            // 
            // rbCSVFile
            // 
            this.rbCSVFile.AutoSize = true;
            this.rbCSVFile.Location = new System.Drawing.Point(18, 36);
            this.rbCSVFile.Name = "rbCSVFile";
            this.rbCSVFile.Size = new System.Drawing.Size(174, 17);
            this.rbCSVFile.TabIndex = 2;
            this.rbCSVFile.Text = "Comma-separated values (CSV)";
            this.rbCSVFile.UseVisualStyleBackColor = true;
            this.rbCSVFile.CheckedChanged += new System.EventHandler(this.CompanionFileType_CheckedChanged);
            // 
            // rbNoAccompanyingFile
            // 
            this.rbNoAccompanyingFile.AutoSize = true;
            this.rbNoAccompanyingFile.Checked = true;
            this.rbNoAccompanyingFile.Location = new System.Drawing.Point(18, 13);
            this.rbNoAccompanyingFile.Name = "rbNoAccompanyingFile";
            this.rbNoAccompanyingFile.Size = new System.Drawing.Size(127, 17);
            this.rbNoAccompanyingFile.TabIndex = 1;
            this.rbNoAccompanyingFile.TabStop = true;
            this.rbNoAccompanyingFile.Text = "No accompanying file";
            this.rbNoAccompanyingFile.UseVisualStyleBackColor = true;
            this.rbNoAccompanyingFile.CheckedChanged += new System.EventHandler(this.CompanionFileType_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose companion file type:";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(254, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1005, 523);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(256, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Accompanying file options:";
            // 
            // CompanionFileTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "CompanionFileTab";
            this.Size = new System.Drawing.Size(1278, 588);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbCustomFile;
        private System.Windows.Forms.RadioButton rbFixedLengthFieldsFile;
        private System.Windows.Forms.RadioButton rbCSVFile;
        private System.Windows.Forms.RadioButton rbNoAccompanyingFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
    }
}
