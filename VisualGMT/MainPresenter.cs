using GMT_BLL.LogicInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMT_GUI_component.ComponentInterface;
using VisualGMT.FormInterface;

namespace VisualGMT
{
    public class MainPresenter
    {
        #region Project Interfaces for Presenter

        private readonly IVisualGMT _view;
        private readonly IFormToolTips _toolTips;
        private readonly IMessageService _messageService;

        #endregion

        #region Constructor

        public MainPresenter(IVisualGMT view, IFormToolTips toolTips, IMessageService messageService)
        {
            #region initialization

            _view = view;
            _toolTips = toolTips;
            _messageService = messageService;

            #endregion

            #region Events connection

            _view.VisualGMTLoad += viewVisualGMTLoad;
            _view.CloseTabError += _view_CloseTabError;
            _view.RulerError += _view_RulerError;

            #endregion
        }

        #endregion

        #region When Event

        // Event when MainForm (VisualGMT) OnLoad
        private void viewVisualGMTLoad(object sender, EventArgs e)
        {
            // Set ToolTips in View
            ToolTipsInitializing();
        }

        // Event when Close tab error
        private void _view_CloseTabError(object sender, EventArgs e)
        {
            _messageService.ShowError(sender.ToString());
        }

        //Event when Ruler error
        private void _view_RulerError(object sender, EventArgs e)
        {
            _messageService.ShowError(sender.ToString());
        }

        #endregion

        #region Methods

        // Set ToolTips for main form
        private void ToolTipsInitializing()
        {
            _toolTips.ToolTip.SetToolTip(_view.interBtnHTNew, _toolTips.New);
            _toolTips.ToolTip.SetToolTip(_view.interBtnHTOpen, _toolTips.Open);
            _toolTips.ToolTip.SetToolTip(_view.interBtnHTSave, _toolTips.Save);
            _toolTips.ToolTip.SetToolTip(_view.interBtnHTPrint, _toolTips.Print);
            _toolTips.ToolTip.SetToolTip(_view.interBtnHTCopy, _toolTips.Copy);
            _toolTips.ToolTip.SetToolTip(_view.interBtnHTCut, _toolTips.Cut);
            _toolTips.ToolTip.SetToolTip(_view.interBtnHTPaste, _toolTips.Paste);
            _toolTips.ToolTip.SetToolTip(_view.interBtnHTUndo, _toolTips.Undo);
            _toolTips.ToolTip.SetToolTip(_view.interBtnHTRedo, _toolTips.Redo);
            _toolTips.ToolTip.SetToolTip(_view.interBtnHTHighlightCurrentLine, _toolTips.HighlightCurrentLine);
            _toolTips.ToolTip.SetToolTip(_view.interBtnHTInvisibleSymbols, _toolTips.InvisibleChars);
            _toolTips.ToolTip.SetToolTip(_view.interBtnHTCodeFolders, _toolTips.Folders);
            _toolTips.ToolTip.SetToolTip(_view.interBtnHTFolderLines, _toolTips.FolderLines);
            _toolTips.ToolTip.SetToolTip(_view.interBtnHTComment, _toolTips.Comment);
            _toolTips.ToolTip.SetToolTip(_view.interBtnHTUnComment, _toolTips.UnComment);
            _toolTips.ToolTip.SetToolTip(_view.interBtnHTSetBookmark, _toolTips.SetBookmark);
            _toolTips.ToolTip.SetToolTip(_view.interBtnHTGetBookmark, _toolTips.GetBookmark);
            _toolTips.ToolTip.SetToolTip(_view.interBtnHTBookmarks, _toolTips.Bookmarks);
            _toolTips.ToolTip.SetToolTip(_view.interBtnHTRun, _toolTips.Run);
            _toolTips.ToolTip.SetToolTip(_view.interBtnHTConsole, _toolTips.Console);
            _toolTips.ToolTip.SetToolTip(_view.interBtnHTPostScript, _toolTips.ShowScriptResult);
            _toolTips.ToolTip.SetToolTip(_view.interBtnHTSettings, _toolTips.Settings);
            _toolTips.ToolTip.SetToolTip(_view.interBtnHTFind, _toolTips.Find);
        }

        #endregion
    }
}
