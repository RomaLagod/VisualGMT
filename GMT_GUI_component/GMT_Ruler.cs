using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace GMT_GUI_component
{
    public class GMT_Ruler : Ruler
    {
        #region Constructors

        public GMT_Ruler() : base()
        {

        }

        public GMT_Ruler(GMT_FastColoredTextBox textBox) : base()
        {
            this.Visible = false;
            this.Dock = DockStyle.Top;
            this.Target = textBox;
        }

        #endregion
    }
}
