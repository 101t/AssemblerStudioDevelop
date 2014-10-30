

namespace AssemblerStudioDevelop
{
    public class OPTAB
    {
        #region < Fields >
        string Mnemonic;
        string Opcod;
        string Format;
        #endregion

        #region < Properties >
        public string MnemonicP
        {
            get { return Mnemonic; }
            set { Mnemonic = value; }
        }

        public string OpcodeP
        {
            get { return Opcod; }
            set { Opcod = value; }
        }

        public string FormatP
        {
            get { return Format; }
            set { Format = value; }
        }
        #endregion

        #region < Constructors >
        public OPTAB(string Mne, string oc, string format)
        {
            Opcod = oc;
            Mnemonic = Mne;
            Format = format;
        }
        #endregion

        #region < Overriding Methods >
        public override string ToString()
        {
            return MnemonicP + "  " + OpcodeP + "  " + FormatP;
        }
        #endregion
    }
}
 