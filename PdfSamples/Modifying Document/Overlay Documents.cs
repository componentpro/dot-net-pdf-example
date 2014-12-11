using System;
using System.Drawing;
using System.Windows.Forms;
using ComponentPro.Pdf;

using ComponentPro.Pdf.Graphics;

namespace PdfDemo.Samples.Modifying_Document
{
    public partial class Overlay_Documents : ExampleControlBase
    {
        public Overlay_Documents()
        {
            InitializeComponent();

            txtDoc1.Text = Util.DataDir + "\\Template1.pdf";
            txtDoc2.Text = Util.DataDir + "\\Template2.pdf";
        }

        protected override void RenderPdf(PdfDocument doc)
        {
            PdfImportedDocument ldDoc1 = new PdfImportedDocument(txtDoc1.Text);
            PdfImportedDocument ldDoc2 = new PdfImportedDocument(txtDoc2.Text);

            for (int i = 0, count = ldDoc2.Pages.Count; i < count; ++i)
            {
                PdfPage page = doc.Pages.Add();
                PdfGraphics g = page.Graphics;

                PdfPageBase lpage = ldDoc2.Pages[i];
                PdfTemplate template = lpage.CreateTemplate();

                g.DrawPdfTemplate(template, PointF.Empty, page.GetClientSize());

                lpage = ldDoc1.Pages[0];
                template = lpage.CreateTemplate();

                g.DrawPdfTemplate(template, PointF.Empty, page.GetClientSize());
            }
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

        public override string Title
        {
            get { return "Overlay Demo"; }
        }

        public override string Description
        {
            get { return "This example demonstrates how to draw PDF templates."; }
        }
    }
}
