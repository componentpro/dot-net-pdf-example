using System;
using System.IO;
using System.Windows.Forms;

namespace PdfDemo
{
    public partial class MainForm : Form
    {
        private const int FolderImageIndex = 0;
        private const int PdfImageIndex = 1;

        private readonly bool _exception;
        private ExampleControlBase _lastControl;
        private TreeNode _lastSelected;

        public MainForm()
        {
            try
            {
                InitializeComponent();
            }
            catch (ComponentPro.Licensing.Pdf.UltimateLicenseException exc)
            {
                MessageBox.Show(exc.Message, "Error");
                _exception = true;
                return;
            }
        }

        /// <summary>
        /// Handles the Form's Load event.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_exception)
                Close();

            BuildTree(Util.SamplesDir, tvSamples.Nodes, File.Exists(Util.SamplesDir + "\\Basic\\Hello World.cs") ? "cs" : "vb");
            tvSamples.SelectedNode = tvSamples.Nodes[0];
        }

        private static void BuildTree(string folderPath, TreeNodeCollection nodes, string extension)
        {
            TreeNode node;
            DirectoryInfo di = new DirectoryInfo(folderPath);
            if (di.Exists)
            {
                FileInfo[] files = di.GetFiles("*." + extension);
                foreach (FileInfo f in files)
                {
                    if (!f.Name.EndsWith(".Designer." + extension))
                    {
                        node = nodes.Add(f.Name.Substring(0, f.Name.Length - 3));
                        node.Tag = f.FullName;
                        node.ImageIndex = PdfImageIndex;
                        node.SelectedImageIndex = PdfImageIndex;                        
                    }
                }

                DirectoryInfo[] dirs = di.GetDirectories();
                foreach (DirectoryInfo d in dirs)
                {
                    node = new TreeNode(d.Name);
                    node.Tag = d.FullName;
                    node.ImageIndex = FolderImageIndex;
                    BuildTree(d.FullName, node.Nodes, extension);
                    if (node.Nodes.Count > 0)
                    {
                        nodes.Add(node);
                        node.Expand();
                    }
                }
            }
        }

        private void EnableButtons(bool enable)
        {
            btnCS.Enabled = enable;
            btnVB.Enabled = enable;
            btnGenerate.Enabled = enable;
        }

        private void tvSamples_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.ImageIndex == PdfImageIndex)
            {
                if (e.Node != _lastSelected)
                {
                    if (_lastControl != null)
                    {
                        Controls.Remove(_lastControl);
                    }

                    string file = (string)e.Node.Tag;
                    _lastControl = ExampleControlBase.Create(file.Remove(0, Util.SamplesDir.Length + 1));
                    _lastControl.Top = lblDescription.Top + lblDescription.Height + 8;
                    _lastControl.Left = lblDescription.Left + 3;
                    if (_lastControl.Controls.Count > 0)
                    {
                        Controls.Add(_lastControl);
                    }

                    if (_lastControl.Description != null)
                        lblDescription.Text = _lastControl.Description;

                    btnGenerate.Text = _lastControl.GenerateButtonText;
                    
                    _lastSelected = e.Node;
                }

                EnableButtons(true);
                if (_lastControl.Description != null)
                    lblDescription.Visible = true;
                _lastControl.Visible = true;
            }
            else
            {
                EnableButtons(false);
                lblDescription.Visible = false;
                if (_lastControl != null)
                    _lastControl.Visible = false;
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (_lastControl != null)
            {
                try
                {
                    if (_lastControl.Create() && _lastControl.OutputFile != null)
                    {
                        if (MessageBox.Show(_lastControl.ViewMessage, "Ultimate PDF Demo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            _lastControl.ViewOutput();
                        }
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Ultimate PDF Demo", MessageBoxButtons.OK);
#if DEBUG
                    System.Diagnostics.Trace.WriteLine(exc.StackTrace);
#endif
                }
            }
        }

        private void btnCS_Click(object sender, EventArgs e)
        {
            if (_lastControl != null)
            {
                string file = (string)_lastSelected.Tag;
                file = file.Substring(0, file.Length - 3) + ".cs";
                CodePreview pre = new CodePreview(file, true);

                pre.ShowDialog();
            }
        }

        private void btnVB_Click(object sender, EventArgs e)
        {
            if (_lastControl != null)
            {
                string file = (string)_lastSelected.Tag;
                file = file.Substring(0, file.Length - 3) + ".vb";
                CodePreview pre = new CodePreview(file, false);

                pre.ShowDialog();
            }
        }
    }
}