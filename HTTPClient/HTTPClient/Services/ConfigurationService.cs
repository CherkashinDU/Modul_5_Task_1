using System.IO;
using Newtonsoft.Json;

namespace HTTPClient
{
    public class ConfigurationService
    {
        public Settings GetSettings()
        {
            var filePath = "Configs\\settings.json";
            var content = File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<Settings>(content);
        }
    }
}
