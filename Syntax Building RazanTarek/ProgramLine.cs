using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssemblerStudioDevelop
{
    class ProgramLine
    {
        #region < Fields >
        string label, instruction, operand;
        #endregion

        #region < Properties >
        public string Label
        {
            get { return label; }
            set { label = value; }
        }

        public string Instruction
        {
            get { return instruction; }
            set { instruction = value; }
        }

        public string Operand
        {
            get { return operand; }
            set { operand = value; }
        }
        #endregion

        #region < Constructors >
        public ProgramLine()
        {
            label = "";
            instruction = "";
            operand = "";
        }

        public ProgramLine(string Label, string Instruction, string Operand)
        {
            label = Label;
            instruction = Instruction;
            operand = Operand;
        }
        #endregion
    }
}
