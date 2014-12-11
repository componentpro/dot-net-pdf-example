using System;
using System.Drawing;
using System.Data;
using ComponentPro.Pdf;
using ComponentPro.Pdf.Graphics;
using ComponentPro.Pdf.Tables;
using System.Data.SqlServerCe;

namespace PdfDemo.Samples.Showcase
{
    public partial class Invoice : ExampleControlBase
    {
        string y, shipName, address, shipCity, shipCountry, shippedDate;
        Double x, total, ftotal, freight;
        int k;
        private string DEF_DB_COMMAND2 = "select OrderID from SyncOrders Order By OrderID";
        
        public Invoice()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //Create dataset with the "Customers" table from Norwind database
            DataSet dataSet = GetNorthwindDataSet(DEF_DB_COMMAND2);

            //Create datatable
            DataTable dt = dataSet.Tables[0];

            //db = new SampleDatabases(SampleDatabases.Connections.NorthwindIO, "select OrderID from SyncOrders Order By OrderID");
            //DataTable dt = db.DataTable;

            // Add Customer ID to the list box.
            foreach (DataRow row in dt.Rows)
                lstCustomerId.Items.Add(row["OrderID"]);
            lstCustomerId.SelectedIndex = 0;
        }

        protected override void RenderPdf(PdfDocument doc)
        {
            total = 0;
            ftotal = 0;
            k = 0;

            doc.PageSettings.Margins.All = 5;

            int id = (int)lstCustomerId.SelectedItem;

            //Add a page
            PdfPage page = doc.Pages.Add();
            PdfGraphics g = page.Graphics;
            PointF location = new PointF(0f, 0f);
            RectangleF rect = new RectangleF(0, 0, page.Graphics.ClientSize.Width, 100);

            //Draw gradient rectangle at the the top and bottom of the page
            PdfLinearGradientBrush lgBrush = new PdfLinearGradientBrush(new PointF(page.Graphics.ClientSize.Width, 0), new PointF(page.Graphics.ClientSize.Width, 100), Color.FromArgb(218, 229, 245), Color.White);
            PdfBrush brush = new PdfSolidBrush(Color.Black);

            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 25);
            g.DrawRectangle(lgBrush, rect);

            lgBrush = new PdfLinearGradientBrush(new PointF(0, page.Graphics.ClientSize.Height), new PointF(0, page.Graphics.ClientSize.Height - 120), Color.FromArgb(218, 229, 245), Color.White);
            rect = new RectangleF(0, page.Graphics.ClientSize.Height - 120, page.Graphics.ClientSize.Width, 120);
            g.DrawRectangle(lgBrush, rect);

            //Add image
            PdfImage image = new PdfBitmap(Util.DataDir + "\\logo.gif");
            g.DrawImage(image, new PointF(10, 20), new SizeF(252f, 30f));

            g.DrawString("INVOICE", font, brush, 425, 20);

            //Get the product table details
            DataTable shipTable = GetShipDetails(id);

            Font f = new Font("Trebuchet MS", 10);
            font = new PdfTrueTypeFont(f);

            //Get the product table details
            GetProductTable(id);

            //Display the "bill to" and "ship to" address
            g.DrawString("Invoice ID:   " + id.ToString(), font, brush, new PointF(325, 116));
            g.DrawString("Shipped Date: " + shippedDate, font, brush, new PointF(325, 130));

