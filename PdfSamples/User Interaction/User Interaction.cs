using System;
using System.Drawing;
using System.Text;
using System.IO;

using ComponentPro.Pdf;
using ComponentPro.Pdf.Actions;
using ComponentPro.Pdf.Annotations;
using ComponentPro.Pdf.Forms;
using ComponentPro.Pdf.Graphics;

namespace PdfDemo.Samples.User_Interaction
{
    public partial class User_Interaction : ExampleControlBase
    {
        public User_Interaction()
        {
            InitializeComponent();
        }

        int _soundAnnPos;
        int _popupAnnPos;
        int _uriAnnPos;
        int _attachmentAnnPos;
        int _intLinkAnnPos;
        int _extLinkAnnPos;
        int _lineAnnPos;

        protected override void RenderPdf(PdfDocument document)
        {
            // Add attachments
            AddAttachments(document);

            // Add a new page
            PdfPage page = document.Pages.Add();
            
            #region Page 1
            // Add action to the first page.
            AddActions(document, page);

            // Add annotation to the first page.
            AddAnnotations(document,page);
            #endregion

            #region Page 2
            page = document.Pages[1]; // Get page 2.

            // Add 3D annotations
            Add3DView(page);
            #endregion

            #region Page 3
            // Add another page
            page = document.Pages.Add();

            // Add form fields
            AddFormFields(document, page);
            #endregion

            // Add Bookmarks
            AddBookmarks(document);
        }

        #region Attachments
        private static void AddAttachments(PdfDocument document)
        {
            // File attachment
            PdfAttachment attachment = new PdfAttachment(Util.DataDir + "\\logo.gif");
            attachment.ModificationDate = DateTime.Now;
            attachment.Description = "ComponentPro Logo";
            attachment.MimeType = "application/giff";
            document.Attachments.Add(attachment);

            using (FileStream fileStream = new FileStream(Util.DataDir + "\\Spring.jpg",
                FileMode.Open))
            {
                PdfAttachment streamAttachment = new PdfAttachment("Spring.jpg", fileStream);
                streamAttachment.MimeType = "application/jpeg";
                document.Attachments.Add(streamAttachment);
            }

            // Attachment from array of bytes
            PdfAttachment textAttachment = new PdfAttachment("textfile.txt", Encoding.ASCII.GetBytes("Simple text file attachment"));
            textAttachment.ModificationDate = DateTime.Now;
            textAttachment.Description = "Sipmle text attachment";
            textAttachment.MimeType = "application/txt";
            document.Attachments.Add(textAttachment);
        }
        #endregion

        #region Action

        private static void AddActions(PdfDocument document, PdfPage page)
        {
            //Create Java action
            PdfJavaScriptAction javaAction = new PdfJavaScriptAction("app.alert(\"The document is being closed\")");

            document.Actions.BeforeClose = javaAction;
        }

        #endregion

        #region Annotation

