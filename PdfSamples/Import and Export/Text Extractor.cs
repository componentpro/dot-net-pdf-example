using System;
using System.Text;
using System.Windows.Forms;
using ComponentPro.Pdf;

namespace PdfDemo.Samples.Import_and_Export
{
    public partial class Text_Extractor : ExampleControlBase
    {
        public Text_Extractor()
        {
            InitializeComponent();

            txtUrl.Text = Util.DataDir + "\\PDFForm.pdf";
        }

        public override bool Create()
        {
            if (txtUrl.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please specify a PDF document.");
                return false;
            }

 	        // Load an existing PDF
            using (PdfImportedDocument ldoc = new PdfImportedDocument(txtUrl.Text))
            {
                // Loading Page collections
                PdfImportedPageCollection loadedPages = ldoc.Pages;

                string s = "";

                // Extract text from PDF document pages
                foreach (PdfImportedPage lpage in loadedPages)
                {
                    s += lpage.ExtractText();
                }

                //Convert the string to byte array
                byte[] b = (new UnicodeEncoding()).GetBytes(s);

                OutputFile = Util.OutputDir + "\\sample.txt";

                // Writing the byte array to text file
                System.IO.FileStream fStream = System.IO.File.Create(OutputFile);
                fStream.Write(b, 0, b.Length);
                fStream.Close();
            }
            
            return true;
        }

        public override string GenerateButtonText
        {
            get
            {
                return "&Extract";
            }
        }

        public override string ViewMessage
        {
            get { return "Text file is generated successfully. Do you want to open the document?"; }
        }

        public override string Title
        {
            get { return "Text Extractor Demo"; }
        }

        public override string Description
        {
            get { return "This example demonstrates how to extract texts from a PDF document."; }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            dlgOpen.FileName = txtUrl.Text;
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                // Assigns the url of the file to the text box
                txtUrl.Text = dlgOpen.FileName;
            }
        }
    }
}
