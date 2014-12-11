using System;
using System.IO;
using System.Windows.Forms;
using ComponentPro.Pdf;

namespace PdfDemo
{
    public class ExampleControlBase : UserControl
    {
        private string _outputFile;

        public ExampleControlBase()
        {
        }

        public ExampleControlBase(string outputFile)
        {
            _outputFile = outputFile;
        }

        public string OutputFile
        {
            get { return _outputFile; }
            set { _outputFile = value; }
        }

        string[] _outputFiles;
        public string[] OutputFiles
        {
            get { return _outputFiles; }
            set { _outputFiles = value; }
        }

        internal string _controlDirectory;
        public string ControlDirectory
        {
            get { return _controlDirectory; }
        }

        public virtual string GenerateButtonText
        {
            get { return "Generate"; }
        }

        internal static string GetControlTypeName(string controlFileName)
        {
            string s = "PdfDemo.Samples." +  controlFileName.Substring(0, controlFileName.Length - 3).Replace(' ', '_').Replace('\\', '.').Replace('-', '_');

            return s;
        }

        internal static ExampleControlBase Create(string controlFileName)
        {
            string tname = GetControlTypeName(controlFileName);
            ExampleControlBase obj = (ExampleControlBase)Activator.CreateInstance(Type.GetType(tname));
            obj.OutputFile = Util.OutputDir + "\\" + Path.GetFileName(controlFileName.Substring(0, controlFileName.Length - 3)) + ".pdf";
            obj._controlDirectory = Util.SamplesDir + "\\" + Path.GetDirectoryName(controlFileName);
            return obj;
        }

        public virtual string ViewMessage
        {
            get { return "PDF file is generated successfully. Do you want to open the document?"; }
        }

        public virtual string Title
        {
            get
            {
                return null;
            }
        }

        public virtual string Description
        {
            get
            {
                return null;
            }
        }

        public virtual PdfDocumentConformanceLevel ConformanceLevel
        {
            get { return PdfDocumentConformanceLevel.None; }
        }

        protected virtual void RenderPdf(PdfDocument document)
        {
        }

        public virtual bool Create()
        {
            // Create a new instance of the PdfDocument class.
            PdfDocument doc = new PdfDocument(ConformanceLevel);

            // Set document's information.
            doc.DocumentInformation.Author = "ComponentPro";
            doc.DocumentInformation.Producer = "ComponentPro";
            doc.DocumentInformation.Creator = "ComponentPro";
            doc.DocumentInformation.Title = Title;

            //doc.PageSettings.Margins = new ComponentPro.Pdf.Graphics.PdfMargins(20.0f);

            // Generate elements.
            RenderPdf(doc);

            if (!Directory.Exists(Util.OutputDir))
                Directory.CreateDirectory(Util.OutputDir);

            // Save the document to a file.
            doc.Save(_outputFile);

            doc.Close();

            return true;
        }

        public void ViewOutput()
        {
            if (_outputFiles == null)
                if (Directory.Exists(_outputFile))
                    System.Diagnostics.Process.Start("explorer", _outputFile);
                else
                    System.Diagnostics.Process.Start(_outputFile);
            else
            {
                foreach (string s in _outputFiles)
                {
                    System.Diagnostics.Process.Start(s);
                }
            }
        }
    }
}