        private void AddAnnotations(PdfDocument document, PdfPage page)
        {
            // Brush for painting the page's border.
            PdfSolidBrush brush = new PdfSolidBrush(System.Drawing.Color.FromArgb(240, 240, 240));

            #region Page Template
            //Draw some border using templates
            RectangleF rect = new RectangleF(0, 0, 10, 10);

            PdfPageTemplateElement  documentLeft = new PdfPageTemplateElement(rect);
            document.Template.Left = documentLeft;
            documentLeft.Graphics.DrawRectangle(brush, rect);
            #endregion

            #region Page Title

            Font f = new Font("Verdana", 14, FontStyle.Regular);
            PdfFont font = new PdfTrueTypeFont(f, false);
            PdfFont descFont = new PdfStandardFont(PdfFontFamily.Helvetica, 10.0f);
            PdfFont classFont = new PdfStandardFont(PdfFontFamily.Helvetica, 12.0f);
            page.Graphics.DrawString("PDF Annotations", font, PdfBrushes.Black, new PointF(200, 10));

            #endregion

            int y = 40; _popupAnnPos = y;

            #region Text Annotation

            // Create Pop up annotation
            RectangleF popupAnnotationRectangle = new RectangleF(300, y + 10, 50, 50);
            PdfPopupAnnotation popupAnnotation = new PdfPopupAnnotation(popupAnnotationRectangle,
                "Test text popup annotation");
            popupAnnotation.Border.Width = 2;
            popupAnnotation.Border.HorizontalRadius = 20;
            popupAnnotation.Border.VerticalRadius = 20;
            popupAnnotation.Icon = PdfPopupIcon.Comment;
            page.Annotations.Add(popupAnnotation);
            page.Graphics.DrawString("PdfPopupAnnotation Class", classFont, PdfBrushes.Black, new PointF(10, y));
            page.Graphics.DrawString("Double click on the icon to show the Pop up", descFont, PdfBrushes.Black, new PointF(10, y + 20));

            #endregion

            y += 50; _lineAnnPos = y;

            #region Line annotation

            //To specify the Line End Points
            int[] points = new int[] { 300 + 50, (int)page.Size.Height - (y + 57), 380 + 50, (int)page.Size.Height - (y + 57) };
            //Create Pdf Line annotation
            PdfLineAnnotation linkannotation = new PdfLineAnnotation(points, "Line Annoation");
            //Create Pdf Line Border
            LineBorder lbr = new LineBorder();
            lbr.BorderStyle = PdfBorderStyle.Solid;
            //lbr.DashArray = 1;
            lbr.BorderWidth = 1;
            linkannotation.lineBorder = lbr;


            linkannotation.LineIntent = PdfLineIntent.LineDimension;

            //Assign the Line Ending Style
            linkannotation.BeginLineStyle = PdfLineEndingStyle.Butt;
            linkannotation.EndLineStyle = PdfLineEndingStyle.Diamond;

            linkannotation.AnnotationFlags = PdfAnnotationFlags.Default;
            //Assign the Line Color
            linkannotation.InnerLineColor = new PdfColor(System.Drawing.Color.Green);
            linkannotation.BackColor = new PdfColor(System.Drawing.Color.Green);

            //Assign the Leader Line
            linkannotation.LeaderLineExt = 0;
            linkannotation.LeaderLine = 0;

            //Assign the Line Caption
            linkannotation.LineCaption = true;
            linkannotation.CaptionType = PdfLineCaptionType.Top;
            linkannotation.EndLineStyle = PdfLineEndingStyle.RClosedArrow;
            linkannotation.BeginLineStyle = PdfLineEndingStyle.Diamond;
            page.Annotations.Add(linkannotation);
            page.Graphics.DrawString("PdfLineAnnotation Class", classFont, PdfBrushes.Black, new PointF(10, y));
            page.Graphics.DrawString("A single straight line on the page", descFont, PdfBrushes.Black, new PointF(10, y + 20));

            #endregion

            y += 50; _attachmentAnnPos = y;

            #region Attachment annotation

            RectangleF attachmentRectangle = new RectangleF(300, y + 7, 16, 20);
            PdfAttachmentAnnotation attachmentAnnotation = new PdfAttachmentAnnotation(attachmentRectangle, Util.DataDir + "\\EULA.rtf");
            page.Annotations.Add(attachmentAnnotation);
            page.Graphics.DrawString("PdfAttachmentAnnotation Class", classFont, PdfBrushes.Black, new PointF(10, y));
            page.Graphics.DrawString("Double click on the icon open the attached document", descFont, PdfBrushes.Black, new PointF(10, y + 20));

            #endregion

            y += 50; _soundAnnPos = y;

            #region Create sound annotation

            RectangleF rectangle = new RectangleF(300, y, 30, 30);
            page.Graphics.DrawString("PdfSoundAnnotation Class", classFont, PdfBrushes.Black, new PointF(10, y));
            page.Graphics.DrawString("Double click on the icon to play sound", descFont, PdfBrushes.Black, new PointF(10, y + 20));
            PdfSoundAnnotation soundAnnotation = new PdfSoundAnnotation(rectangle, Util.DataDir + "\\sound.wav");
            soundAnnotation.Sound.Encoding = PdfSoundEncoding.Signed;
            soundAnnotation.Sound.Channels = PdfSoundChannels.Stereo;
            soundAnnotation.Sound.Bits = 16;
            soundAnnotation.Icon = PdfSoundIcon.Speaker;
            soundAnnotation.Color = new PdfColor(System.Drawing.Color.FromArgb(0x4e, 0x9e, 0xfe));
            page.Annotations.Add(soundAnnotation);

            #endregion

            y += 50; _uriAnnPos = y;

            #region URI annotation

            RectangleF uriAnnotationRectangle = new RectangleF(300, y + 7, 80, 20);
            PdfUriAnnotation uriAnnotation = new PdfUriAnnotation(uriAnnotationRectangle, "http://www.componentpro.com/component/pdf.net/");
            uriAnnotation.Text = "Uri Annotation";
            page.Annotations.Add(uriAnnotation);
            page.Graphics.DrawString("PdfUriAnnotation Class", classFont, PdfBrushes.Black, new PointF(10, y));
            page.Graphics.DrawString("Click on the rectangle to open UltimatePdf web page", descFont, PdfBrushes.Black, new PointF(10, y + 20));

            #endregion

            y += 50; _extLinkAnnPos = y;

            #region External link annotation

            //Create External link annotation
            RectangleF fileLinkAnnotationRectangle = new RectangleF(300, y + 7, 80, 20);
            page.Graphics.DrawString("PdfFileLinkAnnotation Class", classFont, PdfBrushes.Black, new PointF(10, y));
            page.Graphics.DrawString("Click on the rectangle to open an external file", descFont, PdfBrushes.Black, new PointF(10, y + 20));
            PdfFileLinkAnnotation fileLinkAnnotation = new PdfFileLinkAnnotation(fileLinkAnnotationRectangle,
                Util.DataDir + "\\logo.gif");
            page.Annotations.Add(fileLinkAnnotation);

            #endregion

            y += 50; _intLinkAnnPos = y;

            #region Internal link annotation

            RectangleF docLinkAnnotationRectangle = new RectangleF(300, y + 7, 80, 20);
            PdfDocumentLinkAnnotation documentAnnotation = new PdfDocumentLinkAnnotation(docLinkAnnotationRectangle);
            documentAnnotation.Text = "Document link annotation";
            documentAnnotation.Color = new PdfColor(System.Drawing.Color.Green);
            documentAnnotation.Border.Width = 2;
            documentAnnotation.Border.HorizontalRadius = 25;
            documentAnnotation.AnnotationFlags = PdfAnnotationFlags.NoRotate;
            PdfPage page2 = document.Pages.Add();
            documentAnnotation.Destination = new PdfDestination(page2);
            documentAnnotation.Destination.Location = new Point(10, 0);
            documentAnnotation.Destination.Zoom = 5;
            page.Annotations.Add(documentAnnotation);
            page.Graphics.DrawString("PdfDocumentLinkAnnotation Class", classFont, PdfBrushes.Black, new PointF(10, y));
            page.Graphics.DrawString("Click on the rectangle to move to next page", descFont, PdfBrushes.Black, new PointF(10, y + 20));

            #endregion
        }
        #endregion

