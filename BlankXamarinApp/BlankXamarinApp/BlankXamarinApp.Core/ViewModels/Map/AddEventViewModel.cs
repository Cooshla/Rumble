using Acr;
using BlankXamarinApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BlankXamarinApp.Core.ViewModels.Map
{
    public class AddEventViewModel
    {
        public string EventName { get; set; }
        public string Time { get; set; }
        public string Places { get; set; }
        public string Location { get; set; }



        private IPageFactory PageFac { get; set; }
        private IAppNavigation Navi { get; set; }

        public ICommand AddEventCommand { get { return new Command(AddEvent); } }
        public ICommand BackCommand { get { return new Command(Back); } }
        
        public AddEventViewModel(IPageFactory _page, IAppNavigation _navi)
        {
            PageFac = _page;
            Navi = _navi;
        }

        public async void AddEvent()
        {
            App.UserDialogService.ShowLoading("Adding Event...");
            await Task.Delay(2000);
            await Navi.PopModal();
            App.UserDialogService.HideLoading();

        }

        public async void Back()
        {
            await Navi.PopModal();
        }
    }
}
