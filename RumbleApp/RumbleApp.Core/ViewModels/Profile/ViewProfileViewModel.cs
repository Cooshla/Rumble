using JamnationApp.Core.Helpers;
using JamnationApp.Core.Interfaces;
using JamnationApp.Core.UI;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace JamnationApp.Core.ViewModels.Profile
{
    public class ViewProfileViewModel: BaseViewModel
    {
        public JamnationApp.Core.Models.Profile ThisProfile { get; set; }
        public ImageSource UserImage { get; set; }
        public string PhotoText { get; set; }
        public string Interests { get; set; }
        public string Description { get; set; }

        public string LocataionLabel { get; set; }
        public bool LocationSet { get; set; }
        public byte[] ImageBlob { get; set; }

        public bool ShowInterests { get; set; }
        public bool ShowInterestEdit { get; set; }
        public bool ShowDescription { get; set; }
        public bool ShowDescriptionEdit { get; set; }
        public bool IsDirty { get; set; }


        public bool ShowSoundCloud { get; set; }
        public bool ShowSoundCloudEdit { get; set; }


        public string SoundCloudEmbed { get; set; }


        public List<MultiSelectListItem> InterestsItems { get; set; }


        private IAppNavigation Navi { get; set; }
        private IPageFactory Page { get; set; }
        private IProfileService Prof { get; set; }
        private IEventService Evnt { get; set; }


        public ICommand btnSaveClickCommand { get { return new Command(Save); } }
        public ICommand AddPhotoCommand { get { return new Command(Photo); } }
        public ICommand SetLocationCommand { get { return new Command(SetLocation); } }
        public ICommand ShowInterestEditCommand { get { return new Command(ShowInt); } }
        public ICommand ShowDescriptionEditCommand { get { return new Command(ShowDesc); } }
        public ICommand ShowSoundCloudEditCommand { get { return new Command(SoundCloud); } }
        public ICommand AddInterestsCommand { get { return new Command(AddInterest); } }
        public ICommand CloseInterestsCommand { get { return new Command(CloseInterest); } }


        public ViewProfileViewModel(IPageFactory _page, IAppNavigation _navi, IProfileService _prof, IEventService _evnt)
        {
            Navi = _navi;
            Page = _page;
            Prof = _prof;
            Evnt = _evnt;

            RegisterMessageCenter();
        }
        public void RegisterMessageCenter()
        {
            MessagingCenter.Subscribe<MainPage, bool>(this, Messages.ProfileClicked, async (sends, arg) =>
            {
                ThisProfile = App.ThisUser.Profile;
                await GetData();
                
            });
        }


        public async Task GetData()
        {
            App.UserDialogService.ShowLoading();

            IsDirty = false;

            Interests = ThisProfile.Interests;
            Description = ThisProfile.Description;

            UserImage = "http://jammr.azurewebsites.net/profileimages/unknown_male.jpg";
            if (!string.IsNullOrWhiteSpace(ThisProfile.ImageUrl))
                UserImage = "http://jammr.azurewebsites.net/profileimages/" + ThisProfile.ImageUrl;

            SoundCloudEmbed = ThisProfile.SoundCloud;
            SoundCloudEmbed= "<html><iframe width='100%' height='300' scrolling='no' frameborder='no' allow='autoplay' src='https://w.soundcloud.com/player/?url=https%3A//api.soundcloud.com/users/55118534&color=%23ff5500&auto_play=false&hide_related=false&show_comments=true&show_user=true&show_reposts=false&show_teaser=true&visual=true'></iframe></html>";
            if (SoundCloudEmbed != null || SoundCloudEmbed != string.Empty)
            {
                ShowSoundCloud = true;
                ShowSoundCloudEdit = false;
                HtmlWebViewSource url = new HtmlWebViewSource() { Html = SoundCloudEmbed };
                MessagingCenter.Send<ViewProfileViewModel, HtmlWebViewSource>(this, Messages.SetWebViewSource, url);
            }
            else
            {
                ShowSoundCloud = false;
                ShowSoundCloudEdit = false;
            }

            if (string.IsNullOrWhiteSpace(ThisProfile.Location))
            {
                LocationSet = false;
                LocataionLabel = "Set Location";
            }
            else
            {
                LocationSet = true;
                LocataionLabel = "Update Location";
            }

            ShowDescription = true;
            ShowDescriptionEdit = false;
            ShowInterestEdit = false;



            InterestsItems = new List<MultiSelectListItem>();
            InterestsItems.Add(new MultiSelectListItem() { Name = "Any" });
            InterestsItems.Add(new MultiSelectListItem() { Name = "Band" });
            InterestsItems.Add(new MultiSelectListItem() { Name = "Session Musician" });
            InterestsItems.Add(new MultiSelectListItem() { Name = "Guitarist" });
            InterestsItems.Add(new MultiSelectListItem() { Name = "Bassist" });
            InterestsItems.Add(new MultiSelectListItem() { Name = "Drummer" });
            InterestsItems.Add(new MultiSelectListItem() { Name = "Vocals" });
            InterestsItems.Add(new MultiSelectListItem() { Name = "Keyboard" });
            InterestsItems.Add(new MultiSelectListItem() { Name = "Piano" });
            InterestsItems.Add(new MultiSelectListItem() { Name = "Violin" });
            InterestsItems.Add(new MultiSelectListItem() { Name = "Sax" });
            InterestsItems.Add(new MultiSelectListItem() { Name = "Other" });

            foreach(var item in InterestsItems)
            {
                if(Interests.Contains(item.Name))
                {
                    item.SelectCommand.Execute(null);
                }
            }

            ShowInterests = false;
            OnPropertyChanged("InterestsItems");
            OnPropertyChanged("ShowInterests");


            OnPropertyChanged("SoundCloudEmbed");
            OnPropertyChanged("ShowSoundCloud");
            OnPropertyChanged("ShowSoundCloudEdit");

            OnPropertyChanged("ShowDescription");
            OnPropertyChanged("ShowDescriptionEdit");
            
            OnPropertyChanged("ShowInterestEdit");

            OnPropertyChanged("LocationSet");
            OnPropertyChanged("LocataionLabel");
            OnPropertyChanged("Interests");
            OnPropertyChanged("Description");
            OnPropertyChanged("ThisProfile");
            OnPropertyChanged("UserImage");
            OnPropertyChanged("PhotoText");

            Plugin.Geolocator.Abstractions.Position pos = new Plugin.Geolocator.Abstractions.Position();
            pos.Longitude = ThisProfile.Longitude;
            pos.Latitude = ThisProfile.Latitude;


            MessagingCenter.Send<ViewProfileViewModel, string>(this, Messages.SetProfile, Interests);

            MessagingCenter.Send<ViewProfileViewModel, JamnationApp.Core.Models.Profile>(this, Messages.AddressLookupCalled, ThisProfile);


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
                    ImageBlob = new MemoryStream(img).ToArray();
                    UserImage = ImageSource.FromStream(() => new MemoryStream(img));
                    PhotoText = "Update Photo";
                    OnPropertyChanged("UserImage");
                    OnPropertyChanged("PhotoText");
                }
                this.ReleaseTapLock();
            }
        }

        public async void Save()
        {
            App.UserDialogService.ShowLoading("Saving...");

            try
            {
                App.ThisUser.Profile.Interests = Interests;
                App.ThisUser.Profile.Description = Description;
                if (ImageBlob != null)
                    App.ThisUser.Profile.ImageBlob = ImageBlob;

                App.ThisUser.Profile.UserId = App.ThisUser.ID;
                App.ThisUser.Profile.SoundCloud = SoundCloudEmbed;

                App.ThisUser.Profile.Location=ThisProfile.Location;
                App.ThisUser.Profile.Latitude = ThisProfile.Latitude;
                App.ThisUser.Profile.Longitude = ThisProfile.Longitude;

                // Save
                await Prof.UpdateProfile(App.ThisUser.Profile);
                App.ThisUser.Profile = await Prof.GetProfile(App.ThisUser.Profile.ProfileId);


                App.UserDialogService.HideLoading();

                App.UserDialogService.Alert("Profile saved");
            }
            catch (Exception ex)
            {
                App.UserDialogService.HideLoading();
                App.UserDialogService.Alert("There was an issue saving your profile, please try again later");
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);

            }
        }
        
        private async void SetLocation(object obj)
        {
            App.UserDialogService.ShowLoading("Getting location...");

            var locator = CrossGeolocator.Current;
            if (locator.IsGeolocationAvailable)
            {
                if (locator.IsGeolocationEnabled)
                {
                    locator.DesiredAccuracy = 50;

                    var all = await Prof.GetAllProfiles();
                    foreach(var prof in all)
                    {
                        var loc = await locator.GetAddressesForPositionAsync(new Plugin.Geolocator.Abstractions.Position() { Latitude = prof.Latitude, Longitude = prof.Longitude });
                        prof.Location = loc.FirstOrDefault().Locality + ", " + loc.FirstOrDefault().AdminArea + ", " + loc.FirstOrDefault().CountryName;
                        await Prof.UpdateProfile(prof);
                    }


                var position = await locator.GetPositionAsync(new TimeSpan(0, 0, 2));






                if (position != null)
                {

                    var loc = await locator.GetAddressesForPositionAsync(position);

                    ThisProfile.Location = loc.FirstOrDefault().Locality + ", " + loc.FirstOrDefault().AdminArea + ", " + loc.FirstOrDefault().CountryName;
                    ThisProfile.Latitude = position.Latitude;
                    ThisProfile.Longitude = position.Longitude;

                    LocationSet = true;
                    LocataionLabel = "Update Location";

                    OnPropertyChanged("LocationSet");
                    OnPropertyChanged("LocataionLabel");
                    App.UserDialogService.HideLoading();

                    MessagingCenter.Send<ViewProfileViewModel, JamnationApp.Core.Models.Profile>(this, Messages.AddressLookupCalled, ThisProfile);
                }
                else
                {
                    App.UserDialogService.HideLoading();
                    App.UserDialogService.Alert("We could not obtain your location at this time, please try again");
                }
                }
                else
                {
                    App.UserDialogService.HideLoading();
                    App.UserDialogService.Alert("Please enable location services in the app settings");
                }
            }
            else
            {
                App.UserDialogService.HideLoading();
                App.UserDialogService.Alert("Please turn on Location Services");
            }
        }
        
        private void ShowDesc(object obj)
        {
            if (ShowDescription)
            {
                ShowDescription = false;
                ShowDescriptionEdit = true;

                UIPageLocator.MyProfile.ToggleDesc(false);
            }
            else
            {

                ShowDescription = true;
                ShowDescriptionEdit = false;
                UIPageLocator.MyProfile.ToggleDesc(true);
            }

            OnPropertyChanged("ShowDescription");
            OnPropertyChanged("ShowDescriptionEdit");

        }

        private void ShowInt(object obj)
        {
            ShowInterests = true;
            OnPropertyChanged("ShowInterests");
        }


        private void CloseInterest()
        {
            ShowInterests = false;
            OnPropertyChanged("ShowInterests");
        }

        private void AddInterest()
        {
            Interests = string.Join(",", InterestsItems.Where(c => c.Selected == true).Select(c => c.Name));
            OnPropertyChanged("Interests");
            MessagingCenter.Send<ViewProfileViewModel, string>(this, Messages.SetProfile, Interests);
            CloseInterest();
        }

        private void SoundCloud(object obj)
        {
            if (ShowSoundCloud)
            {
                ShowSoundCloud = false;
                ShowSoundCloudEdit = true;
                UIPageLocator.MyProfile.ToggleSoundcloud(false);
            }
            else
            {

                ShowSoundCloud = true;
                ShowSoundCloudEdit = false;
                UIPageLocator.MyProfile.ToggleSoundcloud(true);
            }

            OnPropertyChanged("ShowSoundCloud");
            OnPropertyChanged("ShowSoundCloudEdit");
        }
        
    }
}
