using System;
using System.Drawing;
using System.Windows.Forms;

using ComponentPro.Pdf;
using ComponentPro.Pdf.Graphics;
using ComponentPro.Pdf.Security;


namespace PdfDemo.Samples.Document
{
    public partial class Digital_Signature___Sign_Existing_PDF : ExampleControlBase
    {
        public Digital_Signature___Sign_Existing_PDF()
        {
            InitializeComponent();

            txtSource.Text = Util.DataDir + "\\PDFForm.pdf";
            txtCert.Text = Util.DataDir + "\\Key.pfx";
        }

        public override bool Create()
        {
            PdfDigitalSignature signature;
            PdfBitmap bmp;

            if (this.txtSource.Text == String.Empty || this.txtCert.Text == String.Empty || !this.txtSource.Text.EndsWith(".pdf") || !this.txtCert.Text.EndsWith(".pfx"))
            {
                MessageBox.Show("Please select a PDF document to sign, along with certificate and the password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            PdfCertificate pdfCert;
            try
            {
                pdfCert = new PdfCertificate(txtCert.Text, txtPassword.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Certificate file error: " + ex.Message, "Digital Signature", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            using (PdfImportedDocument doc = new PdfImportedDocument(txtSource.Text))
            {
                bmp = new PdfBitmap(Util.DataDir + "\\Logo.gif");

                PdfPageBase page = doc.Pages[0];
                signature = new PdfDigitalSignature(doc, page, pdfCert, "Signature");

                signature.Bounds = new RectangleF(new PointF(5, 5), bmp.PhysicalDimension);
                signature.ContactInfo = txtContact.Text;
                signature.LocationInfo = txtLocation.Text;
                signature.Reason = txtReason.Text;

                doc.Save(OutputFile);
            }

            return true;
        }

        private void btnBrowseSource_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new System.Windows.Forms.OpenFileDialog();

            openFile.Filter = "PDF files *.pdf|*.pdf";
            openFile.Title = "Select a file";
            openFile.FileName = txtSource.Text;
            if (openFile.ShowDialog() != DialogResult.OK)
                return;

            txtSource.Text = openFile.FileName;
        }

        private void btnBrowseCert_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new System.Windows.Forms.OpenFileDialog();
            openFile.InitialDirectory = Application.StartupPath + @"\..\..\..\..\..\Data";
            openFile.Filter = "Certificate files *.pfx|*.pfx";
            openFile.Title = "Select a file";
            openFile.FileName = txtCert.Text;
            if (openFile.ShowDialog() != DialogResult.OK)
                return;

            txtCert.Text = openFile.FileName;
        }

        public override string GenerateButtonText
        {
            get
            {
                return "Sign";
            }
        }

        public override string Title
        {
            get { return "Signing Existing PDF Document Demo"; }
        }

        public override string Description
        {
            get { return "This example demonstrates how to sign a digital signature to an existing PDF file."; }
        }
    }
}
