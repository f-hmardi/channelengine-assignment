using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChannelEngineServices.domain
{
    public class Content
    {
        public String LogId { get; set; }
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public String Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
