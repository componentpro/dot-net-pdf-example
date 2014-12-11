namespace PdfDemo.Samples.Document
{
    partial class Digital_Signature___Sign_New_PDF
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
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblSignatureType = new System.Windows.Forms.Label();
            this.cbxSignatureType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblSignatureType
            // 
            this.lblSignatureType.AutoSize = true;
            this.lblSignatureType.Location = new System.Drawing.Point(3, 8);
            this.lblSignatureType.Name = "lblSignatureType";
            this.lblSignatureType.Size = new System.Drawing.Size(82, 13);
            this.lblSignatureType.TabIndex = 0;
            this.lblSignatureType.Text = "Signature Type:";
            // 
            // cbxSignatureType
            // 
            this.cbxSignatureType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSignatureType.FormattingEnabled = true;
            this.cbxSignatureType.Items.AddRange(new object[] {
            "Standard",
            "Author"});
            this.cbxSignatureType.Location = new System.Drawing.Point(88, 5);
            this.cbxSignatureType.Name = "cbxSignatureType";
            this.cbxSignatureType.Size = new System.Drawing.Size(121, 21);
            this.cbxSignatureType.TabIndex = 101;
            // 
            // Digital_Signature___Sign_New_PDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbxSignatureType);
            this.Controls.Add(this.lblSignatureType);
            this.Name = "Digital_Signature___Sign_New_PDF";
            this.Size = new System.Drawing.Size(244, 38);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblSignatureType;
        private System.Windows.Forms.ComboBox cbxSignatureType;
    }
}
