using JamnationApp.Core.Interfaces;
using JamnationApp.Core.ViewModels;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static JamnationApp.Core.Models.Events;

namespace JamnationApp.Core.Services
{
    public class SignalRService : BaseViewModel, ISignalRService
    {
        private string URL { get; set; }
        private HubConnection Connection;
        private IHubProxy ChatHubProxy;

        public event MessageReceived OnMessageReceived;

        public SignalRService()
        {
            URL = "http://jammr.azurewebsites.net:9995/";
            Connection = new HubConnection(URL);

            Connection.StateChanged += (StateChange obj) => {
                OnPropertyChanged("ConnectionState");
            };

            ChatHubProxy = Connection.CreateHubProxy("Chat");
            ChatHubProxy.On<string, string>("MessageReceived", (username, text) => {
                OnMessageReceived?.Invoke(username, text);
            });
            Start();
        }

        public void SendMessage(string username, string text)
        {
            ChatHubProxy.Invoke("SendMessage", username, text);
        }

        public Task Start()
        {
            return Connection.Start();
        }

        public bool IsConnectedOrConnecting()
        {
            return Connection.State != ConnectionState.Disconnected;
        }

        public ConnectionState ConnectionState { get { return Connection.State; } }
        
        

    }
}
