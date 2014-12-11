using System.Drawing;
using System.Text;
using System.IO;

using ComponentPro.Pdf;
using ComponentPro.Pdf.Graphics;

namespace PdfDemo.Samples.Basic
{
    public partial class Conformance_Level_PDF_A : ExampleControlBase
    {
        public Conformance_Level_PDF_A()
        {
            InitializeComponent();
        }

        protected override void RenderPdf(PdfDocument doc)
        {
            //Add a page
            PdfPage page = doc.Pages.Add();

            SizeF bounds = page.GetClientSize();

            //Read the RTF document
            StreamReader reader = new StreamReader(Util.DataDir + "\\EULA.rtf", Encoding.ASCII);
            string text = reader.ReadToEnd();
            reader.Close();

            //Convert it as metafile.
            PdfMetafile metafile = (PdfMetafile)PdfImage.FromRtf(text, bounds.Width, PdfImageType.Metafile);
            PdfMetafileLayoutSettings format = new PdfMetafileLayoutSettings();

            //Allow the text to flow multiple pages without any breaks.
            format.SplitTextLines = true;

            //Draw the image.
            metafile.Draw(page, 0, 0, format);
        }

        public override PdfDocumentConformanceLevel ConformanceLevel
        {
            get
            {
                return PdfDocumentConformanceLevel.Pdf_A1B;
            }
        }

        public override string Title
        {
            get { return "Conformance Level PDF_A Demo"; }
        }

        public override string Description
        {
            get { return "This example demonstrates how to create a PDF/A document."; }
        }
    }
}
