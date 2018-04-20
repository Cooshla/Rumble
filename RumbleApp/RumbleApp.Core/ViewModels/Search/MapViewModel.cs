using Newtonsoft.Json;
using JamnationApp.Core.Interfaces;
using JamnationApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace JamnationApp.Core.ViewModels
{
    public class MapViewModel : BaseViewModel
    {
        
        private IPageFactory PageFac { get; set; }
        private IAppNavigation Navi { get; set; }
        private IRestService Rest { get; set; }
        private IAccountService Acc { get; set; }
        private IUserService Usr { get; set; }

        public string Looking { get; set; }
        public string Position { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }


        public ICommand SearchCommand { get { return new Command(Search); } }
        public ICommand ListCommand { get { return new Command(List); } }
        public ICommand ResetCommand { get { return new Command(Reset); } }


        public List<JamnationApp.Core.Models.Profile> SearchResults { get; set; }

        public MapViewModel(IPageFactory _page, IAppNavigation _navi, IRestService _rest, IAccountService _acc, IUserService _user)
        {
            PageFac = _page;
            Navi = _navi;
            Rest = _rest;
            Acc = _acc;
            Usr = _user;
            Reset();

            MessagingCenter.Subscribe<SearchViewModel, List<JamnationApp.Core.Models.Profile>>(this, Messages.SearchResults, (sender, arg) => {
                SearchResults = arg;
                Reset();
            });
        }


        async void Search()
        {
            await Navi.PopToRoot();
        }

        async void List()
        {

            await Navi.RemovePage(PageFac.GetPage(Pages.Map));
            await Navi.PushPage(PageFac.GetPage(Pages.List));
        }

        private void Reset()
        {
            Looking = string.Empty;
            Position = string.Empty;
            Location = string.Empty;
            Name = string.Empty;

  
            OnPropertyChanged("Looking");
            OnPropertyChanged("Position");
            OnPropertyChanged("Location");
            OnPropertyChanged("Name");
        }



    }
}