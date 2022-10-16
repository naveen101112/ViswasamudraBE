using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Data;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

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

        //public ActionResult UpdateRequest()
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://localhost:64189/api/student");

        //        //HTTP POST
        //        var postTask = client.PostAsJsonAsync<T>("student", student);
        //        postTask.Wait();

        //        var result = postTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //    }

        //    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

        //    return View(student);
        //}

    }
}