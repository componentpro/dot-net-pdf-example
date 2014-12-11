using System;
using System.Windows.Forms;
using ComponentPro.Pdf;

namespace PdfDemo.Samples.Modifying_Document
{
    public partial class Merge_Documents : ExampleControlBase
    {
        public Merge_Documents()
        {
            InitializeComponent();
            txtDoc1.Text = Util.DataDir + "\\Template1.pdf";
            txtDoc2.Text = Util.DataDir + "\\Template2.pdf";
        }

        public override bool Create()
        {
            string[] paths = { txtDoc1.Text, txtDoc2.Text };

            PdfDocument doc = PdfDocument.Merge(paths);

            //Save the document
            doc.Save(OutputFile);

            doc.Close();

            return true;
        }

        private void btnBrowse1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "PDF Documents (*.pdf)|*.PDF";
            file.FileName = txtDoc1.Text;
            if (file.ShowDialog() == DialogResult.OK)
                txtDoc1.Text = file.FileName;
        }

        private void btnBrowse2_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "PDF Documents (*.pdf)|*.PDF";
            file.FileName = txtDoc2.Text;
            if (file.ShowDialog() == DialogResult.OK)
                txtDoc2.Text = file.FileName;
        }

        public override string GenerateButtonText
        {
            get
            {
                return "&Merge";
            }
        }

        public override string Title
        {
            get { return "PDF Merge Demo"; }
        }

        public override string Description
        {
            get { return "This example demonstrates how to merge two PDF documents."; }
        }

        public override string ViewMessage
        {
            get
            {
                return "PDF file is merged successfully. Do you want to open the document?";
            }
        }
    }
}
