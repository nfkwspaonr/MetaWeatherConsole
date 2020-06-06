using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Main
{
    public static class ServicesConfig
    {
        public static void Configure(ref ServiceCollection serviceCollection)
        {
            //serviceCollection.AddLogging();
            serviceCollection.AddHttpClient();
            serviceCollection.AddHttpClient("location",
                c => c.BaseAddress = new Uri("https://www.metaweather.com/api/location/"));
        }
    }
}