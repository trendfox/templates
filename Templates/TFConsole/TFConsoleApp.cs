using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace TFConsole
{
    class TFConsoleApp
    {
        readonly ILogger<TFConsoleApp> Logger;

        public TFConsoleApp(ILogger<TFConsoleApp> logger)
        {
            Logger = logger;
        }

        public Task RunAsync()
        {
            Logger.LogInformation("Hello World!");

            return Task.CompletedTask;
        }
    }
}
