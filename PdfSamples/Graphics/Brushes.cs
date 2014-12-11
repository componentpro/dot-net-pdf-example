using System;
using System.Drawing;
using System.IO;

using ComponentPro.Pdf;
using ComponentPro.Pdf.Graphics;
using ComponentPro.Pdf.Graphics.ColorSpaces;
using ComponentPro.Pdf.Functions;

namespace PdfDemo.Samples.Graphics
{
    public partial class Brushes : ExampleControlBase
    {
        public Brushes()
        {
            InitializeComponent();
        }

        static void DrawBrushes(PdfDocument document)
        {
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 6f, PdfFontStyle.Bold);
            PdfGraphics g = document.Pages.Add().Graphics;

            PdfBrush onlyBrush = new PdfSolidBrush(Color.Black);
            g.DrawString("PdfBrushes class", font, onlyBrush, new PointF(125, 10));

            Type type = typeof(PdfBrushes);
            object[] parameters = null;
            System.Reflection.PropertyInfo[] properties = type.GetProperties();

            const int boxWidth = 20;
            const int boxHeight = 20;
            const int space = 5;
            const int num = 11;

            for (int i = 0; i < properties.Length; i++)
            {
                int x = (boxWidth + space) * (i % num) + 15;
                int y = (boxHeight + space) * (i / num) + 20;
                
                onlyBrush = (PdfSolidBrush)properties[i].GetValue(null, parameters);
                g.DrawRectangle(onlyBrush, new RectangleF(x, y, boxWidth, boxHeight));
            }
        }

        static void DrawGraphicBrushes(PdfDocument document)
        {
            PdfPage page = document.Pages.Add();
            PdfGraphics graphics = page.Graphics;
            PdfImage image = PdfImage.FromFile(Util.DataDir + "\\Spring.jpg");
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 8f, PdfFontStyle.Bold);

            graphics.DrawString("PDF Graphic Brushes", font, PdfBrushes.Black, new PointF(110, 10));
            //SolidBrush 
            RectangleF rectangle = new RectangleF(35, 20, 50, 50);
            PdfSolidBrush brush = new PdfSolidBrush(Color.Black);

            graphics.DrawEllipse(brush, rectangle);

            graphics.TranslateTransform(60, 0);
            brush = new PdfSolidBrush(Color.Green);
            graphics.DrawEllipse(brush, rectangle);

            graphics.TranslateTransform(60, 0);
            brush.Color = Color.Red;
            PdfBrush someBrush = brush.Clone();
            graphics.DrawEllipse(someBrush, rectangle);

            //TillingBrush 
            graphics.TranslateTransform(60, 0);

            PdfTilingBrush tillingBrush = new PdfTilingBrush(new SizeF(10, 10));
            RectangleF rect = new RectangleF(0, 0, 10, 10);

            tillingBrush.Graphics.DrawImage(image, 0, 0, 10, 10);
            graphics.DrawEllipse(tillingBrush, rectangle);

            graphics.TranslateTransform(-180, 60);
            tillingBrush = new PdfTilingBrush(rect);
            tillingBrush.Graphics.DrawEllipse(PdfPens.Yellow, rect);
            tillingBrush.Graphics.DrawLine(PdfPens.Green, 0, 0, 10, 10);
            tillingBrush.Graphics.DrawLine(PdfPens.Red, 0, 10, 10, 0);
            graphics.DrawEllipse(tillingBrush, rectangle);

            graphics.TranslateTransform(60, 0);

            rect = new RectangleF(0, 0, 20, 20);
            PdfTilingBrush tillingBrushNew = new PdfTilingBrush(rect);

            tillingBrushNew.Graphics.DrawEllipse(tillingBrush, rect);
            graphics.DrawEllipse(tillingBrushNew, rectangle);

            //GradientBrush
            graphics.TranslateTransform(60, 0);
            PdfColor color1 = Color.Red;
            PdfColor color2 = Color.Yellow;
            PdfGradientBrush gradientBrush = new PdfLinearGradientBrush(rectangle.Location, (PointF)rectangle.Size, color1, color2);

            gradientBrush.AntiAlias = false;
            gradientBrush.Background = Color.Green;
            graphics.DrawEllipse(gradientBrush, rectangle);

            graphics.TranslateTransform(60, 0);
            color2 = Color.Green;
            gradientBrush = new PdfLinearGradientBrush(rectangle, color1, color2, 30f);
            gradientBrush.AntiAlias = true;
            graphics.DrawEllipse(gradientBrush, rectangle);

