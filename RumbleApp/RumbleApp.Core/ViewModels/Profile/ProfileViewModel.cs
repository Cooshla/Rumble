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

        public Profile ThisProfile { get; set; }
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

            RegisterMessageCenter();                
        }
        public void RegisterMessageCenter()
        {
            MessagingCenter.Subscribe<MainPage,bool>(this,Messages.ProfileClicked, async (sends, arg) =>
            {
                await GetData();
            });
        }


        public async Task GetData()
        {
            App.UserDialogService.ShowLoading();

            PhotoText = "Add Photo";

            UserImage = ImageSource.FromFile("unknown_male");

            ThisProfile = new Profile();
            ThisProfile.FirstName = "Stephen";
            ThisProfile.LastName = "Shaw";
            ThisProfile.Email = "123@test.com";
            ThisProfile.PhoneNumber = "12345 654345";

            ThisProfile.Ranking = "Blue Belt";
            ThisProfile.Location = "Haywards Heath, West sussex";
            ThisProfile.Longitude = 50.9990;
            ThisProfile.Latitude = 0.1063;
            ThisProfile.PostCode = "RH16 3PJ";
            ThisProfile.ShowExactLocation = false;

            ThisProfile.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla id erat id ex imperdiet cursus lobortis id magna. Nunc efficitur auctor ultricies. Curabitur id ultrices felis. Nam rhoncus consectetur dolor non pretium. Etiam porttitor ac lectus nec vulputate. Aenean interdum cursus turpis vel efficitur. Etiam sagittis tempus lacus";
            ThisProfile.Interests = "Bjj, Muay thai";

            ThisProfile.EventItems = new List<Event>();
            ThisProfile.EventItems.Add(new Event() { Name = "Event 1", Description = "Open Mat", AllowInAppPurchases = false, Longitude = 50.8225, Latitude = 0.1372, StartDate = DateTime.Now, Places = 40, Location = "Brighton" });
            ThisProfile.EventItems.Add(new Event() { Name = "Event 1", Description = "Open Mat", AllowInAppPurchases = false, Longitude = 50.8225, Latitude = 0.1372, StartDate = DateTime.Now, Places = 40, Location = "Brighton" });
            ThisProfile.EventItems.Add(new Event() { Name = "Event 1", Description = "Open Mat", AllowInAppPurchases = false, Longitude = 50.8225, Latitude = 0.1372, StartDate = DateTime.Now, Places = 40, Location = "Brighton" });

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
