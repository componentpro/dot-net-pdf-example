namespace PdfDemo.Samples.Converters
{
    partial class HTML_to_PDF
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
            this.chkFooter = new System.Windows.Forms.CheckBox();
            this.chkHeader = new System.Windows.Forms.CheckBox();
            this.chkHyperlink = new System.Windows.Forms.CheckBox();
            this.chk_TextBreak = new System.Windows.Forms.CheckBox();
            this.chkJavaScript = new System.Windows.Forms.CheckBox();
            this.cbxPageRotation = new System.Windows.Forms.ComboBox();
            this.lblRot = new System.Windows.Forms.Label();
            this.rdoLandscape = new System.Windows.Forms.RadioButton();
            this.rdoPortrait = new System.Windows.Forms.RadioButton();
            this.grbPageSettings = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdoWidth = new System.Windows.Forms.RadioButton();
            this.rdoHeight = new System.Windows.Forms.RadioButton();
            this.lblOrt = new System.Windows.Forms.Label();
            this.lblRatio = new System.Windows.Forms.Label();
            this.nudMargin = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.rdbMetafile = new System.Windows.Forms.RadioButton();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.rdbBitmap = new System.Windows.Forms.RadioButton();
            this.grbDocument = new System.Windows.Forms.GroupBox();
            this.chkPageBreak = new System.Windows.Forms.CheckBox();
            this.chkPDFA1 = new System.Windows.Forms.CheckBox();
            this.lblConvert = new System.Windows.Forms.Label();
            this.grbUrl = new System.Windows.Forms.GroupBox();
            this.grbPageSettings.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMargin)).BeginInit();
            this.grbDocument.SuspendLayout();
            this.grbUrl.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkFooter
            // 
            this.chkFooter.AutoSize = true;
            this.chkFooter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkFooter.Location = new System.Drawing.Point(121, 65);
            this.chkFooter.Name = "chkFooter";
            this.chkFooter.Size = new System.Drawing.Size(92, 18);
            this.chkFooter.TabIndex = 13;
            this.chkFooter.Text = "Show Footer";
            this.chkFooter.UseVisualStyleBackColor = true;
            // 
            // chkHeader
            // 
            this.chkHeader.AutoSize = true;
            this.chkHeader.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkHeader.Location = new System.Drawing.Point(12, 65);
            this.chkHeader.Name = "chkHeader";
            this.chkHeader.Size = new System.Drawing.Size(97, 18);
            this.chkHeader.TabIndex = 12;
            this.chkHeader.Text = "Show Header";
            this.chkHeader.UseVisualStyleBackColor = true;
            // 
            // chkHyperlink
            // 
            this.chkHyperlink.AutoSize = true;
            this.chkHyperlink.Location = new System.Drawing.Point(214, 80);
            this.chkHyperlink.Name = "chkHyperlink";
            this.chkHyperlink.Size = new System.Drawing.Size(111, 17);
            this.chkHyperlink.TabIndex = 8;
            this.chkHyperlink.Text = "Enable Hyperlinks";
            this.chkHyperlink.UseVisualStyleBackColor = true;
            // 
            // chk_TextBreak
            // 
            this.chk_TextBreak.AutoSize = true;
            this.chk_TextBreak.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chk_TextBreak.Location = new System.Drawing.Point(121, 79);
            this.chk_TextBreak.Name = "chk_TextBreak";
            this.chk_TextBreak.Size = new System.Drawing.Size(101, 18);
            this.chk_TextBreak.TabIndex = 7;
            this.chk_TextBreak.Text = "Split TextLines";
            this.chk_TextBreak.UseVisualStyleBackColor = true;
            // 
            // chkJavaScript
            // 
            this.chkJavaScript.AutoSize = true;
            this.chkJavaScript.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkJavaScript.Location = new System.Drawing.Point(12, 79);
            this.chkJavaScript.Name = "chkJavaScript";
            this.chkJavaScript.Size = new System.Drawing.Size(118, 18);
            this.chkJavaScript.TabIndex = 6;
            this.chkJavaScript.Text = "Enable JavaScript";
            this.chkJavaScript.UseVisualStyleBackColor = true;
            // 
            // cbxPageRotation
            // 
            this.cbxPageRotation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPageRotation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbxPageRotation.FormattingEnabled = true;
            this.cbxPageRotation.Items.AddRange(new object[] {
            "No",
            "Rotate 90",
            "Rotate 180",
            "Rotate 270"});
            this.cbxPageRotation.Location = new System.Drawing.Point(101, 110);
            this.cbxPageRotation.Name = "cbxPageRotation";
            this.cbxPageRotation.Size = new System.Drawing.Size(108, 21);
            this.cbxPageRotation.TabIndex = 17;
            // 
            // lblRot
            // 
            this.lblRot.AutoSize = true;
            this.lblRot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRot.Location = new System.Drawing.Point(11, 113);
            this.lblRot.Name = "lblRot";
            this.lblRot.Size = new System.Drawing.Size(50, 13);
            this.lblRot.TabIndex = 2;
            this.lblRot.Text = "Rotation:";
            // 
            // rdoLandscape
            // 
            this.rdoLandscape.AutoSize = true;
            this.rdoLandscape.Location = new System.Drawing.Point(204, 88);
            this.rdoLandscape.Name = "rdoLandscape";
            this.rdoLandscape.Size = new System.Drawing.Size(78, 17);
            this.rdoLandscape.TabIndex = 16;
            this.rdoLandscape.TabStop = true;
            this.rdoLandscape.Text = "Landscape";
            this.rdoLandscape.UseVisualStyleBackColor = true;
            // 
            // rdoPortrait
            // 
            this.rdoPortrait.AutoSize = true;
            this.rdoPortrait.Checked = true;
            this.rdoPortrait.Location = new System.Drawing.Point(101, 89);
            this.rdoPortrait.Name = "rdoPortrait";
            this.rdoPortrait.Size = new System.Drawing.Size(58, 17);
            this.rdoPortrait.TabIndex = 15;
            this.rdoPortrait.TabStop = true;
            this.rdoPortrait.Text = "Portrait";
            this.rdoPortrait.UseVisualStyleBackColor = true;
            // 
            // grbPageSettings
            // 
            this.grbPageSettings.Controls.Add(this.panel1);
            this.grbPageSettings.Controls.Add(this.cbxPageRotation);
            this.grbPageSettings.Controls.Add(this.lblRot);
            this.grbPageSettings.Controls.Add(this.lblOrt);
            this.grbPageSettings.Controls.Add(this.lblRatio);
            this.grbPageSettings.Controls.Add(this.rdoLandscape);
            this.grbPageSettings.Controls.Add(this.rdoPortrait);
            this.grbPageSettings.Controls.Add(this.chkFooter);
            this.grbPageSettings.Controls.Add(this.chkHeader);
            this.grbPageSettings.Controls.Add(this.nudMargin);
            this.grbPageSettings.Controls.Add(this.label3);
            this.grbPageSettings.Location = new System.Drawing.Point(4, 153);
            this.grbPageSettings.Name = "grbPageSettings";
            this.grbPageSettings.Size = new System.Drawing.Size(371, 140);
            this.grbPageSettings.TabIndex = 86;
            this.grbPageSettings.TabStop = false;
            this.grbPageSettings.Text = "Page Settings";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdoWidth);
            this.panel1.Controls.Add(this.rdoHeight);
            this.panel1.Location = new System.Drawing.Point(97, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 23);
            this.panel1.TabIndex = 9;
            // 
            // rdoWidth
            // 
            this.rdoWidth.Checked = true;
            this.rdoWidth.AutoSize = true;
            this.rdoWidth.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdoWidth.Location = new System.Drawing.Point(3, 3);
            this.rdoWidth.Name = "rdoWidth";
            this.rdoWidth.Size = new System.Drawing.Size(87, 18);
            this.rdoWidth.TabIndex = 9;
            this.rdoWidth.TabStop = true;
            this.rdoWidth.Text = "Keep Width";
            this.rdoWidth.UseVisualStyleBackColor = true;
            // 
            // rdoHeight
            // 
            this.rdoHeight.AutoSize = true;
            this.rdoHeight.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdoHeight.Location = new System.Drawing.Point(106, 3);
            this.rdoHeight.Name = "rdoHeight";
            this.rdoHeight.Size = new System.Drawing.Size(90, 18);
            this.rdoHeight.TabIndex = 10;
            this.rdoHeight.Text = "Keep Height";
            this.rdoHeight.UseVisualStyleBackColor = true;
            // 
            // lblOrt
            // 
            this.lblOrt.AutoSize = true;
            this.lblOrt.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOrt.Location = new System.Drawing.Point(10, 90);
            this.lblOrt.Name = "lblOrt";
            this.lblOrt.Size = new System.Drawing.Size(89, 13);
            this.lblOrt.TabIndex = 84;
            this.lblOrt.Text = "Page Orientation:";
            // 
            // lblRatio
            // 
            this.lblRatio.AutoSize = true;
            this.lblRatio.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRatio.Location = new System.Drawing.Point(11, 19);
            this.lblRatio.Name = "lblRatio";
            this.lblRatio.Size = new System.Drawing.Size(71, 13);
            this.lblRatio.TabIndex = 82;
            this.lblRatio.Text = "Aspect Ratio:";
            // 
            // nudMargin
            // 
            this.nudMargin.Location = new System.Drawing.Point(101, 39);
            this.nudMargin.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudMargin.Name = "nudMargin";
            this.nudMargin.Size = new System.Drawing.Size(63, 20);
            this.nudMargin.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Location = new System.Drawing.Point(10, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 81;
            this.label3.Text = "Page Margins:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Location = new System.Drawing.Point(11, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 82;
            this.label2.Text = "URL";
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Location = new System.Drawing.Point(331, 15);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(31, 20);
            this.button2.TabIndex = 1;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(43, 15);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(282, 20);
            this.txtUrl.TabIndex = 0;
            this.txtUrl.Text = "http://www.google.co.uk";
            // 
            // rdbMetafile
            // 
            this.rdbMetafile.AutoSize = true;
            this.rdbMetafile.Checked = true;
            this.rdbMetafile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdbMetafile.Location = new System.Drawing.Point(101, 17);
            this.rdbMetafile.Name = "rdbMetafile";
            this.rdbMetafile.Size = new System.Drawing.Size(68, 18);
            this.rdbMetafile.TabIndex = 2;
            this.rdbMetafile.TabStop = true;
            this.rdbMetafile.Text = "Metafile";
            this.rdbMetafile.UseVisualStyleBackColor = true;
            // 
            // rdbBitmap
            // 
            this.rdbBitmap.AutoSize = true;
            this.rdbBitmap.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdbBitmap.Location = new System.Drawing.Point(204, 17);
            this.rdbBitmap.Name = "rdbBitmap";
            this.rdbBitmap.Size = new System.Drawing.Size(63, 18);
            this.rdbBitmap.TabIndex = 3;
            this.rdbBitmap.TabStop = true;
            this.rdbBitmap.Text = "Bitmap";
            this.rdbBitmap.UseVisualStyleBackColor = true;
            // 
            // grbDocument
            // 
            this.grbDocument.Controls.Add(this.chkHyperlink);
            this.grbDocument.Controls.Add(this.chkPageBreak);
            this.grbDocument.Controls.Add(this.chkPDFA1);
            this.grbDocument.Controls.Add(this.lblConvert);
            this.grbDocument.Controls.Add(this.chk_TextBreak);
            this.grbDocument.Controls.Add(this.chkJavaScript);
            this.grbDocument.Controls.Add(this.rdbBitmap);
            this.grbDocument.Controls.Add(this.rdbMetafile);
            this.grbDocument.Location = new System.Drawing.Point(4, 46);
            this.grbDocument.Name = "grbDocument";
            this.grbDocument.Size = new System.Drawing.Size(371, 105);
            this.grbDocument.TabIndex = 85;
            this.grbDocument.TabStop = false;
            this.grbDocument.Text = "PDF Document";
            // 
            // chkPageBreak
            // 
            this.chkPageBreak.AutoSize = true;
            this.chkPageBreak.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkPageBreak.Location = new System.Drawing.Point(12, 58);
            this.chkPageBreak.Name = "chkPageBreak";
            this.chkPageBreak.Size = new System.Drawing.Size(145, 18);
            this.chkPageBreak.TabIndex = 5;
            this.chkPageBreak.Text = "Auto Detect PageBreak";
            this.chkPageBreak.UseVisualStyleBackColor = true;
            // 
            // chkPDFA1
            // 
            this.chkPDFA1.AutoSize = true;
            this.chkPDFA1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkPDFA1.Location = new System.Drawing.Point(12, 36);
            this.chkPDFA1.Name = "chkPDFA1";
            this.chkPDFA1.Size = new System.Drawing.Size(127, 18);
            this.chkPDFA1.TabIndex = 4;
            this.chkPDFA1.Text = "PDF/A1-B Standard";
            this.chkPDFA1.UseVisualStyleBackColor = true;
            // 
            // lblConvert
            // 
            this.lblConvert.AutoSize = true;
            this.lblConvert.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblConvert.Location = new System.Drawing.Point(9, 19);
            this.lblConvert.Name = "lblConvert";
            this.lblConvert.Size = new System.Drawing.Size(63, 13);
            this.lblConvert.TabIndex = 82;
            this.lblConvert.Text = "Convert To:";
            // 
            // grbUrl
            // 
            this.grbUrl.Controls.Add(this.txtUrl);
            this.grbUrl.Controls.Add(this.button2);
            this.grbUrl.Controls.Add(this.label2);
            this.grbUrl.Location = new System.Drawing.Point(4, 0);
            this.grbUrl.Name = "grbUrl";
            this.grbUrl.Size = new System.Drawing.Size(371, 45);
            this.grbUrl.TabIndex = 95;
            this.grbUrl.TabStop = false;
            this.grbUrl.Text = "URL source";
            // 
            // HTML_to_PDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbUrl);
            this.Controls.Add(this.grbPageSettings);
            this.Controls.Add(this.grbDocument);
            this.Name = "HTML_to_PDF";
            this.Size = new System.Drawing.Size(379, 302);
            this.grbPageSettings.ResumeLayout(false);
            this.grbPageSettings.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMargin)).EndInit();
            this.grbDocument.ResumeLayout(false);
            this.grbDocument.PerformLayout();
            this.grbUrl.ResumeLayout(false);
            this.grbUrl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkFooter;
        private System.Windows.Forms.CheckBox chkHeader;
        private System.Windows.Forms.CheckBox chkHyperlink;
        private System.Windows.Forms.CheckBox chk_TextBreak;
        private System.Windows.Forms.CheckBox chkJavaScript;
        private System.Windows.Forms.ComboBox cbxPageRotation;
        private System.Windows.Forms.Label lblRot;
        private System.Windows.Forms.RadioButton rdoLandscape;
        private System.Windows.Forms.RadioButton rdoPortrait;
        private System.Windows.Forms.GroupBox grbPageSettings;
        private System.Windows.Forms.RadioButton rdoWidth;
        private System.Windows.Forms.RadioButton rdoHeight;
        private System.Windows.Forms.NumericUpDown nudMargin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.RadioButton rdbMetafile;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.RadioButton rdbBitmap;
        private System.Windows.Forms.GroupBox grbDocument;
        private System.Windows.Forms.GroupBox grbUrl;
        private System.Windows.Forms.CheckBox chkPageBreak;
        private System.Windows.Forms.CheckBox chkPDFA1;
        private System.Windows.Forms.Label lblConvert;
        private System.Windows.Forms.Label lblOrt;
        private System.Windows.Forms.Label lblRatio;
        private System.Windows.Forms.Panel panel1;

    }
}
