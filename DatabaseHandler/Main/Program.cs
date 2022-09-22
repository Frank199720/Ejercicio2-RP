﻿using System.IO;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.Extensions.Configuration.Json;
using DatabaseHandler.Middleware;

namespace DatabaseHandler.Main
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();
            await serviceProvider.GetService<App>().RunAsync(args);
        }

        public static IConfiguration LoadConfiguration()
        {
            var directory = Directory.GetCurrentDirectory();
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                    .AddJsonFile("AppSettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            var config = LoadConfiguration();
            services.AddSingleton(config);

            /* Lectura de opciones del archivo de configuración. */
            var data = config.GetSection($"CollectionConnectionStrings").Value;
            services.Configure<ConnectionStringCollection>(options => config.GetSection($"CollectionConnectionStrings").Bind(options));

            /* Contenedor de inversión de control (IoC) => Middleware. */
            IoC.AddDependency(services);

            return services;
        }
    }
}