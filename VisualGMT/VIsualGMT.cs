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


namespace VisualGMT
{
    public partial class VisualGMT : Form
    {

        // Form constructor by default
        public VisualGMT()
        {
            InitializeComponent();
        }

        // On form Visual GMT Load
        private void VisualGMT_Load(object sender, EventArgs e)
        {
           //var fastDocumentCollection = new GMT_FATabStripCollection();

            //var tab = new GMT_FATabStripItem(null);
            //fastDocumentCollection.AddTab(tab);
            //fastDocumentCollection.SelectedItem = tab;

            //// Initializing ToolTips for main form
            //ToolTipsInitializing();



            //// Event in GMTTextBox
            //tab.GmtTextBox.TextChanged += GmtTextBoxChanged;
            //tab.GmtTextBox.SelectionChanged += GmtCursorChanged;
            //tab.GmtTextBox.ZoomChanged += GmtZoomChanged;
            //tab.GmtTextBox.KeyDown += GmtDownPress;
        }
    }
}
