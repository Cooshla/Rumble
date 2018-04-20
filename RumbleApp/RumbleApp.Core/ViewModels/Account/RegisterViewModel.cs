using Newtonsoft.Json;
using JamnationApp.Core.Interfaces;
using JamnationApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using JamnationApp.Core.Helpers;
using System.IO;

namespace JamnationApp.Core.ViewModels
{
    public class RegisterViewModel:BaseViewModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Interests { get; set; }
        public string Description { get; set; }
        public byte[] PhotoBlob { get; set; }
        public ImageSource ProfileImage { get; set; }

        private IPageFactory PageFac { get; set; }
        private IAppNavigation Navi { get; set; }
        private IRestService Rest { get; set; }
        private IAccountService Acc { get; set; }
        private IUserService Usr { get; set; }
        private IProfileService Pro { get; set; }

        public ICommand SignupCommand { get { return new Command(SignUp); } }
        public ICommand BackCommand { get { return new Command(Back); } }
        public ICommand CloseCommand { get { return new Command(Back); } }
        public ICommand TakePhotoCommand { get { return new Command(TakePhoto); } }


        public RegisterViewModel(IPageFactory _page, IAppNavigation _navi, IRestService _rest, IAccountService _acc, IUserService _user, IProfileService _pro)
        {
            PageFac = _page;
            Navi = _navi;
            Rest = _rest;
            Acc = _acc;
            Usr = _user;
            Pro = _pro;
            ProfileImage = "AddPhoto.png";
        }


        async void SignUp()
        {
            if (IsValidate())
            {
                if (IsInternetConnection())
                {
                    App.UserDialogService.ShowLoading("Signing up...");
                    if (await CreateUser())
                    {
                        if (Settings.IsFirstRun)
                        {
                            Settings.IsFirstRun = false;
                            await Navi.PopModal();
                            await Navi.PopModal();
                            await Navi.PushModal(PageFac.GetPage(Pages.Guide));
                        }
                        else
                        {
                            await Navi.PopModal();
                            await Navi.PopModal();
                        }
                    }
                    App.UserDialogService.HideLoading();
                }
            }
            else
                App.UserDialogService.Alert(ErrorMessage);
        }
        public string ErrorMessage { get; set; }
        private bool IsValidate()
        {
            ErrorMessage = string.Empty;
            bool ret = true;
            if (string.IsNullOrWhiteSpace(FirstName))
                ErrorMessage += "Please enter a first name\r\n";

            if (string.IsNullOrWhiteSpace(LastName))
                ErrorMessage += "Please enter a last name\r\n";

            if (!Validation.IsValidEmail(Email))
                ErrorMessage += "Please enter a valid Email\r\n";

            if (string.IsNullOrWhiteSpace(Password))
                ErrorMessage += "Please enter a password\r\n";

            if (ErrorMessage.Length > 0)
                ret = false;
            return ret;
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
                PhotoBinary=PhotoBlob,
                Status = new UserStatus { ActiveStatus = Status.Active, LastUpdated = DateTime.UtcNow }
            };

            UserResponse response = await Acc.RegisterAsync(user, null);
            
            if (response.success)
            {
                if (await Acc.LoginAsync(Email, Password))
                {
                    var prof = new JamnationApp.Core.Models.Profile()
                    {
                        Created = DateTime.Now,
                        Email = Email,
                        FirstName = FirstName,
                        LastName = LastName,
                        PhoneNumber = Phone,
                        Description = Description,
                        Interests = Interests,
                        ImageBlob = PhotoBlob,
                        UserId= App.ThisUser.ID
                    };
                    
                    var resp = await Pro.AddProfile(prof);
                    //resp.StatusCode
                    App.ThisUser = await Usr.GetUserViewModel(Email, Password);

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


        private async void TakePhoto(object obj)
        {  //TODO probably rotate and resize the image
            var img = await ImageHelper.GetPhoto();
            if (img != null)
            {
                PhotoBlob = new MemoryStream(img).ToArray();                
                ProfileImage = ImageSource.FromStream(() => new MemoryStream(img));
                OnPropertyChanged("ProfileImage");
            }
            this.ReleaseTapLock();
        }

    }
}
