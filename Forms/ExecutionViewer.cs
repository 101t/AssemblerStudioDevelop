using System;
using System.Windows.Forms;

namespace AssemblerStudioDevelop
{
    /// <summary>
    /// Copyright © Bridge Team & Tarek Itien software engineering 2011
    /// </summary>
    public partial class ExecutionViewer : Form
    {
        #region < Fields >
        MainForm MF = null;
        #endregion

        #region < Constructors >
        public ExecutionViewer(MainForm MF)
        {
            this.MF = MF;
            InitializeComponent();
        }
        #endregion

        #region < Event Methods >
        private void ExecutionViewer_Load(object sender, EventArgs e)
        {
            syntaxRichTextBox1.Text = Builder.ContaintCode;
            MF.toolStripStatusLabel01Ready.Text = "Build Succeeded";
        }

        private void syntaxRichTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            // Here Get The Line Number
            MF.toolStripStatusLabel02Line.Text = String.Format("Ln {0}      ", syntaxRichTextBox1.GetLineFromCharIndex(syntaxRichTextBox1.GetFirstCharIndexOfCurrentLine()));//syntaxRichTextBox1.Lines.Length);
            MF.toolStripStatusLabel03Character.Text = String.Format("Ch {0}      ", syntaxRichTextBox1.GetFirstCharIndexOfCurrentLine());
            MF.toolStripStatusLabel01Ready.Text = "Ready";
        }

        private void ExecutionViewer_Activated(object sender, EventArgs e)
        {
            MF.EnableChildBox(false);
        }
        #endregion
    }
}
