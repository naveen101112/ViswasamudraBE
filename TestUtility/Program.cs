using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TestUtility
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using (var client = new HttpClient())
            {
                string url = "/api/masterdata/allnew" + "?from=01-Aug-2000 10:00:00 AM";
                client.BaseAddress = new Uri("https://api.beehivehcm.com");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string auth_token = Console.ReadLine();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", auth_token);
                var getdata = client.GetAsync(url).Result;

                if (getdata.IsSuccessStatusCode)
                {
                    string bbc = getdata.Content.ReadAsStringAsync().Result;
                    //Console.WriteLine(bbc);
                    var lst = JsonConvert.
                    DeserializeObject<ResponseModel>(bbc);

                    var typ = typeof(ResponseModel);
                    
                    var bindingFlags = System.Reflection.BindingFlags.Instance |
                                System.Reflection.BindingFlags.NonPublic |
                                System.Reflection.BindingFlags.Public;
                    List<string> listNames = lst.GetType().GetFields(bindingFlags).Select(field => field.Name.Replace(">k__BackingField", "").Replace("<", "")).Where(value => value != null).ToList();
                    foreach (string name in listNames)
                    {
                        Console.WriteLine(name);
                        try
                        {
                            Console.WriteLine(((List<object>)typ.GetProperty(name).GetValue(lst))[0].ToString());
                        }catch(Exception e)
                        {
                            Console.WriteLine("Ignored");
                        }
                    }


                    foreach (var item in lst.Zone)
                    {
                        Console.WriteLine("Zone: " + item.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("Error");
                    Console.WriteLine("fail~" + getdata.Content == null ? "NoContent"
                    : getdata.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                }
            }
        }
    }
}
