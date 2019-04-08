using GMT_BLL.LogicInterface;
using System.Windows.Forms;

namespace GMT_BLL
{
    /// <summary>
    /// ToolTips (Hints) test for main form
    /// </summary>
    public class FormToolTips : IFormToolTips
    {
        public ToolTip ToolTip { get; set; }
        public string New { get; set; }
        public string Open { get; set; }
        public string Save { get; set; }
        public string Print { get; set; }
        public string Copy { get; set; }
        public string Cut { get; set; }
        public string Paste { get; set; }
        public string Undo { get; set; }
        public string Redo { get; set; }
        public string HighlightCurrentLine { get; set; }
        public string InvisibleChars { get; set; }
        public string Folders { get; set; }
        public string FolderLines { get; set; }
        public string Comment { get; set; }
        public string UnComment { get; set; }
        public string SetBookmark { get; set; }
        public string GetBookmark { get; set; }
        public string Bookmarks { get; set; }
        public string Run { get; set; }
        public string Console { get; set; }
        public string ShowScriptResult { get; set; }
        public string Settings { get; set; }
        public string Find { get; set; }

        public FormToolTips()
        {
            ToolTip = new ToolTip();
            New = "New Document";
            Open = "Open Document...";
            Save = "Save Document...";
            Print = "Print Document...";
            Copy = "Copy";
            Cut = "Cut";
            Paste = "Paste";
            Undo = "Undo";
            Redo = "Redo";
            HighlightCurrentLine = "Highlight Current Line";
            InvisibleChars = "Show/Hide Invisible Chars";
            Folders = "Expand/Hide Sections";
            FolderLines = "Show/Hide Sections Lines";
            Comment = "Comment";
            UnComment = "Uncomment";
            SetBookmark = "Set Bookmark";
            GetBookmark = "Go To Bookmark";
            Bookmarks = "Bookmarks";
            Run = "Run Script";
            Console = "Show Console...";
            ShowScriptResult = "View graphical results...";
            Settings = "Settings...";
            Find = "Find";
        }
    }
}
