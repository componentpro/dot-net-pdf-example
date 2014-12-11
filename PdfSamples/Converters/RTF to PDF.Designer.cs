namespace PdfDemo.Samples.Converters
{
    partial class RTF_to_PDF
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
            this.inputBox = new System.Windows.Forms.TextBox();
            this.lbRTF = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.rbtMeta = new System.Windows.Forms.RadioButton();
            this.rbtImage = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // inputBox
            // 
            this.inputBox.Location = new System.Drawing.Point(73, 3);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(177, 20);
            this.inputBox.TabIndex = 0;
            // 
            // lbRTF
            // 
            this.lbRTF.AutoSize = true;
            this.lbRTF.Location = new System.Drawing.Point(2, 6);
            this.lbRTF.Name = "lbRTF";
            this.lbRTF.Size = new System.Drawing.Size(68, 13);
            this.lbRTF.TabIndex = 109;
            this.lbRTF.Text = "RTF Source:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBrowse.Location = new System.Drawing.Point(253, 3);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(25, 20);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // rbtMeta
            // 
            this.rbtMeta.AutoSize = true;
            this.rbtMeta.Checked = true;
            this.rbtMeta.Location = new System.Drawing.Point(5, 35);
            this.rbtMeta.Name = "rbtMeta";
            this.rbtMeta.Size = new System.Drawing.Size(110, 17);
            this.rbtMeta.TabIndex = 2;
            this.rbtMeta.TabStop = true;
            this.rbtMeta.Text = "To Metafile object";
            this.rbtMeta.UseVisualStyleBackColor = true;
            // 
            // rbtImage
            // 
            this.rbtImage.AutoSize = true;
            this.rbtImage.Location = new System.Drawing.Point(5, 58);
            this.rbtImage.Name = "rbtImage";
            this.rbtImage.Size = new System.Drawing.Size(102, 17);
            this.rbtImage.TabIndex = 3;
            this.rbtImage.Text = "To Image object";
            this.rbtImage.UseVisualStyleBackColor = true;
            // 
            // RTF_to_PDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rbtImage);
            this.Controls.Add(this.rbtMeta);
            this.Controls.Add(this.inputBox);
            this.Controls.Add(this.lbRTF);
            this.Controls.Add(this.btnBrowse);
            this.Name = "RTF_to_PDF";
            this.Size = new System.Drawing.Size(301, 85);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.Label lbRTF;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.RadioButton rbtMeta;
        private System.Windows.Forms.RadioButton rbtImage;
    }
}
