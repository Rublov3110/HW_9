using HW_9.Providers;
using HW_9.Providers.Abstractions;
using HW_9.Services;
using HW_9.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace HW_9
{
    public class Starter
    {
        public void Run()
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<IFileService, FileService>()
                .AddSingleton<IConfigProvider, ConfigProvider>()
                .AddSingleton<ILoggerService, LoggerService>()
                .AddTransient<Actions>()
                .AddTransient<App>()
                .BuildServiceProvider();
            var app = serviceProvider.GetService<App>();

            app?.Run();
        }
    }
}