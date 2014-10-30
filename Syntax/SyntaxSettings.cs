using System.Collections.Generic;
using System.Drawing;

namespace AssemblerStudioDevelop
{
    /// <summary>
    /// Copyright © Bridge Team & Tarek Itien software engineering 2011
    /// Class to store syntax objects in.
    /// </summary>
    public class SyntaxList
    {
        #region < Fields >
        public List<string> m_rgList;// = new List<string>();
        public Color m_color;// = new Color();
        #endregion

        #region < Constructors >
        public SyntaxList() 
        {
            m_rgList = new List<string>();
            m_color = new Color();
        }
        #endregion
    }

    /// <summary>
    /// Copyright © Bridge Team & Tarek Itien software engineering 2011
    /// Settings for the keywords and colors.
    /// </summary>
    public class SyntaxSettings
    {
        #region < Fields >
        SyntaxList m_rgKeywords = new SyntaxList();
        string m_strComment = "";
        Color m_colorComment = Color.Green;
        Color m_colorString = Color.Blue;
        Color m_colorInteger = Color.Red;
        Color m_colorRegisters = Color.SlateBlue;
        Color m_colorSpecialInstructions = Color.Gray;
        bool m_bEnableComments = true;
        bool m_bEnableIntegers = true;
        bool m_bEnableStrings = true;
        bool m_bEnableRegisters = true;
        bool m_bEnableSpecialInstructions = true;
        #endregion

        #region < Properties >
        /// <summary>
        /// A list containing all keywords.
        /// </summary>
        public List<string> Keywords
        {
            get { return m_rgKeywords.m_rgList; }
            set { m_rgKeywords.m_rgList = value; }
        }
        /// <summary>
        /// The color of keywords.
        /// </summary>
        public Color KeywordColor
        {
            get { return m_rgKeywords.m_color; }
            set { m_rgKeywords.m_color = value; }
        }
        /// <summary>
        /// A string containing the comment identifier.
        /// </summary>
        public string Comment
        {
            get { return m_strComment; }
            set { m_strComment = value; }
        }
        /// <summary>
        /// The color of comments.
        /// </summary>
        public Color CommentColor
        {
            get { return m_colorComment; }
            set { m_colorComment = value; }
        }
        /// <summary>
        /// Enables processing of comments if set to true.
        /// </summary>
        public bool EnableComments
        {
            get { return m_bEnableComments; }
            set { m_bEnableComments = value; }
        }
        /// <summary>
        /// Enables processing of integers if set to true.
        /// </summary>
        public bool EnableIntegers
        {
            get { return m_bEnableIntegers; }
            set { m_bEnableIntegers = value; }
        }
        /// <summary>
        /// Enables processing of strings if set to true.
        /// </summary>
        public bool EnableStrings
        {
            get { return m_bEnableStrings; }
            set { m_bEnableStrings = value; }
        }
        /// <summary>
        /// Enables processing of registers if set to true.
        /// </summary>
        public bool EnableRegisters
        { get { return m_bEnableRegisters; } set { m_bEnableRegisters = value; } }
        /// <summary>
        /// Enables processing of Special Instructions if set to true.
        /// </summary>
        public bool EnableSpecialInstructions
        { get { return m_bEnableSpecialInstructions; } set { m_bEnableSpecialInstructions = value; } }
        /// <summary>
        /// The color of strings.
        /// </summary>
        public Color StringColor
        {
            get { return m_colorString; }
            set { m_colorString = value; }
        }
        /// <summary>
        /// The color of integers.
        /// </summary>
        public Color IntegerColor
        {
            get { return m_colorInteger; }
            set { m_colorInteger = value; }
        }
        /// <summary>
        /// The color of registers
        /// </summary>
        public Color RegistersColor
        { get { return m_colorRegisters; } set { m_colorRegisters = value; } }
        /// <summary>
        /// The color of Special Instructions
        /// </summary>
        public Color SpecialInstructionsColor
        { get { return m_colorSpecialInstructions; } set { m_colorSpecialInstructions = value; } }
        #endregion

        #region < Constructors >
        public SyntaxSettings() { }
        #endregion
    }
}
