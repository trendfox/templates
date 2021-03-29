using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using TFConsole.Abstractions;
using TFConsole.Services;

namespace TFConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var config = CreateConfiguration(args);
            var services = new ServiceCollection();

            ConfigureOptions(services, config);
            ConfigureServices(services);
            
            var provider = services.BuildServiceProvider();
            var app = provider.GetRequiredService<TFConsoleApp>();
            
            await app.RunAsync();
        }

        private static IConfigurationRoot CreateConfiguration(in string[] args)
        {
            return new ConfigurationBuilder()
                .AddCommandLine(args, null)
                .Build();
        }

        private static void ConfigureOptions(IServiceCollection services, IConfiguration config)
        {
            // services.Configure<MyOptions>(config);
            // services.Configure<MyOptions>(config.GetSection("MySection"));
        }

        static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ISimpleLogger, ConsoleLogger>();
            services.AddTransient<TFConsoleApp>();
        }
    }
}
