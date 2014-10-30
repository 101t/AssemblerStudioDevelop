using System.Windows.Forms;

namespace AssemblerStudioDevelop
{
    /// <summary>
    /// Copyright © Bridge Team & Tarek Itien software engineering 2011
    /// </summary>
    public partial class Processing : Form
    {
        #region < Constructors >
        public Processing()
        {
            InitializeComponent();
        }
        #endregion

        #region < Methods >
        public void ProcessEvent(int State)
        {
            lock (this)
            {
                if (State == 10)
                {
                    this.Show();
                    //this.progressBar1.Value = 10;
                }
                if (State == 100)
                {
                    this.Close();
                }
            }
        }
        #endregion
    }
}
