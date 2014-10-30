using System;
using System.Collections.Generic;
using System.Collections;
using System.Windows.Forms;
using System.Text;
using System.IO;

namespace AssemblerStudioDevelop
{
    public class Builder
    {
        #region < static Fields >
        //public static string FileContent = string.Empty;
        public static string ContaintCode = string.Empty;
        //public string location1;
        static string PassI = "The Pass I Process Assembler [Location Program At Memory]:\n\n";
        static string PassII = "The Pass II Process Assembler [The Object Program]:\n\n";
        static string ProgramName;
        static string StartingAddress;
        static string ProgramLength;
        public static int DecimalValue;
        static ArrayList ObjectCodeTable = new ArrayList();
        #endregion

        #region < static Methods >
        public static void ProcessPass1(HashTable HT)
        {
            try
            {
                System.IO.StreamReader sr = new StreamReader(".\\SIC XE.txt");
                string line = sr.ReadLine();
                line = line.ToUpper();
                string[] Fields = line.Split(null as char[], StringSplitOptions.RemoveEmptyEntries);
                string LOCCTR;
                int startingAddressDec = 0;
                int programLengthDec;
                while (Fields.Length == 0)//for excepted the null rows
                {
                    PassI = PassI + line + "%";
                    line = sr.ReadLine();
                    line = line.ToUpper();
                    Fields = line.Split(null as char[], StringSplitOptions.RemoveEmptyEntries);
                }
                if (Fields.Length == 2)
                {
                    if (Fields[1] == "START")
                    {
                        ProgramName = Fields[0];
                        if (ProgramName.Length > 6)
                            throw new SyntaxException("Error ! The program name is greater than 6 charecter !");
                        StartingAddress = "0";
                        LOCCTR = "0";

                        PassI = PassI + LOCCTR + " " + line + "%";
                        line = sr.ReadLine();
                        line = line.ToUpper();
                        Fields = line.Split(null as char[], StringSplitOptions.RemoveEmptyEntries);

                        while (Fields.Length == 0)
                        {
                            PassI = PassI + line + "%";
                            line = sr.ReadLine();
                            line = line.ToUpper();
                            Fields = line.Split(null as char[], StringSplitOptions.RemoveEmptyEntries);
                        }
                    }
                    else
                    {
                        ProgramName = "Sub pr";
                        StartingAddress = "0";
                        LOCCTR = "0";
                    }
                }
                else
                {
                    if (Fields[1] == "START")
                    {
                        ProgramName = Fields[0];
                        if (ProgramName.Length > 6)
                            throw new SyntaxException("Error ! The program name is greater than 6 charecter !");
                        DecimalValue = Convert.ToInt32(Fields[2]);
                        startingAddressDec = DecimalValue;
                        LOCCTR = DecimalValue.ToString("X");//from dec to hex
                        StartingAddress = LOCCTR;

                        PassI = PassI + LOCCTR + " " + line + "%";
                        line = sr.ReadLine();
                        line = line.ToUpper();
                        Fields = line.Split(null as char[], StringSplitOptions.RemoveEmptyEntries);

                        while (Fields.Length == 0)
                        {
                            PassI = PassI + line + "%";
                            line = sr.ReadLine();
                            line = line.ToUpper();
                            Fields = line.Split(null as char[], StringSplitOptions.RemoveEmptyEntries);
                        }
                    }
                    else
                    {
                        ProgramName = "Sub pr";
                        StartingAddress = "0";
                        LOCCTR = "0";
                    }
                }
                while (Fields[0] != "END")
                {
                    string[] pass2Line = new string[4];
                    if (Fields[0] != "BASE")
                    {
                        PassI += LOCCTR + " " + line + "%";
                        int found;
                        string opcode;
                        if (Fields.Length == 1)
                        {
                            if (Fields[0] == "RSUB")
                            {
                                pass2Line[0] = LOCCTR;
                                pass2Line[1] = Fields[0];
                                pass2Line[3] = "4F0000";
                                ObjectCodeTable.Add(pass2Line);

                                DecimalValue = Convert.ToInt32(LOCCTR, 16);//from hex to dec
                                DecimalValue = DecimalValue + 3;
                                LOCCTR = DecimalValue.ToString("X");//from dec to hex
                            }
                            else
                            {
                                found = HT.FoundOPCODE(Fields[0], Fields[1], out opcode);
                                if (found == 1)
                                {
                                    pass2Line[0] = LOCCTR;
                                    pass2Line[1] = "1";//format
                                    pass2Line[3] = opcode;
                                    ObjectCodeTable.Add(pass2Line);

                                    DecimalValue = Convert.ToInt32(LOCCTR, 16);//from hex to dec
                                    DecimalValue = DecimalValue + found;
                                    LOCCTR = DecimalValue.ToString("X");//from dec to hex
                                }
                                else
                                    throw new SyntaxException("The instruction has written is invalid !");
                            }
                        }
                        else
                            if (Fields.Length == 2)
                            {
                                if (Fields[0][0] == '+')
                                {
                                    string opc = Fields[0].Substring(1);
                                    found = HT.FoundOPCODE(opc, Fields[1], out opcode);
                                    if (found == 3)
                                    {
                                        pass2Line[0] = LOCCTR;
                                        pass2Line[1] = "4";//format
                                        pass2Line[2] = Fields[1];
                                        pass2Line[3] = opcode;
                                        ObjectCodeTable.Add(pass2Line);

                                        DecimalValue = Convert.ToInt32(LOCCTR, 16);//from hex to dec
                                        DecimalValue = DecimalValue + 4;
                                        LOCCTR = DecimalValue.ToString("X");//from dec to hex
                                    }
                                    else
                                        throw new SyntaxException("The instruction has written is invalid !");
                                }
                                else
                                {
                                    found = HT.FoundOPCODE(Fields[0], Fields[1], out opcode);
                                    if (found != 0)
                                    {
                                        pass2Line[0] = LOCCTR;
                                        pass2Line[1] = "" + found;//format
                                        pass2Line[2] = Fields[1];
                                        pass2Line[3] = opcode;
                                        ObjectCodeTable.Add(pass2Line);

                                        DecimalValue = Convert.ToInt32(LOCCTR, 16);//from hex to dec
                                        DecimalValue = DecimalValue + found;
                                        LOCCTR = DecimalValue.ToString("X");//from dec to hex
                                    }
                                    else
                                        if (Fields[1] == "RSUB")
                                        {
                                            if (HT.FoundLAB(Fields[0]) == true)
                                                throw new SyntaxException("Duplicate Label !");
                                            else
                                            {
                                                pass2Line[0] = LOCCTR;
                                                pass2Line[1] = Fields[1];
                                                pass2Line[3] = "4F0000";
                                                ObjectCodeTable.Add(pass2Line);

                                                HT.InsertLabel(Fields[0], LOCCTR);
                                                DecimalValue = Convert.ToInt32(LOCCTR, 16);//from hex to dec
                                                DecimalValue = DecimalValue + 3;
                                                LOCCTR = DecimalValue.ToString("X");//from dec to hex
                                            }
                                        }
                                        else
                                            if (found == 1)
                                            {
                                                if (HT.FoundLAB(Fields[0]) == true)
                                                    throw new SyntaxException("Duplicate Label !");
                                                else
                                                {
                                                    pass2Line[0] = LOCCTR;
                                                    pass2Line[1] = "1";//format
                                                    pass2Line[3] = opcode;
                                                    ObjectCodeTable.Add(pass2Line);

                                                    HT.InsertLabel(Fields[0], LOCCTR);
                                                    DecimalValue = Convert.ToInt32(LOCCTR, 16);//from hex to dec
                                                    DecimalValue = DecimalValue + found;
                                                    LOCCTR = DecimalValue.ToString("X");//from dec to hex
                                                }
                                            }
                                            else
                                                throw new SyntaxException("The instruction has written is invalid !");
                                }
                            }
                            else
                            {
                                if (HT.FoundLAB(Fields[0]) == true)
                                    throw new SyntaxException("Duplicate Label !");
                                else
                                {
                                    HT.InsertLabel(Fields[0], LOCCTR);
                                }
                                if (Fields[1][0] == '+')
                                {
                                    string opc = Fields[1].Substring(1);
                                    found = HT.FoundOPCODE(opc, Fields[2], out opcode);
                                    if (found == 3)
                                    {
                                        pass2Line[0] = LOCCTR;
                                        pass2Line[1] = "4";//format
                                        pass2Line[2] = Fields[2];
                                        pass2Line[3] = opcode;
                                        ObjectCodeTable.Add(pass2Line);

                                        DecimalValue = Convert.ToInt32(LOCCTR, 16);//from hex to dec
                                        DecimalValue = DecimalValue + 4;
                                        LOCCTR = DecimalValue.ToString("X");//from dec to hex
                                    }
                                    else
                                        throw new SyntaxException("The instruction has written is invalid !");
                                }
                                else
                                {
                                    found = HT.FoundOPCODE(Fields[1], Fields[2], out opcode);
                                    if (found != 0)
                                    {
                                        pass2Line[0] = LOCCTR;
                                        pass2Line[1] = "" + found;//format
                                        pass2Line[2] = Fields[2];
                                        pass2Line[3] = opcode;
                                        ObjectCodeTable.Add(pass2Line);

                                        DecimalValue = Convert.ToInt32(LOCCTR, 16);//from hex to dec
                                        DecimalValue = DecimalValue + found;
                                        LOCCTR = DecimalValue.ToString("X");//from dec to hex
                                    }
                                    else
                                        if (Fields[1] == "WORD")
                                        {
                                            pass2Line[0] = LOCCTR;
                                            pass2Line[1] = "0";//format
                                            pass2Line[2] = Fields[2];
                                            DecimalValue = Convert.ToInt32(Fields[2]);
                                            pass2Line[3] = DecimalValue.ToString("X");
                                            ObjectCodeTable.Add(pass2Line);

                                            DecimalValue = Convert.ToInt32(LOCCTR, 16);//from hex to dec
                                            DecimalValue = DecimalValue + 3;
                                            LOCCTR = DecimalValue.ToString("X");//from dec to hex
                                        }
                                        else
                                            if (Fields[1] == "RESW")
                                            {
                                                pass2Line[0] = LOCCTR;
                                                ObjectCodeTable.Add(pass2Line);

                                                DecimalValue = Convert.ToInt32(LOCCTR, 16);//from hex to dec
                                                DecimalValue = DecimalValue + (3 * Convert.ToInt32(Fields[2]));
                                                LOCCTR = DecimalValue.ToString("X");//from dec to hex
                                            }
                                            else
                                                if (Fields[1] == "RESB")
                                                {
                                                    pass2Line[0] = LOCCTR;
                                                    ObjectCodeTable.Add(pass2Line);

                                                    DecimalValue = Convert.ToInt32(LOCCTR, 16);//from hex to dec
                                                    DecimalValue = DecimalValue + Convert.ToInt32(Fields[2]);
                                                    LOCCTR = DecimalValue.ToString("X");//from dec to hex
                                                }
                                                else
                                                    if (Fields[1] == "BYTE")
                                                    {
                                                        if (Fields[2][0] == 'X')
                                                        {
                                                            int countCharecter = Fields[2].IndexOf("'", 2) - 2;
                                                            string operand = Fields[2].Substring(2, countCharecter);
                                                            pass2Line[0] = LOCCTR;
                                                            pass2Line[1] = "0";//format
                                                            pass2Line[2] = operand;
                                                            pass2Line[3] = operand;
                                                            ObjectCodeTable.Add(pass2Line);

                                                            double countByte = countCharecter / 2;
                                                            countByte = Math.Ceiling(countByte);
                                                            DecimalValue = Convert.ToInt32(LOCCTR, 16);//from hex to dec
                                                            DecimalValue = DecimalValue + Convert.ToInt32(countByte);
                                                            LOCCTR = DecimalValue.ToString("X");//from dec to hex
                                                        }
                                                        else
                                                            if (Fields[2][0] == 'C')
                                                            {
                                                                int asciiCodeDec;
                                                                int countCharecter = Fields[2].IndexOf("'", 2) - 2;
                                                                string operand = Fields[2].Substring(2, countCharecter);
                                                                pass2Line[0] = LOCCTR;
                                                                pass2Line[1] = "0";
                                                                pass2Line[2] = Fields[2];
                                                                pass2Line[3] = "";
                                                                for (int i = 0; i < operand.Length; i++)
                                                                {
                                                                    asciiCodeDec = (int)operand[i];
                                                                    pass2Line[3] += asciiCodeDec.ToString("X");
                                                                }
                                                                ObjectCodeTable.Add(pass2Line);

                                                                DecimalValue = Convert.ToInt32(LOCCTR, 16);//from hex to dec
                                                                DecimalValue = DecimalValue + (Fields[2].IndexOf("'", 2) - 2);
                                                                LOCCTR = DecimalValue.ToString("X");//from dec to hex
                                                            }
                                                            else
                                                                throw new SyntaxException("Error ! The syntax of operand is error !");
                                                    }

                                                    else
                                                        throw new SyntaxException("The instruction has written is invalid !");
                                }
                            }
                    }
                    else
                        PassI += line + "%";
                    line = sr.ReadLine();
                    line = line.ToUpper();
                    Fields = line.Split(null as char[], StringSplitOptions.RemoveEmptyEntries);
                    while (Fields.Length == 0)
                    {
                        PassI += line + "%";
                        line = sr.ReadLine();
                        line = line.ToUpper();
                        Fields = line.Split(null as char[], StringSplitOptions.RemoveEmptyEntries);
                    }
                }
                PassI += line + "%";
                DecimalValue = Convert.ToInt32(LOCCTR, 16);//from hex to dec
                programLengthDec = DecimalValue - startingAddressDec;
                ProgramLength = programLengthDec.ToString("X");//from dec to hex
                PassI += '%';
                PassI += "The program length is " + ProgramLength + "%";
                sr.Close();
            }
            catch (SyntaxException se) { throw new SyntaxException(se.Message); }
            catch { throw new SyntaxException("Sorry unknown erroe has occured with Pass I process !"); }
        }

