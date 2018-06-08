using JamnationApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using JamnationApp.Core.Helpers;
using JamnationApp.Core.Models;
using JamnationApp.Core.UI;
using JamnationApp.Core.Abstracts;
using Xamarin.Forms.Maps;

namespace JamnationApp.Core.ViewModels
{
    public class ProfileViewModel: BaseViewModel
    {

        public JamnationApp.Core.Models.Profile ThisProfile { get; set; }
        public ImageSource UserImage { get; set; }
        public string PhotoText { get; set; }
        private IAppNavigation Navi { get; set; }
        private IPageFactory Page { get; set; }
        private IFriend Friends { get; set; }


        public ICommand AddFriendRequestCommand { get { return new Command(AddFriendRequest); } }

        public ProfileViewModel(IPageFactory _page, IAppNavigation _navi, IProfileService _prof, IFriend _friend)
        {
            Navi = _navi;
            Page = _page;
            Friends = _friend;

            MessagingCenter.Subscribe<ListViewModel, JamnationApp.Core.Models.Profile>(this, Messages.ProfileClicked, (sender, arg)=> {
                ThisProfile = arg;
                OnPropertyChanged("ThisProfile");
                OnPropertyChanged("ThisProfile.Interests");
                OnPropertyChanged("ThisProfile.Description");

                MessagingCenter.Send<ProfileViewModel, JamnationApp.Core.Models.Profile>(this, Messages.AddressLookupCalled, ThisProfile );

                HtmlWebViewSource src = new HtmlWebViewSource() { Html = ThisProfile.SoundCloud };
                MessagingCenter.Send<ProfileViewModel, HtmlWebViewSource>(this, Messages.SetWebViewSource, src);

            });
        }

        private void AddFriendRequest()
        {
            if (!ThisProfile.Friend.Any(c => c.RequestId == App.ThisUser.Profile.ProfileId))
            {
                FriendRequests friend = new FriendRequests();

                friend.ProfileId = ThisProfile.ProfileId;
                friend.RequestId = App.ThisUser.Profile.ProfileId;
                friend.Accepted = false;
                Friends.AddFriend(friend);

                ThisProfile.Friend.Add(friend);

                MessagingCenter.Send<ProfileViewModel, JamnationApp.Core.Models.Profile>(this, Messages.FriendRequestsent, ThisProfile);

                App.UserDialogService.Alert("Friend request sent");
            }
            else
            {
                App.UserDialogService.Alert("Friend request already sent");
            }
        }


    }
}
