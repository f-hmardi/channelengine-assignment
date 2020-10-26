using ChannelEngineServices.api;
using ChannelEngineServices.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChannelEngineServices.service.impl
{
    public class OrdersService : IOrdersService
    {
        public List<Order> getInProgressOrders()
        {
            return ChannelEngineAPIs.GetInProgressOrders();
        }
    }
}
