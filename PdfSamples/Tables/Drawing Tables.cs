using System.Drawing;
using ComponentPro.Pdf;
using ComponentPro.Pdf.Graphics;
using ComponentPro.Pdf.Tables;

namespace PdfDemo.Samples.Tables
{
    public partial class Drawing_Tables : ExampleControlBase
    {
        public Drawing_Tables()
        {
            InitializeComponent();
        }

        private static string[,] CreateDataSource(int width, int height)
        {
            string[,] array = new string[height, width];

            for (int i = 0; i < height; i++)
            {
                float value = i;

                for (int j = 0; j < width; j++)
                {
                    float v = value + j * 0.5f;
                    array[i, j] = v.ToString();
                }
            }

            return array;
        }

        protected override void RenderPdf(PdfDocument doc)
        {
            PdfPage page = doc.Pages.Add();

            const int w = 5;
            const int h = 5;
            int y = 10;
            
            string[,] array = CreateDataSource(w, h);

            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);

            #region Gradient Table Sample

            page.Graphics.DrawString("Gradient Table Sample", font, PdfBrushes.Black, new PointF(200, y));

            PointF point2 = page.GetClientSize().ToPointF();
            point2.Y = 0;

            PdfCellStyle altStyle = new PdfCellStyle(font, PdfBrushes.White, PdfPens.Green);
            PdfLinearGradientBrush grBrush = new PdfLinearGradientBrush(PointF.Empty, point2, Color.FromArgb(0x25, 0x53, 0xff), Color.White);
            altStyle.BackgroundBrush = grBrush;

            PdfSimpleTable table = new PdfSimpleTable();
            table.DataSource = array;
            table.Style.AlternateStyle = altStyle;
            table.Style.BorderOverlapStyle = PdfBorderOverlapStyle.Inside;

            table.Style.CellSpacing = 2;
            table.Style.CellPadding = 4;
            table.Style.BorderPen = PdfPens.DarkGray;

            table.Draw(page, new PointF(0, y  + 20));

            #endregion

            y += h * 30;

            #region Merging Cell

            array = CreateDataSource(w, h);

            page.Graphics.DrawString("Merging Cell Sample", font, PdfBrushes.Black, new PointF(200, y));

            table = new PdfSimpleTable();
            table.DataSource = array;
            altStyle = new PdfCellStyle(font, PdfBrushes.White, PdfPens.Black);
            altStyle.BackgroundBrush = PdfBrushes.LightBlue;
            table.Style.AlternateStyle = altStyle;
            table.Style.BorderOverlapStyle = PdfBorderOverlapStyle.Overlap;

            table.Style.CellSpacing = 0;
            table.Style.CellPadding = 3;
            table.Style.BorderPen = PdfPens.Black;

            table.BeforeRowLayout += table_MergeCellStartRowLayout;

            table.Draw(page, new PointF(0, y + 20));

            #endregion

            y += h * 28;

            #region Cell with Image

            array = CreateDataSource(w, h);

            page.Graphics.DrawString("Cell with Image", font, PdfBrushes.Black, new PointF(200, y));

            table = new PdfSimpleTable();
            table.DataSource = array;

            PdfColumnCollection columns = table.Columns;
            foreach (PdfColumn col in columns)
            {
                col.StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            }

            altStyle = new PdfCellStyle(font, PdfBrushes.White, PdfPens.Black);
            altStyle.BackgroundBrush = new PdfSolidBrush(Color.FromArgb(0x31, 0x4e, 0xff));
            table.Style.AlternateStyle = altStyle;
            table.Style.BorderOverlapStyle = PdfBorderOverlapStyle.Overlap;

            table.Style.CellSpacing = 0;
            table.Style.CellPadding = 3;
            table.Style.BorderPen = PdfPens.Black;

            table.AfterCellLayout += table_CellWithImageAfterCellLayout;

            table.Draw(page, new PointF(0, y + 20));

            #endregion
        }

        public override string Title
        {
            get { return "Table Demo"; }
        }

        public override string Description
        {
            get { return "This example demonstrates how to draw tables."; }
        }

        static void table_CellWithImageAfterCellLayout(object sender, AfterCellLayoutEventArgs args)
        {
            PdfGraphics g = args.Graphics;

            if (args.RowIndex == 2 && args.CellIndex == 3)
            {
                g.DrawEllipse(PdfPens.Red, args.Bounds);
            }
            else if (args.RowIndex == 4 && args.CellIndex == 2)
            {
                RectangleF bounds = args.Bounds;
                PointF point1 = bounds.Location;
                PointF point2 = new PointF(bounds.Right, bounds.Bottom);

                g.DrawLine(PdfPens.Black, point1, point2);
            }
        }

        static void table_MergeCellStartRowLayout(object sender, BeforeRowLayoutEventArgs args)
        {
            int rowIndex = args.RowIndex;

            if (rowIndex == 2)
            {
                PdfFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 24, PdfFontStyle.Bold);
                PdfCellStyle cs = new PdfCellStyle(font, PdfBrushes.DarkBlue, PdfPens.Green);

                PointF point1 = PointF.Empty;
                PointF point2 = new PointF(300, 0);

                PdfLinearGradientBrush grBrush =
                    new PdfLinearGradientBrush(point1, point2, Color.DarkGray, Color.WhiteSmoke);

                grBrush.Extend = PdfExtend.Both;

                cs.BackgroundBrush = grBrush;

                args.CellStyle = cs;

                PdfSimpleTable table = (PdfSimpleTable)sender;
                int count = table.Columns.Count;

                int[] spanMap = new int[count];

                // Set just spanned cells. Other values are not important
                // except negatives that are not allowed.
                spanMap[0] = 2;
                spanMap[2] = 3;

                args.ColumnSpanMap = spanMap;

                //Sets row height.
                args.MinimalHeight = 30f;
            }
        }
    }
}
