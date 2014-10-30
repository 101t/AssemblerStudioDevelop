using System;
using System.Windows.Forms;

namespace AssemblerStudioDevelop
{
    /// <summary>
    /// Copyright © Bridge Team & Tarek Itien software engineering 2011
    /// </summary>
    public partial class MenuStrip : PopedContainer
    {
        #region < Fields >
        private MainForm MF = null;
        #endregion

        #region < Constructors >
        public MenuStrip() { }
        public MenuStrip(MainForm MF)
        {
            this.MF = MF;
            InitializeComponent();
        }
        #endregion

        #region < Find Methods >
        private void btnFind_Click(object sender, System.EventArgs e)
        {
            try
            {
                int StartPosition;
                StringComparison SearchType;
                if (chkMatchCase.Checked == true)
                {
                    SearchType = StringComparison.Ordinal;
                }
                else
                {
                    SearchType = StringComparison.OrdinalIgnoreCase;
                }
                StartPosition = MF.CF.syntaxRichTextBox1.Text.IndexOf(txtSearchTerm.Text, SearchType);
                if (StartPosition == 0)
                {
                    MessageBox.Show("String: " + txtSearchTerm.Text.ToString() + "Sorry Not Found", "No Matches", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                MF.CF.syntaxRichTextBox1.Select(StartPosition, txtSearchTerm.Text.Length);
                MF.CF.syntaxRichTextBox1.ScrollToCaret();
                MF.CF.Focus();
                btnFindNext.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        private void btnFindNext_Click(object sender, System.EventArgs e)
        {
            try
            {
                int StartPosition = MF.CF.syntaxRichTextBox1.SelectionStart + 2;
                StringComparison SearchType;
                if (chkMatchCase.Checked == true)
                {
                    SearchType = StringComparison.Ordinal;
                }
                else
                {
                    SearchType = StringComparison.OrdinalIgnoreCase;
                }
                //StartPosition = Microsoft.VisualBasic.Strings.InStr(StartPosition, mMain.rtbDoc.Text, txtSearchTerm.Text, SearchType);
                StartPosition = MF.CF.syntaxRichTextBox1.Text.IndexOf(txtSearchTerm.Text, StartPosition, SearchType);

                if (StartPosition == 0 || StartPosition < 0)
                {
                    MessageBox.Show("String: " + txtSearchTerm.Text.ToString() + "Sorry Not Found", "No Matches", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                MF.CF.syntaxRichTextBox1.Select(StartPosition, txtSearchTerm.Text.Length);
                MF.CF.syntaxRichTextBox1.ScrollToCaret();
                MF.CF.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        private void txtSearchTerm_TextChanged(object sender, EventArgs e)
        {
            btnFindNext.Enabled = false;
        }
        #endregion

        #region < Replace Methods >
        private void btnFind1_Click(object sender, System.EventArgs e)
        {
            try
            {
                int StartPosition;
                StringComparison SearchType;
                if (chkMatchCase.Checked == true)
                {
                    SearchType = StringComparison.Ordinal;
                }
                else
                {
                    SearchType = StringComparison.OrdinalIgnoreCase;
                }
                StartPosition = MF.CF.syntaxRichTextBox1.Text.IndexOf(txtSearchTerm.Text, SearchType);
                if (StartPosition == 0)
                {
                    MessageBox.Show("String: " + txtSearchTerm.Text.ToString() + "Sorry Not Found", "No Matches", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                MF.CF.syntaxRichTextBox1.Select(StartPosition, txtSearchTerm.Text.Length);
                MF.CF.syntaxRichTextBox1.ScrollToCaret();
                MF.CF.Focus();
                btnFindNext.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        private void btnFindNext1_Click(object sender, System.EventArgs e)
        {
            try
            {
                int StartPosition = MF.CF.syntaxRichTextBox1.SelectionStart + 2;
                StringComparison SearchType;
                if (chkMatchCase.Checked == true)
                {
                    SearchType = StringComparison.Ordinal;
                }
                else
                {
                    SearchType = StringComparison.OrdinalIgnoreCase;
                }
                //StartPosition = Microsoft.VisualBasic.Strings.InStr(StartPosition, mMain.rtbDoc.Text, txtSearchTerm.Text, SearchType);
                StartPosition = MF.CF.syntaxRichTextBox1.Text.IndexOf(txtSearchTerm.Text, StartPosition, SearchType);

                if (StartPosition == 0 || StartPosition < 0)
                {
                    MessageBox.Show("String: " + txtSearchTerm.Text.ToString() + "Sorry Not Found", "No Matches", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                MF.CF.syntaxRichTextBox1.Select(StartPosition, txtSearchTerm.Text.Length);
                MF.CF.syntaxRichTextBox1.ScrollToCaret();
                MF.CF.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        private void txtSearchTerm1_TextChanged(object sender, EventArgs e)
        {
            btnFindNext.Enabled = false;
        }

        private void btnReplace_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (MF.CF.syntaxRichTextBox1.SelectedText.Length != 0)
                {
                    MF.CF.syntaxRichTextBox1.SelectedText = txtReplacementText.Text;
                }
                int StartPosition;
                StringComparison SearchType;

                if (chkMatchCase.Checked == true)
                {
                    SearchType = StringComparison.Ordinal;
                }
                else
                {
                    SearchType = StringComparison.OrdinalIgnoreCase;
                }
                StartPosition = MF.CF.syntaxRichTextBox1.Text.IndexOf(txtSearchTerm.Text, SearchType);
                if (StartPosition == 0 || StartPosition < 0)
                {
                    MessageBox.Show("String: " + txtSearchTerm.Text.ToString() + "Sorry Not Found", "No Matches", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                MF.CF.syntaxRichTextBox1.Select(StartPosition, txtSearchTerm.Text.Length);
                MF.CF.syntaxRichTextBox1.ScrollToCaret();
                MF.CF.syntaxRichTextBox1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        private void btnReplaceAll_Click(object sender, System.EventArgs e)
        {
            try
            {
                MF.CF.syntaxRichTextBox1.Rtf = MF.CF.syntaxRichTextBox1.Rtf.Replace(txtSearchTerm.Text.Trim(), txtReplacementText.Text.Trim());
                int StartPosition;
                StringComparison SearchType;
                if (chkMatchCase.Checked == true)
                {
                    SearchType = StringComparison.Ordinal;
                }
                else
                {
                    SearchType = StringComparison.OrdinalIgnoreCase;
                }

                StartPosition = MF.CF.syntaxRichTextBox1.Text.IndexOf(txtReplacementText.Text, SearchType);

                MF.CF.syntaxRichTextBox1.Select(StartPosition, txtReplacementText.Text.Length);
                MF.CF.syntaxRichTextBox1.ScrollToCaret();
                MF.CF.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }
        #endregion

        #region < Overriding Methods >
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            //this.Location.X = e.X;
            //if (MF.Location != null && e.Button == MouseButtons.Left)
            //{
            //    this.Left += e.X - MF.Location.X;//p.X;
            //    this.Top += e.Y - MF.Location.Y;//p.Y;
            //}
        }
        #endregion
    }
}
