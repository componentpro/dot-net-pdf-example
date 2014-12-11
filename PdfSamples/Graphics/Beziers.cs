using System;
using System.Drawing;
using ComponentPro.Pdf;
using ComponentPro.Pdf.Graphics;

namespace PdfDemo.Samples.Graphics
{
    public partial class Beziers : ExampleControlBase
    {
        public Beziers()
        {
            InitializeComponent();
        }

        protected override void RenderPdf(PdfDocument doc)
        {
            // Add the first page.
            PdfPage page = doc.Pages.Add();

            float contentWidth = page.Size.Width - doc.PageSettings.Margins.Left - doc.PageSettings.Margins.Right;
            float contentHeight = page.Size.Height - doc.PageSettings.Margins.Left - doc.PageSettings.Margins.Right;

            //Create Pdf graphics for the page
            PdfGraphics g = page.Graphics;

            Random rnd = new Random();

            // Draw 30 beziers
            for (int i = 0; i < 30; i++)
            {
                const int pointsNum = 4;
                PointF[] points = new PointF[pointsNum];

                for (int j = 0; j < pointsNum; j++)
                {
                    points[j].X = rnd.Next((int)contentWidth);
                    points[j].Y = rnd.Next((int)contentHeight);
                }

                PdfBezierCurve curve = new PdfBezierCurve(points[0], points[1], points[2], points[3]);
                curve.Pen = new PdfPen(new PdfColor((byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256)));
                curve.Draw(g);
            }
        }

        public override string Title
        {
            get { return "Beziers Demo"; }
        }

        public override string Description
        {
            get { return "This example demonstrates how to draw beziers on a PDF document."; }
        }
    }
}