        #region 3DAnnotaion

        private static void Add3DView(PdfPage page)
        {
            SizeF csize = page.Size;
            const int vwidth = 300;
            RectangleF rect = new RectangleF((csize.Width - vwidth - 30) / 2, 22, vwidth, vwidth);

            //Pdf 3D Annotation
            Pdf3DAnnotation annot = new Pdf3DAnnotation(rect, Util.DataDir + "\\Box.u3d");

            //Create font, font style and brush
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12.0f);
            PdfBrush brush = new PdfSolidBrush(System.Drawing.Color.DarkBlue);
            PdfColor color = new PdfColor(System.Drawing.Color.Black);

            // Pdf 3D Apperance
            annot.Appearance = new PdfAppearance(annot);
            annot.Appearance.Normal.Graphics.DrawString("Click to Activate the 3D Annotation", font, brush, new PointF(50, 40));
            annot.Appearance.Normal.Draw(page, new PointF(annot.Location.X, annot.Location.Y));

            Pdf3DProjection projection = new Pdf3DProjection();
            projection.ProjectionType = Pdf3DProjectionType.Perspective;

            projection.FieldOfView = 10;
            projection.ClipStyle = Pdf3DProjectionClipStyle.ExplicitNearFar;
            projection.NearClipDistance = 10;

            Pdf3DActivation activation = new Pdf3DActivation();
            activation.ActivationMode = Pdf3DActivationMode.ExplicitActivation;
            activation.ShowToolbar = true;
            annot.Activation = activation;

            Pdf3DBackground background = new Pdf3DBackground();
            background.Color = color;

            Pdf3DRendermode rendermode = new Pdf3DRendermode();
            rendermode.Style = Pdf3DRenderStyle.Solid;

            Pdf3DLighting lighting = new Pdf3DLighting();
            lighting.Style = Pdf3DLightingStyle.Headlamp;