            g.DrawString("Northwind Traders\n67,rue des Cinquante Otages,\nElgin,\nUnites States.", font, brush, new RectangleF(10, 116, 200, 200));
            float xpos = 10, ypos = 200;
            f = new Font("Trebuchet MS", 12, FontStyle.Bold);
            font = new PdfTrueTypeFont(f);
            g.DrawString("Bill to:", font, brush, new PointF(xpos, ypos));
            xpos = xpos + 73;
            f = new Font("Trebuchet MS", 10, FontStyle.Regular);
            font = new PdfTrueTypeFont(f);
            g.DrawString(shipName, font, brush, new PointF(xpos, ypos));
            ypos = ypos + 10;
            g.DrawString(address, font, brush, new PointF(xpos, ypos));
            ypos = ypos + 10;
            g.DrawString(shipCity, font, brush, new PointF(xpos, ypos));
            ypos = ypos + 10;
            g.DrawString(shipCountry, font, brush, new PointF(xpos, ypos));
            xpos = 325; ypos = 200;
            f = new Font("Trebuchet MS", 12, FontStyle.Bold);
            font = new PdfTrueTypeFont(f);
            g.DrawString("Ship to:", font, brush, new PointF(xpos, ypos));
            xpos = xpos + 75;
            f = new Font("Trebuchet MS", 10, FontStyle.Regular);
            font = new PdfTrueTypeFont(f);
            g.DrawString(shipName, font, brush, new PointF(xpos, ypos));
            ypos = ypos + 10;
            g.DrawString(address, font, brush, new PointF(xpos, ypos));
            ypos = ypos + 10;
            g.DrawString(shipCity, font, brush, new PointF(xpos, ypos));
            ypos = ypos + 10;
            g.DrawString(shipCountry, font, brush, new PointF(xpos, ypos));

            xpos = 07;

            //Create table and format it. 
            PdfSimpleTable table = new PdfSimpleTable();
            table.DataSource = GetTestOrder(id);

            PdfPen borderPen = new PdfPen(Color.FromArgb(192, 201, 219));
            borderPen.Width = 1.0f;

            PdfCellStyle defStyle = new PdfCellStyle();
            defStyle.Font = font;
            defStyle.BorderPen = borderPen;
            table.Style.DefaultStyle = defStyle;

            f = new Font("Trebuchet MS", 10, FontStyle.Bold);
            PdfFont headerFont = new PdfTrueTypeFont(f);

            PdfCellStyle headerStyle = new PdfCellStyle();
            headerStyle.Font = headerFont;

            PdfStringFormat format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Center;
            headerStyle.StringFormat = format;

            PdfBrush headerBrush = new PdfSolidBrush(Color.FromArgb(218, 229, 245));
            headerStyle.BackgroundBrush = headerBrush;
            headerStyle.BorderPen = borderPen;

            table.Style.HeaderStyle = headerStyle;
            table.Style.HeaderSource = PdfHeaderSource.ColumnCaptions;
            table.Style.ShowHeader = true;
            table.Style.CellPadding = 6f;
            table.Style.BorderPen = borderPen;
            table.Style.BorderOverlapStyle = PdfBorderOverlapStyle.Overlap;
            PdfSimpleTableLayoutResult result = table.Draw(page, 0, ypos + 65, 565);

            table.DataSource = GetProductDetails(id);
            f = new Font("Trebuchet MS", 10, FontStyle.Regular);
            font = new PdfTrueTypeFont(f);
            table.Style.DefaultStyle.Font = font;

            result = table.Draw(result.Page, 0, result.Bounds.Bottom + 30, 565);

            //Create DataTable for source
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID1");
            dataTable.Columns.Add("ID2");

            object[] values = new object[] {
				"SUBTOTAL","$"+ String.Format("{0:#.00}", total)};
            dataTable.Rows.Add(values);

            values = new object[] {
				"FREIGHT","$"+ String.Format("{0:#.00}",shipTable.Rows[0]["Freight"])};
            dataTable.Rows.Add(values);

            ftotal = total + Convert.ToDouble(shipTable.Rows[0]["Freight"]);
            values = new object[] {
				"TOTAL", "$"+ String.Format("{0:#.00}", ftotal) };
            dataTable.Rows.Add(values);

            table.DataSource = dataTable;
            table.Style.ShowHeader = false;
            table.Style.BorderOverlapStyle = PdfBorderOverlapStyle.Overlap;

            result = table.Draw(result.Page, 339, result.Bounds.Bottom, 226);

