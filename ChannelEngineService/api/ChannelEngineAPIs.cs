using ChannelEngineServices.domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ChannelEngineServices.api
{
    
    public class ChannelEngineAPIs
    {
        private const string BASE_URL = "https://api-dev.channelengine.net/api/v2/";
        private const string ORDER_ENDPOINT = "orders";
        private const string PRODUCT_ENDPOINT = "products";
        private static string API_KEY_PARAM = "api_key=541b989ef78ccb1bad630ea5b85c6ebff9ca3322";
        private static string IN_PROGRESS_ORDER_PARAM = "statuses=IN_PROGRESS";


        private static HttpClient GetClient() {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public static List<Order> GetInProgressOrders()
        {
            
            string url = ORDER_ENDPOINT+"?" + API_KEY_PARAM + "&" + IN_PROGRESS_ORDER_PARAM;
            HttpResponseMessage response = GetClient().GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var dataObject = response.Content.ReadAsAsync<GetOrdersResponse>().Result;
                return dataObject.Content;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return null;
        }

        public static Product GetProduct(string merchantProductNo)
        {
            string url = PRODUCT_ENDPOINT+ "/" + merchantProductNo + "?" + API_KEY_PARAM;
            HttpResponseMessage response = GetClient().GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var dataObject = response.Content.ReadAsAsync<GetProductResponse>().Result;
                return dataObject.Content;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return null;
        }

        public static Content PatchProduct(string  merchantProductNo, int stock)
        {
            string url = PRODUCT_ENDPOINT+"/"+ merchantProductNo + "?" + API_KEY_PARAM;

            IList<PatchProductRequest> patchProductRequests = new List<PatchProductRequest>();
            PatchProductRequest request = new PatchProductRequest(stock,"Stock","replace");
            patchProductRequests.Add(request);
            var requestContent = new StringContent(JsonConvert.SerializeObject(patchProductRequests));
            requestContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            HttpResponseMessage response = GetClient().PatchAsync(url, requestContent).Result;
            if (response.IsSuccessStatusCode)
            {
                var dataObject = response.Content.ReadAsAsync<Content>().Result;
                return dataObject;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int) response.StatusCode, response.ReasonPhrase);
            }
            return null;
        }
    }

    
}
