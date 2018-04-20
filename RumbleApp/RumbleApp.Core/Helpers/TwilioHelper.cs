using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Humanizer;
using JamnationApp.Core.ViewModels;
using Plugin.DeviceInfo;

namespace JamnationApp.Core.Helpers
{
    public static class TwilioHelper
    {
        public static string Identity { get; private set; }

        public static async Task<string> GetTokenAsync()
        {
            var id = CrossDeviceInfo.Current.Id;

            var tokenEndpoint = $"https://xamarinchat.azurewebsites.net/token?device={id}";

            var http = new HttpClient();
            var data = await http.GetStringAsync(tokenEndpoint);

            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<TwilioResponse>(data);

            Identity = response.Identity?.Trim('"') ?? string.Empty;

            return response?.Token?.Trim('"') ?? string.Empty;
        }
    }

    public class TwilioResponse
    {
        [Newtonsoft.Json.JsonProperty("identity")]
        public string Identity { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("token")]
        public string Token { get; set; } = string.Empty;
    }
    public class Message : BaseViewModel
    {
        string text;

        public string Text
        {
            get { return text; }
            set {  text=value;OnPropertyChanged("Text"); }
        }

        DateTime messageDateTime;

        public DateTime MessageDateTime
        {
            get { return messageDateTime; }
            set { messageDateTime = value; OnPropertyChanged("MessageDateTime"); }
        }

        public string MessageTimeDisplay => MessageDateTime.Humanize();

        bool isIncoming;

        public bool IsIncoming
        {
            get { return isIncoming; }
            set { isIncoming = value; OnPropertyChanged("IsIncoming"); }
        }

        public bool HasAttachement => !string.IsNullOrEmpty(attachementUrl);

        string attachementUrl;

        public string AttachementUrl
        {
            get { return attachementUrl; }
            set { attachementUrl = value; OnPropertyChanged("AttachementUrl"); }
        }

    }
}
