namespace PdfDemo.Samples.Modifying_Document
{
    partial class Overlay_Documents
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
            this.btnBrowse2 = new System.Windows.Forms.Button();
            this.lblDocument2 = new System.Windows.Forms.Label();
            this.txtDoc2 = new System.Windows.Forms.TextBox();
            this.lblDoc1 = new System.Windows.Forms.Label();
            this.btnBrowse1 = new System.Windows.Forms.Button();
            this.txtDoc1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnBrowse2
            // 
            this.btnBrowse2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBrowse2.Location = new System.Drawing.Point(272, 30);
            this.btnBrowse2.Name = "btnBrowse2";
            this.btnBrowse2.Size = new System.Drawing.Size(29, 20);
            this.btnBrowse2.TabIndex = 4;
            this.btnBrowse2.Text = "...";
            this.btnBrowse2.UseVisualStyleBackColor = true;
            this.btnBrowse2.Click += new System.EventHandler(this.btnBrowse2_Click);
            // 
            // lblDocument2
            // 
            this.lblDocument2.AutoSize = true;
            this.lblDocument2.Location = new System.Drawing.Point(2, 33);
            this.lblDocument2.Name = "lblDocument2";
            this.lblDocument2.Size = new System.Drawing.Size(68, 13);
            this.lblDocument2.TabIndex = 36;
            this.lblDocument2.Text = "Document 2:";
            // 
            // txtDoc2
            // 
            this.txtDoc2.Location = new System.Drawing.Point(73, 31);
            this.txtDoc2.Name = "txtDoc2";
            this.txtDoc2.Size = new System.Drawing.Size(193, 20);
            this.txtDoc2.TabIndex = 3;
            // 
            // lblDoc1
            // 
            this.lblDoc1.AutoSize = true;
            this.lblDoc1.Location = new System.Drawing.Point(2, 8);
            this.lblDoc1.Name = "lblDoc1";
            this.lblDoc1.Size = new System.Drawing.Size(68, 13);
            this.lblDoc1.TabIndex = 35;
            this.lblDoc1.Text = "Document 1:";
            // 
            // btnBrowse1
            // 
            this.btnBrowse1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBrowse1.Location = new System.Drawing.Point(272, 4);
            this.btnBrowse1.Name = "btnBrowse1";
            this.btnBrowse1.Size = new System.Drawing.Size(29, 20);
            this.btnBrowse1.TabIndex = 2;
            this.btnBrowse1.Text = "...";
            this.btnBrowse1.UseVisualStyleBackColor = true;
            this.btnBrowse1.Click += new System.EventHandler(this.btnBrowse1_Click);
            // 
            // txtDoc1
            // 
            this.txtDoc1.Location = new System.Drawing.Point(73, 5);
            this.txtDoc1.Name = "txtDoc1";
            this.txtDoc1.Size = new System.Drawing.Size(193, 20);
            this.txtDoc1.TabIndex = 1;
            // 
            // Overlay_Documents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBrowse2);
            this.Controls.Add(this.lblDocument2);
            this.Controls.Add(this.txtDoc2);
            this.Controls.Add(this.lblDoc1);
            this.Controls.Add(this.btnBrowse1);
            this.Controls.Add(this.txtDoc1);
            this.Name = "Overlay_Documents";
            this.Size = new System.Drawing.Size(316, 63);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse2;
        private System.Windows.Forms.Label lblDocument2;
        private System.Windows.Forms.TextBox txtDoc2;
        private System.Windows.Forms.Label lblDoc1;
        private System.Windows.Forms.Button btnBrowse1;
        private System.Windows.Forms.TextBox txtDoc1;


    }
}
