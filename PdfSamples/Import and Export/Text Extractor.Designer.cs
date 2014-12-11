namespace PdfDemo.Samples.Import_and_Export
{
    partial class Text_Extractor
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
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblPdfSource = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.grbDocument = new System.Windows.Forms.GroupBox();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.grbDocument.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(293, 18);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(24, 21);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblPdfSource
            // 
            this.lblPdfSource.AutoSize = true;
            this.lblPdfSource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPdfSource.Location = new System.Drawing.Point(10, 22);
            this.lblPdfSource.Name = "lblPdfSource";
            this.lblPdfSource.Size = new System.Drawing.Size(68, 13);
            this.lblPdfSource.TabIndex = 90;
            this.lblPdfSource.Text = "PDF Source:";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(81, 19);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(208, 20);
            this.txtUrl.TabIndex = 1;
            // 
            // grbDocument
            // 
            this.grbDocument.Controls.Add(this.txtUrl);
            this.grbDocument.Controls.Add(this.btnBrowse);
            this.grbDocument.Controls.Add(this.lblPdfSource);
            this.grbDocument.Location = new System.Drawing.Point(3, 3);
            this.grbDocument.Name = "grbDocument";
            this.grbDocument.Size = new System.Drawing.Size(329, 53);
            this.grbDocument.TabIndex = 92;
            this.grbDocument.TabStop = false;
            this.grbDocument.Text = "Document Path";
            // 
            // dlgOpen
            // 
            this.dlgOpen.FileName = "openFileDialog1";
            // 
            // Text_Extractor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbDocument);
            this.Name = "Text_Extractor";
            this.Size = new System.Drawing.Size(344, 68);
            this.grbDocument.ResumeLayout(false);
            this.grbDocument.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblPdfSource;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.GroupBox grbDocument;
        private System.Windows.Forms.OpenFileDialog dlgOpen;

    }
}
