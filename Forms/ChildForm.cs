using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.IO;

namespace AssemblerStudioDevelop
{
    /// <summary>
    /// Copyright © Bridge Team & Tarek Itien software engineering 2011
    /// </summary>
    public partial class ChildForm : Form
    {
        #region < Fields >
        public string LocationFile = "";
        public int SizeCode = 0;
        public bool TxtChangeStatus = false;
        MainForm MF = null;
        private int linesPrinted;//Printing
        private string[] lines;//Printing
        #endregion

        #region < Constructors >
        public ChildForm(MainForm MF)
        {
            this.MF = MF;
            InitializeComponent();
            StandardColorEditing();
        }
        #endregion

        #region < Methods >
        private void StandardColorEditing()
        {
            SyntaxSettings SS = new SyntaxSettings();
            SS.CommentColor = Color.LightSkyBlue;
            SS.StringColor = Color.Brown;
            SS.IntegerColor = Color.Red;
            SS.KeywordColor = Color.Blue;
            SS.RegistersColor = Color.SkyBlue;
            syntaxRichTextBox1.Settings = SS;
        }

        public void LoadFile(StreamReader SR,string Path)
        {
                Processing P = new Processing();
                P.StartPosition = FormStartPosition.CenterScreen;
                P.ProcessEvent(10);
                P.progressBar1.Value = 90;
                Application.DoEvents();
                LocationFile = Path;
                syntaxRichTextBox1.Text = SR.ReadToEnd().ToUpper();//.Insert(0, "\n");
                syntaxRichTextBox1.ProcessAllLines();
                SR.Close();
                P.ProcessEvent(100);
                SizeCode = syntaxRichTextBox1.Text.Length;
                TxtChangeStatus = false;
        }

        public void SaveFile()
        {
            if (LocationFile != "")
            {
                StreamWriter SW = new StreamWriter(LocationFile);
                SW.Write(syntaxRichTextBox1.Text);
                SW.Close();
                SizeCode = syntaxRichTextBox1.Text.Length;
                TxtChangeStatus = false;
                MF.toolStripStatusLabel01Ready.Text = "Saved";
            }
            else
            {
                SaveAsFile();
            }
        }

