using System.IO;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;

namespace PdfDemo
{
    /// <summary>
    /// Implements support for highlighted C# code preview in a RichTextBox
    /// </summary>
    public class CSCodeFormatter
    {
        /// <summary>
        /// New class instance
        /// </summary>
        public CSCodeFormatter()
        {
            m_arrKeywords = new Hashtable();

            m_arrKeywords.Add("abstract", "");
            m_arrKeywords.Add("event", "");
            m_arrKeywords.Add("new", "");
            m_arrKeywords.Add("struct", "");
            m_arrKeywords.Add("as", "");
            m_arrKeywords.Add("explicit", "");
            m_arrKeywords.Add("null", "");
            m_arrKeywords.Add("switch", "");
            m_arrKeywords.Add("base", "");
            m_arrKeywords.Add("extern", "");
            m_arrKeywords.Add("object", "");
            m_arrKeywords.Add("this", "");
            m_arrKeywords.Add("bool", "");
            m_arrKeywords.Add("false", "");
            m_arrKeywords.Add("operator", "");
            m_arrKeywords.Add("throw", "");
            m_arrKeywords.Add("break", "");
            m_arrKeywords.Add("finally", "");
            m_arrKeywords.Add("out", "");
            m_arrKeywords.Add("true", "");
            m_arrKeywords.Add("byte", "");
            m_arrKeywords.Add("fixed", "");
            m_arrKeywords.Add("override", "");
            m_arrKeywords.Add("try", "");
            m_arrKeywords.Add("case", "");
            m_arrKeywords.Add("float", "");
            m_arrKeywords.Add("params", "");
            m_arrKeywords.Add("typeof", "");
            m_arrKeywords.Add("catch", "");
            m_arrKeywords.Add("for", "");
            m_arrKeywords.Add("private", "");
            m_arrKeywords.Add("uint", "");
            m_arrKeywords.Add("char", "");
            m_arrKeywords.Add("foreach", "");
            m_arrKeywords.Add("protected", "");
            m_arrKeywords.Add("ulong", "");
            m_arrKeywords.Add("checked", "");
            m_arrKeywords.Add("goto", "");
            m_arrKeywords.Add("public", "");
            m_arrKeywords.Add("unchecked", "");
            m_arrKeywords.Add("class", "");
            m_arrKeywords.Add("if", "");
            m_arrKeywords.Add("readonly", "");
            m_arrKeywords.Add("unsafe", "");
            m_arrKeywords.Add("const", "");
            m_arrKeywords.Add("implicit", "");
            m_arrKeywords.Add("ref", "");
            m_arrKeywords.Add("ushort", "");
            m_arrKeywords.Add("continue", "");
            m_arrKeywords.Add("in", "");
            m_arrKeywords.Add("return", "");
            m_arrKeywords.Add("using", "");
            m_arrKeywords.Add("decimal", "");
            m_arrKeywords.Add("int", "");
            m_arrKeywords.Add("sbyte", "");
            m_arrKeywords.Add("virtual", "");
            m_arrKeywords.Add("default", "");
            m_arrKeywords.Add("interface", "");
            m_arrKeywords.Add("sealed", "");
            m_arrKeywords.Add("volatile", "");
            m_arrKeywords.Add("delegate", "");
            m_arrKeywords.Add("internal", "");
            m_arrKeywords.Add("short", "");
            m_arrKeywords.Add("void", "");
            m_arrKeywords.Add("do", "");
            m_arrKeywords.Add("is", "");
            m_arrKeywords.Add("sizeof", "");
            m_arrKeywords.Add("while", "");
            m_arrKeywords.Add("double", "");
            m_arrKeywords.Add("lock", "");
            m_arrKeywords.Add("stackalloc", "");
            m_arrKeywords.Add("else", "");
            m_arrKeywords.Add("long", "");
            m_arrKeywords.Add("static", "");
            m_arrKeywords.Add("enum", "");
            m_arrKeywords.Add("namespace", "");
            m_arrKeywords.Add("string", "");
        }


        #region Exposed Functionality

        /// <summary>
        /// Controls whether to apply CShart highlight
        /// </summary>
        public bool HighlightCode
        {
            get
            {
                return m_bHighlightCode;
            }
            set
            {
                m_bHighlightCode = value;
            }
        }

        /// <summary>
        /// Controls whether to collapse the designer generated code
        /// </summary>
        public bool CollapseDesignerCode
        {
            get
            {
                return m_bCollapseDesignerCode;
            }
            set
            {
                m_bCollapseDesignerCode = value;
            }
        }

        /// <summary>
        /// Update the edit to show the code for the specified example
        /// </summary>
        /// <param name="sourceEdit"></param>
        /// <param name="leaf"></param>
        public void UpdateSourceEditFromExample(RichTextBox sourceEdit, string fileName)
        {
            // set wait cursor
            Cursor oldCursor = Cursor.Current;
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

            // prepare the source edit
            sourceEdit.Clear();
            sourceEdit.SuspendLayout();
            sourceEdit.Visible = false;

            // load the file in the edit
            StreamReader srRead;
            try
            {
                srRead = new StreamReader((System.IO.Stream)File.OpenRead(fileName), System.Text.Encoding.ASCII);
            }
            catch
            {
                MessageBox.Show("Failed to load file:" + fileName);
                return;
            }

            srRead.BaseStream.Seek(0, SeekOrigin.Begin);
            srRead.BaseStream.Position = 0;

            char[] buffer = new char[srRead.BaseStream.Length];
            srRead.Read(buffer, 0, (int)srRead.BaseStream.Length);

            srRead.DiscardBufferedData();
            srRead.Close();

            sourceEdit.Font = new Font("Courier New", 10);
            sourceEdit.Text = new string(buffer);

            // perform text analysis
            DoCollapseDesignerCode(sourceEdit);
            DoHighlightCode(sourceEdit);

            // resume edit layout
            sourceEdit.Visible = true;
            sourceEdit.ResumeLayout();
            Cursor.Current = oldCursor;
        }


