using RumbleApp.Core.Interfaces;
using RumbleApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace RumbleApp.Core.ViewModels
{
    public class LoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }


        private IPageFactory PageFac { get; set; }
        private IAppNavigation Navi { get; set; }
        private IRestService Rest { get; set; }
        private IAccountService Acc { get; set; }
        private IProfileService Prof { get; set; }

        public ICommand LoginCommand { get { return new Command(Login); } }
        public ICommand SignupCommand { get { return new Command(Signup); } }


        public LoginViewModel(IPageFactory _page, IAppNavigation _navi, IRestService _rest, IAccountService _acc, IProfileService _prof)
        {
            PageFac = _page;
            Navi = _navi;
            Rest = _rest;
            Acc = _acc;
            Prof = _prof;
        }

        async void Login()
        {
            App.UserDialogService.ShowLoading("Signing in...");
            await Task.Delay(3000);
            User u = new User();
            
            u.Email = UserName;
            u.PasswordHash = Password;
            bool success = await Acc.LoginAsync(UserName, Password);
            if(success)
            {
               
                await Navi.PopModal();
                App.UserDialogService.HideLoading();
            }
            else
            {
                App.UserDialogService.HideLoading();
                await App.UserDialogService.AlertAsync("We could not log you in at this time, please try again");
            }                
        }
        async void Signup()
        {
            await Navi.PushModal(PageFac.GetPage(Pages.RegisterPage));
        }
    }
}
