using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssemblerStudioDevelop
{
    class Symbol
    {
        #region < Fields >
        string label, location;
        #endregion

        #region < Properties >
        public string Label
        {
            get { return label; }
            set { label = value; }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }
        #endregion

        #region < Constructors >
        public Symbol(string Label)
        {
            label = Label;
        }

        public Symbol(string Label, string Location)
        {
            label = Label;
            location = Location;
        }
        #endregion
    }
}
