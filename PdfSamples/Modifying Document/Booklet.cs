using System;
using System.Drawing;
using System.Windows.Forms;
using ComponentPro.Pdf;


namespace PdfDemo.Samples.Modifying_Document
{
    public partial class Booklet : ExampleControlBase
    {
        public Booklet()
        {
            InitializeComponent();
            txtUrl.Text = Util.DataDir + "\\PDFForm.pdf";
        }

        public override bool Create()
        {
            //Load a PDF document
            using (PdfImportedDocument ldoc = new PdfImportedDocument(txtUrl.Text))
            {
                //Create booklet with two sides               
                PdfDocument doc = PdfBookletUtil.CreateBooklet(ldoc, new SizeF(float.Parse(txtWidth.Text), float.Parse(txtHeight.Text)), chkTwoSide.Checked);

                //Save the document
                doc.Save(OutputFile);
            }

            return true;
        }

        public override string GenerateButtonText
        {
            get
            {
                return "&Create";
            }
        }

        public override string Title
        {
            get { return "Booklet Demo"; }
        }

        public override string Description
        {
            get { return "This example demonstrates how to create booklet."; }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFile;
            openFile = new System.Windows.Forms.OpenFileDialog();

            openFile.Filter = "PDF files *.pdf|*.pdf|All files *.*|*.*";
            openFile.Title = "Select a file";
            openFile.FileName = txtUrl.Text;
            if (openFile.ShowDialog() != DialogResult.OK)
                return;

            txtUrl.Text = openFile.FileName;
        }
    }
}
