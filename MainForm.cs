using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
//using Microsoft.SDK.Samples.VistaBridge.Dialogs;

namespace AssemblerStudioDevelop
{
    /// <summary>
    /// Copyright © Bridge Team & Tarek Itien software engineering 2011
    /// </summary>
    public partial class MainForm : Form
    {
        #region < Fields >
        public int childFormNumber = 0;
        public ChildForm CF = null;
        StartPage SP;
        MouseEventArgs Mouse;
        #endregion

        #region < Constructors >
        public MainForm()
        {
            MottoSplash MySplash = new MottoSplash();
            this.Visible = false;
            InitializeComponent();
            MySplash.ShowDialog();
            this.Visible = true;
        }
        #endregion

        #region < Methods >
        public void EnableChildBox(bool x)
        {
            if (x)
            {
                saveToolStripMenuItem.Enabled = saveAsToolStripMenuItem.Enabled = printToolStripMenuItem.Enabled = printPreviewToolStripMenuItem.Enabled = pageSetupToolStripMenuItem.Enabled = true;
                cutToolStripMenuItem.Enabled = copyToolStripMenuItem.Enabled = pasteToolStripMenuItem.Enabled = undoToolStripMenuItem.Enabled = redoToolStripMenuItem.Enabled = selectAllToolStripMenuItem.Enabled = deselectAllToolStripMenuItem.Enabled = true;
                findToolStripButton6.Enabled = findToolStripMenuItem.Enabled = true;
                cutToolStripButton.Enabled = copyToolStripButton.Enabled = pasteToolStripButton.Enabled = selectAllToolStripButton.Enabled = deselectAllToolStripButton.Enabled = true;
                propertiesFileToolStripMenuItem.Enabled = PropertiesFileToolStripButton.Enabled = true;
                SaveToolStripButton.Enabled = SaveAsToolStripButton.Enabled = true;
                PageSetupToolStripButton.Enabled = PrintToolStripButton.Enabled = PrintPreviewToolStripButton.Enabled = true;
                startToolStripMenuItem3.Enabled = buildToolStripMenuItem.Visible = startToolStripButton.Visible = true;
            }
            else
            {
                saveToolStripMenuItem.Enabled = saveAsToolStripMenuItem.Enabled = printToolStripMenuItem.Enabled = printPreviewToolStripMenuItem.Enabled = pageSetupToolStripMenuItem.Enabled = false;
                cutToolStripMenuItem.Enabled = copyToolStripMenuItem.Enabled = pasteToolStripMenuItem.Enabled = undoToolStripMenuItem.Enabled = redoToolStripMenuItem.Enabled = selectAllToolStripMenuItem.Enabled = deselectAllToolStripMenuItem.Enabled = false;
                findToolStripButton6.Enabled = findToolStripMenuItem.Enabled = false;
                cutToolStripButton.Enabled = copyToolStripButton.Enabled = pasteToolStripButton.Enabled = selectAllToolStripButton.Enabled = deselectAllToolStripButton.Enabled = false;
                propertiesFileToolStripMenuItem.Enabled = PropertiesFileToolStripButton.Enabled = false;
                SaveToolStripButton.Enabled = SaveAsToolStripButton.Enabled = false;
                PageSetupToolStripButton.Enabled = PrintToolStripButton.Enabled = PrintPreviewToolStripButton.Enabled = false;
                startToolStripMenuItem3.Enabled = buildToolStripMenuItem.Visible = startToolStripButton.Visible = false;
            }
        }

        public void ChildFormDesigner(ChildForm childForm)
        {
            //Tool Strip Menu Item
            this.undoToolStripMenuItem.Click += new EventHandler(childForm.undoToolStripMenuItem_Click);
            this.redoToolStripMenuItem.Click += new EventHandler(childForm.redoToolStripMenuItem_Click);
            this.cutToolStripMenuItem.Click += new EventHandler(childForm.cutToolStripMenuItem_Click);
            this.copyToolStripMenuItem.Click += new EventHandler(childForm.copyToolStripMenuItem_Click);
            this.pasteToolStripMenuItem.Click += new EventHandler(childForm.pasteToolStripMenuItem_Click);
            this.selectAllToolStripMenuItem.Click += new EventHandler(childForm.selectAllToolStripMenuItem_Click);
            this.deselectAllToolStripMenuItem.Click += new EventHandler(childForm.deselectAllToolStripMenuItem_Click);
            //Tool Strip Button
            this.cutToolStripButton.Click += new EventHandler(childForm.cutToolStripMenuItem_Click);
            this.copyToolStripButton.Click += new EventHandler(childForm.copyToolStripMenuItem_Click);
            this.pasteToolStripButton.Click += new EventHandler(childForm.pasteToolStripMenuItem_Click);
            this.selectAllToolStripButton.Click += new EventHandler(childForm.selectAllToolStripMenuItem_Click);
            this.deselectAllToolStripButton.Click += new EventHandler(childForm.deselectAllToolStripMenuItem_Click);
            CF = childForm;
        }
        #endregion

