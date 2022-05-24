using System;
using HW_9.Models;
using HW_9.Models.Enums;
using HW_9.Providers.Abstractions;
using HW_9.Services.Abstractions;

namespace HW_9.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly IFileService _fileService;
        private readonly LoggerConfig _loggerConfig;
        private IDisposable _fileWriter;

        public LoggerService(
            IFileService fileService,
            IConfigProvider configProvider)
        {
            _fileService = fileService;
            _loggerConfig = configProvider.GetConfig().Logger;
        }

        ~LoggerService()
        {
            _fileService.Close(_fileWriter);
        }

        public void LogError(string message)
        {
            Log(message, LogType.Error);
        }

        public void LogInfo(string message)
        {
            Log(message, LogType.Info);
        }

        public void LogWarning(string message)
        {
            Log(message, LogType.Warning);
        }

        public void SetOutput(string filePath)
        {
            _fileWriter = _fileService.Create(filePath);
        }

        private void Log(string message, LogType logType)
        {
            var logItem = $"{DateTime.UtcNow.ToString(_loggerConfig.TimeFormat)}: {logType.ToString()}: {message}";

            Console.WriteLine(logItem);
            _fileService.Write(_fileWriter, logItem);
        }
    }
}