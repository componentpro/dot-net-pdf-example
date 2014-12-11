using System;
using System.Drawing;
using System.Text;
using System.IO;

using ComponentPro.Pdf;
using ComponentPro.Pdf.Fields;
using ComponentPro.Pdf.Graphics;

namespace PdfDemo.Samples.Document
{
    public partial class Header_and_Footer : ExampleControlBase
    {
        private bool _paginateStart = true;
        RectangleF _bounds;

        public Header_and_Footer()
        {
            InitializeComponent();
        }

        public override bool Create()
        {
            // Create a new instance of the PdfDocument class.
            PdfDocument doc = new PdfDocument(ConformanceLevel);

            // Set document's information.
            doc.DocumentInformation.Author = "ComponentPro";
            doc.DocumentInformation.Producer = "ComponentPro";
            doc.DocumentInformation.Creator = "ComponentPro";
            doc.DocumentInformation.Title = Title;

            //Add a page
            PdfPage page = doc.Pages.Add();
            
            //Create font
            PdfStandardFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 11.5f);

             Font ttf = new Font("Calibri", 14f, FontStyle.Bold);
            PdfTrueTypeFont heading = new PdfTrueTypeFont(ttf, true);

            //Adding Header
            AddHeader(doc, "ComponentPro UltimatePdf", "Header and Footer Demo");
           
            //Adding Footer
            AddFooter(doc, "@Copyright " + DateTime.Now.Year);

            //Set formats
            PdfStringFormat format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Justify;
            string path = Util.DataDir + "\\About.txt";
            StreamReader reader = new StreamReader(path, Encoding.ASCII);
            string text = reader.ReadToEnd();
            reader.Close();
            
            RectangleF column = new RectangleF(0, 20, page.Graphics.ClientSize.Width - 10f, page.Graphics.ClientSize.Height);
            _bounds = column;

            //Create text element to control the text flow
            PdfTextElement element = new PdfTextElement(text, font);
            element.Brush = new PdfSolidBrush(Color.Black);
            element.StringFormat = format;
            PdfLayoutSettings layoutFormat = new PdfLayoutSettings();
            layoutFormat.Break = PdfLayoutBreakType.FitPage;
            layoutFormat.Layout = PdfLayoutType.Paginate;
          
            //Get the remaining text that flows beyond the boundary.
            PdfTextLayoutResult result = element.Draw(page, _bounds, layoutFormat);

            path = Util.DataDir + "\\UltimatePdf.txt";
            reader = new StreamReader(path, Encoding.ASCII);
            text = reader.ReadToEnd();
            reader.Close();

            element = new PdfTextElement(text, font);
            element.Brush = new PdfSolidBrush(Color.Black);
            element.StringFormat = format;
            
            // Next paragraph flow from last line of the previous paragraph.
            _bounds.Y = result.LastLineBounds.Y + 35f;

            //Raise the event when the text flows to next page.
            element.BeforePageLayout += BeginPageLayout2;
            
            //Raise the event when the text reaches the end of the page.
            element.AfterPageLayout += EndPageLayout2;
            result.Page.Graphics.DrawString("UltimatePdf",heading,PdfBrushes.DarkBlue,new PointF(_bounds.X, _bounds.Y));

            _bounds.Y = result.LastLineBounds.Y + 60f;
            element.Draw(result.Page,new RectangleF(_bounds.X, _bounds.Y, _bounds.Width,-1),layoutFormat);

            if (!Directory.Exists(Util.OutputDir))
                Directory.CreateDirectory(Util.OutputDir);

            // Save the document to a file.
            doc.Save(OutputFile);

            doc.Close();

            return true;
        }

        public override string Title
        {
            get { return "Header and Footer Demo"; }
        }

        public override string Description
        {
            get { return "This example demonstrates how to add header and footer."; }
        }

