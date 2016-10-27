using BlankXamarinApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BlankXamarinApp.Core.ViewModels
{
    public class LoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }


        private IPageFactory PageFac { get; set; }
        private IAppNavigation Navi { get; set; }
        

        public ICommand LoginCommand { get { return new Command(Login); } }
        public ICommand SignupCommand { get { return new Command(Signup); } }


        public LoginViewModel(IPageFactory _page, IAppNavigation _navi)
        {
            PageFac = _page;
            Navi = _navi;
        }

        async void Login()
        {
            App.UserDialogService.ShowLoading("Signing in...");
            await Task.Delay(3000);
            await Navi.PopModal();
            App.UserDialogService.HideLoading();
                
        }
        async void Signup()
        {
            await Navi.PushModal(PageFac.GetPage(Pages.RegisterPage));
        }
    }
}
