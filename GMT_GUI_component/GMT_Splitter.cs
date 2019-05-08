using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMT_GUI_component
{
    public class GMT_Splitter : Splitter
    {
        #region Constructors

        public GMT_Splitter(): base()
        {
            this.Enabled = true;
            this.Visible = false;
            this.Dock = DockStyle.Right;
            this.MinSize = 25;
            this.MinExtra = 25;
            this.Width = 2;
            this.BackColor = Color.DarkGray;
        }

        #endregion
    }
}