            // Create the default view.
            Pdf3DProjection projection1 = new Pdf3DProjection(Pdf3DProjectionType.Perspective);
            projection1.FieldOfView = 50;
            projection1.ClipStyle = Pdf3DProjectionClipStyle.ExplicitNearFar;
            projection1.NearClipDistance = 10;

            Pdf3DView defaultView = new Pdf3DView();
            defaultView.ExternalName = "Default";
            defaultView.InternalName = "Int Name";
            defaultView.CameraToWorldMatrix = new float[] { -1.382684f, 0.92388f, -0.0000000766026f, 2.18024f, 0.0746579f, 0.980785f, 0.906127f, 0.37533f, -0.19509f, -162.669f, -112.432f, 45.6829f };
            defaultView.CenterOfOrbit = 161.695f;
            defaultView.Background = background;
            defaultView.Projection = projection;
            defaultView.RenderMode = rendermode;
            defaultView.LightingScheme = lighting;
            defaultView.ResetNodesState = true;

            annot.Views.Add(defaultView);

            //Add the pdf Annotation
            page.Annotations.Add(annot);
        }

        #endregion

        #region Bookmarks
        private void AddBookmarks(PdfDocument document)
        {
            // Set the viewer preference as outlines to view the bookmarks by default
            document.ViewerPreferences.PageMode = PdfPageDisplayMode.DisplayOutlines;

            #region Bookmark Outline
            // Create outline
            PdfBookmark outline = document.Bookmarks.Add("UserInteraction");
            outline.Color = Color.Black;
            outline.TextStyle = PdfTextStyle.Bold;
            outline.Title = "User Interaction";

            PdfPage page = document.Pages[0];
            outline.Destination = new PdfDestination(page);
            #endregion

            #region Bookmark Popup
            PdfBookmark popupAnnotation = outline.Add("Popup Annotation");
            popupAnnotation.Color = Color.Black;
            popupAnnotation.Destination = new PdfDestination(page, new PointF(0, _popupAnnPos));
            #endregion

            #region Bookmark Line Annotation
            PdfBookmark lineAnnotation = outline.Add("Line annotation");
            lineAnnotation.Color = Color.Black;
            lineAnnotation.Destination = new PdfDestination(page, new PointF(0, _lineAnnPos));
            #endregion

            #region Bookmark Attachment Annotation
            PdfBookmark attachmentAnnotation = outline.Add("Attachment Annotation");
            attachmentAnnotation.Color = Color.Black;
            attachmentAnnotation.Destination = new PdfDestination(page, new PointF(0, _attachmentAnnPos));
            #endregion

            #region Bookmark Sound
            //create a child node in annotation
            PdfBookmark soundAnnotation  = outline.Add("Sound Annotation");            
            soundAnnotation.Color = Color.Black;
            soundAnnotation.Destination = new PdfDestination(page, new PointF(0, _soundAnnPos));
            #endregion

            #region Bookmark Uri Annotation
            PdfBookmark uriAnnotation  = outline.Add("Uri Annotation");
            uriAnnotation.Color = Color.Black;
            uriAnnotation.Destination = new PdfDestination(page, new PointF(0, _uriAnnPos));
            #endregion

            #region Bookmark External Link
            PdfBookmark fileLinkAnnotation = outline.Add("Internal File Link annotation");
            fileLinkAnnotation.Color = Color.Black;
            fileLinkAnnotation.Destination = new PdfDestination(page, new PointF(0, _extLinkAnnPos));
            #endregion

            #region Bookmark Internal Link
            PdfBookmark docLinkAnnotation  = outline.Add("External File Link annotation");
            docLinkAnnotation.Color = Color.Black;
            docLinkAnnotation.Destination = new PdfDestination(page, new PointF(0, _intLinkAnnPos));
            #endregion

            #region Bookmark Forms
            PdfBookmark pdf3D = outline.Add("3D View");
            pdf3D.TextStyle = PdfTextStyle.Bold;
            pdf3D.Color = Color.Black;
            page = document.Pages[1];
            pdf3D.Destination = new PdfDestination(page);
            #endregion

            #region Bookmark 3D
            // Create new outline
            PdfBookmark forms = outline.Add("PDF Forms");
            forms.TextStyle = PdfTextStyle.Bold;
            forms.Color = Color.Black;
            page = document.Pages[2];
            forms.Destination = new PdfDestination(page);
            #endregion
        }
        #endregion

