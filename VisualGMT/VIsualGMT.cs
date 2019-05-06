using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMT_GUI_component;
using GMT_GUI_component.ComponentInterface;
using VisualGMT.FormInterface;
using FastColoredTextBoxNS;
using System.Text.RegularExpressions;

namespace VisualGMT
{
    public partial class VisualGMT : Form, IVisualGMT
    {
        #region GUI Component

        public Control interBtnHTNew { get; set; }
        public Control interBtnHTOpen { get; set; }
        public Control interBtnHTSave { get; set; }
        public Control interBtnHTPrint { get; set; }
        public Control interBtnHTCopy { get; set; }
        public Control interBtnHTCut { get; set; }
        public Control interBtnHTPaste { get; set; }
        public Control interBtnHTUndo { get; set; }
        public Control interBtnHTRedo { get; set; }
        public Control interBtnHTHighlightCurrentLine { get; set; }
        public Control interBtnHTInvisibleSymbols { get; set; }
        public Control interBtnHTCodeFolders { get; set; }
        public Control interBtnHTFolderLines { get; set; }
        public Control interBtnHTComment { get; set; }
        public Control interBtnHTUnComment { get; set; }
        public Control interBtnHTSetBookmark { get; set; }
        public Control interBtnHTGetBookmark { get; set; }
        public Control interBtnHTBookmarks { get; set; }
        public Control interBtnHTRun { get; set; }
        public Control interBtnHTConsole { get; set; }
        public Control interBtnHTPostScript { get; set; }
        public Control interBtnHTSettings { get; set; }
        public Control interBtnHTFind { get; set; }

        #endregion

        #region Properties

        //Current GMT FastColoredTextBox (Selected)
        //public GMT_FastColoredTextBox CurrentGMTTextBox => (gmt_FATabStripCollection.Items[gmt_FATabStripCollection .SelectedItem.TabIndex] as GMT_FATabStripItem).GmtTextBox;
        GMT_FastColoredTextBox CurrentGMTTextBox
        {
            get
            {
                if (gmt_FATabStripCollection.SelectedItem == null || gmt_FATabStripCollection.Items.Count <= 0)
                    return null;
                return (gmt_FATabStripCollection.SelectedItem.Controls[0] as GMT_FastColoredTextBox);
            }

            set
            {
                gmt_FATabStripCollection.SelectedItem = (value.Parent as GMT_FATabStripItem);
                value.Focus();
            }
        }

        //Find TextBox Changed
        bool tbFindChanged = false;

        //On Form Load
        public event EventHandler VisualGMTLoad;
        //On Ruler error
        public event EventHandler RulerError;
        //On CloseTab error
        public event EventHandler CloseTabError;

        #endregion

        #region Constructor

        // Form constructor by default
        public VisualGMT()
        {
            InitializeComponent();

            //relations GUI Components
            ControlInitialization();
        }

        #endregion

        #region VisualGMT EVENTS sendering

        // On form Visual GMT Load
        private void VisualGMT_Load(object sender, EventArgs e)
        {
            //var fastDocumentCollection = new GMT_FATabStripCollection();

            //Create new GMT Document when Form Load
            NewGMTDocument();

            //// Initializing ToolTips for main form
            //ToolTipsInitializing();

            //On VisualGMT form Load event
            if (VisualGMTLoad != null) VisualGMTLoad(this, e);
        }

        #endregion

        #region GmtTextBox Events

        // Event (When Key press in Gmt textBox)
        private void GmtDownPress(object sender, KeyEventArgs e)
        {
            if (Keys.Insert == e.KeyData)
            {
                if (CurrentGMTTextBox.InsertKeyMode == InsertKeyMode.Insert)
                {
                    CurrentGMTTextBox.InsertKeyMode = InsertKeyMode.Overwrite;
                }
                else
                {
                    CurrentGMTTextBox.InsertKeyMode = InsertKeyMode.Insert;
                }
            }

            TextInsertMode(ssDocumentInfo, 3, CurrentGMTTextBox.InsertKeyMode == InsertKeyMode.Insert ? "INS" : "OVR");
        }

        // Set value Scale in status strip
        private void GmtZoomChanged(object sender, EventArgs e)
        {
            (sender as GMT_FastColoredTextBox).ViewScale(ssDocumentInfo, 4);
        }

