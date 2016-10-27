using BlankXamarinApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BlankXamarinApp.Core.ViewModels.Map
{
    public class MainMapPageViewModel
    {

        public ICommand AddEventCommand { get { return new Command(AddEvent); } }

        private IAppNavigation Navi { get; set; }
        private IPageFactory Page { get; set; }


        public MainMapPageViewModel(IPageFactory _page, IAppNavigation _navi)
        {
            Navi = _navi;
            Page = _page;
        }

        public void AddEvent()
        {
            Navi.PushModal(Page.GetPage(Pages.AddEventPage));
        }
    }
}
