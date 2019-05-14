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
        public static string GMTStrings = @"""""|@""""|''|@"".*?""|(?<!@)(?<range>"".*?[^\\]"")|'.*?[^\\]'";

        #endregion

        #region Comments
        //Comments EMPTY
        #endregion

        #region Numbers

        //Numbers -- don't correct
        public static string Numbers = @"\b*\d+[\.]?\d*([eE]\-?\d+)?[a-zA-Z]?\b|\b0x[a-fA-F\d]+\b";

        #endregion

        #region Attributes
        //Attribute EMPTY
        #endregion

        #region ClassNames

        //Class name
        public static string ClassNames = @"\b(gmt)\b";

        #endregion

        #region GMT other options

        public static string OtherOptions = @"\b(clear)\b|--help\b|--show-cores\b|--show-bindir\b|--show-datadir\b|--show-modules\b|--show-plugindir\b|--show-sharedir\b|--version\b";

        #endregion

        #region Keywords

        //KeyWords
        public static string KeyWords = @"\b(blockmean|blockmedian|blockmode|filter1d|fitcircle|gmt2kml|gmt5syntax|gmtcolors|colors|connect|gmtconnect|"+
                                        @"convert|gmtconvert|defaults|gmtdefaults|get|gmtget|info|gmtinfo|logo|gmtlogo|math|gmtmath|regress|gmtregress|"+
                                        @"select|gmtselect|set|gmtset|simplify|gmtsimplify|spatial|gmtspatial|switch|gmtswitch|vector|gmtvector|which|"+
                                        @"gmtwhich|grd2cpt|grd2rgb|grd2xyz|grdblend|grdclip|grdcontour|grdconvert|grdcut|grdedit|grdfft|grdfilter|"+
                                        @"grdgradient|grdhisteq|grdimage|grdinfo|grdlandmask|grdmask|grdmath|grdpaste|grdproject|grdraster|grdsample|"+
                                        @"grdtrack|grdtrend|grdvector|grdview|grdvolume|greenspline|isogmt|kml2gmt|makecpt|mapproject|nearneighbor|"+
                                        @"project|psbasemap|psclip|pscoast|pscontour|psconvert|pshistogram|psimage|pslegend|postscriptlight|psmask|"+
                                        @"psrose|psscale|psternary|pstext|pswiggle|psxy|psxyz|sample1d|spectrum1d|sph2grd|sphdistance|sphinterpolate|"+
                                        @"sphtriangulate|splitxyz|surface|trend1d|trend2d|triangulate|xyz2grd|gshhg|img2grd|pscoupe|psmeca|pspolar|"+
                                        @"psvelo|pssac|mgd77convert|mgd77header|mgd77info|mgd77list|mgd77magref|mgd77manage|mgd77path|mgd77sniffer|"+
                                        @"mgd77track|dimfilter|gmtflexure|gmtgravmag3d|gpsgridder|gravfft|grdflexure|grdgravmag3d|grdredpol|grdseamount|"+
                                        @"talwani2d|talwani3d|pssegy|pssegyz|segy2grd|backtracker|grdpmodeler|grdrotater|grdspotter|hotspotter|originator|"+
                                        @"rotconverter|rotsmoother|x2sys_binlist|x2sys_cross|x2sys_datalist|x2sys_get|x2sys_init|x2sys_list|x2sys_merge|"+
                                        @"x2sys_put|x2sys_report|x2sys_solve)\b";

        #endregion

        #region Math 

        //page80 in manpages GMT
        public static string MathOperators = @"\b(ABS|ACOS|ACOSH|ACSC|ACOT|ADD|AND|ARC|AREA|ASEC|ASIN|ASINH|ATAN|ATAN2|ATANH|BCDF|BPDF|BEI|BER|BITAND|BITLEFT|BITNOT|BITOR|"+
                                             @"BITRIGHT|BITTEST|BITXOR|CAZ|CBAZ|CDIST|CDIST2|CEIL|CHICRIT|CHICDF|CHIPDF|COL|COMB|CORRCOEFF|COS|COSD|COSH|COT|COTD|CSC|CSCD|CURV|DDT|D2DT2|"+
                                             @"D2DX2|D2DY2|D2DXY|D2R|DDX|DDY|DEG2KM|DENAN|DILOG|DIFF|DIV|DUP|ECDF|ECRIT|EPDF|ERF|ERFC|ERFINV|EQ|EXCH|EXP|EXTREMA|FACT|FCDF|FCRIT|FLIPUD|FLOOR|FMOD|FPDF|"+
                                             @"GE|GT|HYPOT|I0|I1|IFELSE|IN|INRANGE|INSIDE|INT|INV|ISFINITE|ISNAN|J0|J1|JN|K0|K1|KN|KEI|KER|KURT|LCDF|LCRIT|LE|LMSSCL|"+
                                             @"LMSSCLW|LOG|LOG10|LOG1P|LOG2|LOWER|LPDF|LRAND|LSQFIT|LT|MAD|MADW|MAX|MEAN|MEANW|MEDIAN|MEDIANW|MIN|MOD|MODE|MODEW|"+
                                             @"MUL|NAN|NEG|NEQ|NORM|NOT|NRAND|OR|PCDF|PERM|PPDF|PLM|PLMg|POP|POINT|POW|PQUANT|PQUANTW|PSI|PV|QV|R2|R2D|RAND|RCDF|RCRIT|"+
                                             @"RINT|RMS|RMSW|RPDF|ROLL|ROTT|ROTX|ROTY|SAZ|SBAZ|SEC|SECD|SIGN|SIN|SINC|SIND|SINH|SKEW|SQR|SQRT|STD|STDW|STEP|STEPT|STEPX|STEPY|SUB|SUM|TAN|TAND|"+
                                             @"TANH|TAPER|TN|TRIM|TCRIT|TPDF|TCDF|UPPER|VAR|VARW|WCDF|WCRIT|WPDF|WRAP|XOR|Y0|Y1|YN|YLM|YLMg|ZCDF|ZPDF|ZCRIT|ROOTS|)\b";
        //Constants
        public static string MathConstatnts = @"\b(PI|E|EULER|EPS_F|EPS_D|TMIN|TMAX|XMIN|XMAX|XRANGE|TRANGE|TINC|XINC|NX|YMIN|YMAX|YRANGE|YINC|X|Y|XNORM|YNORM|XCOL|YROW|NODE|N|T|TNORM|TROW)\b";

        #endregion

        #region Arguments
        //Arguments
        #endregion

        #region Folding Markers
        //Folding Markers
        #endregion
    }
}
