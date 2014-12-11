using System;
using System.Drawing;
using ComponentPro.Pdf;
using ComponentPro.Pdf.Graphics;
using ComponentPro.Pdf.Fields;

namespace PdfDemo.Samples.Text
{
    public partial class Multiple_Columns_Support : ExampleControlBase
    {
        public Multiple_Columns_Support()
        {
            InitializeComponent();
        }

        protected override void RenderPdf(PdfDocument doc)
        {
           doc.PageSettings.Size = new SizeF(870, 732);

            // Add a page
            PdfPage page = doc.Pages.Add();            

            PdfSolidBrush brush = new PdfSolidBrush(Color.Black);

            // Create font
            PdfStandardFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 2f);

            // Adding Header
            AddDocumentHeader(doc, "Multiple Columns Demo");

            // Adding Footer
            AddDocumentFooter(doc, "Copyright © " + DateTime.Now.Year);

            #region About UltimatePdf HTML text

            string htmlText =
                "<font color='#FF0000F'>Ultimate PDF</font> for .NET is a 100%-managed PDF document component that helps you to add PDF capabilities in your .NET applications. With a few lines of code, " +
                "you can create a complex PDF document from scratch or load an existing PDF file.<br/><br/>In addition to the ease-of-use and flexibility, the Ultimate PDF component " +
                "also offers many features including: drawing text, image, tables and other shapes, compression, hyperlinks, security and custom fonts. PDF files created " +
                "using the <font color='#FF0000F'>Ultimate PDF</font> component are compatible with all versions of Adobe Acrobat or the free version and Acrobat Viewer from Adobe only.";

            // Rendering HtmlText
            PdfHtmlElement richTextElement = new PdfHtmlElement(htmlText, font, brush);
            richTextElement.TextAlign = TextAlign.Justify;
            // Formatting Layout
            PdfMetafileLayoutSettings format = new PdfMetafileLayoutSettings();
            format.Layout = PdfLayoutType.OnePage;
            // Drawing htmlString
            richTextElement.Draw(page, new RectangleF(0, 15, 250, page.GetClientSize().Height), format);

            // Drawing PDF Image
            PdfBitmap image = new PdfBitmap(System.Drawing.Image.FromFile(Util.DataDir + "\\UltimatePdf.gif"));
            page.Graphics.DrawImage(image, new PointF(50, 265));

            htmlText = "Fully-managed .NET components written in C#.<br/>" +
                                "Comprehensive integrated product documentation and 4 Sample projects written in C#, VB.NET and ASP.NET.<br/>" +
                                "UltimatePdf can run under .NET Framework 2.x and above (3.x, ...).<br/>" +
                                "Seamless integration with popular development environments including Microsoft Visual Studio .NET and CodeGear products.<br/>" +
                                "Supports Visual Studio 2005, 2008, 2010, Delphi, C# Builder and other compliant development environments.";

            // Rendering HtmlText
            richTextElement = new PdfHtmlElement(htmlText, font, brush);
            richTextElement.TextAlign = TextAlign.Justify;
            // Formatting Layout
            format = new PdfMetafileLayoutSettings();
            format.Layout = PdfLayoutType.OnePage;
            // Drawing htmlString
            richTextElement.Draw(page, new RectangleF(0, 410, 240, page.GetClientSize().Height), format);

            #endregion

            #region About PDF

            htmlText = "<b>PDF</b> stands for \"Portable Document Format\"." +
                " The key word is <u>portable</u>, intended to combine the qualities of <i>authenticity," +
                " reliability and ease of use together into a single packaged concept</i>.<br/><br/>" +
                "Adobe Systems invented PDF technology in the early 1990s to smooth the " +
                "process of moving text and graphics from publishers to printing-presses." +
                " <b>PDF</b> turned out to be the very essence of paper, brought to life in a computer." +
                " In creating PDF, Adobe had almost unwittingly invented nothing less than a " +
                "bridge between the paper and computer worlds. <br/><br/>To be truly portable, an authentic electronic " +
                "document would have to appear exactly the same way on any computer at any time," +
                " at no cost to the user. It will deliver the exact same results in print or on-screen " +
                "with near-total reliability.";

            richTextElement = new PdfHtmlElement(htmlText, font, brush);
            richTextElement.TextAlign = TextAlign.Justify;
            richTextElement.Draw(page, new RectangleF(195, 15, 295, page.GetClientSize().Height), format);

            image = new PdfBitmap(System.Drawing.Image.FromFile(Util.DataDir + "\\PdfLogo.png"));
            page.Graphics.DrawImage(image, new PointF(50 + 210, 265));