        #region < Event Methods >
        private void ShowNewForm(object sender, EventArgs e)
        {
            NewProjectForm NPF = new NewProjectForm(this);
            NPF.ShowDialog();
            //ChildForm childForm = new ChildForm();
            //ChildFormDesigner(childForm);
            //childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                openFileDialog.Filter = "Text Files (*.txt;*.asm)|*.txt;*.asm|All Files (*.*)|*.*";
                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    //string FileName = openFileDialog.FileName;
                    ChildForm childForm = new ChildForm(this);
                    childForm.MdiParent = this;
                    StreamReader SR = new StreamReader(openFileDialog.FileName);
                    childForm.LoadFile(SR, openFileDialog.FileName);
                    SR.Close();
                    childForm.Text = "Project: " + 
                        openFileDialog.FileName.Remove(0, openFileDialog.InitialDirectory.Length + 1) + 
                        " (" + childFormNumber++ + ")";
                    childForm.Show();
                }
            }
            catch (Exception E) { MessageBox.Show(E.Message, "Error File", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CF.SaveFile();
        }

        private void SaveAsFile(object sender, EventArgs e)
        {
            CF.SaveAsFile();
        }
        
        public void findToolStripButton_MouseDown(object sender, MouseEventArgs e)
        {
            Point p = new Point(500, 100);
            MenuStrip OpeningMenu = new MenuStrip(this);
            PoperContainer m_poperContainerForButton = new PoperContainer(OpeningMenu);
            //MenuStrip MSE = new MenuStrip(this);
            if (e.Button == MouseButtons.Left)
                m_poperContainerForButton.Show(this, p);
            Mouse = e;
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void arrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void toolbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip1.Visible = toolbarToolStripMenuItem.Checked;
        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip1.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                //if (this.Contains(SP))
                //{
                //    SP.Visible = false;
                //    continue;
                //}
                childForm.Close();
            }
            childFormNumber = 0;
            EnableChildBox(false);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SP = new StartPage(this);
            SP.MdiParent = this;
            SP.WindowState = FormWindowState.Maximized;
            SP.Show();
            //EnableChildBox(false);
            //StringReader SR = new StringReader(Properties.Resources.Instructions);
            //Instructions = new List<string>();
            //string str = "j";
            //while(true)
            //{
            //    str = SR.ReadLine();
            //    if (!String.IsNullOrWhiteSpace(str)) Instructions.Add(str.Substring(0, str.IndexOf(',')));
            //    else break;
            //} 
            // SR.Close();
        }

        private void StartingPagetoolStripButton_Click(object sender, EventArgs e)
        {
            if (this.Contains(SP))
                SP.Visible = true;
            else
            {
                SP = new StartPage(this);
                SP.MdiParent = this;
                //SP.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
                //SP.Dock = DockStyle.Fill;
                SP.WindowState = FormWindowState.Maximized;
                SP.Show();
            }
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] s = (string[])e.Data.GetData("FileName");
                StreamReader SR = new StreamReader(s[0]);
                ChildForm CF = new ChildForm(this);
                CF.MdiParent = this;
                CF.LoadFile(SR, s[0]);
                CF.Show();
                //this.Text = SR.ReadToEnd().ToUpper().Insert(0, "\n");
                //ProcessAllLines();
                SR.Close();
                //Bitmap o = (Bitmap)Image.FromFile(s[0]);
                //MainPictureBox.Image = o;
            }
            catch { MessageBox.Show("It Does Not Allow For This Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))//.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }// Okay
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void toolStripButton_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void propertiesFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CF.propertiesFile_Click(sender, e);
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.findToolStripButton_MouseDown(sender, Mouse);
            }
            catch { this.toolStripStatusLabel01Ready.Text = "Cannot Do It Right Now"; }
        }

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CF.PageSetup(sender, e);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CF.Print(sender, e);
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CF.PrintPreview(sender, e);
        }

        private void startToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            CF.Start_Click(sender, e);
        }
        #endregion
    }
}
