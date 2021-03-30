using Common.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SettingMgr
{
    public class ConfigMgr
    {
        private const string SETTINGS_PATH = "./settings.json";

        public string GetDestenationPath()
        {
            using (StreamReader r = new StreamReader(SETTINGS_PATH))
            {
                string json = r.ReadToEnd();
                SettingsConfig settingsConfig = JsonConvert.DeserializeObject<SettingsConfig>(json);
                
                return settingsConfig.DestenationPath;
            }
        }

        public void SetSettings(SettingsConfig settingsConfig)
        {
            string json = JsonConvert.SerializeObject(settingsConfig);
            File.WriteAllText(SETTINGS_PATH, json);
        }
    }
}
