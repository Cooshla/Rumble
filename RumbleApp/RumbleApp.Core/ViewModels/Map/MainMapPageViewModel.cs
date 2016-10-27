using RumbleApp.Core.Interfaces;
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

        private IAppNavigation Navi { get; set; }
        private IPageFactory Page { get; set; }


        public MainMapPageViewModel(IPageFactory _page, IAppNavigation _navi)
        {
            Navi = _navi;
            Page = _page;

            Items = new List<Pin>();
            ShowMap=true;
            ShowMapIcon = ImageSource.FromFile("list");
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
