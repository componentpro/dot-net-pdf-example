using System;
using System.Drawing;
using ComponentPro.Pdf;
using ComponentPro.Pdf.Graphics;
using ComponentPro.Pdf.Security;

namespace PdfDemo.Samples.Document
{
    public partial class Document_Security : ExampleControlBase
    {
        public Document_Security()
        {
            InitializeComponent();
        }

        protected override void RenderPdf(PdfDocument document)
        {
            PdfPage page = document.Pages.Add();
            PdfGraphics graphics = page.Graphics;

            PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 20f,PdfFontStyle.Bold);
            PdfBrush brush = PdfBrushes.Black;
            
            //Document security
            PdfDocumentSecurity security = document.Security;

            //use 128 bits key
            security.KeySize = PdfEncryptionKeySize.Key128Bit;
            security.OwnerPassword = "owner";
            security.Permissions = PdfDocumentPermissions.Print | PdfDocumentPermissions.FullQualityPrint;
            security.UserPassword = "user";

            string text = "Security options:\n\n" + String.Format("KeySize: {0}\n\nOwner Password: {1}\n\nPermissions: {2}\n\n" +
                "UserPassword: {3}", security.KeySize, security.OwnerPassword, security.Permissions, security.UserPassword);

               graphics.DrawString("Document is Encrypted with following settings", font, brush, PointF.Empty);
               font = new PdfStandardFont(PdfFontFamily.Courier, 16f, PdfFontStyle.Bold); 
            graphics.DrawString(text, font, brush, new PointF(0,40));
        }

        public override string Title
        {
            get { return "Document Security Demo"; }
        }

        public override string Description
        {
            get { return "This example demonstrates how to protect a PDF document with passwords."; }
        }
    }
}
