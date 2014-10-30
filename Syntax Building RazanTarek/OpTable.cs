using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace AssemblerStudioDevelop
{
    /// <summary>
    /// Designed By Bridge Team [Razan Gafar]
    /// </summary>
    class OpTable
    {
        #region < Fields >
        Hashtable Table = new Hashtable();
        #endregion

        #region < Indexers >
        public Operation this[string key]
        {
            get { return (Operation)Table[key.ToUpper()]; }
        }

        public ICollection Values
        {
            get { return Table.Values; }
        }
        #endregion

        #region < Constructors >
        public OpTable()
        {
            FillTable();
        }
        #endregion

        #region < Methods >
        private void FillTable()
        {
            Table.Add("ADD", new Operation("ADD", 3, "18"));
            Table.Add("ADDF", new Operation("ADDF", 3, "58"));
            Table.Add("ADDR", new Operation("ADDR", 2, "90"));
            Table.Add("AND", new Operation("AND", 3, "40"));
            Table.Add("CLEAR", new Operation("CLEAR", 2, "B4"));
            Table.Add("COMP", new Operation("COMP", 3, "28"));
            Table.Add("COMPF", new Operation("COMPF", 3, "88"));
            Table.Add("COMPR", new Operation("COMPR", 2, "A0"));
            Table.Add("DIV", new Operation("DIV", 3, "24"));
            Table.Add("DIVF", new Operation("DIVF", 3, "64"));
            Table.Add("DIVR", new Operation("DIVR", 2, "9C"));
            Table.Add("FIX", new Operation("FIX", 1, "C4"));
            Table.Add("FLOAT", new Operation("FLOAT", 1, "C0"));
            Table.Add("HIO", new Operation("HIO", 1, "F4"));
            Table.Add("J", new Operation("J", 3, "3C"));
            Table.Add("JEQ", new Operation("JEQ", 3, "30"));
            Table.Add("JGT", new Operation("JGT", 3, "34"));
            Table.Add("JLT", new Operation("JLT", 3, "38"));
            Table.Add("JSUB", new Operation("JSUB", 3, "48"));
            Table.Add("LDA", new Operation("LDA", 3, "00"));
            Table.Add("LDB", new Operation("LDB", 3, "68"));
            Table.Add("LDCH", new Operation("LDCH", 3, "50"));
            Table.Add("LDF", new Operation("LDF", 3, "70"));
            Table.Add("LDL", new Operation("LDL", 3, "08"));
            Table.Add("LDS", new Operation("LDS", 3, "6C"));
            Table.Add("LDT", new Operation("LDT", 3, "74"));
            Table.Add("LDX", new Operation("LDX", 3, "04"));
            Table.Add("LPS", new Operation("LPS", 3, "D0"));
            Table.Add("MUL", new Operation("MUL", 3, "20"));
            Table.Add("MULF", new Operation("MULF", 3, "60"));
            Table.Add("MULR", new Operation("MULR", 2, "98"));
            Table.Add("NORM", new Operation("NORM", 1, "C8"));
            Table.Add("OR", new Operation("OR", 3, "44"));
            Table.Add("RD", new Operation("RD", 3, "D8"));
            Table.Add("RMO", new Operation("RMO", 2, "AC"));
            Table.Add("RSUB", new Operation("RSUB", 3, "4C"));
            Table.Add("SHIFTL", new Operation("SHIFTL", 2, "A4"));
            Table.Add("SHIFTR", new Operation("SHIFTR", 2, "A8"));
            Table.Add("SIO", new Operation("SIO", 1, "F0"));
            Table.Add("SSK", new Operation("SSK", 3, "EC"));
            Table.Add("STA", new Operation("STA", 3, "0C"));
            Table.Add("STB", new Operation("STB", 3, "78"));
            Table.Add("STCH", new Operation("STCH", 3, "54"));
            Table.Add("STF", new Operation("STF", 3, "80"));
            Table.Add("STI", new Operation("STI", 3, "D4"));
            Table.Add("STL", new Operation("STL", 3, "14"));
            Table.Add("STS", new Operation("STS", 3, "7C"));
            Table.Add("STSW", new Operation("STSW", 3, "E8"));
            Table.Add("STT", new Operation("STT", 3, "84"));
            Table.Add("STX", new Operation("STX", 3, "10"));
            Table.Add("SUB", new Operation("SUB", 3, "1C"));
            Table.Add("SUBF", new Operation("SUBF", 3, "5C"));
            Table.Add("SUBR", new Operation("SUBR", 2, "94"));
            Table.Add("SVC", new Operation("SVC", 2, "B0"));
            Table.Add("TD", new Operation("TD", 3, "E0"));
            Table.Add("TIO", new Operation("TIO", 1, "F8"));
            Table.Add("TIX", new Operation("TIX", 3, "2C"));
            Table.Add("TIXR", new Operation("TIXR", 2, "B8"));
            Table.Add("WD", new Operation("WD", 3, "DC"));
        }

        public bool ContainsKey(string key)
        {
            return Table.ContainsKey(key.ToUpper());
        }
        #endregion
    }
}
