namespace PdfDemo.Samples.Modifying_Document
{
    partial class Stamp_and_Watermark
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtStamp = new System.Windows.Forms.TextBox();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblWastermark = new System.Windows.Forms.Label();
            this.txtWatermark = new System.Windows.Forms.TextBox();
            this.btnWatermarkBrowse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 14);
            this.label3.TabIndex = 34;
            this.label3.Text = "Stamping Text";
            // 
            // txtStamp
            // 
            this.txtStamp.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStamp.Location = new System.Drawing.Point(128, 31);
            this.txtStamp.Name = "txtStamp";
            this.txtStamp.Size = new System.Drawing.Size(202, 20);
            this.txtStamp.TabIndex = 3;
            this.txtStamp.Text = "Demo Application";
            // 
            // txtUrl
            // 
            this.txtUrl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUrl.Location = new System.Drawing.Point(128, 5);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(168, 20);
            this.txtUrl.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 14);
            this.label2.TabIndex = 31;
            this.label2.Text = "Select a PDF document";
            // 
            // btnBrowse
            // 
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBrowse.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(302, 4);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(28, 20);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblWastermark
            // 
            this.lblWastermark.AutoSize = true;
            this.lblWastermark.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWastermark.Location = new System.Drawing.Point(2, 57);
            this.lblWastermark.Name = "lblWastermark";
            this.lblWastermark.Size = new System.Drawing.Size(90, 14);
            this.lblWastermark.TabIndex = 35;
            this.lblWastermark.Text = "Watermark Image";
            // 
            // txtWatermark
            // 
            this.txtWatermark.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWatermark.Location = new System.Drawing.Point(128, 56);
            this.txtWatermark.Name = "txtWatermark";
            this.txtWatermark.Size = new System.Drawing.Size(168, 20);
            this.txtWatermark.TabIndex = 4;
            // 
            // btnWatermarkBrowse
            // 
            this.btnWatermarkBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnWatermarkBrowse.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWatermarkBrowse.Location = new System.Drawing.Point(302, 55);
            this.btnWatermarkBrowse.Name = "btnWatermarkBrowse";
            this.btnWatermarkBrowse.Size = new System.Drawing.Size(28, 20);
            this.btnWatermarkBrowse.TabIndex = 5;
            this.btnWatermarkBrowse.Text = "...";
            this.btnWatermarkBrowse.UseVisualStyleBackColor = true;
            this.btnWatermarkBrowse.Click += new System.EventHandler(this.btnWatermarkBrowse_Click);
            // 
            // Stamp_and_Watermark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnWatermarkBrowse);
            this.Controls.Add(this.txtWatermark);
            this.Controls.Add(this.lblWastermark);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtStamp);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowse);
            this.Name = "Stamp_and_Watermark";
            this.Size = new System.Drawing.Size(341, 89);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStamp;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblWastermark;
        private System.Windows.Forms.TextBox txtWatermark;
        private System.Windows.Forms.Button btnWatermarkBrowse;
    }
}
