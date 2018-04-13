using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using JamnationApp.Core.Helpers;
using Xamarin;


namespace JamnationApp.Core
{
       [Preserve(AllMembers = true)]
    public class ApiHandler
    {
        private static string API_ADDRESS = "";
        private static string API_KEY = "";
		private static string API_Version = "";

        public ApiHandler()
        {
        }


        /*
		public static async Task<TopWrapper> GetSiteAlerts(string SiteId)
        {
			try
			{
				using (var client = new HttpClient())
				{
					client.BaseAddress = new Uri(API_ADDRESS);

					client.DefaultRequestHeaders.Accept.Clear();
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

					using (HttpResponseMessage response = await client.GetAsync(API_Version+"/accommodation/sites/catalogue/"+SiteId+"?apikey="+API_KEY))
					//using (HttpResponseMessage response = await client.GetAsync("v1.0/accommodation/sites/catalogue/"+SiteId+"?apikey=dsieifj3958f845589dk4k6k"))
					{
						if (response.IsSuccessStatusCode)
						{
							string json = Regex.Replace(response.Content.ReadAsStringAsync().Result, "{ }", "\"\"").Replace("- 6.144576", "-6.144576");

							JObject obj = (JObject)
								JsonConvert.DeserializeObject(json, new JsonSerializerSettings()
									{
										ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
									});

							return obj.ToObject<TopWrapper>();
						}
					}

				}
			}
			catch(Exception ex)
			{
				Insights.Report(ex);
			}
			return null;
        }
        */
    }



    
}