        public void SaveAsFile()
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|Assembler Source (*.asm)|*.asm|All Files (*.*)|*.*";
                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    StreamWriter SW = null;
                    if (!saveFileDialog.FileName.Contains(".txt") || !saveFileDialog.FileName.Contains(".asm"))
                        SW = File.CreateText(saveFileDialog.FileName);
                    else
                        SW = File.CreateText(saveFileDialog.FileName + ".txt");
                    SW.Write(syntaxRichTextBox1.Text);
                    SW.Flush();
                    SW.Close();
                    MF.toolStripStatusLabel01Ready.Text = "Saved";
                }
            }
            catch (Exception E)
            { MessageBox.Show(E.Message, "Error File", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        #endregion

        #region < Event Methods >
        private void syntaxRichTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            // Here Get The Line Number
            MF.toolStripStatusLabel02Line.Text = String.Format("Ln {0}      ", syntaxRichTextBox1.GetLineFromCharIndex(syntaxRichTextBox1.GetFirstCharIndexOfCurrentLine()));//syntaxRichTextBox1.Lines.Length);
            MF.toolStripStatusLabel03Character.Text = String.Format("Ch {0}      ", syntaxRichTextBox1.GetFirstCharIndexOfCurrentLine());
            //MF.toolStripStatusLabel03Column.Text = String.Format("Ch {0}",syntaxRichTextBox1.GetFirstCharIndexOfCurrentLine());
            MF.toolStripStatusLabel01Ready.Text = "Ready";
            if (SizeCode != syntaxRichTextBox1.Text.Length)
                TxtChangeStatus = true;
        }

        private void ChildForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MF.toolStripStatusLabel02Line.Text = String.Format("Ln {0}", 0);
            MF.toolStripStatusLabel03Character.Text = String.Format("Ch {0}", 0);
            if (TxtChangeStatus)
            {
                DialogResult DR = MessageBox.Show("Do you want to save changed file?", "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (DR == System.Windows.Forms.DialogResult.No)
                {
                    MF.childFormNumber--;
                    return;
                }
                if (DR == System.Windows.Forms.DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
                if (LocationFile != "")
                {
                    StreamWriter SW = new StreamWriter(LocationFile);
                    SW.Write(syntaxRichTextBox1.Text);
                    SW.Close();
                    MF.childFormNumber--;
                }
                else
                {
                    SaveAsFile();
                    MF.childFormNumber--;
                }
            }
        }

        private void ChildForm_Load(object sender, EventArgs e)
        {
            //MF.EnableChildBox(true);
            //MF.ChildFormDesigner(this);
        }

        public void propertiesFile_Click(object sender, EventArgs e)
        {
            FileProperties FP = new FileProperties(LocationFile);
            FP.ShowDialog();
        }

        public void deselectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(syntaxRichTextBox1.Text))
            {
                syntaxRichTextBox1.DeselectAll();
                MF.toolStripStatusLabel01Ready.Text = "Deselected Items";
            }
            else
                MF.toolStripStatusLabel01Ready.Text = "Press Space Button";
        }

        public void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(syntaxRichTextBox1.Text))
            {
                syntaxRichTextBox1.SelectAll();
                MF.toolStripStatusLabel01Ready.Text = "Selected Items";
            }
            else
                MF.toolStripStatusLabel01Ready.Text = "Press Space Button";
        }

        public void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(syntaxRichTextBox1.Text))
            {
                syntaxRichTextBox1.Paste();
                MF.toolStripStatusLabel01Ready.Text = "Pasted Items";
            }
            else
                MF.toolStripStatusLabel01Ready.Text = "Press Space Button";
        }

        public void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(syntaxRichTextBox1.Text))
            {
                syntaxRichTextBox1.Copy();
                MF.toolStripStatusLabel01Ready.Text = "Copied Items";
            }
            else
                MF.toolStripStatusLabel01Ready.Text = "Press Space Button";
        }

        public void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(syntaxRichTextBox1.Text))
            {
                syntaxRichTextBox1.Cut();
                MF.toolStripStatusLabel01Ready.Text = "Cut Up Items";
            }
            else
                MF.toolStripStatusLabel01Ready.Text = "Press Space Button";
        }

        public void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(syntaxRichTextBox1.CanRedo)syntaxRichTextBox1.Redo();
        }

        public void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (syntaxRichTextBox1.CanUndo) syntaxRichTextBox1.Undo();
        }

        public void Print(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        public void PrintPreview(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        public void PageSetup(object sender, EventArgs e)
        {
            pageSetupDialog1.ShowDialog();
        }
        // OnBeginPrint 
        private void OnBeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            char[] param = { '\n' };
            if (printDialog1.PrinterSettings.PrintRange == PrintRange.Selection)
                lines = syntaxRichTextBox1.SelectedText.Split(param);
            else
                lines = syntaxRichTextBox1.Text.Split(param);
            int i = 0;
            char[] trimParam = { '\r' };
            foreach (string s in lines)
                lines[i++] = s.TrimEnd(trimParam);
        }
        // OnPrintPage
        private void OnPrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;
            Brush brush = new SolidBrush(syntaxRichTextBox1.ForeColor);
            while (linesPrinted < lines.Length)
            {
                e.Graphics.DrawString(lines[linesPrinted++],
                    syntaxRichTextBox1.Font, brush, x, y);
                y += 15;
                if (y >= e.MarginBounds.Bottom) { e.HasMorePages = true; return; }
            }
            linesPrinted = 0;
            e.HasMorePages = false;
        }

        private void ChildForm_Activated(object sender, EventArgs e)
        {
            MF.EnableChildBox(true);
            MF.ChildFormDesigner(this);
        }

        public void Start_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter SW = new StreamWriter(".\\SIC XE.txt");
                SW.Write(syntaxRichTextBox1.Text);
                SW.Close();
                Builder.CleanBuilder();
                HashTable HT = new HashTable();
                HT.AddOpcode();
                HT.AddRegisters();
                Builder.ProcessPass1(HT);
                Builder.ProcessPass2(HT);
                Builder.WriteFile(HT.PrintOPTAB(), HT.PrintSYMTAB(), HT.PrintRegisters());
                ExecutionViewer EV = new ExecutionViewer(MF);
                EV.MdiParent = MF;
                EV.WindowState = FormWindowState.Maximized;
                Builder.ContaintCode = File.ReadAllText(".\\Assempler sic xe.txt");
                EV.Show();
            }
            catch (SyntaxException SE) { MF.toolStripStatusLabel01Ready.Text = SE.Message; }
            catch (Exception E) { MF.toolStripStatusLabel01Ready.Text = E.Message; }
            //catch { MF.toolStripStatusLabel01Ready.Text = "Not Enable"; }
        }
        #endregion
    }
}