        // Set Cursor Position in status strip when Position change
        private void GmtCursorChanged(object sender, EventArgs e)
        {
            (sender as GMT_FastColoredTextBox).ViewCaretPosition(ssDocumentInfo, 2);
        }

        // Set text count information in status strip
        private void GmtTextBoxChanged(object sender, TextChangedEventArgs e)
        {
            (sender as GMT_FastColoredTextBox).ViewCountLinesColumns(ssDocumentInfo, 1);
        }

        //On selection tab changed
        private void gmt_FATabStripCollection_TabStripItemSelectionChanged(FarsiLibrary.Win.TabStripItemChangedEventArgs e)
        {
            if (CurrentGMTTextBox != null)
            {
                CurrentGMTTextBox.Focus();
                CurrentGMTTextBox.ViewScale(ssDocumentInfo, 4);
                CurrentGMTTextBox.ViewCaretPosition(ssDocumentInfo, 2);
                CurrentGMTTextBox.ViewCountLinesColumns(ssDocumentInfo, 1);
                TextInsertMode(ssDocumentInfo, 3, CurrentGMTTextBox.InsertKeyMode == InsertKeyMode.Insert ? "INS" : "OVR");
                RulerCheckState();
                //string text = CurrentTB.Text;
                //ThreadPool.QueueUserWorkItem((o) => ReBuildObjectExplorer(text));
            }
        }

        #endregion

        #region Methods

        //Create new GMT Document
        private void NewGMTDocument()
        {
            //Create new GMT document and add new tab
            var tab = new GMT_FATabStripItem(null);
            gmt_FATabStripCollection.AddTab(tab);
            gmt_FATabStripCollection.SelectedItem = tab;

            //// Event in GMTTextBox
            tab.GmtTextBox.TextChanged += GmtTextBoxChanged;
            tab.GmtTextBox.SelectionChanged += GmtCursorChanged;
            tab.GmtTextBox.ZoomChanged += GmtZoomChanged;
            tab.GmtTextBox.KeyDown += GmtDownPress;
        }

        //Component initialization for Presetner
        private void ControlInitialization()
        {
            interBtnHTNew = btnHTNew;
            interBtnHTOpen = btnHTOpen;
            interBtnHTSave = btnHTSave;
            interBtnHTPrint = btnHTPrint;
            interBtnHTCopy = btnHTCopy;
            interBtnHTCut = btnHTCut;
            interBtnHTPaste = btnHTPaste;
            interBtnHTUndo = btnHTUndo;
            interBtnHTRedo = btnHTRedo;
            interBtnHTHighlightCurrentLine = btnHTHighlightCurrentLine;
            interBtnHTInvisibleSymbols = btnHTInvisibleSymbols;
            interBtnHTCodeFolders = btnHTCodeFolders;
            interBtnHTFolderLines = btnHTFolderLines;
            interBtnHTComment = btnHTComment;
            interBtnHTUnComment = btnHTUnComment;
            interBtnHTSetBookmark = btnHTSetBookmark;
            interBtnHTGetBookmark = btnHTGetBookmark;
            interBtnHTBookmarks = btnHTBookmarks;
            interBtnHTRun = btnHTRun;
            interBtnHTConsole = btnHTConsole;
            interBtnHTPostScript = btnHTPostScript;
            interBtnHTSettings = btnHTSettings;
            interBtnHTFind = btnHTFind;
        }

        // Ruler mainMenu CheckState
        void RulerCheckState()
        {
            if ((CurrentGMTTextBox.Parent as GMT_FATabStripItem).IsRulerVisible)
            {
                rulerToolStripMenuItem.CheckState = CheckState.Checked;
            }
            else
            {
                rulerToolStripMenuItem.CheckState = CheckState.Unchecked;
            }
        }

        #endregion

        #region Status Stip

        private void tsmiScale200_Click(object sender, EventArgs e)
        {
            CurrentGMTTextBox.Zoom = 200;
        }

        private void tsmiScale150_Click(object sender, EventArgs e)
        {
            CurrentGMTTextBox.Zoom = 150;
        }

        private void tsmiScale100_Click(object sender, EventArgs e)
        {
            CurrentGMTTextBox.Zoom = 100;
        }

        private void tsmiScale70_Click(object sender, EventArgs e)
        {
            CurrentGMTTextBox.Zoom = 70;
        }

