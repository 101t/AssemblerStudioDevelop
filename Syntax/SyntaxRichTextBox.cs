using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace AssemblerStudioDevelop
{
    /// <summary>
    /// Developed By Tarek-Itien Software Engineering [Tarek MOH Omer Kala'ajy]
    /// </summary>
    public partial class SyntaxRichTextBox : System.Windows.Forms.RichTextBox
    {
        #region < Fields >
        private SyntaxSettings m_settings = new SyntaxSettings();
        private static bool m_bPaint = true;
        private string m_strLine = "";
        private int m_nContentLength = 0;
        private int m_nLineLength = 0;
        private int m_nLineStart = 0;
        private int m_nLineEnd = 0;
        private string m_strKeywords = "";
        private int m_nCurSelection = 0;
        #endregion

        #region < Properties >
        /// <summary>
        /// The settings.
        /// </summary>
        public SyntaxSettings Settings
        {
            get { return m_settings; }
            set { m_settings = value; }
        }
        #endregion

        #region < Constructors >
        /// <summary>
        /// Constructors
        /// </summary>
        public SyntaxRichTextBox() { }
        #endregion

        #region < Methods >
        /// <summary>
        /// Process a line.
        /// </summary>
        private void ProcessLine()
        {
            // Save the position and make the whole line black
            int nPosition = SelectionStart;
            SelectionStart = m_nLineStart;
            SelectionLength = m_nLineLength;
            SelectionColor = Color.Black;

            // Process the keywords
            //for (int i = 0; i < Settings.Keywords.Count; i++)
            //    ProcessRegex(" " + Settings.Keywords[i] + " ", Settings.KeywordColor);//m_strKeywords
            string m_strKeyword1 = "\\bADD\\b|\\bADDF\\b|\\bADDR\\b|\\bAND\\b|\\bCLEAR\\b|\\bCOMP\\b|\\bCOMPF\\b|\\bCOMPR\\b|\\bDIV\\b|" +
                "\\bDIVF\\b|\\bDIVR\\b|\bFIX\\b|\\bFLOAT\\b|\\bHIO\\b|\\bJ\\b|\\bJEQ\\b|\\bJGT\\b|\\bJLT\\b|\\bJSUB\\b|\\bLDA\\b|" +
                "\\bLDB\\b|\\bLDCH\\b|\\bLDF\\b|\\bLDL\\b|\\bLDS\\b|\\bLDT\\b|\\bLDX\\b|\\bLPS\\b|\\bMULF\\b|\\bMULR\\b|\\bNORM\\b";
            ProcessRegex(m_strKeyword1, Settings.KeywordColor);
            string m_strKeyword2 = "\\bOR\\b|\\bRD\\b|\\bRMO\\b|\\bRSUB\\b|\\bSHIFTL\\b|\\bSHIFTR\\b|\\bSIO\\b|\\bSSK\\b|\\bSTA\\b|\\bSTCH\\b|\\bSTF\\b|" +
                "\\bSTI\\b|\\bSTL\\b|\\bSTS\\b|\\bSTSW\\b|\\bSTT\\b|\\bSTX\\b|\\bSUB\\b|\\bSUBF\\b|\\bSUBR\\b|\\bSVC\\b|\\bTD\\b|\\bTIO\\b|" +
                "\\bTIX\\b|\\bTIXR\\b|\\bWD\\b";
            ProcessRegex(m_strKeyword2, Settings.KeywordColor);
            //Process the special instructions
            string m_strKeyword3 = "\\bSTART\\b|\\bEND\\b|\\bBASE\\b|\\bNOBASE\\b|\\bRESW\\b|\\bRESB\\b|\\bBYTE\\b|\\bWORD\\b|\\bLTORG\\b|\\bEQU\\b";
            ProcessRegex(m_strKeyword3, Settings.SpecialInstructionsColor);
            // Process numbers
            if (Settings.EnableIntegers)
                ProcessRegex("\\b(?:[0-9]*\\.)?[0-9]+\\b" , Settings.IntegerColor);
            // Process strings
            if (Settings.EnableStrings)
                ProcessRegex("\'[^\"\\\\\\r\\n]*(?:\\\\.[^\"\\\\\\r\\n]*)*\'", Settings.StringColor);//"\\b+\\b|\\b@\\b|\\b#\\b"
                //ProcessRegex("\"[^\"\\\\\\r\\n]*(?:\\\\.[^\"\\\\\\r\\n]*)*\"", Settings.StringColor);
            // Process comments
            if (Settings.EnableComments && !string.IsNullOrEmpty(Settings.Comment))
                //ProcessRegex("[^\"\\\\\\r\\n]*(?:\\\\.[^\"\\\\\\r\\n]*)*", Settings.CommentColor);
                ProcessRegex(Settings.Comment + ".*$", Settings.CommentColor);
            // Process registers
            if (Settings.EnableRegisters)
            {
                ProcessRegex("\\bA\\b|\\bX\\b|\\bL\\b|\\bPC\\b|\\bSW\\b|\\bC\\b", Settings.RegistersColor);//SIC
                ProcessRegex("\\bB\\b|\\bS\\b|\\bT\\b|\\bF\\b", Settings.RegistersColor);//SIC XE
            }
            SelectionStart = nPosition;
            SelectionLength = 0;
            SelectionColor = Color.Black;

            m_nCurSelection = nPosition;
        }
        /// <summary>
        /// Process a regular expression.
        /// </summary>
        /// <param name="strRegex">The regular expression.</param>
        /// <param name="color">The color.</param>
        private void ProcessRegex(string strRegex, Color color)
        {
            Regex regKeywords = new Regex(strRegex, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            Match regMatch;

            for (regMatch = regKeywords.Match(m_strLine); regMatch.Success; regMatch = regMatch.NextMatch())
            {
                // Process the words
                int nStart = m_nLineStart + regMatch.Index;
                int nLenght = regMatch.Length;
                SelectionStart = nStart;
                SelectionLength = nLenght;
                SelectionColor = color;
            }
        }
        /// <summary>
        /// Compiles the keywords as a regular expression.
        /// Special Design For Tarek-Itien Software Engineering & Bridge Team [Syria]
        /// </summary>
        private string CompileKeywords()
        {
            for (int i = 0; i < Settings.Keywords.Count; i++)
            {
                string strKeyword = Settings.Keywords[i];
                if (i == Settings.Keywords.Count - 1)
                    m_strKeywords += "\\b" + strKeyword + "\\b";
                else
                    m_strKeywords += "\\b" + strKeyword + "\\b|";
            }
            return m_strKeywords;
        }
        public void ProcessAllLines()
        {
            m_bPaint = false;

            int nStartPos = 0;
            int i = 0;
            int nOriginalPos = SelectionStart;
            while (i < Lines.Length)
            {
                m_strLine = Lines[i];
                m_nLineStart = nStartPos;
                m_nLineEnd = m_nLineStart + m_strLine.Length;
                ProcessLine();
                i++;
                nStartPos += m_strLine.Length + 1;
            }
            m_bPaint = true;
        }

        //private void DragDrop(DragEventArgs e)
        //{
        //    try
        //    {
        //        string[] s = (string[])e.Data.GetData("FileName");
        //        StreamReader SR = new StreamReader(s[0]);
        //        string DF = SR.ReadToEnd().ToUpper();
        //        this.Text = DF;
        //        SR.Close();
        //        //Bitmap o = (Bitmap)Image.FromFile(s[0]);
        //        //MainPictureBox.Image = o;
        //    }
        //    catch { MessageBox.Show("It Does Not Allow For This Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        //}

        //private void DragEnter(DragEventArgs e)
        //{
        //    if (e.Data.GetDataPresent(DataFormats.FileDrop))//.FileDrop))
        //    {
        //        e.Effect = DragDropEffects.Copy;
        //    }// Okay
        //    else
        //    {
        //        e.Effect = DragDropEffects.None;
        //    }
        //}
        #endregion

        #region < Overrided Methods >
        /// <summary>
        /// WndProc [Window Processing]
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == 0x00f)
            {
                if (m_bPaint)
                    base.WndProc(ref m);
                else
                    m.Result = IntPtr.Zero;
            }
            else
                base.WndProc(ref m);
        }
        /// <summary>
        /// OnTextChanged
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTextChanged(EventArgs e)
        {
            // Calculate shit here.
            m_nContentLength = this.TextLength;

            int nCurrentSelectionStart = SelectionStart;
            int nCurrentSelectionLength = SelectionLength;

            m_bPaint = false;

            // Find the start of the current line.
            m_nLineStart = nCurrentSelectionStart;
            while ((m_nLineStart > 0) && (Text[m_nLineStart - 1] != '\n'))
                m_nLineStart--;
            // Find the end of the current line.
            m_nLineEnd = nCurrentSelectionStart;
            while ((m_nLineEnd < Text.Length) && (Text[m_nLineEnd] != '\n'))
                m_nLineEnd++;
            // Calculate the length of the line.
            m_nLineLength = m_nLineEnd - m_nLineStart;
            // Get the current line.
            m_strLine = Text.Substring(m_nLineStart, m_nLineLength);

            // Process this line.
            ProcessLine();

            m_bPaint = true;
        }
        /// <summary>
        /// Drag And Drop Any File
        /// </summary>
        /// <param name="drgevent"></param>
        protected override void OnDragDrop(System.Windows.Forms.DragEventArgs drgevent)
        {
            try
            {
                string[] s = (string[])drgevent.Data.GetData("FileName");
                StreamReader SR = new StreamReader(s[0]);
                this.Text = SR.ReadToEnd().ToUpper().Insert(0, "\n");
                ProcessAllLines();
                SR.Close();
                //Bitmap o = (Bitmap)Image.FromFile(s[0]);
                //MainPictureBox.Image = o;
            }
            catch { MessageBox.Show("It Does Not Allow For This Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            //DragDrop(drgevent);
            //base.OnDragDrop(drgevent);
        }
        /// <summary>
        /// Drag Enter Mouse
        /// </summary>
        /// <param name="drgevent"></param>
        protected override void OnDragEnter(System.Windows.Forms.DragEventArgs drgevent)
        {
            if (drgevent.Data.GetDataPresent(DataFormats.FileDrop))//.FileDrop))
            {
                drgevent.Effect = DragDropEffects.Copy;
            }// Okay
            else
            {
                drgevent.Effect = DragDropEffects.None;
            }
            //DragEnter(drgevent);
            //base.OnDragEnter(drgevent);
        }
        #endregion
    }
}
