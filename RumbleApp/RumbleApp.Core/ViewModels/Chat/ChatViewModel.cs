using JamnationApp.Core.Helpers;
using JamnationApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.Geolocator;
using Xamarin.Forms;
using System.Globalization;


namespace JamnationApp.Core.ViewModels.Profile
{
    public class ChatViewModel : BaseViewModel
    {

        public ObservableCollection<Message> TheseMessages { get; set; }

        string outgoingText = string.Empty;

        public string OutGoingText
        {
            get { return outgoingText; }
            set { outgoingText= value; OnPropertyChanged("OutGoingText"); }
        }

        public ICommand SendCommand { get; set; }

        public ICommand LocationCommand { get; set; }
        public ISignalRService SignalRClient { get; set; }
        public ChatViewModel(ISignalRService _SignalR)
        {

            SignalRClient = _SignalR;
            SignalRClient.Start().ContinueWith(task => {
                if (task.IsFaulted)
                    App.UserDialogService.AlertAsync("Error", "An error occurred when trying to connect to SignalR: " + task.Exception.InnerExceptions[0].Message, "OK");
            });

            //try to reconnect every 10 seconds, just in case
            Device.StartTimer(TimeSpan.FromSeconds(10), () => {
                if (!SignalRClient.IsConnectedOrConnecting())
                    SignalRClient.Start();

                return true;
            });

            
            SignalRClient.OnMessageReceived += (username, message) => {
                TheseMessages.Add(new Message() { Text = username + ": " + message, MessageDateTime = DateTime.Now, IsIncoming = true });
                OnPropertyChanged("TheseMessages");
            };

            TheseMessages = new ObservableCollection<Message>();

            SendCommand = new Command(() =>
            {
                TheseMessages.Add(new Message() { Text = "Me: " + OutGoingText, IsIncoming = false, MessageDateTime=DateTime.Now);
                SignalRClient.SendMessage(App.ThisUser.Email, OutGoingText);
                OnPropertyChanged("TheseMessages");
            });


            LocationCommand = new Command(async () =>
            {
                try
                {
                    var local = await CrossGeolocator.Current.GetPositionAsync();
                    var map = $"https://maps.googleapis.com/maps/api/staticmap?center={local.Latitude.ToString(CultureInfo.InvariantCulture)},{local.Longitude.ToString(CultureInfo.InvariantCulture)}&zoom=17&size=400x400&maptype=street&markers=color:red%7Clabel:%7C{local.Latitude.ToString(CultureInfo.InvariantCulture)},{local.Longitude.ToString(CultureInfo.InvariantCulture)}&key=";

                    var message = new Message
                    {
                        Text = "I am here",
                        AttachementUrl = map,
                        IsIncoming = false,
                        MessageDateTime = DateTime.Now
                    };

                    TheseMessages.Add(message);
                    //App.TwilioMessenger?.SendMessage("attach:" + message.AttachementUrl);

                }
                catch (Exception ex)
                {

                }
            });
            /*

            if (App.TwilioMessenger == null)
                return;

            App.TwilioMessenger.MessageAdded = (message) =>
            {
                TheseMessages.Add(message);
            };*/
        }


        public void InitializeMock()
        {
            this.TheseMessages = new ObservableCollection<Message>()
                {
                    new Message { Text = "Hi Squirrel! \uD83D\uDE0A", IsIncoming = true, MessageDateTime = DateTime.Now.AddMinutes(-25)},
                    new Message { Text = "Hi Baboon, How are you? \uD83D\uDE0A", IsIncoming = false, MessageDateTime = DateTime.Now.AddMinutes(-24)},
                    new Message { Text = "We've a party at Mandrill's. Would you like to join? We would love to have you there! \uD83D\uDE01", IsIncoming = true, MessageDateTime = DateTime.Now.AddMinutes(-23)},
                    new Message { Text = "You will love it. Don't miss.", IsIncoming = true, MessageDateTime = DateTime.Now.AddMinutes(-23)},
                    new Message { Text = "Sounds like a plan. \uD83D\uDE0E", IsIncoming = false, MessageDateTime = DateTime.Now.AddMinutes(-23)},

                    new Message { Text = "\uD83D\uDE48 \uD83D\uDE49 \uD83D\uDE49", IsIncoming = false, MessageDateTime = DateTime.Now.AddMinutes(-23)},

            };
        }

    }
    public class ChatMessages
    {
        public string Content { get; set; }
        public string From { get; set; }
        public string Time { get; set; }
        public int Type { get; set; }
        
        public ChatMessages()
        {

        }
    }
    
}
