using Acr;
using JamnationApp.Core.Interfaces;
using JamnationApp.Core.Models;
using JamnationApp.Core.Objects;
using JamnationApp.Core.UI;
using JamnationApp.Core.UI.Pages.Events;
using JamnationApp.Core.UI.Pages.Map;
using JamnationApp.Core.UI.Pages.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JamnationApp.Core.ViewModels
{
    public class MasterPageViewModel
    {
        private IPageFactory PageFac { get; set; }
        private IAppNavigation Navi { get; set; }

        public List<MenuItem> MasterPageItems { get; set; }

        public ICommand LogoutCommand { get { return new Command(Logout); } }

        public MasterPageViewModel(IPageFactory _page, IAppNavigation _navi)
        {

            PageFac = _page;
            Navi = _navi;

            MasterPageItems = new List<MenuItem>();

            MasterPageItems.Add(new MenuItem
            {
                Title = "Home",
                IconSource = "Search.png",
                TargetType = typeof(MainMapPage),
                Id = "home"
            });

            MasterPageItems.Add(new MenuItem
            {
                Title = "Profile",
                IconSource = "Search.png",
                TargetType = typeof(JamnationApp.Core.UI.Pages.Profile.MyProfile),
                Id="profile"
            });

            MasterPageItems.Add(new MenuItem
            {
                Title = "Events",
                IconSource = "Search.png",
                TargetType = typeof(JamnationApp.Core.UI.Pages.Events.Events),
                Id = "events"
            });
           
           
        }

        private async void Logout()
        {
            await Navi.PushModal(PageFac.GetPage(Pages.LoginPage));
        }
        
    }
}
