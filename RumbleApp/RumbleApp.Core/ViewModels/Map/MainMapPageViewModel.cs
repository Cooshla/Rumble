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


        public List<Pin> Items { get; set; }
        public bool ShowMap { get; set; }
        public ImageSource ShowMapIcon { get; set; }
        public List<Event> AllEvents { get; set; }

        private IAppNavigation Navi { get; set; }
        private IPageFactory Page { get; set; }
        private IEventService Evnt { get; set; }


        public MainMapPageViewModel(IPageFactory _page, IAppNavigation _navi, IEventService _evnt)
        {
            Navi = _navi;
            Page = _page;
            Evnt = _evnt;
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
        }


        private async Task GetData()
        {
            App.UserDialogService.ShowLoading();
            Items = new List<Pin>();
            ShowMap = true;
            ShowMapIcon = ImageSource.FromFile("list");
            AllEvents = await Evnt.GetAllEvents();

            foreach(Event evt in AllEvents)
            {
                Items.Add(new Pin() { Address = evt.Location, Label = evt.Name, Type = PinType.Place, Position = new Position(evt.Latitude, evt.Longitude) });
            }

            OnPropertyChanged("ShowMap");
            OnPropertyChanged("ShowMapIcon");
            OnPropertyChanged("Items");
            MessagingCenter.Send<MainMapPageViewModel, List<Pin>>(this, Messages.MapPinsReady, Items);
            App.UserDialogService.HideLoading();
        }



        public async void AddEvent()
        {
            await Navi.PushModal(Page.GetPage(Pages.AddEventPage));
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
