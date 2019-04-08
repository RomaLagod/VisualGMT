using FarsiLibrary.Win;
using GMT_GUI_component.ComponentInterface;
using System;
using System.IO;

namespace GMT_GUI_component
{
    // Tab item class for component FATabStrip (library TabStrip.dll)
    public class GMT_FATabStripItem : FATabStripItem, IGMT_FATabStripItem
    {
        // GMT FastColoredTextBox
        public GMT_FastColoredTextBox GmtTextBox { get; }

        // File
        public String FileName { get; set; }

        // constructor by default
        public GMT_FATabStripItem() : base()
        {
            //GmtTextBox = new GMT_FastColoredTextBox();
        }

        // special constructor for new tab item
        // include: GMT_FastColoredTextBox
        public GMT_FATabStripItem(string fileName) : base()
        {
            GmtTextBox = new GMT_FastColoredTextBox();
            this.Controls.Add(GmtTextBox);
            this.Title = fileName != null ? Path.GetFileName(fileName) : "[new]";
            FileName = fileName;
            //this.Tag = fileName;
            //if (fileName != null)
            //    GmtTextBox.OpenFile(fileName);

        }
    }
}
