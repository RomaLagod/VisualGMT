using FarsiLibrary.Win;
using GMT_GUI_component.ComponentInterface;
using System;
using System.IO;
using System.Windows.Forms;

namespace GMT_GUI_component
{
    // Tab item class for component FATabStrip (library TabStrip.dll)
    public class GMT_FATabStripItem : FATabStripItem, IGMT_FATabStripItem
    {
        #region Properties

        // GMT FastColoredTextBox
        public GMT_FastColoredTextBox GmtTextBox { get; }

        // GMT Ruler
        public GMT_Ruler GmtRuler { get; set; }

        // GMT DocumentMap
        public GMT_DocumentMap GmtDocumentMap { get; set; }

        // File
        public String FileName { get; set; }

        #endregion


        #region Constructors

        // constructor by default
        public GMT_FATabStripItem() : base()
        {
            //GmtTextBox = new GMT_FastColoredTextBox();
        }

        // special constructor for new tab item
        // include: GMT_FastColoredTextBox
        public GMT_FATabStripItem(string fileName) : base()
        {
            // Create GMT_FastColoredTextBox
            GmtTextBox = new GMT_FastColoredTextBox();
            this.Controls.Add(GmtTextBox);
            this.Title = fileName != null ? Path.GetFileName(fileName) : "[new]";
            FileName = fileName;
            //this.Tag = fileName;
            //if (fileName != null)
            //    GmtTextBox.OpenFile(fileName);

            // Create Ruler
            GmtRuler = new GMT_Ruler(GmtTextBox);
            this.Controls.Add(GmtRuler);

            // Create Document Map
            GmtDocumentMap = new GMT_DocumentMap(GmtTextBox);
            this.Controls.Add(GmtDocumentMap);

            //??
            Splitter splitter = new Splitter();
            splitter.Dock = DockStyle.Right;
            splitter.Enabled = true;
            splitter.Visible = false;
            splitter.MinSize = 25;
            this.Controls.Add(splitter);


        }

        #endregion
    }
}
