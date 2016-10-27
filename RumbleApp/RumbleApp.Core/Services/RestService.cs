using RumbleApp.Core.Interfaces;
using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RumbleApp.Core.Services
{

    public class RestService : IRestService
    {
        
        Uri baseUrl = new Uri("http://rumbleapi.cooshla.com/");


        public RestService()
        {
        }

        public async Task<T> GetClient<T>(string resource, string jsonRequest = "")
        {
            T result = default(T);

            await Task.Run(async () =>
            {
                var client = new System.Net.Http.HttpClient(new NativeMessageHandler());
                client.BaseAddress = baseUrl;
                if (!string.IsNullOrWhiteSpace(App.Token))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.Token);
                }

                var response = await client.GetAsync(resource);

                var responseJson = response.Content.ReadAsStringAsync().Result;

                result = JsonConvert.DeserializeObject<T>(responseJson);
                client.Dispose();
                if (result == null)
                {
                    throw new Exception();
                }

            });
            return result;
        }

        public async Task<T> PostClient<T>(string resource, string jsonRequest = "")
        {
            T result = default(T);

            await Task.Run(async () =>
            {
                var client = new System.Net.Http.HttpClient(new NativeMessageHandler());
                client.BaseAddress = baseUrl;
                if (!string.IsNullOrWhiteSpace(App.Token))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.Token);
                }

                var content = new StringContent(jsonRequest, Encoding.UTF8, "text/json");
                var response = await client.PostAsync(resource, content);

                var responseJson = response.Content.ReadAsStringAsync().Result;

                result = JsonConvert.DeserializeObject<T>(responseJson);
                client.Dispose();
                if (result == null)
                {
                    throw new Exception();
                }

            });
            return result;
        }

        public async Task<T> PutClient<T>(string resource, string jsonRequest = "")
        {
            T result = default(T);

            await Task.Run(async () =>
            {
                var client = new System.Net.Http.HttpClient(new NativeMessageHandler());
                client.BaseAddress = baseUrl;
                if (!string.IsNullOrWhiteSpace(App.Token))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.Token);
                }

                var content = new StringContent(jsonRequest, Encoding.UTF8, "text/json");
                var response = await client.PutAsync(resource, content);

                var responseJson = response.Content.ReadAsStringAsync().Result;

                result = JsonConvert.DeserializeObject<T>(responseJson);
                client.Dispose();
                if (result == null)
                {
                    throw new Exception();
                }

            });
            return result;
        }
    }
}
