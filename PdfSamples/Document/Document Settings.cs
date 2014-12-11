using System;
using System.Drawing;
using ComponentPro.Pdf;
using ComponentPro.Pdf.Graphics;
using ComponentPro.Pdf.Xmp;

namespace PdfDemo.Samples.Document
{
    public partial class Document_Settings : ExampleControlBase
    {
        public Document_Settings()
        {
            InitializeComponent();
        }

        protected override void RenderPdf(PdfDocument doc)
        {
            PdfPage page = doc.Pages.Add();

            // Get xmp object.
            XmpMetadata xmp = doc.DocumentInformation.XmpMetadata;


            // XMP Basic Schema.
            XmpBasicSchema basic = xmp.BasicSchema;
            basic.Advisory.Add("advisory");
            basic.BaseURL = new Uri("http://google.com");
            basic.CreateDate = DateTime.Now;
            basic.CreatorTool = "creator tool";
            basic.Identifier.Add("identifier");
            basic.Label = "label";
            basic.MetadataDate = DateTime.Now;
            basic.ModifyDate = DateTime.Now;
            basic.Nickname = "nickname";
            basic.Rating.Add(-25);

            //Setting various Document properties.
            doc.DocumentInformation.Title = "Document Properties Information";
            doc.DocumentInformation.Author = "ComponentPro";
            doc.DocumentInformation.Keywords = "PDF";
            doc.DocumentInformation.Subject = "PDF demo";
            doc.DocumentInformation.Producer = "ComponentPro Software";
            doc.DocumentInformation.CreationDate = DateTime.Now;

            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 10f);
            PdfFont boldFont = new PdfStandardFont(PdfFontFamily.Helvetica, 12f, PdfFontStyle.Bold);
            PdfBrush brush = PdfBrushes.Black;

            PdfGraphics g = page.Graphics;
            PdfStringFormat format = new PdfStringFormat();
            format.LineSpacing = 20f;
           
            g.DrawString("Press Ctrl+D to see Document Properties", boldFont, brush, 10, 10);
            g.DrawString("Basic Schema Xml:", boldFont, brush, 10, 50);
            g.DrawString(basic.XmlData.OuterXml, font, brush, new RectangleF(10, 70, 500, 500),format);
           
            //Defines and set values for Custom metadata and add them to the Pdf document
            XmpCustomSchema custom = new XmpCustomSchema(xmp, "custom", "http://www.componentpro.com/");
            custom["Company"] = "ComponentPro";
            custom["Website"] = "http://www.componentpro.com/";
            custom["Product"] = "Ultimate PDF";  
        }

        public override string Title
        {
            get { return "Document Settings Demo"; }
        }

        public override string Description
        {
            get { return "This example demonstrates how to set document information."; }
        }
    }
}
