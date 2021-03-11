using System.Threading.Tasks;
using TFConsole.Abstractions;

namespace TFConsole
{
    class TFConsoleApp
    {
        readonly ISimpleLogger Logger;

        public TFConsoleApp(ISimpleLogger logger)
        {
            Logger = logger;
        }

        public Task RunAsync(string[] args)
        {
            Logger.Log("Hello World!");

            return Task.CompletedTask;
        }
    }
}
