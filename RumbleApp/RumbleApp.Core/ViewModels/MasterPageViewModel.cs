using Acr;
using JamnationApp.Core.Interfaces;
using JamnationApp.Core.Models;
using JamnationApp.Core.Objects;
using JamnationApp.Core.UI;
using JamnationApp.Core.UI.Pages.Events;
using JamnationApp.Core.UI.Pages.Map;
using JamnationApp.Core.UI.Pages.Profile;
using JamnationApp.Core.UI.Pages.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace JamnationApp.Core.ViewModels
{
    public class MasterPageViewModel :BaseViewModel
    {
        private IPageFactory PageFac { get; set; }
        private IAppNavigation Navi { get; set; }

        public List<MenuItem> MasterPageItems { get; set; }

        public ICommand LogoutCommand { get { return new Xamarin.Forms.Command(Logout); } }

        public string LogoutText { get; set; }

        public bool IsLoggedIn { get; set; }

        public MasterPageViewModel(IPageFactory _page, IAppNavigation _navi)
        {

            PageFac = _page;
            Navi = _navi;

            MasterPageItems = new List<MenuItem>();

            MasterPageItems.Add(new MenuItem
            {
                Title = "Search",
                IconSource = "search.png",
                TargetType = typeof(Search),
                Id = "home"
            });

            MasterPageItems.Add(new MenuItem
            {
                Title = "Profile",
                IconSource = "myprofile.png",
                TargetType = typeof(JamnationApp.Core.UI.Pages.Profile.MyProfile),
                Id = "profile"
            });

            MasterPageItems.Add(new MenuItem
            {
                Title = "Friends",
                IconSource = "friends.png",
                TargetType = typeof(Friends),
                Id = "home"
            });

            MasterPageItems.Add(new MenuItem
            {
                Title = "Chat",
                IconSource = "message.png",
                TargetType = typeof(JamnationApp.Core.UI.Pages.Profile.ChatHistory),
                Id = "chat"
            });

            /*
            MasterPageItems.Add(new MenuItem
            {
                Title = "Settings",
                IconSource = "settings.png",
                TargetType = typeof(JamnationApp.Core.UI.Pages.Events.Events),
                Id = "events"
            });
           */

            Xamarin.Forms.MessagingCenter.Subscribe<LoginViewModel, bool>(this, Messages.LoginSuccessful, (sender, args) =>
            {
                Task.Run(async () =>
                {

                    IsLoggedIn = args;
                    LogoutText = args ? "Logout" : "Login";
                    OnPropertyChanged("IsLoggedIn");
                    OnPropertyChanged("LogoutText");
                    /*
                    if (args)
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            Settings.IsLoggedIn = true;
                            Navi.PopModal(true);
                            if (Settings.IsFirstRun)
                            {
                                Navi.PushModal(PageFac.GetPage(Pages.Guide));
                                Settings.IsFirstRun = false;
                            }
                        });
                        

                        MessagingCenter.Send<MasterPageViewModel, bool>(this, Messages.LoggedInComplete, args);
                    }*/
                });
            });

            OnPropertyChanged("MasterPageItems");
        }

        private async void Logout()
        {
            IsLoggedIn  = !IsLoggedIn;
            LogoutText = IsLoggedIn ? "Logout" : "Login";
            OnPropertyChanged("IsLoggedIn");
            OnPropertyChanged("LogoutText");

            await Navi.PushModal(PageFac.GetPage(Pages.LoginPage));
        }
        
    }
}
