using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace GMT_GUI_component
{
    public class GMT_DocumentMap : DocumentMap
    {
        #region Constructors

        public GMT_DocumentMap() : base()
        {

        }

        public GMT_DocumentMap(GMT_FastColoredTextBox textBox) : base()
        {
            this.Visible = false;
            this.Width = 100;
            this.ForeColor = Color.DodgerBlue;
            this.Dock = DockStyle.Right;
            this.Scale = 0.3f;
            this.ScrollbarVisible = true;
            this.Target = textBox;
        }

        #endregion
    }
}
