using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace VisualGMT.GlobalSettings
{
    [Serializable]
    public class SettingsXML
    {
        #region Properties

        // Style For GMTTextBox
        public Font GmtTextBoxFont { get; set; }

        // Style For Embedded Console
        public Font EmbeddedConsoleFont { get; set; }

        // Main Form Sizes
        public Size VisualGMT_Size { get; set; }
        public FormWindowState VisualGMT_WindowState { get; set; }
        public Point VisualGMT_Location { get; set; }

        // Enabled Settings (Checked/Unchecked)
        public CheckState HighLightCurrentLine { get; set; }
        public CheckState ShowInvisibleChars { get; set; }
        public CheckState ShowFolderLines { get; set; }
        public CheckState AutoIndentSelectedText { get; set; }
        public CheckState Ruler { get; set; }
        public CheckState PrefferedLine { get; set; }
        public CheckState DocumentMap { get; set; }
        public CheckState EmbeddedConsole { get; set; }
        public CheckState CMD { get; set; }

        // Bookmarks

        // Zoom

        // Recent Files

        #endregion

        #region Const Path to Settings

        private string PathToSettingsXMLFile = Environment.CurrentDirectory + @"Settings.xml";

        #endregion

        #region Constructors

        public SettingsXML()
        {

        }

        #endregion

        #region Open / Save Settings

        public static void SaveXML(SettingsXML settings)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(SettingsXML));

            using (FileStream fs = new FileStream(settings.PathToSettingsXMLFile, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, settings);
            }
        }

        public static SettingsXML OpenXML(SettingsXML settings)
        {
            if (File.Exists(settings.PathToSettingsXMLFile))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(SettingsXML));

                using (FileStream fs = new FileStream(settings.PathToSettingsXMLFile, FileMode.OpenOrCreate))
                {
                    settings = (SettingsXML)formatter.Deserialize(fs);
                }
            }
            return settings;
        }

        #endregion
    }
}
