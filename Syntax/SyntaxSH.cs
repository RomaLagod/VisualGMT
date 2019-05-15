using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntax
{
    internal static class SyntaxSH
    {
        #region Comments

        //Comments
        public static string Comments = @"\#.*$";

        #endregion

        #region Keywords

        //KeyWords
        public static string InternalCommands = @"\b(ASSOC|BREAK|CALL|CD|CHDIR|CHCP|CLS|COLOR|COPY|DATE|DEL|ERASE|DIR|ECHO|ELSE|ENDLOCAL|EXIT|FOR|FTYPE|IF|MD|MKDIR|" +
                                                @"MOVE|PATH|PAUSE|POPD|PROMPT|PUSHD|RD|RMDIR|REN|RENAME|SET|SETLOCAL|SHIFT|START|TIME|TITLE|TYPE|VER|VERIFY|VOL|GOTO|" +
                                                @"EXIST|ELSE|IN|DO|NOT|MKLINK|)\b";

        public static string ExternalCommands = @"\b(ARP|AT|ATTRIB|BCDEDIT|CACLS|CHCP|CHKDSK|CHKNTFS|CHOISE|CIPHER|CLIP|CMD|COMP|COMPACT|CONVERT|DEBUG|DISKCOMP|DISKCOPY|" +
                                                @"DISKPART|DOSKEY|DRIVEQUERY|EXPAND|FC|FIND|FINDSTR|FORFILES|FORMAT|FSUTIL|GPRESULT|GRAFTABL|HELP|ICACLS|IPCONFIG|" +
                                                @"LABEL|MAKECAB|MODE|MORE|NET|OPENFILES|PING|RECOVER|REG|REPLACE|RUNDLL32|SC|SCHTASKS|SETX|SHUDOWN|SORT|SUBST|SYSTEMINFO|" +
                                                @"TASKKILL|TIMEOUT|TREE|WHERE|WMIC|XCOPY|HOSTNAME|TIMEOUT|FTP|FTYPE|GETMAC|NETSH|NETSTAT|NSLOOKUP|PATHPING|ROUTE|" +
                                                @"TELNET|TFTP|TRACERT|DEFRAG|MOUNTVOL|PERFMON|GPUPDATE|PERFMON)\b";

        #endregion

        #region Folding Markers

        //Folding Markers
        public static string FoldingMarkerLeft1 = @"\#{";
        public static string FoldingMarkerRight1 = @"\#}";
        public static string FoldingMarkerLeft2 = @"\#\(";
        public static string FoldingMarkerRight2 = @"\#\)";
        public static string FoldingMarkerLeft3 = @"\#<";
        public static string FoldingMarkerRight3 = @"\#>";

        #endregion

        #region SpecialSymbols

        public static string Symbols = @"[>\|\+\-\/\=\\\*\@\%\!\~\#\$\^\?\:\;\,\<\&\`]";

        #endregion
    }
}
