using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Main;
using Microsoft.Extensions.DependencyInjection;

namespace MetaWeatherConsole
{
    public static class Program
    {
        private static void Main()
        {
            //autofac getting started: https://autofaccn.readthedocs.io/en/latest/integration/netcore.html

            var serviceCollection = new ServiceCollection();
            ServicesConfig.Configure(ref serviceCollection);

            var containerBuilder = new ContainerBuilder();
            // Make your Autofac registrations. Order is important!
            // If you make them BEFORE you call Populate, then the
            // registrations in the ServiceCollection will override Autofac
            // registrations; if you make them AFTER Populate, the Autofac
            // registrations will override. You can make registrations
            // before or after Populate, however you choose.
            ContainerConfig.Configure(ref containerBuilder);
            containerBuilder.Populate(serviceCollection);

            // Creating a new AutofacServiceProvider makes the container
            // available to your app using the Microsoft IServiceProvider
            // interface so you can use those abstractions rather than
            // binding directly to Autofac.
            var container = containerBuilder.Build();
            var serviceProvider = new AutofacServiceProvider(container);

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.Run();
            }

            Console.ReadLine();
        }
    }
}