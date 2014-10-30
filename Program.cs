using System;
using System.Windows.Forms;

namespace AssemblerStudioDevelop
{
    static class Program
    {
        /// <summary>
        /// Copyright © Bridge Team & Tarek Itien software engineering 2011 [Tarek MOH Omer Kala'ajy & Razan Gafar]
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