        #endregion

        #region Implementation

        private bool IsLineComment(string l)
        {
            string ltrimmed = l.TrimStart(null);
            if (ltrimmed.Length >= 2)
            {
                if (ltrimmed.Substring(0, 2) == "//")
                    return true;
            }
            return false;
        }

        private bool IsKeyword(string sWord)
        {
            return m_arrKeywords.ContainsKey(sWord);
        }


        private void DoCollapseDesignerCode(RichTextBox sourceEdit)
        {
            if (m_bCollapseDesignerCode == false)
                return;

            // highlight keywords
            //string word = "";
            //int wordStart = 0;
            int lineStart = 0;
            int lineEnd = 0;

            bool bDesignerCodeFound = false;
            int designerCodeStart = -1;

            // collapse designer code
            lineEnd = sourceEdit.Text.IndexOf('\n');

            while (lineEnd != -1)
            {
                string line = sourceEdit.Text.Substring(lineStart, lineEnd - lineStart + 1);
                string lineTrimmed = line.Trim();

                if (lineTrimmed == "#region Component Designer generated code")
                {
                    // entering a designer code -> save the the start
                    bDesignerCodeFound = true;
                    designerCodeStart = lineStart;
                }
                else if (lineTrimmed == "#endregion" && bDesignerCodeFound)
                {
                    // end region found for designer code -> replace it with a simple string
                    bDesignerCodeFound = false;
                    string genCode = "\t\tWindows Forms Designer generated code";

                    sourceEdit.Text = sourceEdit.Text.Substring(0, designerCodeStart) +
                              genCode +
                              sourceEdit.Text.Substring(lineEnd, sourceEdit.Text.Length - lineEnd);

                    sourceEdit.SelectionStart = designerCodeStart;
                    sourceEdit.SelectionLength = genCode.Length;
                    sourceEdit.SelectionColor = Color.LightGray;
                    sourceEdit.SelectionFont = new Font("Arial", 10, FontStyle.Bold);

                    lineEnd = designerCodeStart;
                }

                // move to next line
                lineStart = lineEnd + 1;
                lineEnd = sourceEdit.Text.IndexOf('\n', lineStart);
            }
        }

        private void DoHighlightCode(RichTextBox sourceEdit)
        {
            if (m_bHighlightCode == false)
                return;

            // highlight keywords
            string word = "";
            int wordStart = 0;
            int lineStart = 0;
            int lineEnd = 0;

            // highlight
            lineStart = 0;
            lineEnd = sourceEdit.Text.IndexOf('\n');

            while (lineEnd != -1)
            {
                string line = sourceEdit.Text.Substring(lineStart, lineEnd - lineStart + 1);

                if (IsLineComment(line))
                {
                    // a comment line
                    sourceEdit.SelectionStart = lineStart;
                    sourceEdit.SelectionLength = lineEnd - lineStart;
                    sourceEdit.SelectionColor = Color.DarkGreen;
                }
                else
                {
                    // parse the line for keywords, inline comments and str constants
                    bool bInStrConst = false;
                    int nStrConstStart = -1;

                    for (int i = 0; i < line.Length; i++)
                    {
                        char c = line[i];

                        // string constants
                        if (c == '"')
                        {
                            // end of str constant
                            if (bInStrConst)
                            {
                                sourceEdit.SelectionStart = nStrConstStart + lineStart;
                                sourceEdit.SelectionLength = i - nStrConstStart + 1;
                                sourceEdit.SelectionColor = Color.DarkSlateBlue;

                                bInStrConst = false;
                            }
                            else
                            {
                                nStrConstStart = i;
                                bInStrConst = true;
                            }

                            continue;
                        }

                        // looking for the end of a string constant
                        if (bInStrConst)
                            continue;

                        // inline comment - > comment the rest of the line
                        if (c == '\'')
                        {
                            sourceEdit.SelectionStart = lineStart + i;
                            sourceEdit.SelectionLength = lineEnd - lineStart - i;
                            sourceEdit.SelectionColor = Color.DarkGreen;
                            break;
                        }

                        // if c is separator in C# sense
                        if (c == ' ' || c == '\t' || c == '(' || c == ')' || c == ',' || c == '.' || c == ';' || c == '\n')
                        {
                            // if some word was accumulated
                            if (word.Length != 0)
                            {
                                if (IsKeyword(word))
                                {
                                    sourceEdit.SelectionStart = wordStart + lineStart;
                                    sourceEdit.SelectionLength = word.Length;
                                    sourceEdit.SelectionColor = Color.Blue;
                                }
                            }

                            // clear word
                            word = "";
                            continue;
                        }

                        if (word.Length == 0)
                            wordStart = i;

                        word += c;
                    }
                }

                // move to next line
                lineStart = lineEnd + 1;
                lineEnd = sourceEdit.Text.IndexOf('\n', lineStart);
            }
        }


        private bool m_bHighlightCode;
        private bool m_bCollapseDesignerCode;
        private Hashtable m_arrKeywords;

        #endregion
    }
}