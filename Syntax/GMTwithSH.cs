using FastColoredTextBoxNS;
using GMT_GUI_component;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Syntax
{
    public class GMTwithSH
    {

        //styles
        TextStyle BlueStyle = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
        TextStyle BoldStyle = new TextStyle(null, null, FontStyle.Bold);
        TextStyle GrayStyle = new TextStyle(Brushes.Gray, null, FontStyle.Regular); // free
        TextStyle MagentaStyle = new TextStyle(Brushes.Magenta, null, FontStyle.Regular);
        TextStyle GreenStyle = new TextStyle(Brushes.Green, null, FontStyle.Italic);
        TextStyle BrownStyle = new TextStyle(Brushes.Brown, null, FontStyle.Italic);
        TextStyle MaroonStyle = new TextStyle(Brushes.Maroon, null, FontStyle.Regular); // free
        TextStyle RedStyle = new TextStyle(Brushes.Red, null, FontStyle.Regular);
        TextStyle OrangeStyle = new TextStyle(Brushes.DarkOrange, null, FontStyle.Regular);
        TextStyle VioletStyle = new TextStyle(Brushes.DarkViolet, null, FontStyle.Regular);
        TextStyle OliveStyle = new TextStyle(Brushes.DarkOliveGreen, null, FontStyle.Regular);
        TextStyle IndigoStyle = new TextStyle(Brushes.Indigo, null, FontStyle.Italic | FontStyle.Bold);

        MarkerStyle SameWordsStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(40, Color.Gray))); // free

        public void SyntaxHighlight(GMT_FastColoredTextBox TextBox, TextChangedEventArgs e)
        {
            //brackets
            TextBox.LeftBracket = '(';
            TextBox.RightBracket = ')';
            TextBox.LeftBracket2 = '\x0';
            TextBox.RightBracket2 = '\x0';

            //clear style of changed range
            e.ChangedRange.ClearStyle(BlueStyle, BoldStyle, GrayStyle, MagentaStyle, GreenStyle, BrownStyle, MaroonStyle, RedStyle, OrangeStyle, VioletStyle, OliveStyle);

            //comment highlighting
            TextBox.CommentPrefix = "#";
            e.ChangedRange.SetStyle(GreenStyle, SyntaxSH.Comments, RegexOptions.Multiline);

            //string highlighting
            e.ChangedRange.SetStyle(BrownStyle, SyntaxGMT.GMTStrings);

            //class name highlighting
            e.ChangedRange.SetStyle(BoldStyle, SyntaxGMT.ClassNames);

            //othes gmt options highlight
            e.ChangedRange.SetStyle(OrangeStyle, SyntaxGMT.OtherOptions);

            //keyword highlighting
            e.ChangedRange.SetStyle(BlueStyle, SyntaxGMT.KeyWords);

            //number highlighting
            e.ChangedRange.SetStyle(MagentaStyle, SyntaxGMT.Numbers);

            //Math Operators and constants
            e.ChangedRange.SetStyle(OliveStyle, SyntaxGMT.MathOperators);
            e.ChangedRange.SetStyle(VioletStyle, SyntaxGMT.MathConstatnts);

            //Console bathc scripting (commands)
            e.ChangedRange.SetStyle(IndigoStyle, SyntaxSH.InternalCommands, RegexOptions.IgnoreCase);
            e.ChangedRange.SetStyle(IndigoStyle, SyntaxSH.ExternalCommands, RegexOptions.IgnoreCase);

            //Symbols
            e.ChangedRange.SetStyle(RedStyle, SyntaxSH.Symbols);

            //clear folding markers
            e.ChangedRange.ClearFoldingMarkers();

            //set folding markers
            e.ChangedRange.SetFoldingMarkers(SyntaxSH.FoldingMarkerLeft1, SyntaxSH.FoldingMarkerRight1);
            e.ChangedRange.SetFoldingMarkers(SyntaxSH.FoldingMarkerLeft2, SyntaxSH.FoldingMarkerRight2);
            e.ChangedRange.SetFoldingMarkers(SyntaxSH.FoldingMarkerLeft3, SyntaxSH.FoldingMarkerRight3);
        }
    }
}
