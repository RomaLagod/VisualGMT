using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMT_BLL;

namespace VisualGMT
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            #region MVP

            VisualGMT visualGmt = new VisualGMT();
            FormToolTips formToolTips = new FormToolTips();

            MainPresenter presenter = new MainPresenter(visualGmt, formToolTips);

            #endregion


            Application.Run(visualGmt);
        }
    }
}
