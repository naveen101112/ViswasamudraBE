using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Data;
using System.Collections.Generic;

namespace ViswaSamudraUI
{
    public class CommonHelper
    {
        public static IConfiguration configuration { get; set; }
        
        String baseUri = configuration["urls"];

        public IEnumerable<T> GetRequest<T>(String Route)
        {
            IEnumerable<T> ModelList = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var getdata = client.GetAsync(Route).Result;
                

                if (getdata.IsSuccessStatusCode)
                {
                    string result = getdata.Content.ReadAsStringAsync().Result;
                    ModelList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(result);                     
                }
                else
                {
                    Console.WriteLine("Error");
                }
                return ModelList;
            }
        }
    }
}