            graphics.TranslateTransform(-180, 60);
            color1 = Color.Yellow;
            gradientBrush = new PdfLinearGradientBrush(rectangle, color1, color2, PdfLinearGradientMode.ForwardDiagonal);
            graphics.DrawEllipse(gradientBrush, rectangle);

            graphics.TranslateTransform(60, 0);
            color1 = Color.Red;
            color2 = Color.Yellow;

            PointF point = new PointF(25, 25);

            gradientBrush = new PdfRadialGradientBrush(point, 50f, point, 5f, color1, color2);
            gradientBrush.AntiAlias = false;
            gradientBrush.Background = Color.Green;
            graphics.DrawEllipse(gradientBrush, rectangle);

            graphics.TranslateTransform(-60, 60);
        }

        static void DrawColorSpaces(PdfDocument document)
        {
            PdfPage page = document.Pages[document.Pages.Count - 1];
            PdfGraphics g = page.Graphics;
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 8f, PdfFontStyle.Bold);

            const int y = 20;
            const int x = 30;

            //Set DeviceRGB Colorspace.
            document.ColorSpace = PdfColorSpace.RGB;
            page.Graphics.DrawString("Device RGB", font, PdfBrushes.Black, new PointF(x, y));
            PdfBrush brush1 = PdfBrushes.Green;
            g.DrawRectangle(brush1, new RectangleF(x + 10, y + 20, 30, 30));

            //Set DeviceCMYK Colorspace.
            document.ColorSpace = PdfColorSpace.CMYK;
            page.Graphics.DrawString("Device CMYK", font, PdfBrushes.Black, new PointF(x + 80, y));
            g.DrawEllipse(brush1, new RectangleF(x + 90, y + 20, 30, 30));

            //Set DeviceGray Colorspace.
            document.ColorSpace = PdfColorSpace.GrayScale;
            page.Graphics.DrawString("Device Gray", font, PdfBrushes.Black, new PointF(x + 160, y));
            g.DrawPie(brush1, new RectangleF(x + 170, y + 20, 30, 30), 0, 45);
        }

        static void DrawCieColorSpaces(PdfDocument document)
        {
            PdfPage page = document.Pages[document.Pages.Count - 1];
            PdfGraphics g = page.Graphics;
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 8f, PdfFontStyle.Bold);

            g.TranslateTransform(20, 70);

            # region CalRGB Color
            document.ColorSpace = PdfColorSpace.RGB;
            g.DrawString("CalRGB Color", font, PdfBrushes.Black, new PointF(10, 20));

            RectangleF rect = new RectangleF(20, 30, 30, 30);

            // Instantiate CalRGB Color Space
            PdfCalRgbColorSpace calRgbCs = new PdfCalRgbColorSpace();
            calRgbCs.Gamma = new double[] { 1.6, 1.1, 2.5 };
            calRgbCs.Matrix = new double[] { 1, 0, 0, 0, 1, 0, 0, 0, 1 };
            calRgbCs.WhitePoint = new double[] { 0.2, 1, 0.8 };
            PdfCalRgbColor red = new PdfCalRgbColor(calRgbCs);
            red.Red = 0;
            red.Green = 1;
            red.Blue = 0;

            PdfBrush brush2 = new PdfSolidBrush(red);
            g.DrawRectangle(brush2, rect);
            # endregion

            # region CalGray Color
            g.DrawString("CalGray Color", font, PdfBrushes.Black, new PointF(90, 20));
            rect = new RectangleF(100, 30, 30, 30);

            PdfGrayColorSpace calGrayCs = new PdfGrayColorSpace();
            calGrayCs.Gamma = 0.7;
            calGrayCs.WhitePoint = new double[] { 0.2, 1, 0.8 };

            PdfGrayColor red1 = new PdfGrayColor(calGrayCs);
            red1.Gray = 0.1;
            brush2 = new PdfSolidBrush(red1);
            g.DrawRectangle(brush2, rect);
            # endregion

            # region Lab Color
            page.Graphics.DrawString("Lab Color", font, PdfBrushes.Black, new PointF(170, 20));

            rect = new RectangleF(180, 30, 30, 30);
            PdfLabColorSpace calGrayCs1 = new PdfLabColorSpace();
            calGrayCs1.Range = new double[] { 0.2, 1, 0.8, 23.5 };
            calGrayCs1.WhitePoint = new double[] { 0.2, 1, 0.8 };

            PdfLabColor red2 = new PdfLabColor(calGrayCs1);
            red2.L = 90;
            red2.A = 0.5;
            red2.B = 20;

            brush2 = new PdfSolidBrush(red2);
            g.DrawRectangle(brush2, rect);
            # endregion

            # region ICC Color
            g.DrawString("ICC Color", font, PdfBrushes.Black, new PointF(10, 100));
            rect = new RectangleF(20, 110, 30, 30);

            PdfCalRgbColorSpace calRgbCs3 = new PdfCalRgbColorSpace();
            calRgbCs3.Gamma = new double[] { 7.6, 5.1, 8.5 };
            calRgbCs3.Matrix = new double[] { 1, 0, 0, 0, 1, 0, 0, 0, 1 };
            calRgbCs3.WhitePoint = new double[] { 0.7, 1, 0.8 };

            // Read the ICC profile.
            FileStream fs = new FileStream(Util.DataDir + "\\RGB_Profile.icc", FileMode.Open, FileAccess.Read);
            byte[] profileData = new byte[fs.Length];
            fs.Read(profileData, 0, profileData.Length);
            fs.Close();

            PdfIccColorSpace iccBasedCs4 = new PdfIccColorSpace();
            iccBasedCs4.ProfileData = profileData;
            iccBasedCs4.AlternateColorSpace = calRgbCs3;
            iccBasedCs4.ColorComponents = 3;
            iccBasedCs4.Range = new double[] { 0.0, 1.0, 0.0, 1.0, 0.0, 1.0 };
            PdfIccColor red4 = new PdfIccColor(iccBasedCs4);
            red4.ColorComponents = new double[] { 1, 0, 1 };
            brush2 = new PdfSolidBrush(red4);

            g.DrawRectangle(brush2, rect);
            # endregion

            # region Separation Color
            g.DrawString("Separation Color", font, PdfBrushes.Black, new PointF(90, 100));
            rect = new RectangleF(100, 110, 30, 30);

            PdfExponentialInterpolationFunction function = new PdfExponentialInterpolationFunction(true);
            float[] numArray = new float[3];
            numArray[0] = 90f;
            numArray[1] = 0.5f;
            numArray[2] = 20f;
            function.C1 = numArray;

            PdfLabColorSpace calLabCs8 = new PdfLabColorSpace();
            calLabCs8.Range = new double[] { 0.2, 1, 0.8, 23.5 };
            calLabCs8.WhitePoint = new double[] { 0.2, 1, 0.8 };

            PdfSeparationColorSpace colorspace8 = new PdfSeparationColorSpace();
            colorspace8.AlternateColorSpaces = calLabCs8;
            colorspace8.TintTransform = function;
            colorspace8.Colorant = "PANTONE Orange 021 C";
            PdfSeparationColor color8 = new PdfSeparationColor(colorspace8);
            color8.Tint = 0.7;

            brush2 = new PdfSolidBrush(color8);
            g.DrawRectangle(brush2, rect);
            # endregion

            # region Indexed Color
            g.DrawString("Indexed Color", font, PdfBrushes.Black, new PointF(170, 100));
            rect = new RectangleF(180, 110, 30, 30);

            PdfIndexedColorSpace colorspace7 = new PdfIndexedColorSpace();
            colorspace7.BaseColorSpace = new PdfDeviceColorSpace(PdfColorSpace.RGB);
            colorspace7.MaxColorIndex = 3;
            colorspace7.IndexedColorTable = new byte[] { 150, 0, 222, 255, 0, 0, 0, 255, 0, 0, 0, 255 };

            PdfIndexedColor color7 = new PdfIndexedColor(colorspace7);
            color7.SelectColorIndex = 3;

            brush2 = new PdfSolidBrush(color7);
            g.DrawRectangle(brush2, rect);
            # endregion
        }

        protected override void RenderPdf(PdfDocument document)
        {
            document.PageSettings = new PdfPageSettings(new SizeF(300, 400));

            DrawBrushes(document);
            DrawGraphicBrushes(document);
            DrawColorSpaces(document);
            DrawCieColorSpaces(document);
        }

        public override string Title
        {
            get { return "Brushes Demo"; }
        }

        public override string Description
        {
            get { return "This example demonstrates how to use brushes."; }
        }
    }
}
