using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntax
{
    internal static class SyntaxBAT
    {
        #region Brackets

        //Brackets
        public static char LeftBracket = '(';
        public static char RightBracket = ')';
        public static char LeftBracket2 = '\x0';
        public static char RightBracket2 = '\x0';

        #endregion

        #region Strings
        //Strings
        #endregion

        #region Comments

        //Comments
        public static string Comments = @"REM.*$";

        #endregion

        #region Numbers
        //Numbers
        #endregion

        #region Attributes
        //Attribute
        #endregion

        #region ClassNames
        //Class name
        #endregion

        #region Keywords
        //KeyWords
        #endregion

        #region Arguments
        //Arguments
        #endregion

        #region Folding Markers

        //Folding Markers
        public static string FoldingMarkerLeft1 = @"REM{";
        public static string FoldingMarkerRight1 = @"REM}";
        public static string FoldingMarkerLeft2 = @"REM\(";
        public static string FoldingMarkerRight2 = @"REM\)";
        public static string FoldingMarkerLeft3 = @"REM<";
        public static string FoldingMarkerRight3 = @"REM>";

        #endregion

        #region SpecialSymbols

        public static string Symbols = @">|>>|\||\+|\-|\/";

        #endregion
    }
}
