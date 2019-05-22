using FastColoredTextBoxNS;
using GMT_GUI_component;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualGMT.GlobalSettings
{
    public class RecentFile
    {
        #region Properties

        public string FullPath { get; set; }
        public string ShortFileName { get; set; }
        public int Zoom { get; set; }
        public BaseBookmarks Bookmarks { get; set; }

        #endregion

        #region Constructors

        public RecentFile(GMT_FastColoredTextBox textBox)
        {
            FullPath = (textBox.Parent as GMT_FATabStripItem).Tag.ToString();
            ShortFileName = Path.GetFileName(FullPath);
            Zoom = textBox.Zoom;
            Bookmarks = textBox.Bookmarks;
        }

        #endregion
    }
}
