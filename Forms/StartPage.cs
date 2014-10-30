using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace AssemblerStudioDevelop
{
    /// <summary>
    /// Copyright © Bridge Team & Tarek Itien software engineering 2011
    /// </summary>
    public partial class StartPage : Form
    {
        #region < Fields >
        MainForm MF = null;
        #endregion

        #region < Constructors >
        public StartPage(MainForm MF)
        {
            this.MF = MF;
            InitializeComponent();
        }
        #endregion

        #region < Event Methods >
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Visible = false;
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NewProjectForm NPF = new NewProjectForm(MF);
            NPF.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                openFileDialog.Filter = "Text Files (*.txt;*.asm)|*.txt;*.asm|All Files (*.*)|*.*";
                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    //string FileName = openFileDialog.FileName;
                    ChildForm childForm = new ChildForm(MF);
                    childForm.MdiParent = MF;
                    StreamReader SR = new StreamReader(openFileDialog.FileName);
                    childForm.LoadFile(SR, openFileDialog.FileName);
                    SR.Close();
                    childForm.Text = "Project: " + openFileDialog.FileName.Remove(0, openFileDialog.InitialDirectory.Length + 1) + " (" + MF.childFormNumber++ + ")";
                    childForm.Show();
                }
            }
            catch (Exception E) { MessageBox.Show(E.Message, "Error File", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo nfo = new ProcessStartInfo("http://www.tarek-aec.webs.com/");
            nfo.UseShellExecute = true;
            Process.Start(nfo);
        }

        private void StartPage_Activated(object sender, EventArgs e)
        {
            MF.EnableChildBox(false);
        }
        #endregion
    }
}
