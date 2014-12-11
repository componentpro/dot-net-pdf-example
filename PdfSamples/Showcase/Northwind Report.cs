using System;
using System.Drawing;
using System.Data;
using System.Data.SqlServerCe;

using ComponentPro.Pdf;
using ComponentPro.Pdf.Graphics;
using ComponentPro.Pdf.Tables;

namespace PdfDemo.Samples.Showcase
{
    public partial class Northwind_Report : ExampleControlBase
    {
        public Northwind_Report()
        {
            InitializeComponent();
        }

        private const string DbCommand = "SELECT CustomerID,CompanyName,ContactName,Address,City,PostalCode,Country FROM Customers";
        
        protected override void RenderPdf(ComponentPro.Pdf.PdfDocument doc)
        {
            //Set font
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 8);

            //Create Pdf ben for drawing broder
            PdfPen borderPen = new PdfPen(PdfBrushes.DarkBlue);
            borderPen.Width = 0;

            //Create brush
            PdfColor color = new PdfColor(250, 250, 250);
            PdfSolidBrush brush = new PdfSolidBrush(color);

            //Create cell styles
            PdfCellStyle altStyle = new PdfCellStyle();
            altStyle.Font = font;
            altStyle.BackgroundBrush = brush;
            altStyle.BorderPen = borderPen;

            PdfCellStyle defStyle = new PdfCellStyle();
            defStyle.Font = font;
            defStyle.BackgroundBrush = PdfBrushes.White;
            defStyle.BorderPen = borderPen;

            PdfCellStyle headerStyle = new PdfCellStyle(font, PdfBrushes.White, PdfPens.DarkBlue);
            brush = new PdfSolidBrush(System.Drawing.Color.FromArgb(33, 67, 126));
            headerStyle.BackgroundBrush = brush;

            //Create DataTable for source
            PdfPage page = doc.Pages.Add();

            //Adding Header
            AddHeader(doc, "Customers");

            //Use DataTable as source
            PdfSimpleTable table = new PdfSimpleTable();

            //Create dataset with the "Customers" table from Norwind database
            DataSet dataSet = GetNorthwindDataSet();

            //Create datatable
            DataTable dataTable = dataSet.Tables[0];

            //Set Data source
            table.DataSource = dataTable;

            //Set table alternate row style
            table.Style.AlternateStyle = altStyle;

            //Set default style
            table.Style.DefaultStyle = defStyle;

            //Set header row style         
            table.Style.HeaderStyle = headerStyle;

            //Show the header row
            table.Style.ShowHeader = true;

            //Repeate header in all the pages
            table.Style.RepeatHeader = true;

            //Set header data from column caption
            table.Style.HeaderSource = PdfHeaderSource.ColumnCaptions;

            table.Style.BorderPen = borderPen;
            table.Style.CellPadding = 2;
            table.Columns[1].Width = 12;
            table.Columns[3].Width = 20;
            table.Style.HeaderStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            table.Style.DefaultStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);

            //Set layout properties
            PdfLayoutSettings format = new PdfLayoutSettings();
            format.Break = PdfLayoutBreakType.FitElement;
            format.Layout = PdfLayoutType.Paginate;

            //Draw table
            table.Draw(page, new PointF(0, 10), format);
        }

        private static DataSet GetNorthwindDataSet()
        {
            DataSet dataSet = new DataSet();
            SqlCeConnection conn = null;

            try
            {
                AppDomain.CurrentDomain.SetData("SQLServerCompactEditionUnderWebHosting", true);
                string connectionstring = Util.DataDir + "\\NorthwindIO.sdf";
                string sqlMobileConnString1 = @"Data Source = " + connectionstring;
                conn = new SqlCeConnection(sqlMobileConnString1);
                conn.Open();
                SqlCeDataAdapter adapter = new SqlCeDataAdapter(DbCommand, conn);
                adapter.Fill(dataSet);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return dataSet;
        }

        private static void AddHeader(PdfDocument doc, string title)
        {
            RectangleF rect = new RectangleF(0, 0, doc.Pages[0].GetClientSize().Width, 54);
            PdfPageTemplateElement header = new PdfPageTemplateElement(rect);
            PdfSolidBrush brush = new PdfSolidBrush(Color.DarkBlue);

            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 16, PdfFontStyle.Bold);
            PdfStringFormat format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Center;
            format.LineAlignment = PdfVerticalAlignment.Middle;
            header.Graphics.DrawString(title, font, brush, new RectangleF(0, 0, header.Width, header.Height), format);

            doc.Template.Top = header;
        }

        public override string Title
        {
            get { return "Northwind Report Demo"; }
        }

        public override string Description
        {
            get { return "This example demonstrates how to generate a report from a database."; }
        }
    }
}
