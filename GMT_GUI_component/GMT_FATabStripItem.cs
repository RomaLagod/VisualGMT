﻿using FarsiLibrary.Win;
using GMT_GUI_component.ComponentInterface;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
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

        // Splitter for Document Map
        public GMT_Splitter GmtSplitter { get; set; }

        // Splitter for Console
        public GMT_Splitter GmtSplitterConsole { get; set; }

        // File
        public String FileName { get; set; }

        // Console (cmd)
        public GMT_Console GmtConsole { get; }

        // Panel with console
        public GMT_Panel GmtPanel { get; }

        // Embedded Console Process
        public Process CurrentCMDProcess { get; set; }

        #endregion

        #region Events Embedded Console

        // Embeded console -> Error Data Receive
        public void OnErrorDataReceivedFromCmd(object sender, DataReceivedEventArgs e)
        {
            Process p = sender as Process;
            if (p == null)
                return;
            if (GmtConsole.InvokeRequired)
            {
                GmtConsole.BeginInvoke(new DataReceivedEventHandler(OnErrorDataReceivedFromCmd), new object[] { sender, e });
            }
            else
            {
                AddErrorToEmbeddedConsole(e.Data);
            }
        }

        // Embeded console -> Data Receive
        public void OnOutputDataReceivedFromCmd(object sender, DataReceivedEventArgs e)
        {
            Process p = sender as Process;
            if (p == null)
                return;
            if (GmtConsole.InvokeRequired)
            {
                GmtConsole.BeginInvoke(new DataReceivedEventHandler(OnOutputDataReceivedFromCmd), new object[] { sender, e });
            }
            else
            {
                AddInfoToEmbeddedConsole(e.Data);
            }
        }

        // Add strings to Embedded Console
        public void AddInfoToEmbeddedConsole(string info)
        {
            try
            {
                string sortOutput = "";
                sortOutput = Environment.NewLine + info;
                GmtConsole.AppendText(sortOutput);
                GmtConsole.ScrollToCaret();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Embedded Console Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Add error to Embedded Console
        private void AddErrorToEmbeddedConsole(string error)
        {
            try
            {
                GmtConsole.SelectionColor = Color.Red;
                string sortOutput = "";
                sortOutput = Environment.NewLine + error;
                GmtConsole.AppendText(sortOutput);
                GmtConsole.SelectionColor = Color.Black;
                GmtConsole.ScrollToCaret();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Embedded Console Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Constructors

        // constructor by default
        public GMT_FATabStripItem() : base()
        {
            //GmtTextBox = new GMT_FastColoredTextBox();
        }

        // special constructor for new tab item without content
        // This constructor produce bad load Cyrilic symbols
        // include: GMT_FastColoredTextBox
        public GMT_FATabStripItem(string fileName) : base()
        {
            // Create GMT_FastColoredTextBox
            GmtTextBox = new GMT_FastColoredTextBox();
            this.Controls.Add(GmtTextBox);
            this.Title = fileName != null ? Path.GetFileName(fileName) : "[new]";
            FileName = fileName;
            this.Tag = fileName;
            if (fileName != null)
                GmtTextBox.OpenFile(fileName);

            // Create Ruler
            GmtRuler = new GMT_Ruler(GmtTextBox);
            this.Controls.Add(GmtRuler);

            //GMT Splitter between DocumentMap and GmtTextBox
            GmtSplitter = new GMT_Splitter();
            this.Controls.Add(GmtSplitter);

            // Create Document Map
            GmtDocumentMap = new GMT_DocumentMap(GmtTextBox);
            this.Controls.Add(GmtDocumentMap);

            //GMT Splitter between DocumentMap and GmtTextBox
            GmtSplitterConsole = new GMT_Splitter();
            GmtSplitterConsole.Dock = DockStyle.Bottom;
            this.Controls.Add(GmtSplitterConsole);

            // Gmt Console (cmd)
            GmtPanel = new GMT_Panel();
            this.Controls.Add(GmtPanel);
            GmtConsole = GmtPanel.gmt_Console;
        }

        // Second special constructor for new tab item with Content
        // include: GMT_FastColoredTextBox
        public GMT_FATabStripItem(string fileName, string content) : base()
        {
            // Create GMT_FastColoredTextBox
            GmtTextBox = new GMT_FastColoredTextBox();
            this.Controls.Add(GmtTextBox);
            this.Title = fileName != null ? Path.GetFileName(fileName) : "[new]";
            FileName = fileName;
            this.Tag = fileName;
            if (fileName != null)
                GmtTextBox.Text = content;

            // Create Ruler
            GmtRuler = new GMT_Ruler(GmtTextBox);
            this.Controls.Add(GmtRuler);

            //GMT Splitter between DocumentMap and GmtTextBox
            GmtSplitter = new GMT_Splitter();
            this.Controls.Add(GmtSplitter);

            // Create Document Map
            GmtDocumentMap = new GMT_DocumentMap(GmtTextBox);
            this.Controls.Add(GmtDocumentMap);

            //GMT Splitter between DocumentMap and GmtTextBox
            GmtSplitterConsole = new GMT_Splitter();
            GmtSplitterConsole.Dock = DockStyle.Bottom;
            this.Controls.Add(GmtSplitterConsole);

            // Gmt Console (cmd)
            GmtPanel = new GMT_Panel();
            this.Controls.Add(GmtPanel);
            GmtConsole = GmtPanel.gmt_Console;
        }

        #endregion
    }
}
