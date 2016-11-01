using RumbleApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using RumbleApp.Core.Helpers;
using RumbleApp.Core.Models;
using RumbleApp.Core.UI;

namespace RumbleApp.Core.ViewModels
{
    public class ProfileViewModel: BaseViewModel
    {

        public RumbleApp.Core.Models.Profile ThisProfile { get; set; }
        public ImageSource UserImage { get; set; }
        public string PhotoText { get; set; }
        private IAppNavigation Navi { get; set; }
        private IPageFactory Page { get; set; }
        private IProfileService Prof { get; set; }
        private IEventService Evnt { get; set; }


        public ICommand btnSaveClickCommand { get { return new Command(Save); } }
        public ICommand btnAddPhoto_ClickedCommand { get { return new Command(Photo); } }
        

        public ProfileViewModel(IPageFactory _page, IAppNavigation _navi, IProfileService _prof, IEventService _evnt)
        {
            Navi = _navi;
            Page = _page;
            Prof = _prof;
            Evnt = _evnt;              
        }



        public async Task GetData(string id)
        {
            App.UserDialogService.ShowLoading();

            ThisProfile =await Prof.GetProfile(int.Parse(id));

            if (string.IsNullOrWhiteSpace(ThisProfile.ImageUrl))
            {
                PhotoText = "Add Photo";
                UserImage = ImageSource.FromFile("unknown_male");
            }
            else
            {
                PhotoText = "Edit Image";
                UserImage = ImageSource.FromUri(new Uri(ThisProfile.ImageUrl));
            }

            ThisProfile.EventItems = await Evnt.GetAllEventsForUser(App.ThisUser.ID);

            OnPropertyChanged("ThisProfile");
            OnPropertyChanged("UserImage");
            OnPropertyChanged("PhotoText");

            App.UserDialogService.HideLoading();
        }
       

        private async void Photo()
        {
            if (this.AcquireTapLock())
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
                this.ReleaseTapLock();
            }
        }

        private async void Save()
        {
            App.UserDialogService.ShowLoading("Saving...");

            await Task.Delay(2000);

            App.UserDialogService.HideLoading();

            App.UserDialogService.Toast("Profile saved");
        }
    }
}
