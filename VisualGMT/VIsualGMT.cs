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
        public IGMT_FastColoredTextBox GmtFastColoredTextBox { get; set; }

        //On Form Load
        public event EventHandler VisualGMTLoad;

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
            if (VisualGMTLoad != null) VisualGMTLoad(this, e);

            var fastDocumentCollection = new GMT_FATabStripCollection();

            var tab = new GMT_FATabStripItem(null);
            fastDocumentCollection.AddTab(tab);
            fastDocumentCollection.SelectedItem = tab;

            //// Initializing ToolTips for main form
            //ToolTipsInitializing();



            //// Event in GMTTextBox
            //tab.GmtTextBox.TextChanged += GmtTextBoxChanged;
            //tab.GmtTextBox.SelectionChanged += GmtCursorChanged;
            //tab.GmtTextBox.ZoomChanged += GmtZoomChanged;
            //tab.GmtTextBox.KeyDown += GmtDownPress;
        }

        #endregion

        #region Methods

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

        #endregion
    }
}
