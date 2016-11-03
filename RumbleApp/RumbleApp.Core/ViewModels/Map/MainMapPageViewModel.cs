using RumbleApp.Core.Abstracts;
using RumbleApp.Core.Interfaces;
using RumbleApp.Core.Models;
using RumbleApp.Core.Services;
using RumbleApp.Core.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace RumbleApp.Core.ViewModels.Map
{
    public class MainMapPageViewModel:BaseViewModel
    {

        public ICommand AddEventCommand { get { return new Command(AddEvent); } }
        public ICommand ShowMapCommand { get { return new Command(ShowMapEvent); } }


        public List<CustomPin> Items { get; set; }
        public bool ShowMap { get; set; }
        public ImageSource ShowMapIcon { get; set; }
        public List<Event> AllEvents { get; set; }
        public List<RumbleApp.Core.Models.Profile> AllProfiles { get; set; }

        private IAppNavigation Navi { get; set; }
        private IPageFactory Page { get; set; }
        private IEventService Evnt { get; set; }
        private IProfileService Prof { get; set; }

        public MainMapPageViewModel(IPageFactory _page, IAppNavigation _navi, IEventService _evnt, IProfileService _prof)
        {
            Navi = _navi;
            Page = _page;
            Evnt = _evnt;
            Prof = _prof;
            RegisterMessageCenter();
            
        }


        public void RegisterMessageCenter()
        {
            MessagingCenter.Subscribe<MainPage, bool>(this, Messages.HomeClicked, async (sends, arg) =>
            {
                await GetData();
            });


            MessagingCenter.Subscribe<AccountService, bool>(this, Messages.LoginSuccessful, async (sends, arg) =>
            {
                await GetData();
            });


            MessagingCenter.Subscribe<MainMapPageViewModel, string>(this, Messages.MapEventsClicked, async (sends, arg) =>
            {
                await Navi.GoToEventPage(arg);
            });


            MessagingCenter.Subscribe<MainMapPageViewModel, string>(this, Messages.MapProfileClicked, async (sends, arg) =>
            {
                await Navi.GoToProfilePage(arg);
            });
        }


        private async Task GetData()
        {

            App.UserDialogService.ShowLoading();
            Items = new List<CustomPin>();
            ShowMap = true;
            ShowMapIcon = ImageSource.FromFile("list");
            AllEvents = await Evnt.GetAllEvents();
            
            foreach(Event evt in AllEvents)
            {
                var pin = new CustomPin
                {
                    Pin = new Pin() { Address = evt.Location, Label = evt.Name, Type = PinType.Place, Position = new Position(evt.Latitude, evt.Longitude) },
                    Id = evt.EventId.ToString(),
                    Type="Event"
                };

                
                Items.Add(pin);
            }

            AllProfiles = await Prof.GetAllProfiles();

            foreach (RumbleApp.Core.Models.Profile usr in AllProfiles)
            {
                var pin = new CustomPin
                {
                    Pin = new Pin() { Address = usr.Location, Label = string.Format("{0} {1}", usr.FirstName, usr.LastName), Type = PinType.Place, Position = new Position(usr.Latitude, usr.Longitude) },
                    Id = usr.ProfileId.ToString(),
                    Type = "Profile"
                };
                
                Items.Add(pin);

            }

            OnPropertyChanged("ShowMap");
            OnPropertyChanged("ShowMapIcon");
            OnPropertyChanged("Items");
            MessagingCenter.Send<MainMapPageViewModel, List<CustomPin>>(this, Messages.MapPinsReady, Items);
            App.UserDialogService.HideLoading();
        }
        

        public async void AddEvent()
        {
            await Navi.PushPage(Page.GetPage(Pages.AddEventPage));
        }

        public  void ShowMapEvent()
        {
            ShowMap = !ShowMap;

            if(ShowMap)
                ShowMapIcon = ImageSource.FromFile("list.png");
            else
                ShowMapIcon = ImageSource.FromFile("map.png");

            OnPropertyChanged("ShowMap");
            OnPropertyChanged("ShowMapIcon");
        }
    }
}
