using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChannelEngineServices.domain
{
    public class Order
    {
        public int Id { get; set; }
        public string ChannelName { get; set; }
        public string ChannelOrderNo { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }
        public IList<Line> Lines { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
