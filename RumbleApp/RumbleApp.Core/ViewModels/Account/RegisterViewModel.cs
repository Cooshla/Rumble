using Newtonsoft.Json;
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
    public class RegisterViewModel:BaseViewModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }


        private IPageFactory PageFac { get; set; }
        private IAppNavigation Navi { get; set; }
        private IRestService Rest { get; set; }
        private IAccountService Acc { get; set; }

        public ICommand SignupCommand { get { return new Command(SignUp); } }
        public ICommand BackCommand { get { return new Command(Back); } }

        public RegisterViewModel(IPageFactory _page, IAppNavigation _navi, IRestService _rest, IAccountService _acc)
        {
            PageFac = _page;
            Navi = _navi;
            Rest = _rest;
            Acc = _acc;
                
        }


        async void SignUp()
        {
            if (IsInternetConnection())
            {
                App.UserDialogService.ShowLoading("Signing up...");
                if (await CreateUser())
                {
                    await Navi.PopModal();
                }
                App.UserDialogService.HideLoading();
            }
        }
        

        private async void Back()
        {
            await Navi.PopModal();
        }


        async Task<bool> CreateUser()
        {
           

            var user = new User
            {
                Email = Email,
                FirstName = FirstName,
                LastName = LastName,
                PhoneNumber = Phone,
                Password = Password,
                Status = new UserStatus { ActiveStatus = Status.Active, LastUpdated = DateTime.UtcNow }
            };

            UserResponse response = null;
            if (App.Token != null)
            {
                //update
                response = await Rest.PutClient<UserResponse>("api/user/update", JsonConvert.SerializeObject(user));
            }
            else
            {
                response = await Rest.PostClient<UserResponse>("api/user/add", JsonConvert.SerializeObject(user));
            }


            if (response.success)
            {
                if (await Acc.LoginAsync(Email, Password))
                {
                    App.ThisUser = user;
                    return true;
                }
                else
                {
                    await App.UserDialogService.AlertAsync("Can't login with user " + Email, "Error", "OK");
                }
            }
            else
            {

                await App.UserDialogService.AlertAsync(response.errors != null ? response.errors.First() : "Not sure what happened there, please try again", "Oops!", "Ok");
            }


            return false;
        }

    }
}
