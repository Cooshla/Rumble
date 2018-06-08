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
using Plugin.Geolocator;

namespace JamnationApp.Core.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {

        private IPageFactory PageFac { get; set; }
        private IAppNavigation Navi { get; set; }
        private IProfileService Prof { get; set; }
        private IKeyboardHelper Key { get; set; }

        public string Looking { get; set; }
        public string Position { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }

        public bool ShowInterests { get; set; }
        public List<string> Interests { get; set; }
        public int SelectedInterest { get; set; }

        public List<MultiSelectListItem> InterestsItems { get; set; }

        public ICommand SearchCommand { get { return new Command(Search); } }
        public ICommand ResetCommand { get { return new Command(Reset); } }

        public ICommand AddInterestsCommand { get { return new Command(AddInterest); } }

        public ICommand CloseInterestsCommand { get { return new Command(CloseInterest); } }

        public ICommand GetCurrentLocationCommand { get { return new Command(GetLocation); } }

        public SearchViewModel(IPageFactory _page, IAppNavigation _navi, IProfileService _prof, IKeyboardHelper _help)
        {
            PageFac = _page;
            Navi = _navi;
            Prof = _prof;
            Key = _help;

            Reset();

           

            SelectedInterest = 0;
        }


        async void Search()
        {
            App.SearchTermBreadcrumbs = string.Empty;
            var all = await Prof.GetAllProfiles();

            if (!string.IsNullOrWhiteSpace(Looking))
            {

                App.SearchTermBreadcrumbs = "Looking for " + Looking;

                all = all.Where(c => Looking.Contains(c.Interests)).ToList();
            }

            if (!string.IsNullOrWhiteSpace(Location))
            {
                all = all.Where(c => c.Location.Contains(Location)).ToList();


                if (string.IsNullOrWhiteSpace(App.SearchTermBreadcrumbs))
                {
                    App.SearchTermBreadcrumbs = "Looking in " + Location;
                }
                else
                {
                    App.SearchTermBreadcrumbs += " in " + Location;
                }
            }

           


            var SearchResults = all.ToList();

            MessagingCenter.Send<SearchViewModel, List<JamnationApp.Core.Models.Profile>>(this, Messages.SearchResults, SearchResults);

            await Navi.PushPage(PageFac.GetPage(Pages.List));
        }

        private void Reset()
        {
            Looking = string.Empty;
            Position = string.Empty;
            Location = string.Empty;
            Name = string.Empty;
            SelectedInterest = 0;
            ShowInterests = false;

            InterestsItems = new List<MultiSelectListItem>();
            InterestsItems.Add(new MultiSelectListItem() { Name = "Any" });
            InterestsItems.Add(new MultiSelectListItem() {  Name= "Band" });
            InterestsItems.Add(new MultiSelectListItem() {  Name= "Session Musician" });
            InterestsItems.Add(new MultiSelectListItem() {  Name= "Guitarist" });
            InterestsItems.Add(new MultiSelectListItem() {  Name= "Bassist" });
            InterestsItems.Add(new MultiSelectListItem() {  Name= "Drummer" });
            InterestsItems.Add(new MultiSelectListItem() {  Name= "Vocals" });
            InterestsItems.Add(new MultiSelectListItem() {  Name= "Keyboard" });
            InterestsItems.Add(new MultiSelectListItem() {  Name= "Piano" });
            InterestsItems.Add(new MultiSelectListItem() {  Name= "Violin" });
            InterestsItems.Add(new MultiSelectListItem() {  Name= "Sax" });
            InterestsItems.Add(new MultiSelectListItem() { Name = "Other" });
            

            OnPropertyChanged("InterestsItems");
            OnPropertyChanged("ShowInterests");
            OnPropertyChanged("SelectedInterest");
            OnPropertyChanged("Looking");
            OnPropertyChanged("Position");
            OnPropertyChanged("Location");
            OnPropertyChanged("Name");
        }

        private async void GetLocation()
        {
            App.UserDialogService.ShowLoading("Getting location...");

            var locator = CrossGeolocator.Current;
            if (locator.IsGeolocationAvailable)
            {
                if (locator.IsGeolocationEnabled)
                {
                    locator.DesiredAccuracy = 50;
                    var position = await locator.GetPositionAsync(new TimeSpan(0, 0, 2));
                    if (position != null)
                    {
                        var loc = await locator.GetAddressesForPositionAsync(position);

                        Location = loc.FirstOrDefault().Locality + ", " + loc.FirstOrDefault().AdminArea + ", " + loc.FirstOrDefault().CountryName;

                        OnPropertyChanged("Location");
                        App.UserDialogService.HideLoading();
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


        private void CloseInterest()
        {
            ShowInterests = false;
            OnPropertyChanged("ShowInterests");
        }

        private void AddInterest()
        {
            Looking = string.Join(",", InterestsItems.Where(c => c.Selected == true).Select(c => c.Name));
            OnPropertyChanged("Looking");
            CloseInterest();
        }

        public void ShowInterestsPopup()
        {
            Key.HideKeyboard();
            ShowInterests = true;
            OnPropertyChanged("ShowInterests");
        }
    }

    public class MultiSelectListItem :BaseViewModel
    {
        public string Name { get; set; }
        public bool Selected { get; set; }
        public ImageSource Image { get; set; }
        public ICommand SelectCommand { get { return new Command(Select); } }


        public MultiSelectListItem()
        {
            Selected = false;
            Image = "notSelected.png";
        }

        private void Select(object obj)
        {
            Selected = !Selected;
            Image = Selected ? "Selected.png" : "notSelected.png";
            OnPropertyChanged("Image");
        }
    }
}