        private static void EndPageLayout2(object sender, AfterPageLayoutEventArgs e)
        {
            AfterTextPageLayoutEventArgs args = (AfterTextPageLayoutEventArgs)e;
            PdfTextLayoutResult tlr = args.Result;
            args.NextPage = tlr.Page;
        }
        private void BeginPageLayout2(object sender, BeforePageLayoutEventArgs e)
        {

            RectangleF bounds = e.Bounds;

            // First column.
            if (!_paginateStart)
            {
                bounds.X = bounds.Width + 20f;
                bounds.Y = 10f;
            }
            else
            {
                // Second column.
                bounds.X = 0f;
                _paginateStart = false;
            }

            e.Bounds = bounds;
        }

        private static void AddHeader(PdfDocument doc, string title, string description)
        {
            RectangleF rect = new RectangleF(0, 0, doc.Pages[0].GetClientSize().Width, 50);

            //Create page template
            PdfPageTemplateElement header = new PdfPageTemplateElement(rect);
            Color activeColor = Color.FromArgb(44, 71, 120);
            SizeF imageSize = new SizeF(252f * 0.8f, 34f * 0.8f);
            //Locating the logo on the right corner of the Drawing Surface
            PointF imageLocation = new PointF(doc.Pages[0].GetClientSize().Width - imageSize.Width - 20, 11);

            PdfImage img = new PdfBitmap(Util.DataDir + "\\Logo.gif");

            //Draw the image in the Header.
            header.Graphics.DrawImage(img, imageLocation, imageSize);

            PdfSolidBrush brush = new PdfSolidBrush(activeColor);

            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 16, PdfFontStyle.Bold);

            //Set formattings for the text
            PdfStringFormat format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Left;
            format.LineAlignment = PdfVerticalAlignment.Middle;

            //Draw title
            header.Graphics.DrawString(title, font, brush, new RectangleF(0, 0, header.Width, header.Height), format);
            brush = new PdfSolidBrush(Color.Gray);
            font = new PdfStandardFont(PdfFontFamily.Helvetica, 6, PdfFontStyle.Bold);

            format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Left;
            format.LineAlignment = PdfVerticalAlignment.Bottom;

            //Draw description
            header.Graphics.DrawString(description, font, brush, new RectangleF(0, 0, header.Width, header.Height - 8), format);

            //Draw some lines in the header
            PdfPen pen = new PdfPen(Color.DarkBlue, 0.7f);
            header.Graphics.DrawLine(pen, 0, 0, header.Width, 0);
            pen = new PdfPen(Color.DarkBlue, 2f);
            header.Graphics.DrawLine(pen, 0, 03, header.Width + 3, 03);
            pen = new PdfPen(Color.DarkBlue, 2f);
            header.Graphics.DrawLine(pen, 0, header.Height - 3, header.Width, header.Height - 3);
            header.Graphics.DrawLine(pen, 0, header.Height, header.Width, header.Height);

            //Add header template at the top.
            doc.Template.Top = header;

        }

        private static void AddFooter(PdfDocument doc, string footerText)
        {
            RectangleF rect = new RectangleF(0, 0, doc.Pages[0].GetClientSize().Width, 50);

            //Create a page template
            PdfPageTemplateElement  footer = new PdfPageTemplateElement(rect);

            PdfSolidBrush brush = new PdfSolidBrush(Color.Gray);

            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 6, PdfFontStyle.Bold);
            PdfStringFormat format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Center;
            format.LineAlignment = PdfVerticalAlignment.Middle;
            footer.Graphics.DrawString(footerText, font, brush, new RectangleF(0, 18, footer.Width, footer.Height), format);

            format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Right;
            format.LineAlignment = PdfVerticalAlignment.Bottom;

            //Create page number field
            PdfPageNumberField pageNumber = new PdfPageNumberField(font, brush);

            //Create page count field
            PdfPageCountField count = new PdfPageCountField(font, brush);

            PdfCompositeField compositeField = new PdfCompositeField(font, brush, "Page {0} of {1}", pageNumber, count);
            compositeField.Bounds = footer.Bounds;
            compositeField.Draw(footer.Graphics, new PointF(470, 40));

            //Add the footer template at the bottom
            doc.Template.Bottom = footer;

        }
    }
}
