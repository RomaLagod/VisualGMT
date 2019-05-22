using FastColoredTextBoxNS;
using GMT_GUI_component.ComponentInterface;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GMT_GUI_component
{
    // form component - FastColoredTextBox with settings for GMT
    public class GMT_FastColoredTextBox : FastColoredTextBox, IGMT_FastColoredTextBox
    {
        // the same word selection style
        public static Style SameWordsStyle { get; set; }

        // Styles
        public Style InvisibleCharsStyle { get; } = new InvisibleCharsRenderer(Pens.Gray);
        public Color CurrentLineColor { get; } = Color.FromArgb(100, 210, 210, 255);

        private Color _changedLineColor = Color.FromArgb(255, 230, 230, 255);

        // Insert Key MODE (Keyboard KeyMode (INS, OVR))
        public InsertKeyMode InsertKeyMode = InsertKeyMode.Insert;

        //Custom languages
        public enum CustomLanguages { GMTwithBAT, GMTwithSH}
        public CustomLanguages lang { get; set; } = CustomLanguages.GMTwithBAT;

        // static constructor
        static GMT_FastColoredTextBox()
        {
            //SameWordsStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(50, SystemColors.Control)));
            SameWordsStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(40, Color.Gray)));
        }

        // default constructor
        public GMT_FastColoredTextBox() : base()
        {
            this.Font = new Font("Consolas", 9.75f);
            //this.ContextMenuStrip = cmMain;

            this.Dock = DockStyle.Fill;
            this.BorderStyle = BorderStyle.None;
            this.BookmarkColor = Color.DodgerBlue;
            //tb.VirtualSpace = true;
            this.LeftPadding = 50;//17 ;

            this.Language = Language.Custom;

            this.AddStyle(SameWordsStyle);//same words style

            //this.Tag = new TbInfo();
            this.Focus();
            //this.DelayedTextChangedInterval = 1000;
            //this.DelayedEventsInterval = 500;

            // Events -----------
            //this.TextChangedDelayed += new EventHandler<TextChangedEventArgs>(tb_TextChangedDelayed);
            //this.SelectionChangedDelayed += new EventHandler(tb_SelectionChangedDelayed);
            //this.KeyDown += new KeyEventHandler(tb_KeyDown);
            //tb.MouseMove += new MouseEventHandler(tb_MouseMove);

            this.ChangedLineColor = _changedLineColor;
            //if (btHighlightCurrentLine.Checked)
            //    this.CurrentLineColor = _currentLineColor;
            //this.ShowFoldingLines = btShowFoldingLines.Checked;            
            this.HighlightingRangeType = HighlightingRangeType.VisibleRange;

            //create autocomplete popup menu
            //AutocompleteMenu popupMenu = new AutocompleteMenu(tb);
            //popupMenu.Items.ImageList = ilAutocomplete;
            //popupMenu.Opening += new EventHandler<CancelEventArgs>(popupMenu_Opening);
            //BuildAutocompleteMenu(popupMenu);
            //(tb.Tag as TbInfo).popupMenu = popupMenu;
            //
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // GMT_FastColoredTextBox
            // 
            this.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Name = "GMT_FastColoredTextBox";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
        }


        #region Work with Status Strip

        //Display number of lines and number chars in status strip
        public void ViewCountLinesColumns(StatusStrip statusStrip, int col)
        {
            statusStrip.Items[col].Text = $"length : {this.TextLength}  lines : {this.LinesCount}";
        }

        //Display caret position in status strip
        public void ViewCaretPosition(StatusStrip statusStrip, int col)
        {
            var selectionCountChars = this.Selection.Length;
            var selectionCountLines = Math.Abs(this.Selection.End.iLine - this.Selection.Start.iLine);

            statusStrip.Items[col].Text = $"Ln : {this.Selection.Start.iLine}  Col : {this.Selection.Start.iChar} " +
                $" Sel : {selectionCountChars}|" +
                $"{(selectionCountChars > 0 ? (selectionCountLines + 1) : selectionCountLines)}";
        }

        //Display current scale
        public void ViewScale(StatusStrip statusStrip, int col)
        {
            statusStrip.Items[col].Text = $"{this.Zoom}%";
        }

        #endregion
    }
}
