
namespace AssemblerStudioDevelop
{
    public class SYMTAB
    {
        #region < Fields >
        string Label;
        string Location;
        #endregion

        #region < Properties >
        public string LabelP
        {
            get { return Label; }
            set { Label = value; }
        }

        public string LocationP
        {
            get { return Location; }
            set { Location = value; }
        }
        #endregion

        #region < Constructors >
        public SYMTAB(string LAB, string LOC)
        {
            Label = LAB;
            Location = LOC;
        }
        #endregion

        #region < Overriding Methods >
        public override string ToString()
        {
            return LocationP + "  " + LabelP;
        }
        #endregion
    }
}
