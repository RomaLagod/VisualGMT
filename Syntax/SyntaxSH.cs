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
        public static string Commands = @"\b(accept|access|aclocal|aconnect|acpi|acpi_available|acpid|addr2line|addresses|agetty|alias|alsactl|amidi|amixer|" +
                                        @"anacron|aplay|aplaymidi|apm|apmd|apropos|apt|aptitude|ar|arch|arecord|arecordmidi|srp|as|aspell|at|atd|atq|" +
                                        @"atrm|audiosend|aumix|autoconf|autoheader|automake|autoreconf|autoscan|autoupdate|awk|" +
                                        @"badbolcks|banner|basename|bash|batch|bc|bg|biff|bind|bison|break|builtin|bzcmp|bzdiff|bzgrep|bzip2|bzless|bzmore|" +
                                        @"cal|cardctl|cardmgr|case|cat|cc|cd|cdda2wav|cdparanoia|cdrdao|cdrecord|cfdisk|chage|chattr|chdir|chfn|chgrp|chkconfig|" +
                                        @"chmod|chown|chpasswd|chroot|chrt|chsh|chvt|cksum|clear|cmp|col|colcrt|colrm|column|comm|command|compress|continue|" +
                                        @"cp|cpio|cpp|cron|crond|crontab|csplit|ctags|cupsd|curl|cut|cvs|" +
                                        @"date|dc|dd|ddrescue|deallocvt|debugfs|declare|depmod|devdump|df|diff|diff3|dig|dir|dircolors|dirname|dirs|disable|" +
                                        @"dlpsh|dmesg|dnsdomainname|doexec|domainname|dosfsck|" +
                                        @"du|dump|dumpe2fs|dumpkeys|" +
                                        @"e2fsck|e2image|e2label|echo|ed|edquota|egrep|eject|elvtune|emacs|enable|env|envsubst|esd|esdcat|esdctl|" +
                                        @"esddsp|esdmon|esdplay|esdrec|esdsample|etags|ethtool|eval|ex|exec|exit|expand|expect|export|expr|" +
                                        @"factor|false|fdformat|fdisk|fetchmail|fg|fgconsole|fgrep|file|find|finger|fingerd|flex|fmt|fold|" +
                                        @"for|formail|format|free|fsck|ftp|ftpd|function|fuser|" +
                                        @"gawk|gcc|gdb|getent|getkeycodes|getopts|gpasswd|gpg|gpgsplit|gpgv|gpm|gprof|grep|groff|groffer|groupadd|groupdel|" +
                                        @"groupmod|groups|grpck|gs|gunzip|gzexe|gzip|" +
                                        @"halt|hash|hdparm|head|help|hexdump|history|host|hostid|hostname|htdigest|htop|hwclock|" +
                                        @"iconv|id|if|fi|ifconfig|ifdown|ifup|imapd|import|inetd|info|init|insmode|install|iostat|ip|ipcrm|ipcs|iptables|" +
                                        @"isodump|isoinfo|isosize|isovfy|ispell|" +
                                        @"jobs|join|" +
                                        @"kbd_mode|kbdrate|kill|killall|killall5|klogd|kudzu|" +
                                        @"last|lastb|lastlog|ld|ldconfig|ldd|less|lesskey|let|lftp|lftpget|link|ln|loadkeys|local|locale|locate|lockfile|logger|login|" +
                                        @"logname|logout|logrotate|look|losetup|lpadmin|lpc|lpinfo|lpmove|lpq|lpr|lprint|lprintd|lprintq|lprm|lpstat|ls|lsattr|lsblk|" +
                                        @"lsmod|lsof|lspci|lsusb|" +
                                        @"m4|mail|mailq|mailstats|mailto|make|makedbm|makemap|man|manpath|mattrib|mbadblocks|mcat|mcd|mcopy|md5sum|mdel|mdeltree|mdir|" +
                                        @"mdu|merge|mesg|metamail|metasend|mformat|mimencode|minfo|mkdir|mkdosfs|mke2fs|mkfifo|mkfs|mkisofs|mkmanifest|" +
                                        @"mknod|mkraid|mkswap|mktemp|mlabel|mmd|mmount|mmove|mmv|modinfo|modprobe|more|most|mount|mountd|mpartition|mpg123|mpg321|" +
                                        @"mrd|mren|mshowfat|mt|mtools|mtoolstest|mtr|mtype|mv|mzip|" +
                                        @"named|namei|nameif|nc|netstat|newaliases|newgrp|newusers|nfsd|nfsstat|nice|nl|nm|nohup|nslookup|nsupdate|" +
                                        @"objcopy|objdump|od|op|open|openvt|" +
                                        @"passwd|paste|patch|pathchk|perl|pgrep|pidof|ping|pinky|pkill|pmap|popd|portmap|poweroff|pppd|pr|praliases|printcap|" +
                                        @"printenv|printf|ps|ptx|pushd|pv|pwck|pwconv|pwd|python|" +
                                        @"quota|quotacheck|quotactl|quotaoff|quotaon|quotastats|" +
                                        @"raidstart|ran|ramsize|ranlin|rar|rarpd|rcp|rdate|rdev|rdist|rdistd|read|readarray|readcd|readelf|readlink|readonly|reboot|" +
                                        @"reject|remsync|rename|renice|repquota|reset|resize2fs|restore|return|rev|rexec|rexecd|richtext|rlogin|rlogind|rm|rmail|" +
                                        @"rmdir|rmmod|rndc|rootflags|route|routed|rpcgen|rpcinfo|rpm|rsh|rshd|rsync|runlevel|rup|ruptime|rusers|rusersd|rwall|" +
                                        @"rwho|rwhod|" +
                                        @"scanadf|scanimage|scp|screen|script|sdiff|sed|select|sendmail|sensors|seq|set|setfdprm|setkeycodes|" +
                                        @"setleds|setmetamode|setquota|setsid|setterm|sftp|sh|sha1sum|shift|shopt|showkey|showmount|shred|shutdown|size|skill|" +
                                        @"slabtop|slattach|sleep|slocate|snice|sort|source|split|ss|ssh|sshd|stat|" +
                                        @"statd|strace|strfile|strings|strip|stty|su|sudo|sum|suspend|swapoff|symlink|sync|sysctl|sysklogd|syslogd|" +
                                        @"tac|tail|tailf|talk|talkd|tar|taskset|tcpd|tcpdump|tcpslice|tee|telinit|telnet|telnetd|test|tftp|tftpd|time|timeout|" +
                                        @"times|tload|tmpwatch|top|touch|tput|tr|tracepath|traceroute|trap|troff|true|tset|tsort|tty|tune2fs|tunelp|type|" +
                                        @"ul|ulimit|umask|umount|unalias|uname|uncompress|unexpand|unicode_start|unicode_stop|uniq|units|unrar|unset|unshar|until|" +
                                        @"uptime|useradd|userdel|usermod|users|usleep|uudecode|uuencode|uuidgen|" +
                                        @"vdir|vi|vidmode|vim|vmstat|volname|" +
                                        @"wait|wall|warnquota|watch|wc|wget|whatis|which|while|who|whoami|whois|write|" +
                                        @"xargs|xinetd|xz|" +
                                        @"yacc|yes|ypbind|ypcat|ypinit|ypmatch|yppasswd|yppoll|yppush|ypserv|ypset|yptest|ypwhich|ypxfr|" +
                                        @"zcat|zcmp|zdiff|zdump|zforce|zgrep|zic|zless|zmore|znew)\b";

        public static string LongCommands = @"apt-get\b|dnssec-keygen\b|dnssec-makekeyset\b|dnssec-signkey\b|dnssec-signzone\b|" +
                                        @"esd-config\b|fc-cache\b|fc-list\b|g\+{2}|iptables-restore\b|iptables-save\b|mkfs.ext3\b|mklost\+{1}found|notify-send\b|sane-find-scanner\b|" +
                                        @"ssh-add\b|ssh-agent\b|ssh-keygen\b|ssh-keyscan\b|xdg-open\b";

        #endregion

        #region Variables

        public static string Variables = @"(\$+\w+?)\b";

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

        public static string Symbols = @"[>\|\+\-\/\=\\\*\@\%\!\~\^\?\:\;\,\<\&\`]";

        #endregion
    }
}
