using System;
using System.Drawing;
using ComponentPro.Pdf;
using ComponentPro.Pdf.Graphics;

namespace PdfDemo.Samples.Graphics
{
    public partial class Ellipses : ExampleControlBase
    {
        public Ellipses()
        {
            InitializeComponent();
        }

        protected override void RenderPdf(PdfDocument doc)
        {
            //Set the font
            Font f = new Font("Arial", 12.0f);
            PdfTrueTypeFont font = new PdfTrueTypeFont(f, false);

            // Add the first page.
            PdfPage page = doc.Pages.Add();

            PdfGraphics g = page.Graphics;

            //Create a text element 
            PdfTextElement element = new PdfTextElement("Random Ellipses on page 1!!", font);
            element.Brush = new PdfSolidBrush(Color.Black);
            element.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);
            element.Draw(g, new PointF(320, 0));

            float contentWidth = page.Size.Width - doc.PageSettings.Margins.Left - doc.PageSettings.Margins.Right;
            float contentHeight = page.Size.Height - doc.PageSettings.Margins.Left - doc.PageSettings.Margins.Right;

            Random rnd = new Random();

            PdfLine line = new PdfLine(new PointF(0, 0), new PointF(contentWidth, contentHeight));
            line.Draw(g);

            PdfRectangle rec = new PdfRectangle(0, 0, contentWidth, contentHeight);
            rec.Draw(g);

            // Draw 30 ellipses
            for (int i = 0; i < 30; i++)
            {
                float left = rnd.Next((int)contentWidth);
                float top = rnd.Next((int)contentHeight);
                PdfEllipse ellipse = new PdfEllipse(left,
                    top,
                    rnd.Next((int)(contentWidth - left)),
                    rnd.Next((int)(contentHeight - top)));
                // Random border color.
                ellipse.Pen = new PdfPen(new PdfColor((byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256)), 1);

                ellipse.Draw(g);
            }
        }

        public override string Title
        {
            get { return "Ellipses Demo"; }
        }

        public override string Description
        {
            get { return "This example demonstrates how to draw ellipses on a PDF document."; }
        }
    }
}
