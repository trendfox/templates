using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;
using Prism.Ioc;
using System;

namespace TFWpf;

public static class ContainerRegistryExtensions
{
    public static IContainerRegistry AddLogging(this IContainerRegistry containerRegistry, IConfiguration config)
    {
        var logLevel = Enum.Parse<LogLevel>(config
            .GetSection("Logging")
            .GetSection("LogLevel")
            .GetSection("Default")
            .Value);

        containerRegistry.RegisterSingleton<LoggerFilterOptions>(cr =>
            new LoggerFilterOptions()
            {
                MinLevel = logLevel
            });

        containerRegistry.RegisterSingleton<ILoggerFactory, LoggerFactory>();
        containerRegistry.RegisterSingleton(typeof(ILogger<>), typeof(Logger<>));
        containerRegistry.RegisterSingleton<ILoggerProvider, EventLogLoggerProvider>();

        return containerRegistry;
    }

    public static IContainerRegistry AddAppServices(this IContainerRegistry containerRegistry)
    {
        return containerRegistry;
    }
}
