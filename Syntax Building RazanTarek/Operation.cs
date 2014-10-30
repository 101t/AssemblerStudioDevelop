using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssemblerStudioDevelop
{
    /// <summary>
    /// Designed By Bridge Team [Razan Gafar]
    /// </summary>
    class Operation
    {
        #region < Fields >
        string name, opcode;
        int format;
        #endregion

        #region < Properties >
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Opcode
        {
            get { return opcode; }
            set { opcode = value; }
        }
        public int Format
        {
            get { return format; }
            set { format = value; }
        }
        #endregion

        #region < Constructors >
        public Operation(string Name, int Format, string Opcode)
        {
            name = Name;
            format = Format;
            opcode = Opcode;
        }
        #endregion
    }
}