        #region Forms
        private static void AddFormFields(PdfDocument document, PdfPage page)
        {
            const int x1 = 10;
            const int x2 = 90;
            const int x3 = 250;
            const int x4 = x3 + (x2 - x1);
            int y = 40;
            const int boxWidth = 130;
            const int boxHeight = 20;

            PdfGraphics g = page.Graphics;
            PdfBrush brush = PdfBrushes.Black;

            #region Page Title

            Font f = new Font("Verdana", 14, FontStyle.Regular);
            PdfFont titleFont = new PdfTrueTypeFont(f, false);
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12.0f);
            g.DrawString("PDF Forms", titleFont, PdfBrushes.Black, new PointF(200, 10));

            #endregion

            #region First Name & Last Name

            g.DrawString("First Name", font, brush, x1, y + 2);
            // Create a text box
            PdfTextBoxField textBox = new PdfTextBoxField(page, "firstName");
            textBox.Bounds = new RectangleF(x2, y, boxWidth, boxHeight);
            textBox.Font = font;
            //Add the textbox in document
            document.Form.Fields.Add(textBox);

            g.DrawString("Last Name", font, brush, x3, y + 2);
            // Create a text box
            textBox = new PdfTextBoxField(page, "lastName");
            textBox.Bounds = new RectangleF(x4, y, boxWidth, boxHeight);
            textBox.Font = font;
            //Add the textbox in document
            document.Form.Fields.Add(textBox);

            #endregion

            y += 40;

            #region Country & State

            g.DrawString("Country", font, brush, x1, y + 2);
            // Create a text box
            textBox = new PdfTextBoxField(page, "country");
            textBox.Bounds = new RectangleF(x2, y, boxWidth, boxHeight);
            textBox.Font = font;
            //Add the textbox in document
            document.Form.Fields.Add(textBox);

            g.DrawString("State", font, brush, x3, y + 2);
            // Create a text box
            textBox = new PdfTextBoxField(page, "state");
            textBox.Bounds = new RectangleF(x4, y, boxWidth, boxHeight);
            textBox.Font = font;
            //Add the textbox in document
            document.Form.Fields.Add(textBox);

            #endregion

            y += 40;

            #region Company & Position

            g.DrawString("Company", font, brush, x1, y + 2);
            // Create a text box
            textBox = new PdfTextBoxField(page, "company");
            textBox.Bounds = new RectangleF(x2, y, boxWidth, boxHeight);
            textBox.Font = font;
            //Add the textbox in document
            document.Form.Fields.Add(textBox);

            g.DrawString("Position", font, brush, x3, y + 2);
            // Create a text box
            PdfComboBoxField positionComboBox = new PdfComboBoxField(page, "position");
            positionComboBox.Bounds = new RectangleF(x4, y, boxWidth, boxHeight);
            positionComboBox.Font = font;
            positionComboBox.Editable = true;
            //Add the textbox in document
            document.Form.Fields.Add(positionComboBox);

            // Create the field item to be added in the combobox
            PdfListFieldItem item1 = new PdfListFieldItem("Developer", "Developer");
            PdfListFieldItem item2 = new PdfListFieldItem("Manager", "Manager");
            PdfListFieldItem item3 = new PdfListFieldItem("CIO", "CIO");
            PdfListFieldItem item4 = new PdfListFieldItem("Sales Manager", "Sales Manager");
            PdfListFieldItem item5 = new PdfListFieldItem("CFO", "CFO");
            PdfListFieldItem item6 = new PdfListFieldItem("CEO", "CEO");

            //Add the items in combobox.
            positionComboBox.Items.Add(item1);
            positionComboBox.Items.Add(item2);
            positionComboBox.Items.Add(item3);
            positionComboBox.Items.Add(item4);
            positionComboBox.Items.Add(item5);
            positionComboBox.Items.Add(item6);

            #endregion

            y += 40;

            #region Team Size

            g.DrawString("Team Size", font, brush, x1, y + 2);
            // Create a text box
            PdfRadioButtonListField teamSize = new PdfRadioButtonListField(page, "teamSize");
            document.Form.Fields.Add(teamSize);

            //Create radiobutton items 
            PdfRadioButtonListItem radioItem1 = new PdfRadioButtonListItem("1-9");
            radioItem1.Bounds = new RectangleF(x2, y, 20, 20);
            g.DrawString("1-9", font, brush, new RectangleF(x2 + 50, y + 2, 180, 20));

