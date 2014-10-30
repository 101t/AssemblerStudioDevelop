using System;
using System.Collections;

namespace AssemblerStudioDevelop
{
    public class HashTable
    {
        #region < Fields >
        private const int SIZE = 101;
        public ArrayList[] HashTableOPTAB;
        public ArrayList[] HashTableSYMTAB;
        public ArrayList[] HashTableRegisters;
        #endregion

        #region < Constructors >
        public HashTable()
        {
            HashTableOPTAB = new ArrayList[SIZE];
            for (int i = 0; i <= SIZE - 1; i++)
                HashTableOPTAB[i] = new ArrayList();

            HashTableRegisters = new ArrayList[SIZE];
            for (int i = 0; i <= SIZE - 1; i++)
                HashTableRegisters[i] = new ArrayList();

            HashTableSYMTAB = new ArrayList[SIZE];
            for (int i = 0; i <= SIZE - 1; i++)
                HashTableSYMTAB[i] = new ArrayList();
        }

        public HashTable(string aliasSYM)
        {
            HashTableSYMTAB = new ArrayList[SIZE];
            for (int i = 0; i <= SIZE - 1; i++)
                HashTableSYMTAB[i] = new ArrayList();
        }
        #endregion

        #region < Methods >
        public int Hash(string symbol)// The Hash function 
        {
            int hashValue = 0;
            for (int i = 0; i < symbol.Length; i++)
            {
                hashValue += (int)symbol[i];
            }
            hashValue = hashValue % SIZE;
            return hashValue;
        }

        public void AddOpcode()
        {
            string[,] OpcodeTable = new string[57, 3] {
        {"ADD" , "18" , "3"},
        {"ADDF" , "58" , "3"},
        {"ADDR" , "90" , "2"},
        {"AND" , "40" , "3"},
        {"CLEAR" , "B4" , "2"},
        {"COMP" , "28" , "3"},
        {"COMPF" , "88" , "3"},
        {"COMPR" , "A0" , "2"},
        {"DIV" , "24" , "3"},
        {"DIVF" , "64" , "3"},
        {"DIVR" , "9C" , "2"},
        {"FIX" , "C4" , "1"},
        {"FLOAT" , "C0" , "1"},
        {"HIO" , "F4" , "1"},
        {"J" , "3C" , "3"},
        {"JEQ" , "30" , "3"},
        {"JGT" , "34" , "3"},
        {"JLT" , "38" , "3"},
        {"JSUB" , "48" , "3"},
        {"LDA" , "00" , "3"},
        {"LDB" , "68" , "3"},
        {"LDCH" , "50" , "3"},
        {"LDF" , "70" , "3"},
        {"LDL" , "08" , "3"},
        {"LDS" , "6C" , "3"},
        {"LDT" , "74" , "3"},
        {"LDX" , "04" , "3"},
        {"LPS" , "D0" , "3"},
        {"MULF" , "60" , "3"},
        {"MULR" , "98" , "2"},
        {"NORM" , "C8" , "1"},
        {"OR" , "44" , "3"},
        {"RD" , "D8" , "3"},
        {"RMO" , "AC" , "2"},
        {"RSUB" , "4C" , "3"},
        {"SHIFTL" , "A4" , "2"},
        {"SHIFTR" , "A8" , "2"},
        {"SIO" , "F0" , "1"},
        {"SSK" , "EC" , "3"},
        {"STA" , "0C" , "3"},
        {"STCH" , "54" , "3"},
        {"STF" , "80" , "3"},
        {"STI" , "D4" , "3"},
        {"STL" , "14" , "3"},
        {"STS" , "7C" , "3"},
        {"STSW" , "E8" , "3"},
        {"STT" , "84" , "3"},
        {"STX" , "10" , "3"},
        {"SUB" , "1C" , "3"},
        {"SUBF" , "5C" , "3"},
        {"SUBR" , "94" , "2"},
        {"SVC" , "B0" , "2"},
        {"TD" , "E0" , "3"},
        {"TIO" , "F8" , "1"},
        {"TIX" , "2C" , "3"},
        {"TIXR" , "B8" , "2"},
        {"WD" , "DC" , "3"}};
            for (int i = 0; i < 57; i++)
            {
                OPTAB OpcodeEliment = new OPTAB(OpcodeTable[i, 0], OpcodeTable[i, 1], OpcodeTable[i, 2]);
                InsertOPTAB(OpcodeEliment);
            }
        }
        
