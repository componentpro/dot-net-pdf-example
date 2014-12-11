using System.Drawing;
using ComponentPro.Pdf;
using ComponentPro.Pdf.Graphics;
using ComponentPro.Pdf.Lists;

namespace PdfDemo.Samples.Text
{
    public partial class Bullets_And_Lists : ExampleControlBase
    {
        public Bullets_And_Lists()
        {
            InitializeComponent();
        }

        protected override void RenderPdf(PdfDocument document)
        {
            //Add a page
            PdfPage page = document.Pages.Add();
            PdfGraphics graphics = page.Graphics;

            //Create a unordered list
            PdfBulletedList list = new PdfBulletedList();

            //Set the marker style
            list.Marker.Style = PdfBulletedListItemMarkerStyle.Disk;

            //Create a font and write title
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 14, PdfFontStyle.Bold);
            graphics.DrawString("Bullets and Lists", font, PdfBrushes.DarkBlue, new PointF(225, 10));

            string[] products = { "Red", "Green", "Blue" };

            font = new PdfStandardFont(PdfFontFamily.Helvetica, 12, PdfFontStyle.Regular);
            graphics.DrawString("This sample demonstrates how to draw numbered list and bulleted list.", font, PdfBrushes.Black, new RectangleF(0, 50, page.Graphics.ClientSize.Width, page.Graphics.ClientSize.Height));

            //Create string format
            PdfStringFormat format = new PdfStringFormat();
            format.LineSpacing = 20f;

            font = new PdfStandardFont(PdfFontFamily.Helvetica, 10, PdfFontStyle.Bold);

            //Apply formattings to list
            list.Font = font;
            list.StringFormat = format;

            //Set list indent
            list.Indent = 10;

            //Add items to the list
            list.Items.Add("Colors");
            list.Items.Add("Products");

            //Set text indent
            list.TextIndent = 10;

            //Create Ordered list as sublist of parent list
            PdfNumberedList subList = new PdfNumberedList();
            subList.Marker.Brush = PdfBrushes.Black;
            subList.Indent = 20;
            list.Items[0].SubList = subList;

            //Set format for sub list
            font = new PdfStandardFont(PdfFontFamily.Helvetica, 10, PdfFontStyle.Italic);
            subList.Font = font;
            subList.StringFormat = format;
            foreach (string s in products)
            {
                //Add items
                subList.Items.Add(s);
            }

            //Create unorderd sublist for the second item of parent list
            PdfBulletedList subsubList = new PdfBulletedList();
            subsubList.Marker.Brush = PdfBrushes.Black;
            subsubList.Indent = 20;
            list.Items[1].SubList = subsubList;

            PdfImage image = PdfImage.FromFile(Util.DataDir + "\\Logo.gif");
            font = new PdfStandardFont(PdfFontFamily.TimesRoman, 10, PdfFontStyle.Regular);
            subsubList.Font = font;
            subsubList.StringFormat = format;

            //Add subitems
            subsubList.Items.Add("Ultimate PDF");
            subsubList.Items.Add("Ultimate FTP");
            subsubList.Items.Add("Ultimate SFTP");
            subsubList.Items.Add("Ultimate FTP Expert");
            subsubList.Items.Add("Ultimate SSH Shell Telnet");            
            subsubList.Items.Add("Ultimate Mail");
            subsubList.Items.Add("Ultimate Mail Expert");
            subsubList.Items.Add("Ultimate Bounce Inspector");
            subsubList.Items.Add("Ultimate Email Validator");
            subsubList.Items.Add("Ultimate Template Engine");
            subsubList.Items.Add("Ultimate Zip");
            subsubList.Items.Add("Ultimate SAML");
            subsubList.Items.Add("Ultimate Dns");

            //Set image as marker
            subsubList.Marker.Image = image;

            //Draw list
            list.Draw(page, new RectangleF(0, 130, page.Graphics.ClientSize.Width, page.Graphics.ClientSize.Height));
        }

        public override string Title
        {
            get { return "Bullets and Lists Demo"; }
        }

        public override string Description
        {
            get { return "This example demonstrates how to draw bullets & lists."; }
        }
    }
}
