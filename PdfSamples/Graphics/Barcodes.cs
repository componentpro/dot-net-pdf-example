using System.Drawing;
using ComponentPro.Pdf;
using ComponentPro.Pdf.Graphics;
using ComponentPro.Pdf.Graphics.Barcode;

namespace PdfDemo.Samples.Graphics
{
    public partial class Barcodes : ExampleControlBase
    {
        public Barcodes()
        {
            InitializeComponent();
        }

        protected override void RenderPdf(PdfDocument doc)
        {
            //Add a page
            PdfPage page = doc.Pages.Add();

            //Create Pdf graphics for the page
            PdfGraphics g = page.Graphics;

            //Create a solid brush
            PdfBrush brush = new PdfSolidBrush(Color.Black);
            const float fontSize = 15f;
            //Set the font
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, fontSize,PdfFontStyle.Bold);

            // Drawing String
            g.DrawString("BarCodes", font, brush, new PointF(230, 10));

            font = new PdfStandardFont(PdfFontFamily.Courier, 10, PdfFontStyle.Italic);

            PdfPen pen = new PdfPen(PdfBrushes.DarkGray, 0.5f);            

            PdfStringFormat format = new PdfStringFormat();
            format.WordWrap = PdfWordWrap.Word;

            #region Codabar
            int y = 70;
            // Drawing CodaBarcode
            PdfCodabar codabar = new PdfCodabar();
            // Setting height of the barcode
            codabar.BarHeight = 45;            
            codabar.Text = "0123";                      
            //Printing barcode on to the Pdf.
            codabar.Draw(page, new PointF(25, y));

            g.DrawString("Type : Codabar", font, PdfBrushes.Black, new PointF(200, y + 5));
            g.DrawString("Allowed Characters : A,B,C,D,0-9,-$,:,/,a dot(.),+ ", font, PdfBrushes.Black, new PointF(200, y + 25));

            g.DrawLine(pen, new PointF(0, y + 70), new PointF(page.GetClientSize().Width, y + 70));
            #endregion             

            #region Code11Barcode
            y += 100;            
            // Drawing Code11  barcode
            PdfCode11 barcode11 = new PdfCode11();
            // Setting height of the barcode
            barcode11.BarHeight = 45;
            barcode11.Text = "012345678";
            barcode11.EncodeStartStopSymbols = true;
            //Printing barcode on to the Pdf.
            barcode11.Draw(page, new PointF(25, y));

            g.DrawString("Type : Code 11", font, PdfBrushes.Black, new PointF(200, y + 5));
            g.DrawString("Allowed Characters : 0-9, a dash(-) ", font, PdfBrushes.Black, new PointF(200, y + 25));

            g.DrawLine(pen, new PointF(0, y + 70), new PointF(page.GetClientSize().Width, y + 70));
            #endregion

            #region Code32
            y += 100;
            PdfCode32 code32 = new PdfCode32();

            code32.Font = font;

            // Setting height of the barcode
            code32.BarHeight = 45;
            code32.Text = "01234567";
            code32.TextDisplayLocation = TextLocation.Bottom;
            code32.EnableCheckDigit = true;
            code32.ShowCheckDigit = true;

            //Printing barcode on to the Pdf.
            code32.Draw(page, new PointF(25, y));

            g.DrawString("Type : Code32", font, PdfBrushes.Black, new PointF(200, y + 5));
            g.DrawString("Allowed Characters : 1 2 3 4 5 6 7 8 9 0 ", font, PdfBrushes.Black, new PointF(200, y + 25));

            g.DrawLine(pen, new PointF(0, y + 70), new PointF(page.GetClientSize().Width, y + 70));

            #endregion

            #region Code39
            y += 100;
            // Drawing Code39 barcode
            PdfCode39 barcode = new PdfCode39();
            // Setting height of the barcode
            barcode.BarHeight = 45;            
            barcode.Text = "CODE39$";         
            //Printing barcode on to the Pdf.
            barcode.Draw(page, new PointF(25, y));

            g.DrawString("Type : Code39", font, PdfBrushes.Black, new PointF(200, y + 5));
            g.DrawString("Allowed Characters : 0-9, A-Z,a dash(-),a dot(.),$,/,+,%, SPACE", font, PdfBrushes.Black, new PointF(200, y + 25));
            
            g.DrawLine(pen, new PointF(0, y + 70), new PointF(page.GetClientSize().Width, y + 70));
            #endregion

            #region Code39Extended
            y += 100;
            // Drawing Code39Extended barcode
            PdfCode39Extended barcodeExt = new PdfCode39Extended();
            // Setting height of the barcode
            barcodeExt.BarHeight = 45;            
            barcodeExt.Text = "CODE39Ext";          
            //Printing barcode on to the Pdf.
            barcodeExt.Draw(page, new PointF(25, y));

            g.DrawString("Type : Code39Ext", font, PdfBrushes.Black, new PointF(200, y + 5));
            g.DrawString("Allowed Characters : 0-9 A-Z a-z ", font, PdfBrushes.Black, new PointF(200, y + 25));
            
            g.DrawLine(pen, new PointF(0, y + 70), new PointF(page.GetClientSize().Width, y + 70));
            #endregion  

            #region Code93

            PdfCode93 code93 = new PdfCode93();
            y += 100;
            // Setting height of the barcode
            code93.BarHeight = 45;
            code93.Text = "ABC 123456789";
            //Printing barcode on to the Pdf.
            code93.Draw(page, new PointF(25, y));


