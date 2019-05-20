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
using System.IO;
using Syntax;
using System.Diagnostics;

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

        // Current GMT FastColoredTextBox (Selected)
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

        // Find TextBox Changed
        bool tbFindChanged = false;

        // Path to File
        public string FilePath { get; set; }

        // Content of File
        public string Content
        {
            get { return CurrentGMTTextBox.Text; }
            set
            {
                //CurrentGMTTextBox.Text = value;
                NewGMTDocument(FilePath, value);
            }
        }

        //SyntaxHighLight
        private GMTwithBAT _GMTwithBAT = new GMTwithBAT();
        private GMTwithSH _GMTwithSH = new GMTwithSH();

        // On Form Load
        public event EventHandler VisualGMTLoad;
        // On Ruler error
        public event EventHandler RulerError;
        // On CloseTab error
        public event EventHandler CloseTabError;
        // On DocumentMap Error
        public event EventHandler DocumentMapError;
        // On Embedded Console Error
        public event EventHandler EmbeddedConsoleError;
        // On OpenFile
        public event EventHandler FileOpenClick;
        // On SaveFile
        public event EventHandler FileSaveClick;
        // On ContentChanged
        public event EventHandler ContentChanged;

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
            NewGMTDocument(null);

            //// Initializing ToolTips for main form
            //ToolTipsInitializing();

            //On VisualGMT form Load event
            if (VisualGMTLoad != null) VisualGMTLoad(this, e);
        }

        // When Main Form closing ask about Save Open Documents
        private void VisualGMT_FormClosing(object sender, FormClosingEventArgs e)
        {
            List<GMT_FATabStripItem> list = new List<GMT_FATabStripItem>();
            foreach (GMT_FATabStripItem tab in gmt_FATabStripCollection.Items)
                list.Add(tab);
            foreach (var tab in list)
            {
                FarsiLibrary.Win.TabStripItemClosingEventArgs args = new FarsiLibrary.Win.TabStripItemClosingEventArgs(tab);
                gmt_FATabStripCollection_TabStripItemClosing(args);
                if (args.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
                gmt_FATabStripCollection.RemoveTab(tab);
            }
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

            // View document status in Status Strip
            DocumentStatus((sender as GMT_FastColoredTextBox));
        }

        // Set text count information in status strip
        private void GmtTextBoxChanged(object sender, TextChangedEventArgs e)
        {
            // Status Strip
            (sender as GMT_FastColoredTextBox).ViewCountLinesColumns(ssDocumentInfo, 1);

            // SyntaxHighLight
            if ((sender as GMT_FastColoredTextBox).lang == GMT_FastColoredTextBox.CustomLanguages.GMTwithBAT)
            {
                _GMTwithBAT.SyntaxHighlight((sender as GMT_FastColoredTextBox), e);
            }
            else
            {
                _GMTwithSH.SyntaxHighlight((sender as GMT_FastColoredTextBox), e);
            }
        }

        // On selection tab changed
        private void gmt_FATabStripCollection_TabStripItemSelectionChanged(FarsiLibrary.Win.TabStripItemChangedEventArgs e)
        {
            if (CurrentGMTTextBox != null)
            {
                CurrentGMTTextBox.Focus();
                CurrentGMTTextBox.ViewScale(ssDocumentInfo, 4);
                CurrentGMTTextBox.ViewCaretPosition(ssDocumentInfo, 2);
                CurrentGMTTextBox.ViewCountLinesColumns(ssDocumentInfo, 1);
                TextInsertMode(ssDocumentInfo, 3, CurrentGMTTextBox.InsertKeyMode == InsertKeyMode.Insert ? "INS" : "OVR");
                ShowGmtRuler();
                ShowGmtDocumentMap();
                InvalidateCurrentLine();
                InvalidatePreferredLine();
                ShowFolderLines();
                DocumentStatus(CurrentGMTTextBox);
                ShowGmtEmbeddedConsole();
                //string text = CurrentTB.Text;
                //ThreadPool.QueueUserWorkItem((o) => ReBuildObjectExplorer(text));
            }
        }

        // On Text Changed Delayed in GMT TextBox
        private void TextChangedDelayed(object sender, TextChangedEventArgs e)
        {
            // Show invisible chars
            HighlightInvisibleChars(e.ChangedRange);
        }

        #endregion

        #region TabStripCollection Events

        // When closing all tabs from tab collection
        private void gmt_FATabStripCollection_TabStripItemClosing(FarsiLibrary.Win.TabStripItemClosingEventArgs e)
        {
            if ((e.Item.Controls[0] as GMT_FastColoredTextBox).IsChanged)
            {
                switch (MessageBox.Show("Do you want save " + e.Item.Title + " ?", "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information))
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        if (!Save(e.Item as GMT_FATabStripItem))
                            e.Cancel = true;
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

        #endregion

        #region Methods

        // Create new GMT Document
        private void NewGMTDocument(string fileName, string content = null)
        {
            try
            {
                // Create new GMT document and add new tab
                var tab = new GMT_FATabStripItem(fileName, content);
                gmt_FATabStripCollection.AddTab(tab);
                gmt_FATabStripCollection.SelectedItem = tab;

                //// Event in GMTTextBox
                tab.GmtTextBox.TextChanged += GmtTextBoxChanged;
                tab.GmtTextBox.SelectionChanged += GmtCursorChanged;
                tab.GmtTextBox.ZoomChanged += GmtZoomChanged;
                tab.GmtTextBox.KeyDown += GmtDownPress;
                tab.GmtTextBox.TextChangedDelayed += TextChangedDelayed;

                //// Event in EmbeddedConsole
                tab.GmtPanel.StopConsole.Click += GmtStopEmbeddedConsole;
                tab.GmtPanel.HideConsole.Click += GmtHideEmbeddedConsole;
                tab.GmtPanel.SaveConsole.Click += GmtSaveEmbeddedConsole;


                // default syntax highlight
                DefaultGMTTextBoxLanguageSettings(fileName);
            }
            catch (Exception ex)
            {
                if (MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.Retry)
                    NewGMTDocument(fileName, content);
            }
        }

        // Component initialization for Presetner
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
            interBtnHTGetBookmark = btnHTDeleteBookmark;
            interBtnHTBookmarks = btnHTBookmarks;
            interBtnHTRun = btnHTRun;
            interBtnHTConsole = btnHTConsole;
            interBtnHTPostScript = btnHTPostScript;
            interBtnHTSettings = btnHTSettings;
            interBtnHTFind = btnHTFind;
        }

        // Show/Hide Ruler for GMT TextBox
        private void ShowGmtRuler()
        {
            try
            {
                foreach (GMT_FATabStripItem tab in gmt_FATabStripCollection.Items)
                {
                    if (rulerToolStripMenuItem.Checked)
                    {
                        tab.GmtRuler.Visible = true;
                    }
                    else
                    {
                        tab.GmtRuler.Visible = false;
                    }
                }
            }
            catch (Exception exception)
            {
                RulerError(exception, EventArgs.Empty);
            }
        }

        // Show/Hide DocumentMap for Gmt TextBox
        private void ShowGmtDocumentMap()
        {
            try
            {
                foreach (GMT_FATabStripItem tab in gmt_FATabStripCollection.Items)
                {
                    if (documentMapToolStripMenuItem.Checked)
                    {
                        tab.GmtSplitter.Visible = true;
                        tab.GmtDocumentMap.Visible = true;
                    }
                    else
                    {
                        tab.GmtSplitter.Visible = false;
                        tab.GmtDocumentMap.Visible = false;
                    }
                }
            }
            catch (Exception exception)
            {
                DocumentMapError(exception, EventArgs.Empty);
            }
        }

        // Show/Hide Embeded Console for Gmt TextBox
        private void ShowGmtEmbeddedConsole()
        {
            try
            {
                foreach (GMT_FATabStripItem tab in gmt_FATabStripCollection.Items)
                {
                    if (btnHTConsole.Checked)
                    {
                        tab.GmtSplitterConsole.Visible = true;
                        tab.GmtPanel.Visible = true;
                    }
                    else
                    {
                        tab.GmtSplitterConsole.Visible = false;
                        tab.GmtPanel.Visible = false;
                    }
                }
                openEmbededConsoleToolStripMenuItem.CheckState = btnHTConsole.CheckState;
            }
            catch (Exception exception)
            {
                EmbeddedConsoleError(exception, EventArgs.Empty);
            }
        }

        // Highlight invisible chars in GMT TextBox method
        private void HighlightInvisibleChars(Range range)
        {
            range.ClearStyle(CurrentGMTTextBox.InvisibleCharsStyle);
            if (btnHTInvisibleSymbols.Checked)
                range.SetStyle(CurrentGMTTextBox.InvisibleCharsStyle, @".$|.\r\n|\s");
        }

        // Invalidate GMT TextBox with invisible chars
        private void InvalidateInvisibleChars()
        {
            foreach (GMT_FATabStripItem tab in gmt_FATabStripCollection.Items)
                HighlightInvisibleChars((tab.Controls[0] as FastColoredTextBox).Range);
            if (CurrentGMTTextBox != null)
                CurrentGMTTextBox.Invalidate();
        }

        // Highlight Current Line in GMT TextBox
        private void HighLightCurrentLine()
        {
            foreach (GMT_FATabStripItem tab in gmt_FATabStripCollection.Items)
            {
                if (btnHTHighlightCurrentLine.Checked)
                    (tab.Controls[0] as FastColoredTextBox).CurrentLineColor = CurrentGMTTextBox.CurrentLineColor;
                else
                    (tab.Controls[0] as FastColoredTextBox).CurrentLineColor = Color.Transparent;
            }
        }

        //Invalidate GMT TextBox with highlight Current Line
        private void InvalidateCurrentLine()
        {
            HighLightCurrentLine();
            if (CurrentGMTTextBox != null)
                CurrentGMTTextBox.Invalidate();
        }

        // Show/Hide Preferred Line in GMT TextBox
        private void HighLightPreferredLine()
        {
            foreach (GMT_FATabStripItem tab in gmt_FATabStripCollection.Items)
            {
                if (preferredLineToolStripMenuItem.Checked)
                    (tab.Controls[0] as FastColoredTextBox).PreferredLineWidth = 150;
                else
                    (tab.Controls[0] as FastColoredTextBox).PreferredLineWidth = 0;
            }
        }

        // Invalidate Preferred Line in Gmt TextBox
        private void InvalidatePreferredLine()
        {
            HighLightPreferredLine();
            if (CurrentGMTTextBox != null)
                CurrentGMTTextBox.Invalidate();
        }

        // Show/Hide Folder Lines in GMT TextBox
        private void ShowFolderLines()
        {
            foreach (GMT_FATabStripItem tab in gmt_FATabStripCollection.Items)
                (tab.Controls[0] as GMT_FastColoredTextBox).ShowFoldingLines = btnHTFolderLines.Checked;
            if (CurrentGMTTextBox != null)
                CurrentGMTTextBox.Invalidate();
        }

        //Fill context menu with all present Bookmarks
        private void FillBookmarksItems(ToolStripItemCollection itemsCollection)
        {
            itemsCollection.Clear();
            foreach (Control tab in gmt_FATabStripCollection.Items)
            {
                GMT_FastColoredTextBox tb = tab.Controls[0] as GMT_FastColoredTextBox;
                foreach (var bookmark in tb.Bookmarks)
                {
                    var item = itemsCollection.Add(bookmark.Name + " [" + Path.GetFileNameWithoutExtension(tab.Tag as String) + "]");
                    item.Tag = bookmark;
                    item.Click += (o, a) => {
                        var b = (Bookmark)(o as ToolStripItem).Tag;
                        try
                        {
                            CurrentGMTTextBox = (GMT_FastColoredTextBox)b.TB;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            return;
                        }
                        b.DoVisible();
                    };
                }
            }
        }

        // DefaultLanguageSettings
        private void DefaultGMTTextBoxLanguageSettings(string fileType)
        {
            //set language
            CurrentGMTTextBox.ClearStylesBuffer();
            CurrentGMTTextBox.Range.ClearStyle(StyleIndex.All);
            //CurrentGMTTextBox.AutoIndentNeeded -= fctb_AutoIndentNeeded;

            if (fileType != null && fileType.ToLower() == ".sh".ToLower())
            {
                fileType = Path.GetExtension(fileType);
                CurrentGMTTextBox.lang = GMT_FastColoredTextBox.CustomLanguages.GMTwithSH;
            }
            else
            {
                CurrentGMTTextBox.lang = GMT_FastColoredTextBox.CustomLanguages.GMTwithBAT;
            }

            CurrentGMTTextBox.OnTextChanged();
            CurrentGMTTextBox.OnSyntaxHighlight(new TextChangedEventArgs(CurrentGMTTextBox.Range));
        }

        // Save to file
        private bool Save(GMT_FATabStripItem tab)
        {
            var tb = (tab.Controls[0] as GMT_FastColoredTextBox);
            if (tab.Tag == null)
            {
                if (sfdGeneralSave.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return false;
                tab.Title = Path.GetFileName(sfdGeneralSave.FileName);
                tab.Tag = sfdGeneralSave.FileName;
                FilePath = sfdGeneralSave.FileName;
            }

            try
            {
                //File.WriteAllText(tab.Tag as string, tb.Text);
                if (FileSaveClick != null) FileSaveClick(this, EventArgs.Empty);
                tb.IsChanged = false;
                DefaultGMTTextBoxLanguageSettings(tab.Tag.ToString());
            }
            catch (Exception ex)
            {
                if (MessageBox.Show(ex.Message + ex.StackTrace, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                    return Save(tab);
                else
                    return false;
            }

            tb.Invalidate();

            return true;
        }

        // Parameter Line for Status Strip (isChanged and file type)
        private void DocumentStatus(GMT_FastColoredTextBox TextBox)
        {
            string documentType = String.Empty;

            if ((TextBox.Parent as GMT_FATabStripItem).Tag != null)
            {
                if (Path.GetExtension((TextBox.Parent as GMT_FATabStripItem).Tag.ToString().ToLower()) == ".bat".ToLower())
                {
                    documentType = @"[Current File Type : BAT, Syntax-BAT] ";
                }
                else if (Path.GetExtension((TextBox.Parent as GMT_FATabStripItem).Tag.ToString().ToLower()) == ".sh".ToLower())
                {
                    documentType = @"[Current File Type : SH, Syntax-SH] ";
                }
                else if (Path.GetExtension((TextBox.Parent as GMT_FATabStripItem).Tag.ToString().ToLower()) == ".txt".ToLower())
                {
                    documentType = @"[Current File Type : TXT, Syntax-BAT] ";
                }
            }
            else
            {
                documentType = @"[Current document type : UNKNOUN, Syntax-BAT] ";
            }

            ViewTextDocumentStatus(ssDocumentInfo, 0, documentType);
        }

        #endregion

        #region Script Runners

        // Execute BAT command in embeded CMD
        private void ExecuteBATCommand(string command)
        {
            ProcessStartInfo processInfo;
            Process process;

            processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;

            // *** Redirect the output ***
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            // new process
            process = new Process();

;
            // event handlers for output & error
            process.OutputDataReceived += (CurrentGMTTextBox.Parent as GMT_FATabStripItem).OnOutputDataReceivedFromCmd;
            process.ErrorDataReceived += (CurrentGMTTextBox.Parent as GMT_FATabStripItem).OnErrorDataReceivedFromCmd;

            process.StartInfo = processInfo;
            process.Start();

            process.BeginErrorReadLine();
            process.BeginOutputReadLine();
            process.WaitForExit();


            // *** Read the streams ***
            // Warning: This approach can lead to deadlocks, see Edit #2
            //string output = process.StandardOutput.ReadToEnd();
            //string error = process.StandardError.ReadToEnd();

            //exitCode = process.ExitCode;

            //MessageBox.Show("output>>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
            //MessageBox.Show("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
            //MessageBox.Show("ExitCode: " + exitCode.ToString(), "ExecuteCommand");
            //process.Close();
        }

        // Execute BAT File in external Console (Win CMD)
        private void ExecuteBATFile(string fileName)
        {
            Process process = new Process();
            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe", "/k " + fileName);
            psi.UseShellExecute = true;
            process.StartInfo = psi;

            try
            {
                process.Start();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        #endregion

        #region Embedded Console (Methods and Events)

        // Button -> Hide Embedded Console
        private void GmtHideEmbeddedConsole(object sender, EventArgs e)
        {
            btnHTConsole.Checked = false;
            ShowGmtEmbeddedConsole();
        }

        // Button -> Stop Run script in Embedded Console
        private void GmtStopEmbeddedConsole(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        // Button -> Save Console Output

        private void GmtSaveEmbeddedConsole(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Status Strip

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

        // Set document status
        private void ViewTextDocumentStatus(StatusStrip statusStrip, int col, string documentInfo)
        {
            statusStrip.Items[col].Text = $"{documentInfo}";
        }

        #endregion

        #region ToolBar

        // New Document Click
        private void btnHTNew_Click(object sender, EventArgs e)
        {
            NewGMTDocument(null);
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

        // Show Invisible chars
        private void btnHTInvisibleSymbols_CheckedChanged(object sender, EventArgs e)
        {
            InvalidateInvisibleChars();
            showInvisibleCharToolStripMenuItem.CheckState = (sender as CheckBox).CheckState;
        }

        // Highlight Current Line
        private void btnHTHighlightCurrentLine_CheckedChanged(object sender, EventArgs e)
        {
            InvalidateCurrentLine();
            highlightCurrentLineToolStripMenuItem.CheckState = (sender as CheckBox).CheckState;
        }

        // Set bookmark
        private void btnHTSetBookmark_Click(object sender, EventArgs e)
        {
            if (CurrentGMTTextBox == null)
                return;
            CurrentGMTTextBox.BookmarkLine(CurrentGMTTextBox.Selection.Start.iLine);
        }

        //Delete bookmark
        private void btnHTDeleteBookmark_Click(object sender, EventArgs e)
        {
            if (CurrentGMTTextBox == null)
                return;
            CurrentGMTTextBox.UnbookmarkLine(CurrentGMTTextBox.Selection.Start.iLine);
        }

        // GOTO bookmark (when context menu opening)
        private void cmsBookmarks_Opening(object sender, CancelEventArgs e)
        {
            FillBookmarksItems(cmsBookmarks.Items);
        }

        // Open GMT File
        private void btnHTOpen_Click(object sender, EventArgs e)
        {
            if (ofdGeneralOpen.ShowDialog() == DialogResult.OK)
            {
                FilePath = ofdGeneralOpen.FileName;
                if (FileOpenClick != null) FileOpenClick(this, EventArgs.Empty);
            }
        }

        // Save GMT File
        private void btnHTSave_Click(object sender, EventArgs e)
        {
            if (gmt_FATabStripCollection.SelectedItem != null)
                Save(tab: gmt_FATabStripCollection.SelectedItem as GMT_FATabStripItem);
        }

        // Print button
        private void btnHTPrint_Click(object sender, EventArgs e)
        {
            if (CurrentGMTTextBox != null)
            {
                var settings = new PrintDialogSettings();
                settings.Title = gmt_FATabStripCollection.SelectedItem.Title;
                settings.Header = "&b&w&b";
                settings.Footer = "&b&p";
                settings.IncludeLineNumbers = true;
                CurrentGMTTextBox.Print(settings);
            }
        }

        // Show/Hide Folding Lines
        private void btnHTFolderLines_CheckedChanged(object sender, EventArgs e)
        {
            ShowFolderLines();
            showFolderLinesToolStripMenuItem.CheckState = (sender as CheckBox).CheckState;
        }

        // Collapse all Folding blocks
        private void btnHTCodeFolders_CheckedChanged(object sender, EventArgs e)
        {
            CurrentGMTTextBox.CollapseAllFoldingBlocks();
            (sender as CheckBox).CheckState = CheckState.Unchecked;
        }

        // Comment selected
        private void btnHTComment_Click(object sender, EventArgs e)
        {
            CurrentGMTTextBox.InsertLinePrefix(CurrentGMTTextBox.CommentPrefix);
        }

        // Uncoment Selected
        private void btnHTUnComment_Click(object sender, EventArgs e)
        {
            CurrentGMTTextBox.RemoveLinePrefix(CurrentGMTTextBox.CommentPrefix);
        }

        // Show/Hide Embedded Console
        private void btnHTConsole_CheckedChanged(object sender, EventArgs e)
        {
            ShowGmtEmbeddedConsole();
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
            ShowGmtRuler();
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

        // Show Invisible chars
        private void showInvisibleCharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvalidateInvisibleChars();
            btnHTInvisibleSymbols.CheckState = (sender as ToolStripMenuItem).CheckState;
        }

        // Highlight Current Line
        private void highlightCurrentLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvalidateCurrentLine();
            btnHTHighlightCurrentLine.CheckState = (sender as ToolStripMenuItem).CheckState;
        }

        // GOTO bookmark (when context menu opening)
        private void AllBookmarksToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            FillBookmarksItems(AllBookmarksToolStripMenuItem.DropDownItems);
        }

        // Show/Hide Preferred Line in Gmt TextBox
        private void preferredLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvalidatePreferredLine();
        }

        // View -> DocumentMap
        private void documentMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowGmtDocumentMap();
        }

        // Save As GMT File (File -> SaveAs...)
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gmt_FATabStripCollection.SelectedItem != null)
            {
                string oldFile = gmt_FATabStripCollection.SelectedItem.Tag as string;
                gmt_FATabStripCollection.SelectedItem.Tag = null;
                if (!Save(tab: gmt_FATabStripCollection.SelectedItem as GMT_FATabStripItem))
                    if (oldFile != null)
                    {
                        gmt_FATabStripCollection.SelectedItem.Tag = oldFile;
                        gmt_FATabStripCollection.SelectedItem.Title = Path.GetFileName(oldFile);
                    }
            }
        }

        // ?-> Show AboutBox
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        // File -> Close All Tabs
        private void CloseAllTabstoolStripMenuItem_Click(object sender, EventArgs e)
        {
            while (gmt_FATabStripCollection.Items.Count > 0)
            {
                try
                {
                    GMT_FATabStripItem tab = gmt_FATabStripCollection.Items[0] as GMT_FATabStripItem;
                    gmt_FATabStripCollection.RemoveTab(tab);
                }
                catch (Exception exception)
                {
                    CloseTabError(exception, e);
                }
            }
        }

        // View -> Show/Hide Folder Lines
        private void showFolderLinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFolderLines();
            btnHTFolderLines.CheckState = (sender as ToolStripMenuItem).CheckState;
        }

        // View -> Collapse All Folding Blocks
        private void collapseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentGMTTextBox.CollapseAllFoldingBlocks();
        }

        // View -> Expand All Folding Blocks
        private void expandtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentGMTTextBox.ExpandAllFoldingBlocks();
        }

        // View -> Navigate Backward
        private void goBakcwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentGMTTextBox.NavigateBackward();
        }

        // View -> Navigate Forward
        private void goForwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentGMTTextBox.NavigateForward();
        }

        //Edit -> Set Selected As Read Only
        private void setSelectedAsReadOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentGMTTextBox.Selection.ReadOnly = true;
        }

        //Edit -> Set Selected As Writable
        private void setSelectedAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentGMTTextBox.Selection.ReadOnly = false;
        }

        // Edit -> Increase Indent (+Tabulation)
        private void increaseIndentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentGMTTextBox.IncreaseIndent();
        }

        // Edit -> Decrease Indent (-Tabulation)
        private void decreaseIndentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentGMTTextBox.DecreaseIndent();
        }

        // Tools -> Show/Hide Embedded Console
        private void openEmbededConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnHTConsole.Checked = !btnHTConsole.Checked;
            ShowGmtEmbeddedConsole();
        }

        #endregion

        #region Timer work (Update Interface)

        // When timer tick
        private void tmUpdateInterface_Tick(object sender, EventArgs e)
        {
            try
            {
                if (CurrentGMTTextBox != null && gmt_FATabStripCollection.Items.Count > 0)
                {
                    var tb = CurrentGMTTextBox;
                    btnHTUndo.Enabled = undoToolStripMenuItem.Enabled = tb.UndoEnabled;
                    btnHTRedo.Enabled = redoToolStripMenuItem.Enabled = tb.RedoEnabled;
                    btnHTSave.Enabled = saveToolStripMenuItem.Enabled = tb.IsChanged;
                    saveAsToolStripMenuItem.Enabled = true;
                    btnHTPaste.Enabled = pasteToolStripMenuItem.Enabled = true;
                    btnHTCut.Enabled = cutToolStripMenuItem.Enabled =
                    btnHTCopy.Enabled = copyToolStripMenuItem.Enabled = !tb.Selection.IsEmpty;
                    btnHTPrint.Enabled = printToolStripMenuItem.Enabled = true;

                    btnHTSetBookmark.Enabled = toogleBookmarkToolStripMenuItem.Enabled = true;
                    btnHTDeleteBookmark.Enabled = DeleteBookmarksToolStripMenuItem.Enabled = true;
                    btnHTBookmarks.Enabled = bookmarksToolStripMenuItem.Enabled = AllBookmarksToolStripMenuItem.Enabled = true;
                    deleteToolStripMenuItem.Enabled = true;
                    selectAllToolStripMenuItem.Enabled = true;
                    findAndReplaceToolStripMenuItem.Enabled = findToolStripMenuItem.Enabled = true;
                    ZoomtoolStripMenuItem.Enabled = tssbScaleDefault.Enabled = true;
                    btnHTComment.Enabled = commentSelectedLinesToolStripMenuItem.Enabled =
                    btnHTUnComment.Enabled = uncommentSelectedLinesToolStripMenuItem.Enabled = true;
                    collapseToolStripMenuItem.Enabled = expandtoolStripMenuItem.Enabled = true;
                    btnHTRun.Enabled = runInEmbededConsoleToolStripMenuItem.Enabled =
                    runInShellToolStripMenuItem.Enabled = runInWinConsoleToolStripMenuItem.Enabled =
                    checkUpToolStripMenuItem.Enabled = true;
                    autoIndentSelectedTextToolStripMenuItem.Enabled = true;
                    closeTabToolStripMenuItem.Enabled = CloseAllTabstoolStripMenuItem.Enabled = true;

                    btnHTFolderLines.Enabled = showFolderLinesToolStripMenuItem.Enabled = true;
                    btnHTCodeFolders.Enabled = collapseToolStripMenuItem.Enabled = expandtoolStripMenuItem.Enabled = true;
                    setSelectedAsReadOnlyToolStripMenuItem.Enabled = setSelectedAsToolStripMenuItem.Enabled = true;
                    increaseIndentToolStripMenuItem.Enabled = decreaseIndentToolStripMenuItem.Enabled = true;

                    goBakcwardToolStripMenuItem.Enabled = goForwardToolStripMenuItem.Enabled = true;
                    btnHTHighlightCurrentLine.Enabled = highlightCurrentLineToolStripMenuItem.Enabled = true;
                    btnHTInvisibleSymbols.Enabled = showInvisibleCharToolStripMenuItem.Enabled = true;
                    rulerToolStripMenuItem.Enabled = true;
                    preferredLineToolStripMenuItem.Enabled = true;
                    documentMapToolStripMenuItem.Enabled = true;

                    btnHTConsole.Enabled = openEmbededConsoleToolStripMenuItem.Enabled = true;
                }
                else
                {
                    btnHTSave.Enabled = saveToolStripMenuItem.Enabled = false;
                    saveAsToolStripMenuItem.Enabled = false;
                    btnHTCut.Enabled = cutToolStripMenuItem.Enabled =
                    btnHTCopy.Enabled = copyToolStripMenuItem.Enabled = false;
                    btnHTPaste.Enabled = pasteToolStripMenuItem.Enabled = false;
                    btnHTPrint.Enabled = printToolStripMenuItem.Enabled = false;
                    btnHTUndo.Enabled = undoToolStripMenuItem.Enabled = false;
                    btnHTRedo.Enabled = redoToolStripMenuItem.Enabled = false;

                    btnHTSetBookmark.Enabled = toogleBookmarkToolStripMenuItem.Enabled = false;
                    btnHTDeleteBookmark.Enabled = DeleteBookmarksToolStripMenuItem.Enabled = false;
                    btnHTBookmarks.Enabled = bookmarksToolStripMenuItem.Enabled = AllBookmarksToolStripMenuItem.Enabled = false;
                    deleteToolStripMenuItem.Enabled = false;
                    selectAllToolStripMenuItem.Enabled = false;
                    findAndReplaceToolStripMenuItem.Enabled = findToolStripMenuItem.Enabled = false;
                    ZoomtoolStripMenuItem.Enabled = tssbScaleDefault.Enabled = false;
                    btnHTComment.Enabled = commentSelectedLinesToolStripMenuItem.Enabled =
                    btnHTUnComment.Enabled = uncommentSelectedLinesToolStripMenuItem.Enabled = false;
                    collapseToolStripMenuItem.Enabled = expandtoolStripMenuItem.Enabled = false;
                    btnHTRun.Enabled = runInEmbededConsoleToolStripMenuItem.Enabled =
                    runInShellToolStripMenuItem.Enabled = runInWinConsoleToolStripMenuItem.Enabled =
                    checkUpToolStripMenuItem.Enabled = false;
                    autoIndentSelectedTextToolStripMenuItem.Enabled = false;
                    closeTabToolStripMenuItem.Enabled = CloseAllTabstoolStripMenuItem.Enabled = false;

                    btnHTFolderLines.Enabled = showFolderLinesToolStripMenuItem.Enabled = false;
                    btnHTCodeFolders.Enabled = collapseToolStripMenuItem.Enabled = expandtoolStripMenuItem.Enabled = false;
                    setSelectedAsReadOnlyToolStripMenuItem.Enabled = setSelectedAsToolStripMenuItem.Enabled = false;
                    increaseIndentToolStripMenuItem.Enabled = decreaseIndentToolStripMenuItem.Enabled = false;

                    goBakcwardToolStripMenuItem.Enabled = goForwardToolStripMenuItem.Enabled = false;
                    btnHTHighlightCurrentLine.Enabled = highlightCurrentLineToolStripMenuItem.Enabled = false;
                    btnHTInvisibleSymbols.Enabled = showInvisibleCharToolStripMenuItem.Enabled = false;
                    rulerToolStripMenuItem.Enabled = false;
                    preferredLineToolStripMenuItem.Enabled = false;
                    documentMapToolStripMenuItem.Enabled = false;

                    btnHTConsole.Enabled = openEmbededConsoleToolStripMenuItem.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Time error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region RUN

        // Run Script (BAT Script) in Embeded Console
        private void btnHTRun_Click(object sender, EventArgs e)
        {
            // Save File
            btnHTSave.PerformClick();

            // Check
            if ((CurrentGMTTextBox.Parent as GMT_FATabStripItem).Tag != null && Path.GetExtension((CurrentGMTTextBox.Parent as GMT_FATabStripItem).Tag.ToString().ToLower()) == ".bat".ToLower())
            {
                (CurrentGMTTextBox.Parent as GMT_FATabStripItem).GmtSplitterConsole.Visible = true;
                (CurrentGMTTextBox.Parent as GMT_FATabStripItem).GmtPanel.Visible = true;
                // Execute
                ExecuteBATCommand((CurrentGMTTextBox.Parent as GMT_FATabStripItem).Tag.ToString());
            }
            else
            {
                if (MessageBox.Show("For RUN this BAT script, Save script (*.bat), please!", "Run script", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    btnHTSave.PerformClick();
                }
            }
        }

        // Run Script (BAT Script) in Embeded Console
        private void runInEmbededConsoleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            btnHTRun.PerformClick();
        }

        // Run Script (BAT FILE) in Win Console (CMD)
        private void runInWinConsoleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Save File
            btnHTSave.PerformClick();

            // Check
            if ((CurrentGMTTextBox.Parent as GMT_FATabStripItem).Tag != null && Path.GetExtension((CurrentGMTTextBox.Parent as GMT_FATabStripItem).Tag.ToString().ToLower()) == ".bat".ToLower())
            {
                // Execute
                ExecuteBATFile((CurrentGMTTextBox.Parent as GMT_FATabStripItem).Tag.ToString());
            }
            else
            {
                if (MessageBox.Show("For RUN this BAT File, Save script (*.bat), please!","Run script", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    btnHTSave.PerformClick();
                }
            }
        }

        #endregion
    }
}
