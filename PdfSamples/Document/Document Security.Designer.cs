namespace PdfDemo.Samples.Document
{
    partial class Document_Security
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
            this.grbPassword = new System.Windows.Forms.GroupBox();
            this.lblUserPassword = new System.Windows.Forms.Label();
            this.lblOwnerPassword = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblOwner = new System.Windows.Forms.Label();
            this.grbPassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbPassword
            // 
            this.grbPassword.Controls.Add(this.lblUserPassword);
            this.grbPassword.Controls.Add(this.lblOwnerPassword);
            this.grbPassword.Controls.Add(this.lblUser);
            this.grbPassword.Controls.Add(this.lblOwner);
            this.grbPassword.Location = new System.Drawing.Point(3, 3);
            this.grbPassword.Name = "grbPassword";
            this.grbPassword.Size = new System.Drawing.Size(259, 60);
            this.grbPassword.TabIndex = 28;
            this.grbPassword.TabStop = false;
            this.grbPassword.Text = "Document Passwords";
            // 
            // lblUserPassword
            // 
            this.lblUserPassword.AutoSize = true;
            this.lblUserPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserPassword.Location = new System.Drawing.Point(159, 38);
            this.lblUserPassword.Name = "lblUserPassword";
            this.lblUserPassword.Size = new System.Drawing.Size(31, 13);
            this.lblUserPassword.TabIndex = 28;
            this.lblUserPassword.Text = "user";
            // 
            // lblOwnerPassword
            // 
            this.lblOwnerPassword.AutoSize = true;
            this.lblOwnerPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOwnerPassword.Location = new System.Drawing.Point(159, 17);
            this.lblOwnerPassword.Name = "lblOwnerPassword";
            this.lblOwnerPassword.Size = new System.Drawing.Size(41, 13);
            this.lblOwnerPassword.TabIndex = 27;
            this.lblOwnerPassword.Text = "owner";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(11, 38);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(147, 13);
            this.lblUser.TabIndex = 26;
            this.lblUser.Text = "Password for Read-only User:";
            // 
            // lblOwner
            // 
            this.lblOwner.AutoSize = true;
            this.lblOwner.Location = new System.Drawing.Point(11, 17);
            this.lblOwner.Name = "lblOwner";
            this.lblOwner.Size = new System.Drawing.Size(105, 13);
            this.lblOwner.TabIndex = 25;
            this.lblOwner.Text = "Password for Owner:";
            // 
            // Document_Security
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbPassword);
            this.Name = "Document_Security";
            this.Size = new System.Drawing.Size(312, 94);
            this.grbPassword.ResumeLayout(false);
            this.grbPassword.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbPassword;
        private System.Windows.Forms.Label lblOwnerPassword;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblOwner;
        private System.Windows.Forms.Label lblUserPassword;
    }
}
