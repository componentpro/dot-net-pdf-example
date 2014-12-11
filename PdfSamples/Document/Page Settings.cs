using System.Drawing;
using ComponentPro.Pdf;
using ComponentPro.Pdf.Graphics;
using ComponentPro.Pdf.Fields;

namespace PdfDemo.Samples.Document
{
    public partial class Page_Settings : ExampleControlBase
    {
        public Page_Settings()
        {
            InitializeComponent();
        }

        protected override void RenderPdf(PdfDocument doc)
        {
            PdfSection section;

            // Create few sections with one page in each.
            for (int i = 0; i < 5; ++i)
            {
                section = doc.Sections.Add();

                //Create page label
                PdfPageLabel label = new PdfPageLabel();

                label.Prefix = "Sec" + i + "-";
                section.PageLabel = label;
                section.Pages.Add();
                section.Pages[0].Graphics.SetTransparency(0.55f);
                section.PageSettings.Transition.PageDuration = 1;
                section.PageSettings.Transition.Duration = 1;
                section.PageSettings.Transition.Style = PdfTransitionEffect.Box;
            }

            //Set page size
            doc.PageSettings.Size = PdfPageSize.A6;

            //Set viewer prefernce.
            doc.ViewerPreferences.HideToolbar = true;
            doc.ViewerPreferences.PageMode = PdfPageDisplayMode.DisplayFullScreen;

            //Set page orientation
            doc.PageSettings.Orientation = PdfPageOrientation.Landscape;

            //Create a brush
            PdfSolidBrush brush = new PdfSolidBrush(Color.Black);
            brush.Color = new PdfColor(System.Drawing.Color.FromArgb(0xa0, 0xa0, 0xa0));

            //Create a Rectangle
            PdfRectangle rect = new PdfRectangle(0, 0, 1000f, 1000f);
            rect.Brush = brush;
            PdfPen pen = new PdfPen(System.Drawing.Color.Blue);
            pen.Width = 6f;

            //Get the first page in first section
            PdfPage page = doc.Sections[0].Pages[0];

            //Draw the rectangle
            rect.Draw(page.Graphics);

            // Add margins.
            doc.PageSettings.SetMargins(0f);

            //Get the first page in second section
            page = doc.Sections[1].Pages[0];
            doc.Sections[1].PageSettings.Rotate = PdfPageRotateAngle.RotateAngle90;
            rect.Draw(page.Graphics);

            // Change the angle f the section. This should rotate the previous page.
            doc.Sections[2].PageSettings.Rotate = PdfPageRotateAngle.RotateAngle180;
            page = doc.Sections[2].Pages[0];
            rect.Draw(page.Graphics);

            // Change the angle f the section. This should rotate the previous page.
            doc.Sections[3].PageSettings.Rotate = PdfPageRotateAngle.RotateAngle270;
            page = doc.Sections[3].Pages[0];
            rect.Draw(page.Graphics);

            section = doc.Sections[4];
            section.PageSettings.Orientation = PdfPageOrientation.Portrait;
            page = section.Pages[0];
            rect.Draw(page.Graphics);

            //Set the font
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 16f);
            PdfSolidBrush fieldBrush = new PdfSolidBrush(Color.Black);

            //Create page number field
            PdfPageNumberField pageNumber = new PdfPageNumberField(font, fieldBrush);

            //Create page count field
            PdfPageCountField count = new PdfPageCountField(font, fieldBrush);

            //Draw page template
            PdfPageTemplateElement templateElement = new PdfPageTemplateElement(400, 400);
            templateElement.Graphics.DrawString("Page :\tof", font, PdfBrushes.Black, new PointF(260, 200));

            //Draw current page number
            pageNumber.Draw(templateElement.Graphics, new PointF(306, 200));

            //Draw number of pages
            count.Draw(templateElement.Graphics, new PointF(345, 200));
            doc.Template.Stamps.Add(templateElement);
            templateElement.Background = true;
        }

        public override string Title
        {
            get { return "Hello World Demo"; }
        }

        public override string Description
        {
            get { return "This example demonstrates how to use set page settings."; }
        }
    }
}
