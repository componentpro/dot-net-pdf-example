namespace PdfDemo.Samples.Modifying_Document
{
    partial class Merge_Documents
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtDoc2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowse1 = new System.Windows.Forms.Button();
            this.txtDoc1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnBrowse2
            // 
            this.btnBrowse2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBrowse2.Location = new System.Drawing.Point(316, 30);
            this.btnBrowse2.Name = "btnBrowse2";
            this.btnBrowse2.Size = new System.Drawing.Size(28, 21);
            this.btnBrowse2.TabIndex = 4;
            this.btnBrowse2.Text = "...";
            this.btnBrowse2.UseVisualStyleBackColor = true;
            this.btnBrowse2.Click += new System.EventHandler(this.btnBrowse2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Select another document";
            // 
            // txtDoc2
            // 
            this.txtDoc2.Location = new System.Drawing.Point(135, 31);
            this.txtDoc2.Name = "txtDoc2";
            this.txtDoc2.Size = new System.Drawing.Size(175, 20);
            this.txtDoc2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Select a document";
            // 
            // btnBrowse1
            // 
            this.btnBrowse1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBrowse1.Location = new System.Drawing.Point(316, 4);
            this.btnBrowse1.Name = "btnBrowse1";
            this.btnBrowse1.Size = new System.Drawing.Size(28, 21);
            this.btnBrowse1.TabIndex = 2;
            this.btnBrowse1.Text = "...";
            this.btnBrowse1.UseVisualStyleBackColor = true;
            this.btnBrowse1.Click += new System.EventHandler(this.btnBrowse1_Click);
            // 
            // txtDoc1
            // 
            this.txtDoc1.Location = new System.Drawing.Point(135, 5);
            this.txtDoc1.Name = "txtDoc1";
            this.txtDoc1.Size = new System.Drawing.Size(175, 20);
            this.txtDoc1.TabIndex = 1;
            // 
            // Merge_Documents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBrowse2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDoc2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowse1);
            this.Controls.Add(this.txtDoc1);
            this.Name = "Merge_Documents";
            this.Size = new System.Drawing.Size(359, 67);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDoc2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowse1;
        private System.Windows.Forms.TextBox txtDoc1;


    }
}
