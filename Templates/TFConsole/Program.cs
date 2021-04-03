using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace TFConsole
{
    class Program
    {
        static IConfiguration Configuration;

        static async Task Main(string[] args)
        {
            Configuration = CreateConfiguration(args);
            var services = new ServiceCollection();

            ConfigureOptions(services);
            ConfigureServices(services);
            
            var provider = services.BuildServiceProvider();
            var app = provider.GetRequiredService<TFConsoleApp>();
            
            await app.RunAsync();
        }

        private static IConfigurationRoot CreateConfiguration(in string[] args)
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddCommandLine(args, null)
                .Build();
        }

        private static void ConfigureOptions(IServiceCollection services)
        {
            //services.AddOptions<MyOptions>()
            //    .Bind(Configuration.GetSection("MySection"))
            //    .ValidateDataAnnotations();
        }

        static void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(options =>
            {
                options
                    .AddConfiguration(Configuration.GetSection("Logging"))
                    .AddConsole();
            });

            services.AddTransient<TFConsoleApp>();
        }
    }
}
