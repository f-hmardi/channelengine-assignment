using ChannelEngineServices.api;
using ChannelEngineServices.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChannelEngineServices.service.impl
{
    public class ProductsService : IProductsService
    {
        public Content updateStockTo(string merchantProductNo, int stock)
        {
            return ChannelEngineAPIs.PatchProduct(merchantProductNo, stock);
        }

        public List<Product> getTopFiveProducts(List<Order> orders)
        {
            List<Product> products = orders.Select(order => new Product(order.Lines.ElementAt(0).Description, order.Lines.ElementAt(0).Gtin, order.Lines.ElementAt(0).Quantity, order.Lines.ElementAt(0).MerchantProductNo)).ToList();
            return products.OrderByDescending(product => product.Quantity).Take(5).ToList();
        }
    }
}
