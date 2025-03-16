using System.IO;
using System.Xml.Serialization;

namespace BasicFacebookFeatures
{
    public class AppSettings
    {
        private const string k_FileName = "AppSettings.xml";
        public string[] Permissions { get; set; }
        public string LastAccessToken { get; set; }
        public bool RememberUser { get; set; }

        private AppSettings()
        {
        }

        public void SaveToFile()
        {
            if (File.Exists(k_FileName))
            {
                File.Delete(k_FileName);
            }

            using (Stream appSettingsStream = File.OpenWrite(k_FileName))
            {
                XmlSerializer appSettingsSerializer = new XmlSerializer(this.GetType());

                appSettingsSerializer.Serialize(appSettingsStream, this);
            }
        }

        public static AppSettings LoadFromFile()
        {
            AppSettings appSettings = new AppSettings();

            if (File.Exists(k_FileName))
            {
                using (Stream appSettingsStream = File.OpenRead(k_FileName))
                {
                    XmlSerializer appSettingsSerializer = new XmlSerializer(typeof(AppSettings));

                    appSettings = appSettingsSerializer.Deserialize(appSettingsStream) as AppSettings;
                }
            }

            return appSettings;
        }
    }
}
