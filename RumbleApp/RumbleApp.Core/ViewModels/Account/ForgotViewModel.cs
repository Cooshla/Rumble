using JamnationApp.Core.Interfaces;
using JamnationApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace JamnationApp.Core.ViewModels
{
    public class ForgotViewModel : BaseViewModel
    {
        public string Email { get; set; }



        private IPageFactory PageFac { get; set; }
        private IAppNavigation Navi { get; set; }
        private IRestService Rest { get; set; }
        private IAccountService Acc { get; set; }
        private IProfileService Prof { get; set; }
        
        public ICommand ResetCommand { get { return new Command(Reset); } }


        public ForgotViewModel(IPageFactory _page, IAppNavigation _navi, IRestService _rest, IAccountService _acc, IProfileService _prof)
        {
            PageFac = _page;
            Navi = _navi;
            Rest = _rest;
            Acc = _acc;
            Prof = _prof;
        }


        async void Reset()
        {
            App.UserDialogService.Alert("Forgot pushed");
        }
    }
}
