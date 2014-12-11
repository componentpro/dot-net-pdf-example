using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ComponentPro.Pdf;
using ComponentPro.Pdf.Graphics;
using System.IO;

namespace PdfDemo.Samples.Converters
{
    public partial class RTF_to_PDF : ExampleControlBase
    {
        public RTF_to_PDF()
        {
            InitializeComponent();

            inputBox.Text = Util.DataDir + "\\EULA.rtf";
        }

        public override bool Create()
        {
            if (inputBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please select a RTF file to convert", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //Create a new PDF document.
            PdfDocument doc = new PdfDocument();

            //Add a page
            PdfPage page = doc.Pages.Add();
            SizeF bounds = page.GetClientSize();

            //Read the RTF document
            StreamReader reader = new StreamReader(inputBox.Text, Encoding.ASCII);
            string text = reader.ReadToEnd();
            reader.Close();

            if (rbtMeta.Checked)
            {
                //Convert it as metafile.
                PdfMetafile metafile = (PdfMetafile)PdfImage.FromRtf(text, bounds.Width, PdfImageType.Metafile);
                PdfMetafileLayoutSettings format = new PdfMetafileLayoutSettings();

                //Allow the text to flow multiple pages without any breaks.
                format.SplitTextLines = true;

                //Draw the image.
                metafile.Draw(page, 0, 0, format);
            }
            else
            {
                //Convert it as Bitmap image.
                PdfImage bitmap = PdfImage.FromRtf(text, bounds.Width, PdfImageType.Bitmap);
                PdfLayoutSettings format = new PdfLayoutSettings();
                format.Break = PdfLayoutBreakType.FitPage;
                format.Layout = PdfLayoutType.Paginate;
                bitmap.Draw(page, 0, 0, format);
            }

            //Save the document.
            doc.Save(OutputFile);

            return true;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new System.Windows.Forms.OpenFileDialog();

            openFile.Filter = "RTF files *.rtf|*.rtf|All files *.*|*.*";
            openFile.Title = "Select a file";
            openFile.FileName = inputBox.Text;
            if (openFile.ShowDialog() != DialogResult.OK)
                return;

            inputBox.Text = openFile.FileName;
        }

        public override string GenerateButtonText
        {
            get
            {
                return "Convert";
            }
        }

        public override string Title
        {
            get { return "RTF to PDF Demo"; }
        }

        public override string Description
        {
            get { return "This example demonstrates how to convert a RTF file to a PDF file."; }
        }
    }
}
