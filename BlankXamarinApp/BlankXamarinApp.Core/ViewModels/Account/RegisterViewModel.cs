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
    public class RegisterViewModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }


        private IPageFactory PageFac { get; set; }
        private IAppNavigation Navi { get; set; }

        public ICommand SignupCommand { get { return new Command(SignUp); } }
        public ICommand BackCommand { get { return new Command(Back); } }

        public RegisterViewModel(IPageFactory _page, IAppNavigation _navi)
        {
            PageFac = _page;
            Navi = _navi;
        }


        async void SignUp()
        {
            App.UserDialogService.ShowLoading("Signing in...");
            await Task.Delay(3000);
            await Navi.PopModal();
            App.UserDialogService.HideLoading();
        }
        

        private async void Back()
        {
            await Navi.PopModal();
        }

    }
}
