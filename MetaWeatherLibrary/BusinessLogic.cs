using System;

namespace MetaWeatherLibrary
{
    public class BusinessLogic : IBusinessLogic
    {
        private readonly IConsoleLogger _ConsoleLogger;

        public BusinessLogic(IConsoleLogger consoleLoger)
        {
            _ConsoleLogger = consoleLoger;
        }

        public void StartLogic()
        {
            _ConsoleLogger.Log("starting business logic");
            Console.WriteLine("... executing business logic ...");
            _ConsoleLogger.Log("business logic finnished");
        }
    }
}