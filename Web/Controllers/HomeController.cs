using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ChannelEngineServices.domain;
using ChannelEngineServices.service;
using ChannelEngineServices.service.impl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOrdersService _ordersService;
        private readonly IProductsService  _productsService;

        public HomeController(ILogger<HomeController> logger, IOrdersService ordersService,IProductsService productsService)
        {
            _logger = logger;
            _ordersService = ordersService;
            _productsService = productsService;
        }

        public IActionResult Index()
        {
            List<Order> orders = _ordersService.getInProgressOrders();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Orders()
        {
            List<Order> orders = _ordersService.getInProgressOrders();
            return View(orders);
        }
        public IActionResult Products()
        {
            List<Order> orders = _ordersService.getInProgressOrders();
            List<Product> products = _productsService.getTopFiveProducts(orders);
            return View(products);
        }

      
        public IActionResult SetStock(string id)
        {
            Content content = _productsService.updateStockTo(id, 25);
            if (content.Success)
                TempData["MSG"] = " Update successfully";
            else
                TempData["MSG"] = " Update not successfully";

            return Redirect("/Home/Products");
        }
    }
}
