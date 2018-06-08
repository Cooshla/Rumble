
using JamnationApp.Core.Interfaces;
using JamnationApp.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace JamnationApp.Core.ViewModels
{
    public class ListViewModel : BaseViewModel
    {
        
        private IPageFactory PageFac { get; set; }
        private IAppNavigation Navi { get; set; }
        private IRestService Rest { get; set; }
        private IAccountService Acc { get; set; }
        private IUserService Usr { get; set; }



        public string SearchBreadcrumbs { get; set; }

        public ICommand SearchCommand { get { return new Command(Search); } }
        public ICommand MapCommand { get { return new Command(Map); } }
        public ICommand ResetCommand { get { return new Command(Reset); } }

        public List<JamnationApp.Core.Models.Profile> SearchResults { get; set; }

        public ListViewModel(IPageFactory _page, IAppNavigation _navi, IRestService _rest, IAccountService _acc, IUserService _user)
        {
            PageFac = _page;
            Navi = _navi;
            Rest = _rest;
            Acc = _acc;
            Usr = _user;


            Reset();

            
            MessagingCenter.Subscribe<JamnationApp.Core.UI.Pages.Search.ListView, JamnationApp.Core.Models.Profile>(this, Messages.ProfileClicked, (sender, arg) => {
                ShowProfile(arg);
            });

            MessagingCenter.Subscribe<SearchViewModel, List<JamnationApp.Core.Models.Profile>>(this, Messages.SearchResults, (sender, arg)=> {
                SearchResults = arg;
                Reset();
            });


            MessagingCenter.Subscribe<ProfileViewModel, JamnationApp.Core.Models.Profile>(this, Messages.FriendRequestsent, (sender, arg) => {
                
                foreach(var res in SearchResults)
                {
                    if(res.ProfileId==arg.ProfileId)
                    {
                        res.Friend = arg.Friend;
                        OnPropertyChanged("SearchResults");
                        break;
                    }
                }
            });
        }


        async void Search()
        {
            await Navi.PopToRoot();
        }

        async void Map()
        {
            await Navi.PushPage(PageFac.GetPage(Pages.Map));
        }

        async void ShowProfile(JamnationApp.Core.Models.Profile profile)
        {
            MessagingCenter.Send<ListViewModel, JamnationApp.Core.Models.Profile>(this, Messages.ProfileClicked, profile);
            await Navi.PushPage(PageFac.GetPage(Pages.ProfilePage));
        }

        private void Reset()
        {

            SearchBreadcrumbs = App.SearchTermBreadcrumbs;



            OnPropertyChanged("SearchBreadcrumbs");
            OnPropertyChanged("SearchResults");
            OnPropertyChanged("Looking");
            OnPropertyChanged("Position");
            OnPropertyChanged("Location");
            OnPropertyChanged("Name");
        }



    }
}
