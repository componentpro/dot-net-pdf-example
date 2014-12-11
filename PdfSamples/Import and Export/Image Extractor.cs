using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Imaging;
using ComponentPro.Pdf;

namespace PdfDemo.Samples.Import_and_Export
{
    public partial class Image_Extractor : ExampleControlBase
    {
        public Image_Extractor()
        {
            InitializeComponent();

            txtUrl.Text = Util.DataDir + "\\Images.pdf";
        }

        public override bool Create()
        {
            if (txtUrl.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please specify a PDF document.");
                return false;
            }

            OutputFile = Util.OutputDir + "\\Extracted Images";
            if (!Directory.Exists(OutputFile))
                Directory.CreateDirectory(OutputFile);

 	        // Load an existing PDF
            using (PdfImportedDocument ldoc = new PdfImportedDocument(txtUrl.Text))
            {
                // Loading Page collections
                PdfImportedPageCollection loadedPages = ldoc.Pages;

                bool found = false;

                // Extract Image from PDF document pages
                foreach (PdfImportedPage lpage in loadedPages)
                {
                    Image[] img = lpage.ExtractImages();
                    if (img != null && img.Length > 0)
                    {
                        found = true;
                        foreach (Image img1 in img)
                        {
                            img1.Save(OutputFile + "\\Image" + Guid.NewGuid().ToString() + ".png", ImageFormat.Png);
                        }
                    }
                }

                if (!found)
                    MessageBox.Show("No images found");

                return found;
            }
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
            get { return "Image files are extracted successfully. Do you want to browse the folder containing those images?"; }
        }

        public override string Title
        {
            get { return "Image Extractor Demo"; }
        }

        public override string Description
        {
            get { return "This example demonstrates how to extract images from a PDF document."; }
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
