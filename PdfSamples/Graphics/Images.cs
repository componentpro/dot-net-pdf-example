using System.Drawing;
using ComponentPro.Pdf;
using ComponentPro.Pdf.Graphics;

namespace PdfDemo.Samples.Graphics
{
    public partial class Images : ExampleControlBase
    {
        public Images()
        {
            InitializeComponent();
        }

        protected override void RenderPdf(PdfDocument doc)
        {
            string jpgImage = Util.DataDir + "\\Spring.jpg";
            string tifImage = Util.DataDir + "\\256.tif";
            string bmpImage = Util.DataDir + "\\mask2.bmp";
            string emfImage = Util.DataDir + "\\MAPPING2.EMF";
            string multiframeImage = Util.DataDir + "\\mul.tif";
            string gifImage = Util.DataDir + "\\Ani.gif";
            string pngImage = Util.DataDir + "\\PdfLogo.png";

            doc.ViewerPreferences.PageMode = PdfPageDisplayMode.DisplayFullScreen;
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Tahoma", 20f, FontStyle.Bold), false);
            PdfSolidBrush brush = new PdfSolidBrush(Color.Black);

            PdfSection section = doc.Sections.Add();
            PdfPage page = section.Pages.Add();
            PdfGraphics g = page.Graphics;

            //Metafile
            g = page.Graphics;
            PdfMetafile metafile = new PdfMetafile(emfImage);
            page.Graphics.DrawString("Metafile", font, brush, new PointF(10, 0));
            g.DrawImage(metafile, new PointF(0, 50));

            //Bitmap with Tiff image mask
            page = section.Pages.Add();
            g = page.Graphics;
            PdfImage image = new PdfBitmap(tifImage);
            ((PdfBitmap)image).Mask = new PdfImageMask(new PdfBitmap(bmpImage));
            page.Graphics.DrawString("Image mask", font, brush, new PointF(10, 0));
            g.DrawImage(image, 80, 40);            

            //Image pagination -jpg
            image = new PdfBitmap(jpgImage);

            PdfLayoutSettings format = new PdfLayoutSettings();
            format.Layout = PdfLayoutType.Paginate;

            PointF location = new PointF(0, 400);
            SizeF size = new SizeF(400, -1);
            RectangleF rect = new RectangleF(location, size);
            page.Graphics.DrawString("Image Pagination", font, brush, new PointF(10, 360));
            image.Draw(page, rect, format);

            //Multiframe Tiff image
            PdfBitmap tiffImage = new PdfBitmap(multiframeImage);

            int frameCount = tiffImage.FrameCount;

            for (int i = 0; i < frameCount; i++)
            {
                page = section.Pages.Add();
                section.PageSettings.Margins.All = 0;
                g = page.Graphics;
                tiffImage.ActiveFrame = i;
                g.DrawImage(tiffImage, 0, 0, page.GetClientSize().Width, page.GetClientSize().Height);
            }

            page = section.Pages.Add();
            g = page.Graphics;
            image = new PdfBitmap(gifImage);
            g.DrawImage(image, 0, 0, page.Graphics.ClientSize.Width, image.Height);
            page.Graphics.DrawString("Gif Image", font, brush, new PointF(10, 0));

            section.Pages[section.Pages.Count - 2].Graphics.DrawString("Tiff Image", font, brush, new PointF(10, 10));
            section.PageSettings.Transition.PageDuration = 1;
            section.PageSettings.Transition.Duration = 1;
            section.PageSettings.Transition.Style = PdfTransitionEffect.Fly;

            //PNG Image
            page = section.Pages.Add();
            g = page.Graphics;
            image = new PdfBitmap(pngImage);
            page.Graphics.DrawString("PNG Image", font, brush, new PointF(10, 10));
            g.DrawImage(image, new PointF(150, 150));
        }

        public override string Title
        {
            get { return "Images Demo"; }
        }

        public override string Description
        {
            get { return "This example demonstrates how to draw images` on a PDF document."; }
        }
    }
}
