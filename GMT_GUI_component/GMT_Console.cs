using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMT_GUI_component
{
    public class GMT_Console : RichTextBox
    {
        #region Constructors

        public GMT_Console()
        {
            this.Enabled = true;
            this.Visible = true;
            this.Dock = DockStyle.Fill;
            this.ReadOnly = true;
            this.BorderStyle = BorderStyle.None;
            this.BackColor = Color.White;
            this.ScrollBars = RichTextBoxScrollBars.Both;
            this.WordWrap = false;
            this.Font = new Font("Consolas", 10f);
        }

        #endregion
    }
}
