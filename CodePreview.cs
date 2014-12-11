using System;
using System.Windows.Forms;
using System.IO;

using Manoli.Utils.CSharpFormat;

namespace PdfDemo
{
    public partial class CodePreview : Form
    {
        readonly bool _cs;
        readonly string _fileName;

        public CodePreview()
        {
            InitializeComponent();
        }

        public CodePreview(string fileName, bool cs)
        {
            InitializeComponent();

            this.Text = Path.GetFileName(fileName) + " - Code Preview";
            _cs = cs;
            _fileName = fileName;

            code.Url = new Uri(AppDomain.CurrentDomain.BaseDirectory + "EmptyCode.template");
            code.DocumentCompleted += code_DocumentCompleted;
        }

        void code_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            CodeFormat formatter;

            if (_cs)
                formatter = new CSharpFormat();
            else
                formatter = new VisualBasicFormat();

            StreamReader sw = new StreamReader(_fileName);
            string formattedCode = formatter.FormatCode(sw.BaseStream);
            sw.Close();

            code.Document.Body.InnerHtml = formattedCode;
        }
    }
}