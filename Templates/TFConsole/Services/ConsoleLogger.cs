using System;
using TFConsole.Abstractions;

namespace TFConsole.Services
{
    class ConsoleLogger
        : ISimpleLogger
    {
        public void Log(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
