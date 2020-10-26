using System;
using System.Collections.Generic;
using System.Text;

namespace ChannelEngineServices.domain
{
    public class GetOrdersResponse : Content
    {
        public List<Order> Content { get; set; }
    }
}
