using System.Drawing;
using System.Text;
using System.IO;

using ComponentPro.Pdf;
using ComponentPro.Pdf.Graphics;

namespace PdfDemo.Samples.Text
{
    public partial class Drawing_Text : ExampleControlBase
    {
        public Drawing_Text()
        {
            InitializeComponent();
        }

        protected override void RenderPdf(PdfDocument doc)
        {
            //Set compression level
            doc.CompressionLevel = PdfCompressionLevel.NoCompression;
            
            //Add a page to the document.
            PdfPage page = doc.Pages.Add();

            //Read the text from the text file
            string path = Util.DataDir + "\\EULA.txt";
            StreamReader reader = new StreamReader(path, Encoding.ASCII);
            string text = reader.ReadToEnd();
            reader.Close();

            //Set the font
            Font f = new Font("Arial", 12);
            PdfTrueTypeFont font = new PdfTrueTypeFont(f, false);

            //Set the formats for the text
            PdfStringFormat format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Justify;
            format.LineAlignment = PdfVerticalAlignment.Top;
            format.ParagraphIndent = 15f;

            //Create a text element 
            PdfTextElement element = new PdfTextElement(text, font);
            element.Brush = new PdfSolidBrush(Color.Black);
            element.StringFormat = format;
            element.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);
            
            //Set the properties to paginate the text.
            PdfLayoutSettings layoutFormat = new PdfLayoutSettings();
            layoutFormat.Break = PdfLayoutBreakType.FitPage;
            layoutFormat.Layout = PdfLayoutType.Paginate;

            RectangleF bounds = new RectangleF(new PointF(10,10),new SizeF(page.Graphics.ClientSize.Width-20,page.Graphics.ClientSize.Height-10));

            if (chkStamp.Checked)
            {
                element.AfterPageLayout += EndPageLayout;

                //Draw the text element with the properties and formats set.
                element.Draw(page, bounds, layoutFormat);
                //Set the font
                PdfFont stampFont = new PdfStandardFont(PdfFontFamily.Helvetica ,60,PdfFontStyle.Bold);
                PdfPageTemplateElement  stamp = new PdfPageTemplateElement(new SizeF(500,500));
                stamp.Background = true;
                stamp.Graphics.SetTransparency(0.25f);
                stamp.Graphics.RotateTransform(-45);
                stamp.Graphics.DrawString("DEMO", stampFont, PdfBrushes.Blue, new PointF(-150,400), format);
                doc.Template.Stamps.Add(stamp);

             }

            else
            {
                //Raise the events to draw the graphic elements for each page.
                element.BeforePageLayout += BeginPageLayout;
                element.AfterPageLayout += EndPageLayout;

                //Draw the text element with the properties and formats set.
                element.Draw(page, bounds, layoutFormat);
            }
        }

        private static void BeginPageLayout(object sender, BeforePageLayoutEventArgs e)
        {
            int index = e.Page.Section.Pages.IndexOf(e.Page);
            const float offset = 50;
            PdfSolidBrush brush = new PdfSolidBrush(Color.LightBlue);

            if (index % 3 == 0)
            {
                RectangleF bounds = e.Bounds;
                e.Page.Graphics.DrawPie(brush, offset + 10, offset + 10, 2 * offset, 2 * offset, 0, 270);
            }
            else
            {
                RectangleF bounds = e.Bounds;
                e.Page.Graphics.DrawRectangle(brush, offset + 10, offset + 10, 2 * offset, 2 * offset);
            }
        }

        private static void EndPageLayout(object sender, AfterPageLayoutEventArgs e)
        {
            AfterTextPageLayoutEventArgs args = (AfterTextPageLayoutEventArgs)e;
            PdfPage page = args.Result.Page;
            PdfPen pen = PdfPens.Cyan;
            page.Graphics.DrawRectangle(pen, new RectangleF(Point.Empty,page.Graphics.ClientSize));
        }

        public override string Title
        {
            get { return "Drawing Text Demo"; }
        }

        public override string Description
        {
            get { return "This example demonstrates how to draw texts."; }
        }
    }
}
