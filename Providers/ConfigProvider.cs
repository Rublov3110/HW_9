using HW_9.Models;
using HW_9.Providers.Abstractions;
using HW_9.Services.Abstractions;
using Newtonsoft.Json;

namespace HW_9.Providers
{
    public class ConfigProvider : IConfigProvider
    {
        private const string ConfigPath = "config.json";
        private readonly IFileService _fileService;

        public ConfigProvider(IFileService fileService)
        {
            _fileService = fileService;
            Config = LoadFromFile();
        }

        private Config Config { get; init; }

        public Config GetConfig()
        {
            return Config;
        }

        private Config LoadFromFile()
        {
            var configFile = _fileService.Read(ConfigPath);

            return JsonConvert.DeserializeObject<Config>(configFile);
        }
    }
}