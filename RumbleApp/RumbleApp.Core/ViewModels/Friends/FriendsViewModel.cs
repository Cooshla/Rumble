using JamnationApp.Core.Interfaces;
using JamnationApp.Core.UI;
using JamnationApp.Core.UI.Pages.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace JamnationApp.Core.ViewModels.Profile
{
    public class FriendsViewModel : BaseViewModel
    {

        private IAppNavigation Navi { get; set; }
        private IPageFactory Page { get; set; }
        private IProfileService Prof { get; set; }
        private IFriend Friend { get; set; }
        

        public ICommand AcceptCommand { get { return new Command(Accept); } }

        public ICommand DeclineCommand { get { return new Command(Decline); } }



        public List<JamnationApp.Core.Models.Profile> SearchResults { get; set; }
        public FriendsViewModel(IPageFactory _page, IAppNavigation _navi, IProfileService _prof, IFriend _friend)
        {
            Navi = _navi;
            Page = _page;
            Prof = _prof;

            MessagingCenter.Subscribe<MainPage, bool>(this, Messages.FriendsClicked,  async (sender, arg)=> {

                App.UserDialogService.ShowLoading("Please Wait");
                SearchResults = await Prof.GetAllProfilesOfFriends(App.ThisUser.Profile.ProfileId);
                OnPropertyChanged("SearchResults");

                App.UserDialogService.HideLoading();
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


        private void Accept(object obj)
        {
            App.UserDialogService.ShowLoading("Please Wait");
            int friendId = 0;
            int.TryParse(obj.ToString(), out friendId);

            if(friendId!=0)
            {
                var frnd = App.ThisUser.Profile.Friend.Where(c => c.FriendId == friendId).FirstOrDefault();
                Friend.UpdateFriend(frnd);
            }
            App.UserDialogService.HideLoading();
        }
        private void Decline(object obj)
        {
            App.UserDialogService.ShowLoading("Please Wait");
            int friendId = 0;
            int.TryParse(obj.ToString(), out friendId);

            if (friendId != 0)
            {
                var frnd = App.ThisUser.Profile.Friend.Where(c => c.FriendId == friendId).FirstOrDefault();
                Friend.DeleteFriend(friendId);
                App.ThisUser.Profile.Friend.Remove(frnd);
                SearchResults.Remove(SearchResults.Where(c => c.ProfileId == friendId).FirstOrDefault());
                OnPropertyChanged("SearchResults");
            }
            App.UserDialogService.HideLoading();
        }
    }
}
