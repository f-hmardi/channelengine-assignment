using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChannelEngineServices.domain
{
    public class Product
    {

        public string ProductName { get; set; }
        public string GTIN { get; set; }
        public int Quantity { get; set; }

        public String MerchantProductNo { get; set; }

        public string Stock { get; set; }


        public Product(string productName, string gTIN, int quantity, string merchantProductNo)
        {
            ProductName = productName;
            GTIN = gTIN;
            Quantity = quantity;
            MerchantProductNo = merchantProductNo;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }          
    }
}
