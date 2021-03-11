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
            var services = new ServiceCollection();
            
            ConfigureServices(services);
            
            var provider = services.BuildServiceProvider();
            var app = provider.GetRequiredService<TFConsoleApp>();
            
            await app.RunAsync(args);
        }

        static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ISimpleLogger, ConsoleLogger>();
            services.AddTransient<TFConsoleApp>();
        }
    }
}
