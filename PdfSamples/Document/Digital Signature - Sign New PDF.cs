using System.Drawing;
using System.Windows.Forms;

using ComponentPro.Pdf;
using ComponentPro.Pdf.Graphics;
using ComponentPro.Pdf.Security;

namespace PdfDemo.Samples.Document
{
    public partial class Digital_Signature___Sign_New_PDF : ExampleControlBase
    {
        public Digital_Signature___Sign_New_PDF()
        {
            InitializeComponent();

            cbxSignatureType.SelectedIndex = 0;
        }

        public override bool Create()
        {
            PdfDigitalSignature signature = null;
            PdfBitmap bmp = null;
            PdfGraphics g;        

            PdfDocument doc = new PdfDocument();

            PdfPage page = doc.Pages.Add();
            PdfSolidBrush brush = new PdfSolidBrush(Color.Black);
            PdfPen pen = new PdfPen(brush, 0.2f);
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12, PdfFontStyle.Regular);

            try
            {
                PdfCertificate pdfCert = new PdfCertificate(Util.DataDir + "\\Key.pfx", "password");
                signature = new PdfDigitalSignature(page, pdfCert, "Signature");
                bmp = new PdfBitmap(Util.DataDir + "\\Logo.gif");

                signature.Bounds = new RectangleF(new PointF(5, 5), bmp.PhysicalDimension);
                signature.ContactInfo = "contact@domain.com";
                signature.LocationInfo = "California";
                signature.Reason = "I am author of this document.";

                if (cbxSignatureType.SelectedIndex == 1)
                    signature.Certificated = true;
                else
                    signature.Certificated = false;
                g = signature.Appearence.Normal.Graphics;
            }
            catch (System.ArgumentNullException exc)
            {
                g = signature.Appearence.Normal.Graphics;

                MessageBox.Show("Warning Certificate not found \"Cannot sign This Document\": " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Draw the Text at specified location.
                g.DrawString("Warning this document is not signed", font, brush, new PointF(0, 20));
                g.DrawString("Create a self signed Digital ID to sign this document", font, brush, new PointF(20, 40));
                g.DrawLine(pen, new PointF(0, 100), new PointF(page.GetClientSize().Width, 200));
                g.DrawLine(pen, new PointF(0, 200), new PointF(page.GetClientSize().Width, 100));
            }
            string validto = "Valid To: " + signature.Certificate.ValidTo.ToString();
            string validfrom = "Valid From: " + signature.Certificate.ValidFrom.ToString();

            g.DrawImage(bmp, 0, 0);

            doc.Pages[0].Graphics.DrawString("Certificate Info", font, pen, brush, 0, 70);
            doc.Pages[0].Graphics.DrawString(validfrom, font, pen, brush, 20, 90);
            doc.Pages[0].Graphics.DrawString(validto, font, pen, brush, 20, 110);

            doc.Pages[0].Graphics.DrawString("- Click on the signature on this page to validate Signature\n- Click document status icon on the bottom left of the acrobat reader to check Document Status", font, pen, brush, 0, 150);

            // Save the PDF file.
            doc.Save(OutputFile);
            
            return true;
        }

        public override string GenerateButtonText
        {
            get
            {
                return "Create && Sign";
            }
        }

        public override string Title
        {
            get { return "Signing a new PDF Document Demo"; }
        }

        public override string Description
        {
            get { return "This example demonstrates how to sign a digital signature to a new PDF file."; }
        }
    }
}
