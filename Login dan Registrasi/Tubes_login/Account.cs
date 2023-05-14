using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Account
{
    public class Config
    {
        internal string tipe_akun;
        private string v1;
        private string v2;

        public string Name { get; set; }
        public string Password { get; set; }

        public Config() { }

        public Config(string name, string password, string password1)
        {
            this.Name = name;
            this.Password = password;
        }

        public Config(string v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
    }

    public class Account
    {
        public Config config;
        public const string filePath = @"./acc_config.json";

        public Account()
        {
            try
            {
                ReadConfigFile();
            }
            catch
            {
                SetDefault();
                WriteNewConfigFile();
            }
        }
        public Config ReadConfigFile()
        {
            string configJsonData = File.ReadAllText(filePath);
            config = JsonSerializer.Deserialize<Config>(configJsonData);
            return config;
        }

        private void SetDefault()
        {
            config = new Config("username", "password");
        }

        public void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filePath, jsonString);
        }

    }
}
