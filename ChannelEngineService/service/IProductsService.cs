using ChannelEngineServices.domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChannelEngineServices.service
{
    public interface IProductsService
    {
        List<Product> getTopFiveProducts(List<Order> order);
        Content updateStockTo(String merchantProductNo, int stock);
    }
}
