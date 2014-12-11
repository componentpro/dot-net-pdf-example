namespace PdfDemo.Samples.Text
{
    partial class Drawing_Text
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
            this.chkStamp = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkStamp
            // 
            this.chkStamp.AutoSize = true;
            this.chkStamp.Location = new System.Drawing.Point(1, 1);
            this.chkStamp.Name = "chkStamp";
            this.chkStamp.Size = new System.Drawing.Size(56, 17);
            this.chkStamp.TabIndex = 0;
            this.chkStamp.Text = "Stamp";
            this.chkStamp.UseVisualStyleBackColor = true;
            // 
            // Drawing_Text
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkStamp);
            this.Name = "Drawing_Text";
            this.Size = new System.Drawing.Size(282, 186);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkStamp;

    }
}