        public static void ProcessPass2(HashTable HT)
        {
            try
            {
                PassII += "H^" + ProgramName;
                int count = 6 - ProgramName.Length;
                while (count != 0)
                {
                    PassII += " ";
                    count -= 1;
                }
                PassII += "^";
                count = 6 - StartingAddress.Length;
                while (count != 0)
                {
                    PassII += "0";
                    count -= 1;
                }
                PassII += StartingAddress + "^";
                count = 6 - ProgramLength.Length;
                while (count != 0)
                {
                    PassII += "0";
                    count -= 1;
                }
                PassII += ProgramLength + "%";
                string objectText = "";
                string[] temp = (string[])ObjectCodeTable[0];
                string[] tempForLoc;
                string[] pre;
                string startingAddressForTextRecord = temp[0];
                int textRecordLengthDec;
                int startingAddressForTextRecordDec;
                int preLocDec;
                int locDec;
                PassII += "T^";
                count = 6 - startingAddressForTextRecord.Length;
                while (count != 0)
                {
                    PassII += "0";
                    count -= 1;
                }
                PassII += startingAddressForTextRecord + "^";
                for (int i = 0; i < ObjectCodeTable.Count; i++)
                {
                    temp = (string[])ObjectCodeTable[i];
                    if (temp[1] == null)
                    {
                        pre = (string[])ObjectCodeTable[i - 1];
                        startingAddressForTextRecordDec = Convert.ToInt32(startingAddressForTextRecord, 16);//from hex to dec
                        preLocDec = Convert.ToInt32(pre[0], 16);//from hex to dec
                        textRecordLengthDec = preLocDec - startingAddressForTextRecordDec + 1;
                        PassII += textRecordLengthDec.ToString("X") + objectText + "%";
                        for (int j = i + 1; j < ObjectCodeTable.Count; j++)
                        {
                            temp = (string[])ObjectCodeTable[j];
                            if (temp[1] == null) continue;
                            else
                            {
                                PassII += "T^";
                                startingAddressForTextRecord = temp[0];
                                count = 6 - startingAddressForTextRecord.Length;
                                while (count != 0)
                                {
                                    PassII += "0";
                                    count -= 1;
                                }
                                PassII += startingAddressForTextRecord + "^";
                                objectText = "^" + temp[3];
                                i = j;
                                break;
                            }
                        }
                        continue;
                    }
                    if (i < ObjectCodeTable.Count - 1)
                    {
                        tempForLoc = (string[])ObjectCodeTable[i + 1];
                        if (temp[1] == "3" || temp[1] == "4")
                            temp[3] += HT.RetriveLocation(tempForLoc[0], temp[1], temp[2]);
                    }
                    else
                    {
                        if (temp[1] == "3" || temp[1] == "4")
                        {
                            int decimalvalue_temp = Convert.ToInt32(temp[0], 16);
                            DecimalValue = Convert.ToInt32(temp[1]);
                            DecimalValue = DecimalValue + decimalvalue_temp;
                            string loc_hex = DecimalValue.ToString("X");
                            temp[3] += HT.RetriveLocation(loc_hex, temp[1], temp[2]);
                        }
                    }
                    string lenghtOfTextRecord = objectText.Replace("^", "");
                    textRecordLengthDec = lenghtOfTextRecord.Length;
                    if (textRecordLengthDec <= 60)
                    {
                        objectText += "^" + temp[3];
                        if (i == ObjectCodeTable.Count - 1)
                        {
                            startingAddressForTextRecordDec = Convert.ToInt32(startingAddressForTextRecord, 16);//from hex to dec
                            locDec = Convert.ToInt32(temp[0], 16);//from hex to dec
                            textRecordLengthDec = locDec - startingAddressForTextRecordDec + 1;
                            PassII += textRecordLengthDec.ToString("X") + objectText + "%";
                        }
                    }
                    else
                    {
                        pre = (string[])ObjectCodeTable[i - 1];
                        startingAddressForTextRecordDec = Convert.ToInt32(startingAddressForTextRecord, 16);//from hex to dec
                        preLocDec = Convert.ToInt32(pre[0], 16);//from hex to dec
                        textRecordLengthDec = preLocDec - startingAddressForTextRecordDec + 1;
                        PassII += textRecordLengthDec.ToString("X") + objectText + "%";
                        PassII += "T^";
                        startingAddressForTextRecord = temp[0];
                        count = 6 - startingAddressForTextRecord.Length;
                        while (count != 0)
                        {
                            PassII += "0";
                            count -= 1;
                        }
                        PassII += startingAddressForTextRecord + "^";
                        objectText = "^" + temp[3];
                        if (i == ObjectCodeTable.Count - 1)
                        {
                            startingAddressForTextRecordDec = Convert.ToInt32(startingAddressForTextRecord, 16);//from hex to dec
                            locDec = Convert.ToInt32(temp[0], 16);//from hex to dec
                            textRecordLengthDec = locDec - startingAddressForTextRecordDec + 1;
                            PassII += textRecordLengthDec.ToString("X") + objectText + "%";
                        }
                    }
                }
                PassII += "E^";
                count = 6 - StartingAddress.Length;
                while (count != 0)
                {
                    PassII += "0";
                    count -= 1;
                }
                PassII += StartingAddress + "%";
            }
            catch
            {
                throw new SyntaxException("Sorry unknown erroe has occured with Pass II process !");
            }
        }