        public void InsertOPTAB(OPTAB symbol)
        {
            int hashValue = Hash(symbol.MnemonicP);
            HashTableOPTAB[hashValue].Add(symbol);
        }
        
        public int FoundOPCODE(string data, string operand, out string opcode)
        {
            int hashValue = Hash(data);
            if (HashTableOPTAB[hashValue].Count == 0)
            {
                opcode = "";
                return 0;
            }
            else
                for (int i = 0; i < HashTableOPTAB[hashValue].Count; i++)
                {
                    OPTAB c = (OPTAB)HashTableOPTAB[hashValue][i];
                    if (c.MnemonicP == data)
                    {
                        opcode = c.OpcodeP;
                        int format = Convert.ToInt32(c.FormatP);
                        if (format == 1)
                            return format;
                        else
                            if (format == 2)
                            {
                                string regVal;
                                string numReg1;
                                string numReg2;
                                if (operand.Contains(",") == false)
                                {
                                    numReg1 = FoundREG(operand, out regVal);
                                    if (numReg1 == "-1")
                                        throw new SyntaxException("The register has written is invalid !");
                                    else
                                    {
                                        opcode += numReg1 + "0";
                                        return format;
                                    }
                                }
                                else
                                {
                                    string[] registers = operand.Split(',');
                                    if (registers.Length > 2)
                                        throw new SyntaxException("The registers has written is invalid !");
                                    else
                                    {
                                        numReg1 = FoundREG(registers[0], out regVal);
                                        numReg2 = FoundREG(registers[1], out regVal);
                                        if (numReg1 == "-1" || numReg2 == "-1")
                                            throw new SyntaxException("The registers has written is invalid !");
                                        else
                                        {
                                            opcode += numReg1 + numReg2;
                                            return format;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                int opcodeDec = Convert.ToInt32(opcode, 16);
                                if (operand.StartsWith("@") == true)//Indirect Addressing
                                    opcodeDec += 2;
                                else
                                    if (operand.StartsWith("#") == true)//Immediate Addressing
                                        opcodeDec += 1;
                                    else
                                        opcodeDec += 3;
                                opcode = opcodeDec.ToString("X");//X Register Usage
                                if (opcode.Length == 1)
                                    opcode = "0" + opcode;
                                return format;
                            }
                    }
                }
            opcode = "";
            return 0;
        }
        
        public string PrintOPTAB()
        {
            string optab = "";
            for (int i = 0; i < SIZE; i++)
                if (HashTableOPTAB[i].Count != 0)
                {
                    optab += i + " ";
                    for (int j = 0; j < HashTableOPTAB[i].Count; j++)
                        optab += HashTableOPTAB[i][j].ToString() + "   ";
                    optab += "%";
                }
            return optab;
        }
        
        public void AddRegisters()
        {
            string[,] RegistersTable = new string[9, 2] {
            {"A","0"},
            {"X","1"},
            {"L","2"},
            {"B","3"},
            {"S","4"},
            {"T","5"},
            {"F","6"},
            {"PC","8"},
            {"SW","9"}
            };
            for (int i = 0; i < 9; i++)
            {
                Registers RegistersElement = new Registers(RegistersTable[i, 0], RegistersTable[i, 1], "0");
                InsertREG(RegistersElement);
            }
        }
        
        public void InsertREG(Registers REG)
        {
            int hashValue = Hash(REG.MnemonicP);
            HashTableRegisters[hashValue].Add(REG);
        }
        
        public string FoundREG(string data, out string value)
        {
            int hashValue = Hash(data);
            if (HashTableRegisters[hashValue].Count == 0)
            {
                value = "0";
                return "-1";
            }
            else
                for (int i = 0; i < HashTableRegisters[hashValue].Count; i++)
                {
                    Registers R = (Registers)HashTableRegisters[hashValue][i];
                    if (R.MnemonicP == data)
                    {
                        value = R.ValueP;
                        return R.NumberP;
                    }
                }
            value = "0";
            return "-1";
        }
        
        public string PrintRegisters()
        {
            string reg = "";
            for (int i = 0; i < SIZE; i++)
                if (HashTableRegisters[i].Count != 0)
                {
                    reg += i + " ";
                    for (int j = 0; j < HashTableRegisters[i].Count; j++)
                        reg += HashTableRegisters[i][j].ToString() + "   ";
                    reg += "%";
                }
            return reg;
        }
        
        public void InsertLabel(string lab, string loc)
        {
            int hashValue = Hash(lab);
            SYMTAB LABEL = new SYMTAB(lab, loc);
            HashTableSYMTAB[hashValue].Add(LABEL);
        }
        
        public bool FoundLAB(string lab)
        {
            int hashValue = Hash(lab);
            if (HashTableSYMTAB[hashValue].Count == 0)
                return false;
            else
                for (int i = 0; i < HashTableSYMTAB[hashValue].Count; i++)
                {
                    SYMTAB c = (SYMTAB)HashTableSYMTAB[hashValue][i];
                    if (c.LabelP == lab)
                        return true;
                }
            return false;
        }
        
        public string RetriveLocation(string pc, string format, string operand)
        {
            string operandWithoutSharp;
            int count;
            string operandObjectCode = "";
            if (operand.Contains(",") == false)
            {
                if (operand.StartsWith("@") == true || operand.StartsWith("#") == true)
                    operandWithoutSharp = operand.Substring(1);
                else
                    operandWithoutSharp = operand;
                if (format == "4")
                {
                    if (char.IsDigit(operand[1]) == true)
                    {
                        Builder.DecimalValue = Convert.ToInt32(operandWithoutSharp);
                        string operandHex = Builder.DecimalValue.ToString("X");
                        //if (operandHex.Length > 3)
                        //{
                        //    //throw new SyntaxException("The operand is too big to set in format 3 !");
                        //    return "!!!!";
                        //}
                        //else
                        //{
                        count = 5 - operandHex.Length;
                        while (count != 0)
                        {
                            operandObjectCode += "0";
                            count -= 1;
                        }
                        operandObjectCode += operandHex;
                        operandObjectCode = "0" + operandObjectCode;
                        return operandObjectCode;
                        //}
                    }
                    else
                    {
                        int hashValue = Hash(operandWithoutSharp);
                        for (int i = 0; i < HashTableSYMTAB[hashValue].Count; i++)
                        {
                            SYMTAB c = (SYMTAB)HashTableSYMTAB[hashValue][i];
                            if (c.LabelP == operandWithoutSharp)
                            {
                                count = 5 - c.LocationP.Length;
                                while (count != 0)
                                {
                                    operandObjectCode += "0";
                                    count -= 1;
                                }
                                operandObjectCode += c.LocationP;
                                operandObjectCode = "1" + operandObjectCode;
                                return operandObjectCode;
                            }
                        }
                        //throw new SyntaxException("The operand has written is invalid or is not exist !");
                        return "!!!!";
                    }//End Else Statement
                }
                else
                    if (char.IsDigit(operand[1]) == true)
                    {
                        Builder.DecimalValue = Convert.ToInt32(operandWithoutSharp);
                        string operandHex = Builder.DecimalValue.ToString("X");
                        if (operandHex.Length > 3)
                        {
                            //throw new SyntaxException("The operand is too big to set in format 3 !");
                            return "!!!!";
                        }
                        else
                        {
                            count = 3 - operandHex.Length;
                            while (count != 0)
                            {
                                operandObjectCode += "0";
                                count -= 1;
                            }
                            operandObjectCode += operandHex;
                            operandObjectCode = "0" + operandObjectCode;
                            return operandObjectCode;
                        }
                    }
                    else
                    {
                        operandObjectCode = "";
                        int dispDec;
                        int pcDec;
                        string dispHex;
                        int hashValue = Hash(operandWithoutSharp);
                        for (int i = 0; i < HashTableSYMTAB[hashValue].Count; i++)
                        {
                            SYMTAB c = (SYMTAB)HashTableSYMTAB[hashValue][i];
                            if (c.LabelP == operandWithoutSharp)
                            {
                                Builder.DecimalValue = Convert.ToInt32(c.LocationP, 16);
                                pcDec = Convert.ToInt32(pc, 16);
                                dispDec = Builder.DecimalValue - pcDec;

                                if (dispDec < -2048 || dispDec > 2047)
                                {
                                    string regVal;
                                    FoundREG("B", out regVal);
                                    int regValDec = Convert.ToInt32(regVal);
                                    dispDec = Builder.DecimalValue - regValDec;
                                    dispHex = dispDec.ToString("X");
                                    count = 3 - dispHex.Length;
                                    while (count != 0)
                                    {
                                        operandObjectCode += "0";
                                        count -= 1;
                                    }
                                    operandObjectCode += dispHex;
                                    operandObjectCode = "4" + operandObjectCode;
                                    return operandObjectCode;
                                }
                                else
                                {
                                    dispHex = dispDec.ToString("X");
                                    if (dispDec < 0)
                                        dispHex = dispHex.Substring(dispHex.Length - 3);
                                    count = 3 - dispHex.Length;
                                    while (count != 0)
                                    {
                                        operandObjectCode += "0";
                                        count -= 1;
                                    }
                                    operandObjectCode += dispHex;
                                    operandObjectCode = "2" + operandObjectCode;
                                    return operandObjectCode;
                                }
                            }

                        }
                        //throw new SyntaxException("The operand has written is invalid or is not exist !");
                        return "!!!!";
                    }
            }
            else
            {
                string[] index = operand.Split(',');
                if (index.Length > 2)
                    throw new SyntaxException("The operand with index has written is invalid !");
                else
                {
                    string operandIndex = index[0];
                    string indexer = index[1];
                    if (format == "4")
                    {
                        int hashValue = Hash(operandIndex);
                        for (int i = 0; i < HashTableSYMTAB[hashValue].Count; i++)
                        {
                            SYMTAB c = (SYMTAB)HashTableSYMTAB[hashValue][i];
                            if (c.LabelP == operandIndex)
                            {
                                count = 5 - c.LocationP.Length;
                                while (count != 0)
                                {
                                    operandObjectCode += "0";
                                    count -= 1;
                                }
                                operandObjectCode += c.LocationP;
                                operandObjectCode = "9" + operandObjectCode;
                                return operandObjectCode;
                            }
                        }
                        //throw new SyntaxException("The operand has written is invalid or is not exist !");
                        return "!!!!";
                    }
                    else
                    {
                        operandObjectCode = "";
                        int dispDec;
                        int pcDec;
                        string dispHex;
                        int hashValue = Hash(operandIndex);
                        for (int i = 0; i < HashTableSYMTAB[hashValue].Count; i++)
                        {
                            SYMTAB c = (SYMTAB)HashTableSYMTAB[hashValue][i];
                            if (c.LabelP == operandIndex)
                            {
                                Builder.DecimalValue = Convert.ToInt32(c.LocationP, 16);
                                pcDec = Convert.ToInt32(pc, 16);
                                dispDec = Builder.DecimalValue - pcDec;

                                if (dispDec < -2048 || dispDec > 2047)
                                {
                                    string regVal;
                                    FoundREG("B", out regVal);
                                    int regValDec = Convert.ToInt32(regVal);
                                    dispDec = Builder.DecimalValue - regValDec;
                                    dispHex = dispDec.ToString("X");
                                    count = 3 - dispHex.Length;
                                    while (count != 0)
                                    {
                                        operandObjectCode += "0";
                                        count -= 1;
                                    }
                                    operandObjectCode += dispHex;
                                    operandObjectCode = "C" + operandObjectCode;
                                    return operandObjectCode;
                                }
                                else
                                {
                                    dispHex = dispDec.ToString("X");
                                    if (dispDec < 0)
                                        dispHex = dispHex.Substring(dispHex.Length - 3);
                                    count = 3 - dispHex.Length;
                                    while (count != 0)
                                    {
                                        operandObjectCode += "0";
                                        count -= 1;
                                    }
                                    operandObjectCode += dispHex;
                                    operandObjectCode = "A" + operandObjectCode;
                                    return operandObjectCode;
                                }
                            }

                        }
                        //throw new SyntaxException("The operand has written is invalid or is not exist !");
                        return "!!!!";
                    }
                }
            }
        }
        
        public string PrintSYMTAB()
        {
            string symtab = "";
            for (int i = 0; i < SIZE; i++)
                if (HashTableSYMTAB[i].Count != 0)
                {
                    symtab += i + " ";
                    for (int j = 0; j < HashTableSYMTAB[i].Count; j++)
                        symtab += HashTableSYMTAB[i][j].ToString() + "   ";
                    symtab += "%";
                }
            return symtab;
        }
        #endregion
    }
}
