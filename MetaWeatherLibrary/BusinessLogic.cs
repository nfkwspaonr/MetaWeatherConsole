using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MetaWeatherLibrary.Models;

namespace MetaWeatherLibrary
{
    public class BusinessLogic : IBusinessLogic
    {
        private const string Hamburg = "656958";
        private readonly IConsoleLogger _ConsoleLogger;
        private readonly IHttpClientFactory _HttpClientFactory;

        public BusinessLogic(IConsoleLogger consoleLoger, IHttpClientFactory httpClientFactory)
        {
            _ConsoleLogger = consoleLoger;
            _HttpClientFactory = httpClientFactory;
        }

        public void StartLogic()
        {
            _ConsoleLogger.Log("starting business logic");
            RunAPILocationCallAsync().GetAwaiter().GetResult();
            //RunAPISearchQueryCallAsync().GetAwaiter().GetResult();
            _ConsoleLogger.Log("business logic finnished");
        }

        private async Task RunAPILocationCallAsync()
        {
            var client = _HttpClientFactory.CreateClient("location");
            Console.WriteLine("Enter woeid:");
            var woeId = Console.ReadLine();
            try
            {
                var model = await client.GetFromJsonAsync<LocationModel>(woeId).ConfigureAwait(false);
                Console.WriteLine(ObjectDumper.Dump(model));
            }
            catch (Exception e)
            { Console.WriteLine("Error on api connection: " + e.Message); }
        }

        private async Task RunAPISearchQueryCallAsync()
        {
            var client = _HttpClientFactory.CreateClient("search");
            Console.WriteLine("Enter search string:");
            var searchQuery = "?query=" + Console.ReadLine();
            try
            {
                var model = await client.GetFromJsonAsync<List<SearchQueryItem>>(searchQuery).ConfigureAwait(false);
                Console.WriteLine(ObjectDumper.Dump(model));
            }
            catch (Exception e)
            { Console.WriteLine("Error on api connection: " + e.Message); }
        }
    }
}