            y += 25;

            PdfRadioButtonListItem radioItem2 = new PdfRadioButtonListItem("10-49");
            radioItem2.Bounds = new RectangleF(x2, y, 20, 20);
            g.DrawString("10-49", font, brush, new RectangleF(x2 + 50, y + 2, 180, 20));

            y += 25;

            PdfRadioButtonListItem radioItem3 = new PdfRadioButtonListItem("50 or more");
            radioItem3.Bounds = new RectangleF(x2, y, 20, 20);
            g.DrawString("50 or more", font, brush, new RectangleF(x2 + 50, y + 2, 180, 20));

            //add the items to radi button group
            teamSize.Items.Add(radioItem1);
            teamSize.Items.Add(radioItem2);
            teamSize.Items.Add(radioItem3);

            #endregion

            y -= 50;

            #region Language

            g.DrawString("Language", font, brush, x3, y + 2);
            // Create a text box
            PdfListBoxField listBox = new PdfListBoxField(page, "language");
            listBox.Bounds = new RectangleF(x4, y, boxWidth, boxHeight * 3);
            listBox.HighlightMode = PdfHighlightMode.Outline;
            document.Form.Fields.Add(listBox);

            //Add the items to the list box
            listBox.Items.Add(new PdfListFieldItem("CSharp", "C#"));
            listBox.Items.Add(new PdfListFieldItem("VB.NET", "VB.NET"));
            listBox.Items.Add(new PdfListFieldItem("J#", "J#"));

            //Select the item
            listBox.SelectedIndex = 2;

            //Set the multiselect option
            listBox.MultiSelect = true;

            #endregion

            y += 90;

            #region OS

            g.DrawString("OS", font, brush, x1, y + 2);
            
            // Create a text box
            PdfCheckBoxField checkBox = new PdfCheckBoxField(page, "OS");
            checkBox.Bounds = new RectangleF(x2, y, boxHeight, boxHeight);
            checkBox.HighlightMode = PdfHighlightMode.Push;
            checkBox.BorderStyle = PdfBorderStyle.Beveled;
            checkBox.Checked = true;
            document.Form.Fields.Add(checkBox);
            g.DrawString("Windows", font, brush, new RectangleF(x2 + 50, y + 2, 180, 20));

            y += 25;

            checkBox = new PdfCheckBoxField(page, "OS");
            checkBox.Bounds = new RectangleF(x2, y, boxHeight, boxHeight);
            checkBox.HighlightMode = PdfHighlightMode.Push;
            checkBox.BorderStyle = PdfBorderStyle.Beveled;
            checkBox.Checked = true;
            document.Form.Fields.Add(checkBox);
            g.DrawString("Linux", font, brush, new RectangleF(x2 + 50, y + 2, 180, 20));

            #endregion

            y -= 25;

            #region Signature

            g.DrawString("Signature", font, brush, new RectangleF(x3, y, 80, 60));

            PdfSignatureField sign = new PdfSignatureField(page, "sign");
            sign.Bounds = new RectangleF(x4, y, boxWidth, boxHeight * 3);
            document.Form.Fields.Add(sign);

            #endregion

            y += boxHeight * 3 + 20;

            PdfSubmitFormAction submitAction = new PdfSubmitFormAction("http://stevex.net/dump.php");
            submitAction.DataFormat = SubmitDataFormat.Html;

            PdfResetFormAction resetAction = new PdfResetFormAction();

            //Create submit button to transfer the values in the form
            PdfButtonField submitButton = new PdfButtonField(page, "submitButton");
            submitButton.Bounds = new RectangleF(140, y, 90, 20);
            submitButton.Font = font;
            submitButton.Text = "Submit";
            submitButton.Actions.MouseUp = submitAction;
            document.Form.Fields.Add(submitButton);

            //Create reset button to reset all the values
            PdfButtonField resetButton = new PdfButtonField(page, "resetButton");
            resetButton.Bounds = new RectangleF(250, y, 90, 20);
            resetButton.Font = font;
            resetButton.Text = "Reset";
            resetButton.Actions.MouseUp = resetAction;
            document.Form.Fields.Add(resetButton);
        }
        #endregion

        public override string Title
        {
            get { return "User Interaction Demo"; }
        }

        public override string Description
        {
            get { return "This example demonstrates User Interaction features."; }
        }
    }
}
