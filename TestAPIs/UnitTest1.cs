using ChannelEngineServices.api;
using ChannelEngineServices.domain;
using ChannelEngineServices.service;
using ChannelEngineServices.service.impl;
using Microsoft.Practices.EnterpriseLibrary.Common.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace TestAPIs
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestTop5Products()
        {
            string json = File.ReadAllText("Orders.json");
            var ordersJson = JsonConvert.DeserializeObject(json);
            JObject jObject = ((JObject)ordersJson);
            GetOrdersResponse ordersResponse = jObject.ToObject<GetOrdersResponse>();
            IProductsService productsService = new ProductsService();
            List<Product> products = productsService.getTopFiveProducts(ordersResponse.Content);
            Assert.AreEqual(3, products.ToArray()[0].Quantity);

        }
    }
}
