namespace ImageExtract
{
    partial class TestImageGenerator
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
            this.label4 = new System.Windows.Forms.Label();
            this.tbMatchedPaymentSeq = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbBatchSeq = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbStatementID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSampleImageFolderPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbItemRef = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbImageSide = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.pbResult = new System.Windows.Forms.PictureBox();
            this.cbNFD = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbSampleImageName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbResult)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Matched_Payment_Seq";
            // 
            // tbMatchedPaymentSeq
            // 
            this.tbMatchedPaymentSeq.Location = new System.Drawing.Point(146, 130);
            this.tbMatchedPaymentSeq.Name = "tbMatchedPaymentSeq";
            this.tbMatchedPaymentSeq.Size = new System.Drawing.Size(377, 20);
            this.tbMatchedPaymentSeq.TabIndex = 14;
            this.tbMatchedPaymentSeq.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Batch_Seq";
            // 
            // tbBatchSeq
            // 
            this.tbBatchSeq.Location = new System.Drawing.Point(146, 104);
            this.tbBatchSeq.Name = "tbBatchSeq";
            this.tbBatchSeq.Size = new System.Drawing.Size(377, 20);
            this.tbBatchSeq.TabIndex = 12;
            this.tbBatchSeq.Text = "256001";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Statement_ID";
            // 
            // tbStatementID
            // 
            this.tbStatementID.Location = new System.Drawing.Point(146, 77);
            this.tbStatementID.Name = "tbStatementID";
            this.tbStatementID.Size = new System.Drawing.Size(377, 20);
            this.tbStatementID.TabIndex = 10;
            this.tbStatementID.Text = "1319";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Sample image folder path";
            // 
            // tbSampleImageFolderPath
            // 
            this.tbSampleImageFolderPath.Location = new System.Drawing.Point(146, 12);
            this.tbSampleImageFolderPath.Name = "tbSampleImageFolderPath";
            this.tbSampleImageFolderPath.Size = new System.Drawing.Size(377, 20);
            this.tbSampleImageFolderPath.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Item_Ref";
            // 
            // tbItemRef
            // 
            this.tbItemRef.Location = new System.Drawing.Point(146, 156);
            this.tbItemRef.Name = "tbItemRef";
            this.tbItemRef.Size = new System.Drawing.Size(377, 20);
            this.tbItemRef.TabIndex = 16;
            this.tbItemRef.Text = "10";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Image Side";
            // 
            // tbImageSide
            // 
            this.tbImageSide.Location = new System.Drawing.Point(146, 182);
            this.tbImageSide.Name = "tbImageSide";
            this.tbImageSide.Size = new System.Drawing.Size(159, 20);
            this.tbImageSide.TabIndex = 18;
            this.tbImageSide.Text = "F";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(210, 228);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(110, 43);
            this.btnGenerate.TabIndex = 20;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // pbResult
            // 
            this.pbResult.Location = new System.Drawing.Point(17, 298);
            this.pbResult.Name = "pbResult";
            this.pbResult.Size = new System.Drawing.Size(516, 216);
            this.pbResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbResult.TabIndex = 21;
            this.pbResult.TabStop = false;
            // 
            // cbNFD
            // 
            this.cbNFD.AutoSize = true;
            this.cbNFD.Location = new System.Drawing.Point(359, 184);
            this.cbNFD.Name = "cbNFD";
            this.cbNFD.Size = new System.Drawing.Size(54, 17);
            this.cbNFD.TabIndex = 23;
            this.cbNFD.Text = "NFD?";
            this.cbNFD.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Sample image name";
            // 
            // tbSampleImageName
            // 
            this.tbSampleImageName.Location = new System.Drawing.Point(146, 41);
            this.tbSampleImageName.Name = "tbSampleImageName";
            this.tbSampleImageName.Size = new System.Drawing.Size(377, 20);
            this.tbSampleImageName.TabIndex = 24;
            // 
            // TestImageGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 526);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbSampleImageName);
            this.Controls.Add(this.cbNFD);
            this.Controls.Add(this.pbResult);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbImageSide);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbItemRef);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbMatchedPaymentSeq);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbBatchSeq);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbStatementID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSampleImageFolderPath);
            this.Name = "TestImageGenerator";
            this.Text = "TestImageGenerator";
            ((System.ComponentModel.ISupportInitialize)(this.pbResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbMatchedPaymentSeq;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbBatchSeq;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbStatementID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSampleImageFolderPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbItemRef;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbImageSide;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.PictureBox pbResult;
        private System.Windows.Forms.CheckBox cbNFD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbSampleImageName;

    }
}