using System;

namespace MetaWeatherLibrary
{
    public class ConsoleLogger : IConsoleLogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"logging: {message}");
        }
    }
}