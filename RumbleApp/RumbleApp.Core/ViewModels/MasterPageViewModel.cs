using Acr;
using RumbleApp.Core.Interfaces;
using RumbleApp.Core.Models;
using RumbleApp.Core.Objects;
using RumbleApp.Core.UI;
using RumbleApp.Core.UI.Pages.Events;
using RumbleApp.Core.UI.Pages.Map;
using RumbleApp.Core.UI.Pages.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RumbleApp.Core.ViewModels
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
                TargetType = typeof(RumbleApp.Core.UI.Pages.Profile.Profile),
                Id="profile"
            });

            MasterPageItems.Add(new MenuItem
            {
                Title = "Events",
                IconSource = "Search.png",
                TargetType = typeof(RumbleApp.Core.UI.Pages.Events.Events),
                Id = "events"
            });
           
           
        }

        private async void Logout()
        {
            await Navi.PushModal(PageFac.GetPage(Pages.LoginPage));
        }
        
    }
}
