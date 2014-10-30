using System;
using System.Windows.Forms;
using System.IO;

namespace AssemblerStudioDevelop
{
    /// <summary>
    /// Copyright © Bridge Team & Tarek Itien software engineering 2011
    /// </summary>
    public partial class FileProperties : Form
    {
        #region < Fields >
        string CF = null;
        #endregion

        #region < Constructors >
        public FileProperties(string CF)
        {
            this.CF = CF;
            InitializeComponent();
        }
        #endregion

        #region < Event Methods >
        private void FileProperties_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(CF)) return;
            FileInfo FI = new FileInfo(CF);
            lblFileName.Text = FI.Name.Replace(FI.Extension, "");
            lblFileFullName.Text = FI.FullName;
            lblFileAttribute.Text = FI.Attributes.ToString();
            lblFileExtension.Text = FI.Extension;
            string loc = FI.DirectoryName;
            if (loc.Length > 50)
                loc = loc.Substring(0, 15) + "..." + loc.Substring(loc.LastIndexOf("\\"));
            lblFileLocation.Text = loc;
            lblFileSize.Text = (FI.Length / 1024.0).ToString("0.0") + " KB";
            lblFileCreatedOn.Text = FI.CreationTime.ToString("dddd MMMM dd, yyyy");
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //private void ImageInfo_Load(object sender, EventArgs e)
        //{
        //    FileInfo fileInfo = new FileInfo(imageHandler.BitmapPath);
        //    lblImageName.Text = fileInfo.Name.Replace(fileInfo.Extension, "");
        //    lblImageExtension.Text = fileInfo.Extension;
        //    string loc = fileInfo.DirectoryName;
        //    if (loc.Length > 50)
        //        loc = loc.Substring(0, 15) + "..." + loc.Substring(loc.LastIndexOf("\\"));
        //    lblImageLocation.Text = loc;
        //    lblImageDimension.Text = imageHandler.CurrentBitmap.Width + " x " + imageHandler.CurrentBitmap.Height;
        //    lblImageSize.Text = (fileInfo.Length / 1024.0).ToString("0.0") + " KB";
        //    lblImageCreatedOn.Text = fileInfo.CreationTime.ToString("dddd MMMM dd, yyyy");
        //}
        #endregion
    }
}
