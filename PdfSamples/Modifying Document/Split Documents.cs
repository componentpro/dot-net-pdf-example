using System;
using System.Windows.Forms;
using ComponentPro.Pdf;


namespace PdfDemo.Samples.Modifying_Document
{
    public partial class Split_Documents : ExampleControlBase
    {
        public Split_Documents()
        {
            InitializeComponent();
            txtSplitDoc.Text = Util.DataDir + "\\Images.pdf";
        }

        public override bool Create()
        {
            // To load a existing document which has to be split
            using (PdfImportedDocument ldoc = new PdfImportedDocument(txtSplitDoc.Text))
            {
                //Create two pdf documents
                PdfDocument doc1 = new PdfDocument();
                PdfDocument doc2 = new PdfDocument();

                //Split the source document into two based on the split-at page value.
                int splitAtPage = (int)nudSplitPage.Value;
                for (int i = 0; i < splitAtPage; i++)
                    doc1.ImportPage(ldoc, i);

                for (int j = splitAtPage; j < ldoc.Pages.Count; j++)
                    doc2.ImportPage(ldoc, j);

                string doc1FileName = Util.OutputDir + "\\Doc1.pdf";
                string doc2FileName = Util.OutputDir + "\\Doc2.pdf";

                OutputFiles = new string[] { doc1FileName, doc2FileName };

                //Save pdf document1
                doc1.Save(doc1FileName);

                //Save pdf document2
                doc2.Save(doc2FileName);

                doc1.Close();

                doc2.Close();
            }

            return true;
        }

        private void btnBrowse1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "PDF Documents (*.pdf)|*.PDF";
            file.FileName = txtSplitDoc.Text;
            if (file.ShowDialog() == DialogResult.OK)
                txtSplitDoc.Text = file.FileName;
        }

        public override string GenerateButtonText
        {
            get
            {
                return "&Split";
            }
        }

        public override string Title
        {
            get { return "PDF Split Demo"; }
        }

        public override string Description
        {
            get { return "This example demonstrates how to split a PDF document."; }
        }

        public override string ViewMessage
        {
            get
            {
                return "PDF file is splitted successfully. Do you want to open the splitted PDF documents?";
            }
        }
    }
}
