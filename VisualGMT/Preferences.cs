using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisualGMT.GlobalPreferences;

namespace VisualGMT
{
    public partial class Preferences : Form
    {
        #region Properties

        public PreferencesXML PreferencesXML { get; set; }

        #endregion

        #region Override

        public PreferencesXML ShowDialog(PreferencesXML preferencesXML)
        {
            PreferencesXML = preferencesXML;
            LoadPathToTextBoxes();
            base.ShowDialog();
            return PreferencesXML;
        }

        #endregion

        #region Form Creating

        public Preferences()
        {
            InitializeComponent();
        }

        #endregion

        #region Load Current Paths

        private void LoadPathToTextBoxes()
        {
            if (PreferencesXML != null)
            {
                tbPathToLinuxTerminal.Text = PreferencesXML.PathToLinuxTerminal;
                tbPathToGMTMainDirectory.Text = PreferencesXML.PathToGMT;
                tbPathToPSViewer.Text = PreferencesXML.PathToPSViewer;
                tbPathToWorkingDirectory.Text = PreferencesXML.PathToWorkingDirectory;
            }
        }

        #endregion

        #region Set Path

        // Linux Terminal Path
        private void btnOpenPathToLinuxTerminal_Click(object sender, EventArgs e)
        {
            if(ofdFile.ShowDialog() == DialogResult.OK)
            {
                tbPathToLinuxTerminal.Text = ofdFile.FileName;
            }
        }

        // Path tp PS Viewer
        private void btnOpenPathToPSViewer_Click(object sender, EventArgs e)
        {
            if (ofdFile.ShowDialog() == DialogResult.OK)
            {
                tbPathToPSViewer.Text = ofdFile.FileName;
            }
        }

        // Path to GMT Directory
        private void btnOpenPathToGMTMainDirectory_Click(object sender, EventArgs e)
        {
            if(fbdDirectory.ShowDialog() == DialogResult.OK)
            {
                tbPathToGMTMainDirectory.Text = fbdDirectory.SelectedPath;
            }
        }

        // Path To Working Directory
        private void btnOpenPathToWorkingDirectory_Click(object sender, EventArgs e)
        {
            if (fbdDirectory.ShowDialog() == DialogResult.OK)
            {
                tbPathToWorkingDirectory.Text = fbdDirectory.SelectedPath;
            }
        }

        #endregion

        #region Save/Cancel path

        // Close Preferences Form without saving
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Save Path and exit
        private void btnSaveAndExit_Click(object sender, EventArgs e)
        {
            // Set path to class
            PreferencesXML.PathToLinuxTerminal = tbPathToLinuxTerminal.Text;
            PreferencesXML.PathToPSViewer = tbPathToPSViewer.Text;
            PreferencesXML.PathToGMT = tbPathToGMTMainDirectory.Text;
            PreferencesXML.PathToWorkingDirectory = tbPathToWorkingDirectory.Text;

            // Save XML
            PreferencesXML.SaveXML(PreferencesXML);

            // Close form
            this.Close();
        }

        #endregion
    }
}
