using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using ComponentPro.Pdf;
using ComponentPro.Pdf.Graphics;
using ComponentPro.Pdf.Fields;
using ComponentPro.HtmlConverter;

namespace PdfDemo.Samples.Converters
{
    public partial class HTML_to_PDF : ExampleControlBase
    {
        public HTML_to_PDF()
        {
            InitializeComponent();
            cbxPageRotation.SelectedIndex = 0;
        }

        public override bool Create()
        {
            if (this.chkPageBreak.Checked && rdbBitmap.Checked)
            {
                MessageBox.Show("The PageBreak option only works with Metafile ImageType.");
                return false;
            }

            PdfDocument doc;

            if (chkPDFA1.Checked)
            {
                //Create a PDF document in PDF_A1B standard
                doc = new PdfDocument(PdfDocumentConformanceLevel.Pdf_A1B);
            }
            else
            {
                //Create a PDF document
                doc = new PdfDocument();
            }

            //Set page margins
            doc.PageSettings.SetMargins((float)this.nudMargin.Value);

            //Set page orientation
            if (rdoPortrait.Checked)
                doc.PageSettings.Orientation = PdfPageOrientation.Portrait;
            else
                doc.PageSettings.Orientation = PdfPageOrientation.Landscape;

            //Set rotation
            doc.PageSettings.Rotate = (PdfPageRotateAngle)this.cbxPageRotation.SelectedIndex;

            //Add a page
            PdfPage page = doc.Pages.Add();

            SizeF pageSize = page.GetClientSize();

            //Adding Header
            if (chkHeader.Checked)
                AddHeader(doc, "Ultimate PDF", " ");

            //Adding Footer
            if (chkFooter.Checked)
                AddFooter(doc, "@Copyright ComponentPro " + DateTime.Now.Year);

            PdfUnitConvertor convertor = new PdfUnitConvertor();
            float width = -1;
            float height = -1;

            //Calculates the height and width of the pdf image
            AspectRatio dimension = AspectRatio.None;
            if (rdoHeight.Checked)
            {
                dimension = AspectRatio.KeepHeight;
                height = convertor.ConvertToPixels(page.GetClientSize().Height, PdfGraphicsUnit.Point);
            }
            else if (rdoWidth.Checked)
            {
                dimension = AspectRatio.KeepWidth;
                width = convertor.ConvertToPixels(page.GetClientSize().Width, PdfGraphicsUnit.Point);
            }

            Html2PdfOptions options = new Html2PdfOptions();
            options.EnableJavaScript = this.chkJavaScript.Checked;
            options.AutoDetectPageBreak = this.chkPageBreak.Checked;
            options.EnableHyperlinks = this.chkHyperlink.Checked;
            options.Width = (int)width;
            options.Height = (int)height;
            options.SplitTextLines = this.chk_TextBreak.Checked;
            options.AspectRatio = dimension;
            options.ImageType = rdbBitmap.Checked ? ImageType.Bitmap : ImageType.Metafile;

            doc.ImportHtml(txtUrl.Text, options);

            //Save the document.
            doc.Save(OutputFile);

            return true;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new System.Windows.Forms.OpenFileDialog();

            openFile.Filter = "HTML files *.html|*.html" + (char)0 + "HTM files *.htm|*.htm" + (char)0 + "All files *.*|*.*";
            openFile.Title = "Select a file";
            openFile.FileName = txtUrl.Text;
            if (openFile.ShowDialog() != DialogResult.OK)
                return;

            txtUrl.Text = openFile.FileName;
        }

        #region Helper Methods
        
        private static void AddHeader(PdfDocument doc, string title, string description)
        {
            RectangleF rect = new RectangleF(0, 0, doc.Pages[0].GetClientSize().Width, 50);

            //Create page template
            PdfPageTemplateElement  header = new PdfPageTemplateElement(rect);
            Color activeColor = Color.FromArgb(44, 71, 120);
            SizeF imageSize = new SizeF(250f, 30f);
            //Locating the logo on the right corner of the Drawing Surface
            PointF imageLocation = new PointF(doc.Pages[0].GetClientSize().Width - imageSize.Width - 20, 5);

            PdfImage img = new PdfBitmap(Util.DataDir + "\\logo.gif");

            //Draw the image in the Header.
            header.Graphics.DrawImage(img, imageLocation, imageSize);

            PdfSolidBrush brush = new PdfSolidBrush(activeColor);

            Font f = new Font("Helvetica", 16, FontStyle.Bold);
            PdfFont font = new PdfTrueTypeFont(f, true);

            //Set formattings for the text
            PdfStringFormat format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Left;
            format.LineAlignment = PdfVerticalAlignment.Middle;

            //Draw title
            header.Graphics.DrawString(title, font, brush, new RectangleF(10, 0, header.Width, header.Height), format);
            brush = new PdfSolidBrush(Color.Gray);
            f = new Font("Helvetica", 6, FontStyle.Bold);
            font = new PdfTrueTypeFont(f, true);

            format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Left;
            format.LineAlignment = PdfVerticalAlignment.Bottom;

            //Draw description
            header.Graphics.DrawString(description, font, brush, new RectangleF(0, 0, header.Width, header.Height - 8), format);

            //Add header template at the top.
            doc.Template.Top = header;
        }

        private static void AddFooter(PdfDocument doc, string footerText)
        {
            RectangleF rect = new RectangleF(0, 0, doc.Pages[0].GetClientSize().Width, 50);

            //Create a page template
            PdfPageTemplateElement  footer = new PdfPageTemplateElement(rect);

            PdfSolidBrush brush = new PdfSolidBrush(Color.Gray);

            Font f = new Font("Helvetica", 6, FontStyle.Bold);
            PdfFont font = new PdfTrueTypeFont(f, true);

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

        #endregion

        public override string GenerateButtonText
        {
            get
            {
                return "Convert";
            }
        }

        public override string Title
        {
            get { return "HTML to PDF Demo"; }
        }

        public override string Description
        {
            get { return "This example demonstrates how to convert a HTML file/Url to a PDF file."; }
        }
    }
}
