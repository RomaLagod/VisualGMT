using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMT_GUI_component
{
    public class GMT_Panel : Panel
    {
        #region Properties

        public GMT_Console gmt_Console { get; }
        public Button StopConsole { get; }
        public Button ClearConsole { get; }
        public Button HideConsole { get; }

        #endregion

        #region Constructors

        public GMT_Panel()
        {
            this.Enabled = true;
            this.Visible = false;
            this.Dock = DockStyle.Bottom;
            this.Height = 100;

            // Create GMTConsole (RichTextBox)
            gmt_Console = new GMT_Console();
            this.Controls.Add(gmt_Console);

            // Create Panel with Buttons for console
            Panel panelForButtons = new Panel();
            panelForButtons.Dock = DockStyle.Left;
            panelForButtons.Width = 45;
            panelForButtons.BackColor = Color.DarkGray;
            //--
            HideConsole = new Button();
            HideConsole.Text = "Hide";
            HideConsole.FlatStyle = FlatStyle.Flat;
            HideConsole.ForeColor = Color.Maroon;
            HideConsole.Dock = DockStyle.Top;
            panelForButtons.Controls.Add(HideConsole);
            //--
            ClearConsole = new Button();
            ClearConsole.Text = "Clear";
            ClearConsole.FlatStyle = FlatStyle.Flat;
            ClearConsole.ForeColor = Color.Maroon;
            ClearConsole.Dock = DockStyle.Top;
            ClearConsole.Click += _ClearConsole;
            panelForButtons.Controls.Add(ClearConsole);
            //--
            StopConsole = new Button();
            StopConsole.Text = "Stop";
            StopConsole.FlatStyle = FlatStyle.Flat;
            StopConsole.ForeColor = Color.Maroon;
            StopConsole.Dock = DockStyle.Top;
            panelForButtons.Controls.Add(StopConsole);
            //--
            this.Controls.Add(panelForButtons);
        }

        #endregion

        #region Events

        // On Button Clear Click -> Clear embedded console
        private void _ClearConsole(object sender, EventArgs e)
        {
            gmt_Console.Clear();
        }

        #endregion

    }
}
