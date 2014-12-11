namespace PdfDemo.Samples.Modifying_Document
{
    partial class Booklet
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
            this.label6 = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.chkTwoSide = new System.Windows.Forms.CheckBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUrl = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.grbSource = new System.Windows.Forms.GroupBox();
            this.grbPageSettings = new System.Windows.Forms.GroupBox();
            this.grbSource.SuspendLayout();
            this.grbPageSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(216, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 19);
            this.label6.TabIndex = 93;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(301, 18);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(24, 21);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "...";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // chkTwoSide
            // 
            this.chkTwoSide.AutoSize = true;
            this.chkTwoSide.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkTwoSide.Location = new System.Drawing.Point(11, 53);
            this.chkTwoSide.Name = "chkTwoSide";
            this.chkTwoSide.Size = new System.Drawing.Size(90, 18);
            this.chkTwoSide.TabIndex = 5;
            this.chkTwoSide.Text = "Double Side";
            this.chkTwoSide.UseVisualStyleBackColor = true;
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(267, 19);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(58, 20);
            this.txtHeight.TabIndex = 4;
            this.txtHeight.Text = "580";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(80, 19);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(59, 20);
            this.txtWidth.TabIndex = 3;
            this.txtWidth.Text = "595";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Location = new System.Drawing.Point(194, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 88;
            this.label4.Text = "Page Height";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Location = new System.Drawing.Point(11, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 87;
            this.label3.Text = "Page Width";
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUrl.Location = new System.Drawing.Point(11, 22);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(29, 13);
            this.lblUrl.TabIndex = 86;
            this.lblUrl.Text = "URL";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(66, 19);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(232, 20);
            this.txtUrl.TabIndex = 1;
            // 
            // grbSource
            // 
            this.grbSource.Controls.Add(this.txtUrl);
            this.grbSource.Controls.Add(this.lblUrl);
            this.grbSource.Controls.Add(this.btnLoad);
            this.grbSource.Location = new System.Drawing.Point(0, 2);
            this.grbSource.Name = "grbSource";
            this.grbSource.Size = new System.Drawing.Size(338, 54);
            this.grbSource.TabIndex = 94;
            this.grbSource.TabStop = false;
            this.grbSource.Text = "PDF Source";
            // 
            // grbPageSettings
            // 
            this.grbPageSettings.Controls.Add(this.txtWidth);
            this.grbPageSettings.Controls.Add(this.label3);
            this.grbPageSettings.Controls.Add(this.label4);
            this.grbPageSettings.Controls.Add(this.chkTwoSide);
            this.grbPageSettings.Controls.Add(this.txtHeight);
            this.grbPageSettings.Location = new System.Drawing.Point(0, 63);
            this.grbPageSettings.Name = "grbPageSettings";
            this.grbPageSettings.Size = new System.Drawing.Size(338, 80);
            this.grbPageSettings.TabIndex = 95;
            this.grbPageSettings.TabStop = false;
            this.grbPageSettings.Text = "Page Settings";
            // 
            // Booklet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbPageSettings);
            this.Controls.Add(this.grbSource);
            this.Controls.Add(this.label6);
            this.Name = "Booklet";
            this.Size = new System.Drawing.Size(348, 158);
            this.grbSource.ResumeLayout(false);
            this.grbSource.PerformLayout();
            this.grbPageSettings.ResumeLayout(false);
            this.grbPageSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.CheckBox chkTwoSide;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.GroupBox grbSource;
        private System.Windows.Forms.GroupBox grbPageSettings;

    }
}
