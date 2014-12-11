namespace PdfDemo
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pbBottom = new System.Windows.Forms.PictureBox();
            this.btnVB = new System.Windows.Forms.Button();
            this.btnCS = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.pbRight = new System.Windows.Forms.PictureBox();
            this.pbLeft = new System.Windows.Forms.PictureBox();
            this.pbMid = new System.Windows.Forms.PictureBox();
            this.tvSamples = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.lblDescription = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMid)).BeginInit();
            this.SuspendLayout();
            // 
            // pbBottom
            // 
            this.pbBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbBottom.Image = global::PdfDemo.Properties.Resources.Bottom;
            this.pbBottom.Location = new System.Drawing.Point(0, 423);
            this.pbBottom.Name = "pbBottom";
            this.pbBottom.Size = new System.Drawing.Size(721, 8);
            this.pbBottom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBottom.TabIndex = 92;
            this.pbBottom.TabStop = false;
            // 
            // btnVB
            // 
            this.btnVB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVB.BackColor = System.Drawing.Color.Transparent;
            this.btnVB.Enabled = false;
            this.btnVB.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnVB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnVB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnVB.Image = global::PdfDemo.Properties.Resources.@__vb;
            this.btnVB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVB.Location = new System.Drawing.Point(306, 390);
            this.btnVB.Name = "btnVB";
            this.btnVB.Size = new System.Drawing.Size(71, 26);
            this.btnVB.TabIndex = 91;
            this.btnVB.Text = "&VB";
            this.btnVB.UseVisualStyleBackColor = false;
            this.btnVB.Click += new System.EventHandler(this.btnVB_Click);
            // 
            // btnCS
            // 
            this.btnCS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCS.BackColor = System.Drawing.Color.Transparent;
            this.btnCS.Enabled = false;
            this.btnCS.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnCS.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnCS.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCS.Image = global::PdfDemo.Properties.Resources.@__cs;
            this.btnCS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCS.Location = new System.Drawing.Point(229, 390);
            this.btnCS.Name = "btnCS";
            this.btnCS.Size = new System.Drawing.Size(71, 26);
            this.btnCS.TabIndex = 90;
            this.btnCS.Text = "&C#";
            this.btnCS.UseVisualStyleBackColor = false;
            this.btnCS.Click += new System.EventHandler(this.btnCS_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.BackColor = System.Drawing.Color.Transparent;
            this.btnGenerate.Enabled = false;
            this.btnGenerate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnGenerate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnGenerate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGenerate.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerate.Image")));
            this.btnGenerate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerate.Location = new System.Drawing.Point(595, 390);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(119, 26);
            this.btnGenerate.TabIndex = 89;
            this.btnGenerate.Text = "&Generate";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // pbRight
            // 
            this.pbRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbRight.Image = global::PdfDemo.Properties.Resources.Right;
            this.pbRight.Location = new System.Drawing.Point(546, 0);
            this.pbRight.Name = "pbRight";
            this.pbRight.Size = new System.Drawing.Size(175, 56);
            this.pbRight.TabIndex = 29;
            this.pbRight.TabStop = false;
            // 
            // pbLeft
            // 
            this.pbLeft.Image = global::PdfDemo.Properties.Resources.Left;
            this.pbLeft.Location = new System.Drawing.Point(0, 0);
            this.pbLeft.Name = "pbLeft";
            this.pbLeft.Size = new System.Drawing.Size(104, 56);
            this.pbLeft.TabIndex = 28;
            this.pbLeft.TabStop = false;
            // 
            // pbMid
            // 
            this.pbMid.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbMid.Image = global::PdfDemo.Properties.Resources.Mid;
            this.pbMid.Location = new System.Drawing.Point(0, 0);
            this.pbMid.Name = "pbMid";
            this.pbMid.Size = new System.Drawing.Size(721, 56);
            this.pbMid.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMid.TabIndex = 30;
            this.pbMid.TabStop = false;
            // 
            // tvSamples
            // 
            this.tvSamples.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.tvSamples.ImageIndex = 0;
            this.tvSamples.ImageList = this.imageList;
            this.tvSamples.Location = new System.Drawing.Point(5, 62);
            this.tvSamples.Name = "tvSamples";
            this.tvSamples.SelectedImageIndex = 0;
            this.tvSamples.Size = new System.Drawing.Size(218, 356);
            this.tvSamples.TabIndex = 93;
            this.tvSamples.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvSamples_AfterSelect);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Folder_Closed.ico");
            this.imageList.Images.SetKeyName(1, "Pdf.ico");
            this.imageList.Images.SetKeyName(2, "Folder_blue.ico");
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(229, 65);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(0, 13);
            this.lblDescription.TabIndex = 94;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(721, 431);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.tvSamples);
            this.Controls.Add(this.pbBottom);
            this.Controls.Add(this.btnVB);
            this.Controls.Add(this.btnCS);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.pbRight);
            this.Controls.Add(this.pbLeft);
            this.Controls.Add(this.pbMid);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ultimate PDF Demo";
            ((System.ComponentModel.ISupportInitialize)(this.pbBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbRight;
        private System.Windows.Forms.PictureBox pbLeft;
        private System.Windows.Forms.PictureBox pbMid;
        private System.Windows.Forms.Button btnVB;
        private System.Windows.Forms.Button btnCS;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.PictureBox pbBottom;
        private System.Windows.Forms.TreeView tvSamples;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Label lblDescription;

    }
}