using BlankXamarinApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BlankXamarinApp.Core.ViewModels.Events
{
    public class EventsViewModel :BaseViewModel
    {
        private IAppNavigation Navi { get; set; }
        private IPageFactory Page { get; set; }

        public bool ShowNearby { get; set; }
        public bool ShowHistory { get; set; }
        public ImageSource ToggleListsIcon { get; set; }

        public ICommand ToggleListsCommand { get { return new Command(ToggleLists); } }



        public EventsViewModel(IPageFactory _page, IAppNavigation _navi)
        {
            Navi = _navi;
            Page = _page;
            
            ShowNearby = false;
            ShowHistory = true;
            ToggleListsIcon = ImageSource.FromFile("Nearby");
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
