using ChannelEngineServices.service;
using ChannelEngineServices.service.impl;
using Microsoft.Extensions.DependencyInjection;

namespace ChannelEngineServices.dependecies
{
    public static class ServicesDependency
    {

        public static IServiceCollection AddServiceDependecy(this IServiceCollection services) {
            services.AddSingleton<IOrdersService, OrdersService> ();
            services.AddSingleton<IProductsService, ProductsService>();
            return services;
        }
    }
}