        private void tsmiScale50_Click(object sender, EventArgs e)
        {
            CurrentGMTTextBox.Zoom = 50;
        }

        private void tsmiScale20_Click(object sender, EventArgs e)
        {
            CurrentGMTTextBox.Zoom = 20;
        }

        private void tssbScaleDefault_DoubleClick(object sender, EventArgs e)
        {
            CurrentGMTTextBox.Zoom = 100;
        }

        // Set insert mode
        private void TextInsertMode(StatusStrip statusStrip, int col, string insertKeyMode)
        {
            statusStrip.Items[col].Text = $"{insertKeyMode}";
        }

        #endregion

        #region ToolBar

        // New Document Click
        private void btnHTNew_Click(object sender, EventArgs e)
        {
            NewGMTDocument();
        }

        // Copy selected Text to clipboard
        private void btnHTCopy_Click(object sender, EventArgs e)
        {
            CurrentGMTTextBox?.Copy();
        }

        // Cut selected Text to clipboard
        private void btnHTCut_Click(object sender, EventArgs e)
        {
            CurrentGMTTextBox?.Cut();
        }

        // Paste Text from clipboard
        private void btnHTPaste_Click(object sender, EventArgs e)
        {
            CurrentGMTTextBox?.Paste();
        }

        // UNDO operation
        private void btnHTUndo_Click(object sender, EventArgs e)
        {
            CurrentGMTTextBox?.Undo();
        }

        // REDO operation
        private void btnHTRedo_Click(object sender, EventArgs e)
        {
            CurrentGMTTextBox?.Redo();
        }

        #endregion

        #region MainMenu

        // Edit -> Delete selected text
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentGMTTextBox != null)
            {
                CurrentGMTTextBox.SelectedText = "";
            }
        }

        // Edit -> Select All text
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentGMTTextBox?.SelectAll();
        }

        // File -> Close program
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        // File -> Close Tab
        private void closeTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                gmt_FATabStripCollection.RemoveTab((CurrentGMTTextBox.Parent as GMT_FATabStripItem));
            }
            catch (Exception exception)
            {
                CloseTabError(exception, e);
            }
        }

        // View -> Ruler
        private void rulerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(CurrentGMTTextBox.Parent as GMT_FATabStripItem).IsRulerVisible)
                {
                    (CurrentGMTTextBox.Parent as GMT_FATabStripItem).GmtRuler.Visible = true;
                    (CurrentGMTTextBox.Parent as GMT_FATabStripItem).IsRulerVisible = true;
                }
                else
                {
                    (CurrentGMTTextBox.Parent as GMT_FATabStripItem).GmtRuler.Visible = false;
                    (CurrentGMTTextBox.Parent as GMT_FATabStripItem).IsRulerVisible = false;
                }
            }
            catch (Exception exception)
            {
                RulerError(exception, e);
            }
        }

        // Edit -> Find
        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentGMTTextBox?.ShowFindDialog();
        }

        // Edit -> Find and Replace
        private void findAndReplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentGMTTextBox?.ShowReplaceDialog();
        }

        // Find from textBox
        private void tbHTFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' && CurrentGMTTextBox != null)
            {
                //(sender as TextBox).Text = (sender as TextBox).Text.Remove((sender as TextBox).Text.Length);
                Range r = tbFindChanged ? CurrentGMTTextBox.Range.Clone() : CurrentGMTTextBox.Selection.Clone();
                tbFindChanged = false;
                r.End = new Place(CurrentGMTTextBox[CurrentGMTTextBox.LinesCount - 1].Count, CurrentGMTTextBox.LinesCount - 1);
                var pattern = Regex.Escape((sender as TextBox).Text);
                foreach (var found in r.GetRanges(pattern))
                {
                    found.Inverse();
                    CurrentGMTTextBox.Selection = found;
                    CurrentGMTTextBox.DoSelectionVisible();
                    return;
                }
                MessageBox.Show("Not found.");
            }
            else
                tbFindChanged = true;
        }

        // Clear last enter in find TextBox
        private void tbHTFind_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && CurrentGMTTextBox != null)
            {
                (sender as TextBox).Text = (sender as TextBox).Text.Remove((sender as TextBox).Text.Length - 1);
            }
        }

        #endregion


    }
}
