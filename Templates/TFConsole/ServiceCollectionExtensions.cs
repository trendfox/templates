using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TFConsole;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppLogging(this IServiceCollection services, IConfiguration config)
    {
        services.AddLogging(options =>
        {
            options.AddConfiguration(config.GetSection("Logging"));
            options.AddConsole();
        });
        return services;
    }

    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddSingleton<App>();
        return services;
    }
}