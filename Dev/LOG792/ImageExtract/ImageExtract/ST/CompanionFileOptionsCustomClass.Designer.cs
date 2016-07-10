namespace ImageExtract.ST
{
    partial class CompanionFileOptionsCustomClass
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
            this.cbCustomClass = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbCustomClass
            // 
            this.cbCustomClass.FormattingEnabled = true;
            this.cbCustomClass.Location = new System.Drawing.Point(32, 57);
            this.cbCustomClass.Name = "cbCustomClass";
            this.cbCustomClass.Size = new System.Drawing.Size(204, 21);
            this.cbCustomClass.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Companion file generator custom class";
            // 
            // CompanionFileCustomClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbCustomClass);
            this.Controls.Add(this.label2);
            this.Name = "CompanionFileCustomClass";
            this.Size = new System.Drawing.Size(1005, 523);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCustomClass;
        private System.Windows.Forms.Label label2;
    }
}