            htmlText = "<b>PDF</b> is used for representing two-dimensional documents in " +
            "a manner independent of the application software, hardware, and operating system.<sup>[1]</sup>" +
            "<br/><br/>Each PDF file encapsulates a complete description of a fixed-layout 2-D document " +
            "(and, with Acrobat 3-D, embedded 3-D documents) that includes the text, fonts, images, " +
            "and 2-D vector graphics which comprise the documents." +
            " <br/><br/><b>PDF</b> is an open standard that was officially published on July 1, 2008 by the ISO as" +
            "ISO 32000-1:2008.<sub>[1]</sub><br/><br/>" +
            "The PDF combines the technologies such as A sub-set of the PostScript page description programming " +
            "language, a font-embedding/replacement system to allow fonts to travel with the documents and a " +
            "structured storage system to bundle these elements and any associated content into a single file," +
            "with data compression where appropriate. <font size=\"1\">1-http://www.adobe.com/devnet/acrobat/pdfs/pdf_reference_1-7.pdf</font>";

            richTextElement = new PdfHtmlElement(htmlText, font, brush);
            richTextElement.TextAlign = TextAlign.Justify;
            richTextElement.Draw(page, new RectangleF(195, 395, 295, page.GetClientSize().Height + 10), format);

            #endregion

            #region About ComponentPro

            // Drawing Image
            image = new PdfBitmap(System.Drawing.Image.FromFile(Util.DataDir + "\\Logo.gif"));
            page.Graphics.DrawImage(image, new PointF(435, 15));

            htmlText = "ComponentPro, a division of ComponentPro, located in Walnut, California, is a leading provider of File Transfer, Mail, Compression, and SAML" +
                       "- Single Sign On components. We specialize in developing network tools and libraries for Windows developers and providing custom software " +
                       "development and consulting services. Building on its expertise in networking development and Microsoft technologies, " +
                       "ComponentPro helps customers to build competitive applications on their markets." + 
                       "<br/><br/>Every ComponentPro license includes a <i>one-year subscription</i> for unlimited technical support and new releases." +
                       "ComponentPro licenses each product on a simple per-developer basis and charges no royalties," +
                       "runtimes, or server deployment fees. A licensee can install his/her " +
                       "license on multiple personal machines at <u>no extra charge.</u><br/><br/>" +
                       "At ComponentPro we are very excited about the Microsoft .NET platform.<br/><br/>" +
                       "We believe that one of the key benefits of <i>.NET</i> is improved programmer productivity. " +
                       "Solutions that used to take a very long time with traditional tools can now be " +
                       "implemented in a much shorter time period with the <i>.NET</i> platform.";
            richTextElement = new PdfHtmlElement(htmlText, font, brush);
            richTextElement.TextAlign = TextAlign.Justify;
            richTextElement.Draw(page, new RectangleF(425, 55, 290, page.GetClientSize().Height), format);

            #endregion
        }

        private static void AddDocumentHeader(PdfDocument doc, string title)
        {
            RectangleF rect = new RectangleF(0, 0, doc.Pages[0].GetClientSize().Width, 50);

            // Create page template
            PdfPageTemplateElement  header = new PdfPageTemplateElement(rect);
            Color activeColor = System.Drawing.Color.FromArgb(44, 71, 120);
            SizeF imageSize = new SizeF(252f, 34f);
            // Locating the logo on the right corner of the Drawing Surface
            PointF imageLocation = new PointF(0, 9);

            PdfImage img = new PdfBitmap(Util.DataDir + "\\logo.gif");

            // Draw the image in the Header.
            header.Graphics.DrawImage(img, imageLocation, imageSize);

            PdfSolidBrush brush = new PdfSolidBrush(activeColor);

            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 16, PdfFontStyle.Bold);

            // Set formattings for the text
            PdfStringFormat format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Right;
            format.LineAlignment = PdfVerticalAlignment.Middle;

            // Draw title
            header.Graphics.DrawString(title, font, brush, new RectangleF(0, 0, header.Width, header.Height), format);
            
            format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Left;
            format.LineAlignment = PdfVerticalAlignment.Bottom;            

            // Add header template at the top.
            doc.Template.Top = header;

        }

        private static void AddDocumentFooter(PdfDocument doc, string footerText)
        {
            RectangleF rect = new RectangleF(0, 0, doc.Pages[0].GetClientSize().Width, 50);

            //Create a page template
            PdfPageTemplateElement footer = new PdfPageTemplateElement(rect);

            PdfSolidBrush brush = new PdfSolidBrush(Color.Black);

            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 10, PdfFontStyle.Bold);
            PdfStringFormat format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Left;
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
            compositeField.Draw(footer.Graphics, new PointF(570, 40));

            //Add the footer template at the bottom
            doc.Template.Bottom = footer;

        }

        public override string Title
        {
            get { return "Multiple Columns Text Demo"; }
        }

        public override string Description
        {
            get { return "This example demonstrates how to draw multi columns text."; }
        }
    }
}
