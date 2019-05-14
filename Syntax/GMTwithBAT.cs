using FastColoredTextBoxNS;
using GMT_GUI_component;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Syntax
{
    public class GMTwithBAT
    {

        //styles
        TextStyle BlueStyle = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
        TextStyle BoldStyle = new TextStyle(null, null, FontStyle.Bold);
        TextStyle GrayStyle = new TextStyle(Brushes.Gray, null, FontStyle.Regular);
        TextStyle MagentaStyle = new TextStyle(Brushes.Magenta, null, FontStyle.Regular);
        TextStyle GreenStyle = new TextStyle(Brushes.Green, null, FontStyle.Italic);
        TextStyle BrownStyle = new TextStyle(Brushes.Brown, null, FontStyle.Italic);
        TextStyle MaroonStyle = new TextStyle(Brushes.Maroon, null, FontStyle.Regular);
        TextStyle RedStyle = new TextStyle(Brushes.Red, null, FontStyle.Regular);
        TextStyle OrangeStyle = new TextStyle(Brushes.DarkOrange, null, FontStyle.Regular);
        TextStyle VioletStyle = new TextStyle(Brushes.DarkViolet, null, FontStyle.Regular);



        MarkerStyle SameWordsStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(40, Color.Gray)));

        public void SyntaxHighlight(GMT_FastColoredTextBox TextBox, TextChangedEventArgs e)
        {
            //brackets
            TextBox.LeftBracket = '(';
            TextBox.RightBracket = ')';
            TextBox.LeftBracket2 = '\x0';
            TextBox.RightBracket2 = '\x0';

            //clear style of changed range
            e.ChangedRange.ClearStyle(BlueStyle, BoldStyle, GrayStyle, MagentaStyle, GreenStyle, BrownStyle, MaroonStyle, RedStyle, OrangeStyle, VioletStyle);

            //string highlighting
            //e.ChangedRange.SetStyle(BrownStyle, @"""""|@""""|''|@"".*?""|(?<!@)(?<range>"".*?[^\\]"")|'.*?[^\\]'");

            //comment highlighting
            //e.ChangedRange.SetStyle(GreenStyle, @"//.*$", RegexOptions.Multiline);
            //e.ChangedRange.SetStyle(GreenStyle, @"(/\*.*?\*/)|(/\*.*)", RegexOptions.Singleline);
            //e.ChangedRange.SetStyle(GreenStyle, @"(/\*.*?\*/)|(.*\*/)", RegexOptions.Singleline | RegexOptions.RightToLeft);

            //number highlighting
            //e.ChangedRange.SetStyle(MagentaStyle, @"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b");

            //attribute highlighting
            //e.ChangedRange.SetStyle(GrayStyle, @"^\s*(?<range>\[.+?\])\s*$", RegexOptions.Multiline);

            //class name highlighting
            e.ChangedRange.SetStyle(BoldStyle, SyntaxGMT.ClassNames);

            //othes gmt options highlight
            e.ChangedRange.SetStyle(OrangeStyle, SyntaxGMT.OtherOptions);

            //keyword highlighting
            e.ChangedRange.SetStyle(BlueStyle, SyntaxGMT.KeyWords);

            //Math Operators and constants
            e.ChangedRange.SetStyle(MaroonStyle, SyntaxGMT.MathOperators);
            e.ChangedRange.SetStyle(VioletStyle, SyntaxGMT.MathConstatnts);

            //Arguments

            //clear folding markers
            e.ChangedRange.ClearFoldingMarkers();

            //set folding markers
            //e.ChangedRange.SetFoldingMarkers("{", "}");//allow to collapse brackets block
            //e.ChangedRange.SetFoldingMarkers(@"#region\b", @"#endregion\b");//allow to collapse #region blocks
            //e.ChangedRange.SetFoldingMarkers(@"/\*", @"\*/");//allow to collapse comment block
        }
    }
}
