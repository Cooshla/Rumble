using RumbleApp.Core.Interfaces;
using RumbleApp.Core.Models;
using RumbleApp.Core.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace RumbleApp.Core.ViewModels.Events
{
    public class EventsViewModel :BaseViewModel
    {
        private IAppNavigation Navi { get; set; }
        private IPageFactory Page { get; set; }

        private IEventService Evnt { get; set; }

        public bool ShowNearby { get; set; }
        public bool ShowHistory { get; set; }
        public ImageSource ToggleListsIcon { get; set; }

        public ICommand ToggleListsCommand { get { return new Command(ToggleLists); } }

        public List<Event> Events { get; set; }

        public EventsViewModel(IPageFactory _page, IAppNavigation _navi,IEventService _evnt)
        {
            Navi = _navi;
            Page = _page;
            Evnt = _evnt;
            RegisterMessageCenter();
        }

        public void RegisterMessageCenter()
        {
            MessagingCenter.Subscribe<MainPage, bool>(this, Messages.EventsClicked, async (sends, arg) =>
            {
                await GetData();
            });
        }

        private async Task GetData()
        {
            App.UserDialogService.ShowLoading();
            ShowNearby = false;
            ShowHistory = true;
            ToggleListsIcon = ImageSource.FromFile("Nearby");
            Events = await Evnt.GetAllEventsAttendedByUser(App.ThisUser.ID);
            App.UserDialogService.HideLoading();
        }

        public void ToggleLists()
        {

            ShowNearby = !ShowNearby;
            ShowHistory = !ShowNearby;

            if (!ShowNearby)
                ToggleListsIcon = ImageSource.FromFile("Nearby.png");
            else
                ToggleListsIcon = ImageSource.FromFile("history.png");

            OnPropertyChanged("ShowNearby");
            OnPropertyChanged("ShowHistory");
            OnPropertyChanged("ToggleListsIcon");
        }
    }
}