            g.DrawString("THANK YOU FOR THE BUSINESS", font, brush, 240, 760);
        }

        private void GetProductTable(int id)
        {
            DEF_DB_COMMAND2 = "Select ShipName,ShipAddress,Freight,ShippedDate,ShipCity,ShipCountry from Orders where OrderID=" + id;

            //Create dataset with the "Customers" table from Norwind database
            DataSet dataSet = GetNorthwindDataSet(DEF_DB_COMMAND2);

            //Create datatable
            DataTable dataTable = dataSet.Tables[0];

            DataRow dr;
            int rows = dataTable.Rows.Count;
            for (int i = 0; i < rows; i++)
            {
                dr = dataTable.Rows[i];
                shipName = dr["ShipName"].ToString();
                freight = System.Convert.ToDouble(dr["Freight"].ToString());
                address = dr["ShipAddress"].ToString();
                shippedDate = dr["ShippedDate"].ToString();
                shipCity = dr["ShipCity"].ToString();
                shipCountry = dr["ShipCountry"].ToString();
            }
        }

        //Main table
        private DataSet GetTestOrder(int id)
        {

            DEF_DB_COMMAND2 = "Select ShipName,ShipAddress,Freight,ShippedDate,ShipCity,ShipCountry from Orders where OrderID=" + id;

            //Create dataset with the "Customers" table from Norwind database
            DataSet dataSet = GetNorthwindDataSet(DEF_DB_COMMAND2);

            return dataSet;
        }

        //Sub table
        private DataTable GetProductDetails(int id)
        {
            DEF_DB_COMMAND2 = "select ProductID,Quantity,UnitPrice,Discount from SyncOrderDetails where OrderID=" + id;

            //Create dataset with the "Customers" table from Norwind database
            DataSet dataSet = GetNorthwindDataSet(DEF_DB_COMMAND2);

            //Create datatable
            DataTable prodDT = dataSet.Tables[0];

            //Add new column
            prodDT.Columns.Add(new DataColumn("Price", typeof(String)));

            DEF_DB_COMMAND2 = "select Quantity,UnitPrice from SyncOrderDetails where OrderID=" + id;

            //Create dataset with the "Customers" table from Norwind database
            DataSet dataSet1 = GetNorthwindDataSet(DEF_DB_COMMAND2);

            //Create datatable
            DataTable dt = dataSet1.Tables[0];

            DataRow dr;
            int rows = dt.Rows.Count;
            for (int i = 0; i < rows; i++)
            {
                dr = dt.Rows[i];
                x = System.Convert.ToDouble(dr["Quantity"].ToString()) * System.Convert.ToDouble(dr["UnitPrice"].ToString());
                dr = prodDT.Rows[k];
                y = "$" + x.ToString();
                dr["Price"] = y.ToString();
                k++;

                total = total + x;
            }
            return prodDT;
        }

        private DataTable GetShipDetails(int TestOrderId)
        {
            DEF_DB_COMMAND2 = String.Format("SELECT ShipName,ShipAddress,Freight,ShipCity,ShipCountry,ShippedDate from Orders where OrderID={0}", TestOrderId);

            //Create dataset with the "Customers" table from Norwind database
            DataSet dataSet = GetNorthwindDataSet(DEF_DB_COMMAND2);

            //Create datatable
            DataTable dt = dataSet.Tables[0];

            return dt;
        }

        private DataSet GetNorthwindDataSet(string selectCommand)
        {
            DataSet dataSet = new DataSet();
            SqlCeConnection conn = null;
            try
            {
                AppDomain.CurrentDomain.SetData("SQLServerCompactEditionUnderWebHosting", true);
                string connectionstring = Util.DataDir + "\\NorthwindIO.sdf";
                string SqlMobileConnString1 = @"Data Source = " + connectionstring;
                conn = new SqlCeConnection(SqlMobileConnString1);
                conn.Open();
                SqlCeDataAdapter adapter = new SqlCeDataAdapter(DEF_DB_COMMAND2, conn);
                adapter.Fill(dataSet);
            }
            finally
            {
                conn.Close();
            }

            return dataSet;

        }

        public override string Title
        {
            get { return "Invoice Demo"; }
        }

        public override string Description
        {
            get { return "This example demonstrates how to generate an invoice from a database."; }
        }
    }
}
