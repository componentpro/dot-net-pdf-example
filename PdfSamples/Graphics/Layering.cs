using System.Drawing;
using ComponentPro.Pdf;
using ComponentPro.Pdf.Graphics;

namespace PdfDemo.Samples.Graphics
{
    public partial class Layering : ExampleControlBase
    {
        public Layering()
        {
            InitializeComponent();
        }

        protected override void RenderPdf(PdfDocument doc)
        {
            doc.PageSettings = new PdfPageSettings(new SizeF(450, 300));

            PdfPage page = doc.Pages.Add();

            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 16);

            page.Graphics.DrawString("Layers Sample", font, PdfBrushes.Black, new PointF(150,10));

            //Add the first layer
            page.Layers.Add();

            Color c1 = Color.FromArgb(0xff, 0x30, 0x76, 0xff);
            Color c2 = Color.FromArgb(0xff, 0x5a, 0x91, 0xfe);
            Color c3 = Color.FromArgb(0xff, 0xa3, 0xc1, 0xfd);
            Color c4 = Color.FromArgb(0xff, 0xda, 0xe6, 0xfc);

            PdfGraphics graphics = page.DefaultLayer.Graphics;
            graphics.TranslateTransform(50, 60);

            //Draw Arc 
            PdfPen pen = new PdfPen(c1, 50);
            RectangleF rect = new RectangleF(0, 0, 50, 50);
            graphics.DrawArc(pen, rect, 360, 360);

            pen = new PdfPen(c2, 30);
            graphics.DrawArc(pen, 0, 0, 50, 50, 360, 360);

            pen = new PdfPen(c3, 20);
            graphics.DrawArc(pen, rect, 360, 360);

            pen = new PdfPen(c4, 10);
            graphics.DrawArc(pen, 0, 0, 50, 50, 360, 360);

            //Add another layer on the page
            page.Layers.Add();

            //Increment the layer
            page.DefaultLayerIndex += 1;
            graphics = page.DefaultLayer.Graphics;
            graphics.TranslateTransform(150, 50);
            graphics.SkewTransform(0, 30);
            graphics.ScaleTransform(0.3f, 0.3f);            
            
            //Draw another set of elements
            //pen = new PdfPen(c1, 50);
            //graphics.DrawArc(pen, rect, 360, 360);
            //pen = new PdfPen(c2, 30);
            //graphics.DrawArc(pen, 0, 0, 50, 50, 360, 360);
            //pen = new PdfPen(c3, 20);
            //graphics.DrawArc(pen, rect, 360, 360);
            //pen = new PdfPen(c4, 10);
            //graphics.DrawArc(pen, 0, 0, 50, 50, 360, 360);

            string tifImage = Util.DataDir + "\\256.tif";
            PdfImage image = new PdfBitmap(tifImage);
            graphics.DrawImage(image, 0, 0);

            //Add another layer
            page.Layers.Add();
            page.DefaultLayerIndex += 1;
            graphics = page.DefaultLayer.Graphics;
            graphics.TranslateTransform(320, 70);

            const int a1 = -80;
            const int a2 = 160;

            //Draw another set of elements.
            pen = new PdfPen(c1, 50);
            graphics.DrawArc(pen, rect, a1, a2);
            pen = new PdfPen(c2, 30);
            graphics.DrawArc(pen, 0, 0, 50, 50, a1, a2);
            pen = new PdfPen(c3, 20);
            graphics.DrawArc(pen, rect, a1, a2);
            pen = new PdfPen(c4, 10);
            graphics.DrawArc(pen, 0, 0, 50, 50, a1, a2);
        }

        public override string Title
        {
            get { return "Layering Demo"; }
        }

        public override string Description
        {
            get { return "This example demonstrates how to use layers."; }
        }
    }
}
