using Common.Models;
using Newtonsoft.Json;
using System.IO;

namespace SettingMgr
{
    public class ConfigMgr
    {
        private const string SETTINGS_PATH = "./settings.json";

        private SettingsConfig configs;

        public ConfigMgr()
        {
            configs = GetConfigsData();
        }

        public string GetDestenationPath()
        {
            return configs.DestenationPath;
        }

        public string GetClientArchivePathPath()
        {
            return configs.ClientsArchiveFilePath;
        }

        public void SetSettings(SettingsConfig settingsConfig)
        {
            string json = JsonConvert.SerializeObject(settingsConfig);
            File.WriteAllText(SETTINGS_PATH, json);
        }

        private SettingsConfig GetConfigsData()
        {
            using (StreamReader r = new StreamReader(SETTINGS_PATH))
            {
                string json = r.ReadToEnd();
                SettingsConfig settingsConfig = JsonConvert.DeserializeObject<SettingsConfig>(json);

                return settingsConfig;
            }
        }
    }
}
