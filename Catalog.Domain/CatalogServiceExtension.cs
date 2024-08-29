using Catalog.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain
{
    public static class CatalogServiceExtension
    {
        public static IServiceCollection AddCatalogServices (this IServiceCollection services)
        {
            services.AddScoped<ICatalogService, CatalogService>();

            return services;
        }
    }
}
