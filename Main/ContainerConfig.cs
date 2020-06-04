using System;
using System.Net.Http;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MetaWeatherLibrary;

namespace MetaWeatherConsole
{
    public static class ContainerConfig
    {
        public static void Configure(ref ContainerBuilder builder)
        {
            //var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<ConsoleLogger>().As<IConsoleLogger>();
            builder.RegisterType<BusinessLogic>().As<IBusinessLogic>();

            //builder.RegisterAssemblyTypes(Assembly.Load(nameof(MetaWeatherLibrary)))
            //    //.Where(w => w.Namespace.Contains("nameOfNamespace"))  //wenn nach namespaces gefiltert werden soll
            //    .As(a => Array.Find(a.GetInterfaces(), f => f.Name == "I" + a.Name));
        }
    }
}