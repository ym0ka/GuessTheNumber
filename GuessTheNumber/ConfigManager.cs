using System.Text.Json;

namespace GuessTheNumber
{
    public class ConfigManager
    {
        //Initialising variables to use them after
        private string configFilePath;
        private string configFileContent;
        private JsonElement jsonData;

        public ConfigManager()
        {
            //Recovering config from file added in project resources and separating each key to use them individually later.
            configFilePath = "./config.json";
            configFileContent = File.ReadAllText(configFilePath);
            jsonData = JsonSerializer.Deserialize<JsonElement>(configFileContent);
            Console.WriteLine("Config found, data value :");
            Console.WriteLine(jsonData);
        }

        public string GetValueBasedOnKey(string key)
        {
            if (jsonData.TryGetProperty(key, out JsonElement value))
            {
                return value.ToString();
            }
            {
                Console.WriteLine("Key not found, returned null value.");
                return null;
            }
        }
            
    }
}