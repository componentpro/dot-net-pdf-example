using System.Drawing;
using ComponentPro.Pdf;
using ComponentPro.Pdf.Graphics;

namespace PdfDemo.Samples.Basic
{
    public partial class Hello_World : ExampleControlBase
    {
        public Hello_World()
        {
            InitializeComponent();
        }

        protected override void RenderPdf(PdfDocument doc)
        {
            // Add a page
            PdfPage page = doc.Pages.Add();

            // Create a solid brush
            PdfBrush brush = new PdfSolidBrush(Color.Black);

            const float fontSize = 24.0f;

            // Set the font
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, fontSize);

            // Draw the text
            page.Graphics.DrawString("Hello World!", font, brush, new PointF(30, 30));
        }

        public override string Title
        {
            get { return "Hello World Demo"; }
        }

        public override string Description
        {
            get { return "This example demonstrates how to write a simple text to a PDF document."; }
        }
    }
}
