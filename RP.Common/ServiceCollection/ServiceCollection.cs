using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using RP.Common.Helpers;
using RP.Common.Repository;
using RP.Common.Services;
using RP.Domain.Interfaces.Managment;
using RP.Domain.Interfaces.Repository;
using RP.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP.Common.ServiceCollection
{
    public static class ServiceCollection
    {
        public static void AddCommonLayer(this IServiceCollection services)
        {
            /* Repositorios. */
            services.AddTransient<IProductRepository, ProductRepository>();


            /* Servicios. */
            services.AddTransient<IProductService, ProductService>();

            /* Helpers */
            services.AddSingleton<IUriService>(o =>
            {
                var accessor = o.GetRequiredService<IHttpContextAccessor>();
                var request = accessor.HttpContext.Request;
                var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(uri);
            });
            services.AddScoped(typeof(IDataShapeHelper<>), typeof(DataShapeHelper<>));
        }
    }
}
