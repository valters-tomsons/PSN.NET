using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PSN.NET
{
    public class ChihiroAPIClient
    {
        private const string BaseUrl = "https://store.playstation.com/chihiro-api/viewfinder/";

        public ChihiroAPIClient(bool DisableIntro = false)
        {
            if(!DisableIntro)
            {
                Console.WriteLine("[PSN.NET] ChihiroAPI Client Started");
            }
        }

        //Regions to region codes dict
        Dictionary<string, string> RegionCodes = new Dictionary<string, string>()
        {
            { "EU" , "GB/en" },
            { "US", "CA/en" },
            { "JP", "JP/jp" },
            { "ASIA", "JP/jp" }
        };

        public PSNItem GetItem(string ContentID, string Region, string age)
        {
            return GetPSNItem(ContentID, Region, age).Result;
        }

        private async Task<PSNItem> GetPSNItem(string ContentID, string Region, string age)
        {
            PSNItem item = new PSNItem();
            NetworkResponse response = await GetResponse(ContentID, Region, age);
            
            if(response.ResponseCode == "OK")
            {
                string body = response.Body;
                item = PSNItem.FromJson(body);
                return item;
            }
            else
            {
                return null;
            }

        }

        private async Task<NetworkResponse> GetResponse(string ContentID, string Region, string age)
        {
            NetworkResponse RESTResponse = new NetworkResponse();
            Uri RequestURL = new Uri($"{BaseUrl}/{RegionCodes[Region]}/{age}/{ContentID}");

            HttpClient client = new HttpClient();
            HttpResponseMessage Response = null;
            client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent","PSN.NET Library");

            try
            {
                Response = await client.GetAsync(RequestURL);
                Response.EnsureSuccessStatusCode();

                string ResponseBody = await Response.Content.ReadAsStringAsync();
                RESTResponse.ResponseCode = Response.StatusCode.ToString();
                RESTResponse.Body = ResponseBody;

                client.Dispose();
                return RESTResponse;

            }
            catch(HttpRequestException e)
            {
                RESTResponse.ResponseCode = Response.StatusCode.ToString();
                RESTResponse.Exception = e.Message;
                return RESTResponse;
            }
        }




    }
}
