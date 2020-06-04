using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MetaWeatherLibrary.Models;

namespace MetaWeatherLibrary
{
    public class BusinessLogic : IBusinessLogic
    {
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
            RunAPICallAsync().GetAwaiter().GetResult();
            _ConsoleLogger.Log("business logic finnished");
        }

        private async Task RunAPICallAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://www.metaweather.com/api/location/656958/");

            var client = _HttpClientFactory.CreateClient();

            var response = await client.SendAsync(request).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var model = await response.Content.ReadFromJsonAsync<MetaWeatherModel>().ConfigureAwait(false);
                Console.WriteLine(ObjectDumper.Dump(model));
            }
            else
            {
                Console.WriteLine("Error connecting to api: " + response.ReasonPhrase);
            }
        }
    }
}