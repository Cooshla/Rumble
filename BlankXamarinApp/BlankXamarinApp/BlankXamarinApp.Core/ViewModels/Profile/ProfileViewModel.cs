using BlankXamarinApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using BlankXamarinApp.Core.Helpers;

namespace BlankXamarinApp.Core.ViewModels
{
    public class ProfileViewModel: BaseViewModel
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ImageSource UserImage { get; set; }
        public string PhotoText { get; set; }


        private IAppNavigation Navi { get; set; }
        private IPageFactory Page { get; set; }


        public ICommand btnSaveClickCommand { get { return new Command(Save); } }
        public ICommand btnAddPhoto_ClickedCommand { get { return new Command(Photo); } }



        public ProfileViewModel(IPageFactory _page, IAppNavigation _navi)
        {
            Navi = _navi;
            Page = _page;

            PhotoText = "Add Photo";

            UserImage = ImageSource.FromFile("unknown.png");


            FirstName = "Testy";
            LastName = "Testerson";
            Email = "123@test.com";
            PhoneNumber = "12345 654345";


            OnPropertyChanged("FirstName");
            OnPropertyChanged("LastName");
            OnPropertyChanged("Email");
            OnPropertyChanged("PhoneNumber");

            OnPropertyChanged("UserImage");
            OnPropertyChanged("PhotoText");
        }



        public void GetData()
        {
            App.UserDialogService.ShowLoading();

            FirstName = "Testy";
            LastName = "Testerson";
            Email = "123@test.com";
            PhoneNumber = "12345 654345";

           
            OnPropertyChanged("FirstName");
            OnPropertyChanged("LastName");
            OnPropertyChanged("Email");
            OnPropertyChanged("PhoneNumber");

            OnPropertyChanged("UserImage");
            OnPropertyChanged("PhotoText");

            App.UserDialogService.HideLoading();
        }
       

        private async void Photo()
        {
            //TODO probably rotate and resize the image
            var img = await ImageHelper.GetPhoto();
            if (img != null)
            {
                UserImage = ImageSource.FromStream(() => new MemoryStream(img));
                PhotoText = "Update Photo";
                OnPropertyChanged("UserImage");
                OnPropertyChanged("PhotoText");
            }

        }

        private async void Save()
        {
            App.UserDialogService.ShowLoading("Saving...");

            await Task.Delay(2000);

            App.UserDialogService.HideLoading();
        }
    }
}
