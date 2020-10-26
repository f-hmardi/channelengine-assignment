using ChannelEngineServices.domain;
using ChannelEngineServices.api;
using ChannelEngineServices.service;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;
using ChannelEngineServices.dependecies;
using ChannelEngineServices.service.impl;

namespace ConsoleApp
{
    public class Program
    {

        static void Main(string[] args)
        {

            var services = new ServiceCollection();
            services.AddServiceDependecy();
            // Generate a provider
            var serviceProvider = services.BuildServiceProvider();

            var ordersService = serviceProvider.GetService<IOrdersService>();
            var productsService = serviceProvider.GetService<IProductsService>();
            List<Order> orders = ordersService.getInProgressOrders();
            Console.WriteLine("----- In Progress Orders -----");
            foreach (Order order in orders)
            {
                Console.WriteLine(order);
            }

            Console.WriteLine("----- Top Five Products -----");
            List<Product> products = productsService.getTopFiveProducts(orders);
            foreach (Product product in products)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine("----- Update stock of the product with merchantProductNo ={0} to 25 -----", products.ToArray()[0].MerchantProductNo);
            Content content = productsService.updateStockTo(products.ToArray()[0].MerchantProductNo, 25);
            Console.WriteLine(content);


        }
    }
}
