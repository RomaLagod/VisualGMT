using System.Windows.Forms;

namespace GMT_BLL.LogicInterface
{
    public interface IFormToolTips
    {
        ToolTip ToolTip { get; set; }
        string New { get; set; }
        string Open { get; set; }
        string Save { get; set; }
        string Print { get; set; }
        string Copy { get; set; }
        string Cut { get; set; }
        string Paste { get; set; }
        string Undo { get; set; }
        string Redo { get; set; }
        string HighlightCurrentLine { get; set; }
        string InvisibleChars { get; set; }
        string Folders { get; set; }
        string FolderLines { get; set; }
        string Comment { get; set; }
        string UnComment { get; set; }
        string Find { get; set; }
        string SetBookmark { get; set; }
        string GetBookmark { get; set; }
        string Bookmarks { get; set; }
        string Run { get; set; }
        string Console { get; set; }
        string ShowScriptResult { get; set; }
        string Settings { get; set; }
        string Preferences { get; set; }
    }
}
