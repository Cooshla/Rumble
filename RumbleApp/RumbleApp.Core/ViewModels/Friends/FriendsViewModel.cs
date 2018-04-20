using JamnationApp.Core.Interfaces;
using JamnationApp.Core.UI;
using JamnationApp.Core.UI.Pages.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JamnationApp.Core.ViewModels.Profile
{
    public class FriendsViewModel : BaseViewModel
    {

        private IAppNavigation Navi { get; set; }
        private IPageFactory Page { get; set; }

        public List<JamnationApp.Core.Models.Profile> SearchResults { get; set; }
        public FriendsViewModel(IPageFactory _page, IAppNavigation _navi)
        {
            Navi = _navi;
            Page = _page;


            MessagingCenter.Subscribe<MainPage, bool>(this, Messages.FriendsClicked, (sender, arg)=> {

                List<JamnationApp.Core.Models.Profile> SearchResults = new List<Models.Profile>();
                SearchResults.Add(new Models.Profile());
                SearchResults.Add(new Models.Profile());
                SearchResults.Add(new Models.Profile());
                SearchResults.Add(new Models.Profile());
                SearchResults.Add(new Models.Profile());
                SearchResults.Add(new Models.Profile());
                SearchResults.Add(new Models.Profile());
                SearchResults.Add(new Models.Profile());
                SearchResults.Add(new Models.Profile());
                SearchResults.Add(new Models.Profile());
                OnPropertyChanged("SearchResults");
            });

            MessagingCenter.Subscribe<ChatHistory, JamnationApp.Core.Models.Profile>(this, Messages.FriendsClicked, (sender, arg) =>
            {
                GoToProfile(arg);
            });
        }

        private async void GoToProfile(JamnationApp.Core.Models.Profile prof)
        {
            await Navi.GoToProfilePage(prof.ProfileId.ToString());
        }
    }
}
