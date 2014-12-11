using System;
using System.Drawing;
using System.Windows.Forms;

using ComponentPro.Pdf;
using ComponentPro.Pdf.Graphics;


namespace PdfDemo.Samples.Modifying_Document
{
    public partial class Stamp_and_Watermark : ExampleControlBase
    {
        public Stamp_and_Watermark()
        {
            InitializeComponent();
            txtUrl.Text = Util.DataDir + "\\Template1.pdf";            
        }

        public override bool Create()
        {
            using (PdfImportedDocument lDoc = new PdfImportedDocument(txtUrl.Text))
            {
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 36f);

                foreach (PdfPageBase lPage in lDoc.Pages)
                {
                    PdfGraphics g = lPage.Graphics;
                    PdfGraphicsState state = g.Save();
                    g.SetTransparency(0.25f);
                    g.RotateTransform(-40);
                    g.DrawString(txtStamp.Text, font, PdfPens.Red, PdfBrushes.Red, new PointF(-150, 450));

                    if (txtWatermark.Text.Length > 0)
                    {
                        PdfImage image = new PdfBitmap(txtWatermark.Text);
                        g.Restore(state);
                        g.SetTransparency(0.25f);
                        g.DrawImage(image, 0, 0, lPage.Graphics.ClientSize.Width, lPage.Graphics.ClientSize.Height);
                    }
                }

                lDoc.Save(OutputFile);
            }

            return true;
        }

        private void btnWatermarkBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "GIF file (*.gif)|*.gif|JPEG file (*.jpg)|*.jpg|PNG file (*.png)|*.png|All files (*.*)|*.*";
            file.FileName = txtWatermark.Text;
            if (file.ShowDialog() == DialogResult.OK)
                txtWatermark.Text = file.FileName;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "PDF Documents (*.pdf)|*.PDF";
            file.FileName = txtUrl.Text;
            if (file.ShowDialog() == DialogResult.OK)
                txtUrl.Text = file.FileName;
        }

        public override string Title
        {
            get { return "Stamp & Watermark Demo"; }
        }

        public override string Description
        {
            get { return "This example demonstrates how to draw stamp and watermark"; }
        }
    }
}
