using ChannelEngineServices.domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChannelEngineServices.service
{
    public interface IOrdersService
    {
        List<Order> getInProgressOrders();
    }
}