        public static void WriteFile(string optab, string symtab, string registers)
        {
            try
            {
                StreamWriter AssemplerSicXe = new StreamWriter(".\\Assempler sic xe.txt");
                string[] lines = PassI.Split('%');
                for (int i = 0; i < lines.Length; i++)
                    AssemplerSicXe.WriteLine(lines[i]);
                AssemplerSicXe.WriteLine();
                AssemplerSicXe.WriteLine();
                lines = PassII.Split('%');
                for (int i = 0; i < lines.Length; i++)
                    AssemplerSicXe.WriteLine(lines[i]);
                AssemplerSicXe.WriteLine();
                AssemplerSicXe.WriteLine();
                AssemplerSicXe.Close();
                StreamWriter hashTables = new StreamWriter(".\\Hash Tables.txt");
                hashTables.WriteLine("The SYMTAB table");
                hashTables.WriteLine();
                lines = symtab.Split('%');
                for (int i = 0; i < lines.Length; i++)
                    hashTables.WriteLine(lines[i]);
                hashTables.WriteLine();
                hashTables.WriteLine("----------------------------------------------");
                hashTables.WriteLine("The OPTAB table");
                hashTables.WriteLine();
                lines = optab.Split('%');
                for (int i = 0; i < lines.Length; i++)
                    hashTables.WriteLine(lines[i]);
                hashTables.WriteLine();
                hashTables.WriteLine("----------------------------------------------");
                hashTables.WriteLine("The Registers table");
                hashTables.WriteLine();
                lines = registers.Split('%');
                for (int i = 0; i < lines.Length; i++)
                    hashTables.WriteLine(lines[i]);
                hashTables.Close();
            }
            catch { throw new SyntaxException("Sorry unknown erroe has occured with Write File process !"); }
        }

        public static void CleanBuilder()
        {
            PassI = "The Pass I Process Assembler [Location Program At Memory]:\n\n";
            PassII = "The Pass II Process Assembler [The Object Program]:\n\n";
            ContaintCode = string.Empty;
            DecimalValue = 0;
            ObjectCodeTable = null;
            ObjectCodeTable = new ArrayList();
        }
        
        //public void Executions()
        //{
        //    try
        //    {
        //        HashTable HT = new HashTable();
        //        HT.AddOpcode();
        //        HT.AddRegisters();
        //        ProcessPass1(HT);
        //        ProcessPass2(HT);
        //        WriteFile(HT.PrintOPTAB(), HT.PrintSYMTAB(), HT.PrintRegisters());
        //    }
        //    catch (SyntaxException se)
        //    {
        //        MessageBox.Show(se.Message,"Error Detection");
        //    }
        //}
        #endregion
    }
}
