
namespace AssemblerStudioDevelop
{
    public class Registers
    {
        #region < Fields >
        string Mnemonic;
        string Number;
        string Value;
        #endregion

        #region < Properties >
        public string MnemonicP
        {
            get { return Mnemonic; }
            set { Mnemonic = value; }
        }

        public string NumberP
        {
            get { return Number; }
            set { Number = value; }
        }

        public string ValueP
        {
            get { return Value; }
            set { Value = value; }
        }
        #endregion

        #region < Constructors >
        public Registers(string mne, string num, string val)
        {
            Mnemonic = mne;
            Number = num;
            Value = val;
        }
        #endregion

        #region < Overriding Methods >
        public override string ToString()
        {
            return MnemonicP + "  " + NumberP;
        }
        #endregion
    }
}
