using System;
using System.Reflection;
using Autofac;

namespace MetaWeatherConsole
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>();

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(MetaWeatherLibrary)))
                //.Where(w => w.Namespace.Contains("nameOfNamespace"))  //wenn nach namespaces gefiltert werden soll
                .As(a => Array.Find(a.GetInterfaces(), f => f.Name == "I" + a.Name));

            return builder.Build();
        }
    }
}