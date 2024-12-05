using Salaros.Configuration;
using System.IO;
using System;


namespace OriontaxSync.libs
{
    public static class ConfigReader
    {
        private static ConfigParser config;
        private static string filePath;
        public static string base_url = @"https://oriontax.f5sys.com.br/api/v1/test";

        public static void LoadConfig(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new Exception("Arquivo de config.conf não localizado");
            }

            config = new ConfigParser(fileName);
            filePath = fileName;
        }
        public static void ReloadConfig()
        {
            config = new ConfigParser(filePath);
        }

        public static void SaveConfig()
        {
            config.Save();
        }

        public static void SetConfigValue(string section, string key, string value)
        {
            config.SetValue(section, key, value);
        }

        public static string GetConfigValue(string section, string key)
        {
            String value = config.GetValue(section, key);
            return value;
        }
    }
}