            g.DrawString("Type : Code93", font, PdfBrushes.Black, new PointF(200, y + 5));
            g.DrawString("Allowed Characters : 1 2 3 4 5 6 7 8 9 0 A B C D E F G H I J K L M N O P Q R S T U V W X Y Z - . $ / + % SPACE ", font, PdfBrushes.Black, new RectangleF(200, y + 25,300,200),format);

            g.DrawLine(pen, new PointF(0, y + 70), new PointF(page.GetClientSize().Width, y + 70));
            #endregion
            
            #region Code93Extended
            y += 100;
            PdfCode93Extended code93Ext = new PdfCode93Extended();
            
            //Setting height of the barcode
            code93Ext.BarHeight = 45;
            code93Ext.EncodeStartStopSymbols = true;
            code93Ext.Text = "(abc) 123456789";

            //Printing barcode on to the Pdf.
            code93Ext.Draw(page, new PointF(25, y));

            g = page.Graphics;
            g.DrawString("Type : Code93 Extended", font, PdfBrushes.Black, new PointF(200, y + 5));
            g.DrawString("Allowed Characters : All 128 ASCII characters ", font, PdfBrushes.Black, new PointF(200, y + 25));

            g.DrawLine(pen, new PointF(0, y + 70), new PointF(page.GetClientSize().Width, y + 70));
            #endregion

            page = doc.Pages.Add();
            g = page.Graphics;

            #region Code128
            y = 50;
            PdfCode128A barcode128A = new PdfCode128A();
            // Setting height of the barcode
            barcode128A.BarHeight = 45;
            barcode128A.Text = "ABCD 12345";
            barcode128A.EnableCheckDigit = true;
            barcode128A.EncodeStartStopSymbols = true;
            barcode128A.ShowCheckDigit = true;
           
            //Printing barcode on to the Pdf.
            barcode128A.Draw(page, new PointF(25, y));

            g.DrawString("Type : Code128 A", font, PdfBrushes.Black, new PointF(200, y + 5));
            g.DrawString("Allowed Characters : NUL (0x00) SOH (0x01) STX (0x02) ETX (0x03) EOT (0x04) ENQ (0x05) ACK (0x06) BEL (0x07) BS (0x08) HT (0x09) LF (0x0A) VT (0x0B) FF (0x0C) CR (0x0D) SO (0x0E) SI (0x0F) DLE (0x10) DC1 (0x11) DC2 (0x12) DC3 (0x13) DC4 (0x14) NAK (0x15) SYN (0x16) ETB (0x17) CAN (0x18) EM (0x19) SUB (0x1A) ESC (0x1B) FS (0x1C) GS (0x1D) RS (0x1E) US (0x1F) SPACE (0x20) \" ! # $ % & ' ( ) * + , - . / 0 1 2 3 4 5 6 7 8 9 : ; < = > ? @ A B C D E F G H I J K L M N O P Q R S T U V W X Y Z [ / ]^ _  ", font, PdfBrushes.Black, new RectangleF(200, y + 25,300,200),format);

            g.DrawLine(pen, new PointF(0, y + 170), new PointF(page.GetClientSize().Width, y + 170));

            y += 200;
            PdfCode128B barcode128B = new PdfCode128B();
            // Setting height of the barcode
            barcode128B.BarHeight = 45;
            barcode128B.Text = "12345 abcd";
            barcode128B.EnableCheckDigit = true;
            barcode128B.EncodeStartStopSymbols = true;
            barcode128B.ShowCheckDigit = true;

            //Printing barcode on to the Pdf.
            barcode128B.Draw(page, new PointF(25, y));

            g.DrawString("Type : Code128 B", font, PdfBrushes.Black, new PointF(200, y + 5));
            g.DrawString("Allowed Characters : SPACE (0x20) !  \" # $ % & ' ( ) * + , - . / 0 1 2 3 4 5 6 7 8 9 : ; < = > ? @ A B C D E F G H I J K L M N O P Q R S T U V W X Y Z [ / ]^ _ ` a b c d e f g h i j k l m n o p q r s t u v w x y z { | } ~ DEL (\x7F)  ", font, PdfBrushes.Black,new RectangleF(200, y + 25,300,200),format);

            g.DrawLine(pen, new PointF(0, y + 100), new PointF(page.GetClientSize().Width, y + 100));

            y += 130;
            PdfCode128C barcode128C = new PdfCode128C();
            // Setting height of the barcode
            barcode128C.BarHeight = 45;
            barcode128C.Text = "001122334455";
            barcode128C.EnableCheckDigit = true;
            barcode128C.EncodeStartStopSymbols = true;
            barcode128C.ShowCheckDigit = true;

            //Printing barcode on to the Pdf.
            barcode128C.Draw(page, new PointF(25, y));

            g.DrawString("Type : Code128 C", font, PdfBrushes.Black, new PointF(200, y + 5));
            g.DrawString("Allowed Characters : 0 1 2 3 4 5 6 7 8 9 ", font, PdfBrushes.Black, new PointF(200, y + 25));

            g.DrawLine(pen, new PointF(0, y + 70), new PointF(page.GetClientSize().Width, y + 70));

            #endregion
        }

        public override string Title
        {
            get { return "Barcodes Demo"; }
        }

        public override string Description
        {
            get { return "This example demonstrates how to draw barcodes on a PDF document."; }
        }
    }
}
