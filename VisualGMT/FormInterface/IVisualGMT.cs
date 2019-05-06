using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMT_GUI_component.ComponentInterface;

namespace VisualGMT.FormInterface
{
    public interface IVisualGMT
    {
        #region GUI Components

        Control interBtnHTNew { get; set; }
        Control interBtnHTOpen { get; set; }
        Control interBtnHTSave { get; set; }
        Control interBtnHTPrint { get; set; }
        Control interBtnHTCopy { get; set; }
        Control interBtnHTCut { get; set; }
        Control interBtnHTPaste { get; set; }
        Control interBtnHTUndo { get; set; }
        Control interBtnHTRedo { get; set; }
        Control interBtnHTHighlightCurrentLine { get; set; }
        Control interBtnHTInvisibleSymbols { get; set; }
        Control interBtnHTCodeFolders { get; set; }
        Control interBtnHTFolderLines { get; set; }
        Control interBtnHTComment { get; set; }
        Control interBtnHTUnComment { get; set; }
        Control interBtnHTSetBookmark { get; set; }
        Control interBtnHTGetBookmark { get; set; }
        Control interBtnHTBookmarks { get; set; }
        Control interBtnHTRun { get; set; }
        Control interBtnHTConsole { get; set; }
        Control interBtnHTPostScript { get; set; }
        Control interBtnHTSettings { get; set; }
        Control interBtnHTFind { get; set; }

        #endregion

        #region Properties

        #endregion

        #region Events

        //Event On Main Form Load
        event EventHandler VisualGMTLoad;
        //Event Ruler error
        event EventHandler RulerError;
        //Event CloseTab error
        event EventHandler CloseTabError;

        #endregion

        #region Methods

        #endregion
    }
}
