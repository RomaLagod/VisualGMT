using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntax
{
    internal static class SyntaxGMT
    {
        #region Brackets
        //Brackets EMPTY
        #endregion

        #region Strings
        //Strings
        #endregion

        #region Comments
        //Comments EMPTY
        #endregion

        #region Numbers
        //Numbers
        #endregion

        #region Attributes
        //Attribute EMPTY
        #endregion

        #region ClassNames

        //Class name
        public static string ClassNames = @"\b(gmt)\b";

        #endregion

        #region GMT other options

        public static string OtherOptions = @"\b(clear|--help|--show-cores|--show-bindir|--show-datadir|--show-modules|--show-plugindir|--show-sharedir|--version)\b";

        #endregion

        #region Keywords

        //KeyWords
        public static string KeyWords = @"\b(blockmean|blockmedian|blockmode|filter1d|fitcircle|gmt2kml|gmt5syntax|gmtcolors|colors|connect|convert|defaults|get|"+
                                        @"info|logo|math)\b";

        #endregion

        #region Math 
        //page80 in manpages GMT
        public static string MathOperators = @"\b(ABS|ACOS|ACOSH|ACSC|ACOT|ADD|AND|ASEC|ASIN|ASINH|ATAN|ATAN2|ATANH|BCDF|BPDF|BEI|BER|BITAND|BITLEFT|BITNOT|BITOR|"+
                                             @"BITRIGHT|BITTEST|BITXOR|CEIL|CHICRIT|CHICDF|CHIPDF|COL|COMB|CORRCOEFF|COS|COSD|COSH|COT|COTD|CSC|CSCD|DDT|D2DT2|"+
                                             @"D2R|DENAN|DILOG|DIFF|DIV|DUP|ECDF|ECRIT|EPDF|ERF|ERFC|ERFINV|EQ|EXCH|EXP|FACT|FCDF|FCRIT|FLIPUD|FLOOR|FMOD|FPDF|"+
                                             @"GE|GT|HYPOT|I0|I1|IFELSE|IN|INRANGE|INT|INV|ISFINITE|ISNAN|J0|J1|JN|K0|K1|KN|KEI|KER|KURT|LCDF|LCRIT|LE|LMSSCL|"+
                                             @"LMSSCLW|LOG|LOG10|LOG1P|LOG2|LOWER|LPDF|LRAND|LSQFIT|LT|MAD|MADW|MAX|MEAN|MEANW|MEDIAN|MEDIANW|MIN|MOD|MODE|MODEW|"+
                                             @"MUL|NAN|NEG|NEQ|NORM|NOT|NRAND|OR|PCDF|PERM|PPDF|PLM|PLMg|POP|POW|PQUANT|PQUANTW|PSI|PV|QV|R2|R2D|RAND|RCDF|RCRIT|"+
                                             @"RINT|RMS|RMSW|RPDF|ROLL|ROTT|SEC|SECD|SIGN|SIN|SINC|SIND|SINH|SKEW|SQR|SQRT|STD|STDW|STEP|STEPT|SUB|SUM|TAN|TAND|"+
                                             @"TANH|TAPER|TN|TCRIT|TPDF|TCDF|UPPER|VAR|VARW|WCDF|WCRIT|WPDF|XOR|Y0|Y1|YN|ZCDF|ZPDF|ZCRIT|ROOTS|)\b";
        //Constants
        public static string MathConstatnts = @"\b(PI|E|EULER|EPS_F|EPS_D|TMIN|TMAX|TRANGE|TINC|N|T|TNORM|TROW)\b";
        #endregion

        #region Arguments
        //Arguments
        #endregion

        #region Folding Markers
        //Folding Markers
        #endregion
    }
}
