using Acr;
using BlankXamarinApp.Core.Interfaces;
using BlankXamarinApp.Core.Objects;
using BlankXamarinApp.Core.UI;
using BlankXamarinApp.Core.UI.Pages.Events;
using BlankXamarinApp.Core.UI.Pages.Map;
using BlankXamarinApp.Core.UI.Pages.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BlankXamarinApp.Core.ViewModels
{
    public class MasterPageViewModel
    {
        private IPageFactory PageFac { get; set; }
        private IAppNavigation Navi { get; set; }

        public List<MasterPageItem> MasterPageItems { get; set; }

        public ICommand LogoutCommand { get { return new Command(Logout); } }

        public MasterPageViewModel(IPageFactory _page, IAppNavigation _navi)
        {

            PageFac = _page;
            Navi = _navi;

            MasterPageItems = new List<MasterPageItem>();

            MasterPageItems.Add(new MasterPageItem
            {
                Title = "Home",
                IconSource = "Search.png",
                TargetType = typeof(MainMapPage)
            });

            MasterPageItems.Add(new MasterPageItem
            {
                Title = "Profile",
                IconSource = "Search.png",
                TargetType = typeof(Profile)
            });

            MasterPageItems.Add(new MasterPageItem
            {
                Title = "Events",
                IconSource = "Search.png",
                TargetType = typeof(BlankXamarinApp.Core.UI.Pages.Events.Events)
            });
           
           
        }

        private async void Logout()
        {
            await Navi.PushModal(PageFac.GetPage(Pages.LoginPage));
        }
        
    }
}
