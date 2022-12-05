using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using TestBehiveAPIs;
using BehiveDataImporter.IOModels;
using Newtonsoft.Json;

namespace BehiveDataImporter.Helper
{
    public class CommonHelper
    {
        public static TokenResponse LoginBehive(string baseAddress)
        {
            TokenResponse token = new TokenResponse();
            using (var client = new HttpClient())
            {
                Dictionary<string, string> form = new Dictionary<string, string>();
                form.Add("grant_type", "password");
                form.Add("username", "demo_vsepl_b83678d0-762f-4a2e-a0a7-0d01ce0d9f11");
                form.Add("password", "b2d4f403-2ddc-449b-9a61-333adac2ff1a");

                var tokenResponse = client.PostAsync(baseAddress + "/oauth/token", new FormUrlEncodedContent(form)).Result;
                var tokenString = tokenResponse.Content.ReadAsStringAsync().Result;
                Console.WriteLine("Response = {0}", tokenString);
                token = JsonConvert.DeserializeObject<TokenResponse>(tokenString);
                if (string.IsNullOrEmpty(token.error))
                {
                    Console.WriteLine("Token = {0}", token.access_token);
                    Console.WriteLine("Token Type = {0}", token.token_type);
                    Console.WriteLine("Expires In = {0}", token.expires_in);
                    Session.auth_token = token.access_token;
                }
                else
                {
                    Console.WriteLine("Error = {0}", token.error);
                }
            }
            return token;
        }
        public static string GetRequest(string baseUri, string Route, string query = "")
        {
            using (var client = new HttpClient())
            {
                if (string.IsNullOrEmpty(Session.auth_token))
                {
                    return "Unauthorized Request : Session Auth Token is null";
                }
                //string url = Route + "?from=01-Aug-2020 10:00:00 AM";// (string.IsNullOrEmpty(query) ? "" : "?"+query);
                string url = Route + (string.IsNullOrEmpty(query) ? "" : "?"+query);
                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.auth_token);
                var getdata = client.GetAsync(url).Result;

                if (getdata.IsSuccessStatusCode)
                {
                    return getdata.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    Console.WriteLine("Error");
                    return "fail~"+getdata.Content == null ? "NoContent"
                    : getdata.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }
            }
        }

        public string PostRequest<T>(string baseUri, string Route, T PoIoModel)
        {
            string Status = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);
                var postTask = client.PostAsJsonAsync<T>(Route, PoIoModel);
                postTask.Wait();

                var getdata = postTask.Result;
                if (getdata.IsSuccessStatusCode)
                {
                    return getdata.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    Console.WriteLine("Error");
                    var responseContent = getdata.Content == null ? "NoContent"
                    : getdata.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    //throw new HttpRequestException($"{getdata.StatusCode} (ReasonPhrase: {getdata.ReasonPhrase}, Content: {responseContent})");
                    //return new ResponseBody() { Status = false, Message = responseContent };
                    return responseContent;

                }
            }
        }

    }
}