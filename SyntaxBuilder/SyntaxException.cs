using System.IO;

namespace AssemblerStudioDevelop
{
    class SyntaxException : IOException
    {
        #region < Constructors >
        public SyntaxException() : base("Error ! The syntax of program is wrong !") { }

        public SyntaxException(string se) : base(se) { }
        #endregion
    }
}
