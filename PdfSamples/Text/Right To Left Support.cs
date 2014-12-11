using System.Drawing;
using System.Text;
using System.IO;

using ComponentPro.Pdf;
using ComponentPro.Pdf.Graphics;

namespace PdfDemo.Samples.Text
{
    public partial class Right_To_Left_Support : ExampleControlBase
    {
        public Right_To_Left_Support()
        {
            InitializeComponent();
        }

        protected override void RenderPdf(PdfDocument doc)
        {
            //Add a page
            PdfPage page = doc.Pages.Add();

            //Create font
            Font f = new Font("Tahoma", 14);
            PdfFont font = new PdfTrueTypeFont(f, true);
            string path = Util.DataDir + "\\Arabic.txt";

            //Read the text from text file
            StreamReader reader = new StreamReader(path, Encoding.Unicode);
            string text = reader.ReadToEnd();
            reader.Close();

            //Create a brush
            PdfBrush brush = new PdfSolidBrush(Color.Black);
            PdfPen pen = new PdfPen(Color.Black);
            SizeF clipBounds = page.Graphics.ClientSize;
            RectangleF rect = new RectangleF(0, 0, clipBounds.Width, clipBounds.Height / 4f);

            //Set the property for RTL text
            PdfStringFormat format = new PdfStringFormat();
            format.RightToLeft = true;
            format.ParagraphIndent = 35f;

            page.Graphics.DrawString(text, font, brush, rect, format);
            page.Graphics.DrawRectangle(pen, rect);
            page.Graphics.DrawString("Top Left", font, brush, new PointF(rect.Left + 5, rect.Bottom - 25));

            //Set the alignment
            format.Alignment = PdfTextAlignment.Center;
            rect.Offset(0, rect.Height);
            page.Graphics.DrawString(text, font, brush, rect, format);
            page.Graphics.DrawRectangle(pen, rect);
            page.Graphics.DrawString("Top Center", font, brush, new PointF(rect.Left + 5, rect.Bottom - 25));

            format.Alignment = PdfTextAlignment.Right;
            rect.Offset(0, rect.Height);
            page.Graphics.DrawString(text, font, brush, rect, format);
            page.Graphics.DrawRectangle(pen, rect);
            page.Graphics.DrawString("Top Right", font, brush, new PointF(rect.Left + 5, rect.Bottom - 25));

            format.Alignment = PdfTextAlignment.Justify;
            format.LineAlignment = PdfVerticalAlignment.Middle;
            rect.Offset(0, rect.Height);
            page.Graphics.DrawString(text, font, brush, rect, format);
            page.Graphics.DrawRectangle(pen, rect);
            page.Graphics.DrawString("Middle and Justified", font, brush, new PointF(rect.Left + 5, rect.Bottom - 25));
        }

        public override string Title
        {
            get { return "Right to Left Demo"; }
        }

        public override string Description
        {
            get { return "This example demonstrates Right-To-Left text align support in UltimatePdf."; }
        }
    }
}
