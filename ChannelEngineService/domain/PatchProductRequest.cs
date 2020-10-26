using System;
using System.Collections.Generic;
using System.Text;

namespace ChannelEngineServices.domain
{
    public class PatchProductRequest
    {
        public Object Value { get; set; }
        public string Path { get; set; }
        public string Op { get; set; }

        public PatchProductRequest(object value, string path, string op)
        {
            Value = value;
            Path = path;
            Op = op;
        }
    }
}
