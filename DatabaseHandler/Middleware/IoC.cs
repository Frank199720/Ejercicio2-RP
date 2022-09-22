using Microsoft.Extensions.DependencyInjection;
using DatabaseHandler.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseHandler.Middleware
{
    public static class IoC
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            /* Inyectamos la clase 'App' */
            services.AddSingleton<App>();

            /* Otros servicios de la aplicación de la consola. */
            //services.AddTransient<IUser, User>();

            return services;
        }
    }
}
