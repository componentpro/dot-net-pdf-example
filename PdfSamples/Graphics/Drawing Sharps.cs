using System;
using System.Drawing;
using ComponentPro.Pdf;
using ComponentPro.Pdf.Graphics;

namespace PdfDemo.Samples.Graphics
{
    public partial class Drawing_Sharps : ExampleControlBase
    {
        public Drawing_Sharps()
        {
            InitializeComponent();
        }

        protected override void RenderPdf(PdfDocument doc)
        {
            Color lightGreen = Color.FromArgb(0xff, 0x76, 0xfe, 0x96);
            Color lightBlue = Color.FromArgb(0xff, 0x8f, 0xb5, 0xfe);

            int i;
            // Create a new page.
            PdfPage page = doc.Pages.Add();
            // Obtain PdfGraphics object.
            PdfGraphics g = page.Graphics;
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 14, PdfFontStyle.Bold);

            #region Polygon
            PdfPen pen = new PdfPen(Color.Black);
            pen.Width = 3;

            const int pointNum = 6;
            PointF[] points = new PointF[pointNum];
            const double f = 360.0 / pointNum * Math.PI / 180.0;
            const double r = 100;
            PointF center = new PointF(140, 140);

            for (i = 0; i < pointNum; ++i)
            {
                PointF p = new PointF();
                double theta = i * f;

                p.Y = (float)(Math.Sin(theta) * r + center.Y);
                p.X = (float)(Math.Cos(theta) * r + center.X);

                points[i] = p;
            }

            PdfSolidBrush brush = new PdfSolidBrush(lightBlue);
            pen.Color = lightGreen;
            pen.Width = 10;
            pen.LineJoin = PdfLineJoin.Round;
            g.DrawString("Polygon", font, PdfBrushes.DarkBlue, new PointF(50, 0));
            g.DrawPolygon(pen, brush, points);

            #endregion

            #region Rectangle
            RectangleF rect = new RectangleF(310, 50, 200, 100);
            brush.Color = lightBlue;
            pen.Color = lightGreen;
            g.DrawString("Simple Rectangle", font, PdfBrushes.DarkBlue, new PointF(310, 0));
            g.DrawRectangle(pen, brush, rect);
            #endregion

            #region  Pie

            rect = new RectangleF(200, 50, 200, 200);
            brush.Color = lightBlue;
            pen.Color = lightGreen;
            pen.Width = 10;

            rect.Location = new PointF(20, 280);
            pen.LineJoin = PdfLineJoin.Round;
            g.DrawString("Pie shape", font, PdfBrushes.DarkBlue, new PointF(50, 250));
            g.DrawPie(pen, brush, rect, 180 + 25, 60 + 25);
            g.DrawPie(pen, brush, rect, 360 - 60 + 25, 60 + 25);
            g.DrawPie(pen, brush, rect, 60 + 25, 60 + 25);

            #endregion

            #region Arc

            g.DrawString("Arcs", font, PdfBrushes.DarkBlue, new PointF(330, 250));
            pen = new PdfPen(Color.Black);
            pen.Width = 11;
            pen.LineCap = PdfLineCap.Round;
            pen.Color = lightBlue;
            rect = new RectangleF(310, 280, 200, 200);
            g.DrawArc(pen, rect, 0, 90);

            pen.Color = lightGreen;
            rect.X -= 10;
            g.DrawArc(pen, rect, 90, 90);

            pen.Color = lightBlue;
            rect.Y -= 10;
            g.DrawArc(pen, rect, 180, 90);

            pen.Color = lightGreen;
            rect.X += 10;
            g.DrawArc(pen, rect, 270, 90);

            #endregion

            #region ellipse

            // Draw a simple ellipse.
            rect = new RectangleF(80, 520, 150, 200);
            PdfLinearGradientBrush lgBrush = new PdfLinearGradientBrush(rect, lightBlue, Color.White, 90);

            pen.Color = lightGreen;
            pen.Width = 10.0f;
            g.DrawString("Ellipse with Gradient", font, PdfBrushes.DarkBlue, new PointF(50, 490));
            g.DrawEllipse(lgBrush, rect);

            #endregion            

            #region Transaparency

            page = doc.Pages.Add();
            // Obtain PdfGraphics object.
            g = page.Graphics;

            g.DrawString("Transparent Rectangles", font, PdfBrushes.DarkBlue, new PointF(230, 470));
            rect = new RectangleF(250, 500, 100, 100);

            pen = new PdfPen(Color.Black);
            PdfBrush gBrush = new PdfSolidBrush(lightGreen);
            g.DrawRectangle(pen, gBrush, rect);

            gBrush = new PdfSolidBrush(lightBlue);
            rect.X += 20;
            rect.Y += 20;
            g.SetTransparency(0.1f);
            g.DrawRectangle(pen, gBrush, rect);

            rect.X += 20;
            rect.Y += 20;
            gBrush = new PdfLinearGradientBrush(rect, Color.DarkGreen, Color.Brown, PdfLinearGradientMode.BackwardDiagonal);
            g.SetTransparency(0.5f);
            g.DrawRectangle(pen, gBrush, rect);

            rect.X += 20;
            rect.Y += 20;
            gBrush = new PdfSolidBrush(Color.Gray);
            g.SetTransparency(0.25f);
            g.DrawRectangle(pen, gBrush, rect);

            rect.X += 20;
            rect.Y += 20;
            gBrush = new PdfSolidBrush(Color.Red);
            g.SetTransparency(0.1f);
            g.DrawRectangle(pen, gBrush, rect);

            #endregion
        }

        public override string Title
        {
            get { return "Drawing Sharps Demo"; }
        }

        public override string Description
        {
            get { return "This example demonstrates how to draw sharps on a PDF document."; }
        }
    }
}
