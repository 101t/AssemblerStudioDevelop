using System;
using System.Windows.Forms;
using System.IO;

namespace AssemblerStudioDevelop
{
    /// <summary>
    /// Copyright © Bridge Team & Tarek Itien software engineering 2011
    /// </summary>
    public partial class NewProjectForm : Form
    {
        #region < Fields >
        string FileName = "";
        MainForm MF = null;
        #endregion

        #region < Constructors >
        public NewProjectForm(MainForm MF)
        {
            this.MF = MF;
            InitializeComponent();
        }
        #endregion

        #region < Methods >
        private void ChildFormDesigner(ChildForm childForm)
        {
            childForm.LocationFile = FileName;
            MF.childFormNumber++;
            if (FileLocationtextBox1.Text == "" || FileNametextBox2.Text == "")
                childForm.Text = FileLocationtextBox1.Text.Remove(0, FileNametextBox2.Text.Length);
            else
                childForm.Text = "Project [" + MF.childFormNumber + "]";
            childForm.MdiParent = MF;
        }
        #endregion

        #region < Event Methods >
        private void OpenFileChildForm(object sender, EventArgs e)
        {
            if (FileLocationtextBox1.Text == "" || FileNametextBox2.Text == "")
            {
                DialogResult DR = MessageBox.Show("Do you want to continue without saving file?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DR == System.Windows.Forms.DialogResult.No)
                    return;
            }
            ChildForm childForm = new ChildForm(MF);
            ChildFormDesigner(childForm);
            childForm.Show();
            this.Dispose(true);
        }
        
        private void SaveAsFile(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|Assembler Source (*.asm)|*.asm|All Files (*.*)|*.*";
                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    FileName = saveFileDialog.FileName;
                    StreamWriter SW = null;
                    if (!saveFileDialog.FileName.Contains(".txt") || !saveFileDialog.FileName.Contains(".asm"))
                        SW = File.CreateText(saveFileDialog.FileName);
                    else
                        SW = File.CreateText(saveFileDialog.FileName + ".txt");
                    SW.Write(" ");
                    SW.Flush();
                    SW.Close();
                    FileLocationtextBox1.Text = saveFileDialog.InitialDirectory; //+ "\\" + saveFileDialog.FileName;
                    FileNametextBox2.Text = saveFileDialog.FileName;
                    //File.CreateText(saveFileDialog.InitialDirectory + "\\" + saveFileDialog.FileName);
                }
            }
            catch (Exception E)
            { MessageBox.Show(E.Message, "Error File", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        #endregion
    }
}
