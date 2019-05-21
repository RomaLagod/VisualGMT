using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace VisualGMT.GlobalPreferences
{
    [Serializable]
    public class PreferencesXML
    {
        public string PathToLinuxTerminal { get; set; }
        public string PathToGMT { get; set; }
        public string PathToPSViewer { get; set; }
        public string PathToWorkingDirectory { get; set; }

        private string PathToPreferencesXMLFile = Environment.CurrentDirectory + @"Preferences.xml";

        public PreferencesXML()
        {

        }

        public static void SaveXML(PreferencesXML preferences)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(PreferencesXML));

            using (FileStream fs = new FileStream(preferences.PathToPreferencesXMLFile, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, preferences);
            }
        }

        public static PreferencesXML OpenXML(PreferencesXML preferences)
        {
            if (File.Exists(preferences.PathToPreferencesXMLFile))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(PreferencesXML));

                using (FileStream fs = new FileStream(preferences.PathToPreferencesXMLFile, FileMode.OpenOrCreate))
                {
                    preferences = (PreferencesXML)formatter.Deserialize(fs);
                }
            }
            return preferences;
        }
    }
}
