using System.IO;
using ComponentPro.Pdf;
using ComponentPro.Pdf.Forms;

namespace PdfDemo.Samples.Modifying_Document
{
    public partial class Fill_Form : ExampleControlBase
    {
        public Fill_Form()
        {
            InitializeComponent();
        }

        public override bool Create()
        {
            //Load the template document
            using (PdfImportedDocument doc = new PdfImportedDocument(Util.DataDir + "\\PDFForm.pdf"))
            {
                PdfImportedForm form = doc.Form;

                // fill the fields from the first page
                ((PdfImportedTextBoxField)form.Fields["f1-1"]).Text = "1";
                ((PdfImportedTextBoxField)form.Fields["f1-2"]).Text = "1";
                ((PdfImportedTextBoxField)form.Fields["f1-3"]).Text = "1";
                ((PdfImportedTextBoxField)form.Fields["f1-4"]).Text = "3";
                ((PdfImportedTextBoxField)form.Fields["f1-5"]).Text = "1";
                ((PdfImportedTextBoxField)form.Fields["f1-6"]).Text = "1";
                ((PdfImportedTextBoxField)form.Fields["f1-7"]).Text = "22";
                ((PdfImportedTextBoxField)form.Fields["f1-8"]).Text = "30";
                ((PdfImportedTextBoxField)form.Fields["f1-9"]).Text = "John";
                ((PdfImportedTextBoxField)form.Fields["f1-10"]).Text = "Doe";
                ((PdfImportedTextBoxField)form.Fields["f1-11"]).Text = "1 Microsoft Way";
                ((PdfImportedTextBoxField)form.Fields["f1-12"]).Text = "Redmond, WA";
                ((PdfImportedTextBoxField)form.Fields["f1-13"]).Text = "332";
                ((PdfImportedTextBoxField)form.Fields["f1-14"]).Text = "43";
                ((PdfImportedTextBoxField)form.Fields["f1-15"]).Text = "4556";
                ((PdfImportedTextBoxField)form.Fields["f1-16"]).Text = "3";
                ((PdfImportedTextBoxField)form.Fields["f1-17"]).Text = "2000";
                ((PdfImportedTextBoxField)form.Fields["f1-18"]).Text = "Exempt";
                ((PdfImportedTextBoxField)form.Fields["f1-19"]).Text = "Microsoft";
                ((PdfImportedTextBoxField)form.Fields["f1-20"]).Text = "200";
                ((PdfImportedTextBoxField)form.Fields["f1-21"]).Text = "22";
                ((PdfImportedTextBoxField)form.Fields["f1-22"]).Text = "56654";
                ((PdfImportedCheckBoxField)form.Fields["c1-1[0]"]).Items[0].Checked = true;
                ((PdfImportedCheckBoxField)form.Fields["c1-1[1]"]).Items[0].Checked = true;

                // fill the fields from the second page
                ((PdfImportedTextBoxField)form.Fields["f2-1"]).Text = "3200";
                ((PdfImportedTextBoxField)form.Fields["f2-2"]).Text = "4850";
                ((PdfImportedTextBoxField)form.Fields["f2-3"]).Text = "0";
                ((PdfImportedTextBoxField)form.Fields["f2-4"]).Text = "500";
                ((PdfImportedTextBoxField)form.Fields["f2-5"]).Text = "500";
                ((PdfImportedTextBoxField)form.Fields["f2-6"]).Text = "800";
                ((PdfImportedTextBoxField)form.Fields["f2-7"]).Text = "0";
                ((PdfImportedTextBoxField)form.Fields["f2-8"]).Text = "0";
                ((PdfImportedTextBoxField)form.Fields["f2-9"]).Text = "3";
                ((PdfImportedTextBoxField)form.Fields["f2-10"]).Text = "3";
                ((PdfImportedTextBoxField)form.Fields["f2-11"]).Text = "3";
                ((PdfImportedTextBoxField)form.Fields["f2-12"]).Text = "2";
                ((PdfImportedTextBoxField)form.Fields["f2-13"]).Text = "3";
                ((PdfImportedTextBoxField)form.Fields["f2-14"]).Text = "3";
                ((PdfImportedTextBoxField)form.Fields["f2-15"]).Text = "2";
                ((PdfImportedTextBoxField)form.Fields["f2-16"]).Text = "1";
                ((PdfImportedTextBoxField)form.Fields["f2-17"]).Text = "200";
                ((PdfImportedTextBoxField)form.Fields["f2-18"]).Text = "600";
                ((PdfImportedTextBoxField)form.Fields["f2-19"]).Text = "250";

                if (!Directory.Exists(Util.OutputDir))
                    Directory.CreateDirectory(Util.OutputDir);

                // Save the document to a file.
                doc.Save(OutputFile);
            }

            return true;
        }

        public override string GenerateButtonText
        {
            get
            {
                return "&Fill";
            }
        }

        public override string Title
        {
            get { return "Form Filling Demo"; }
        }

        public override string Description
        {
            get { return "This example demonstrates how to fill data to fields of a PDF document."; }
        }
    }
}
