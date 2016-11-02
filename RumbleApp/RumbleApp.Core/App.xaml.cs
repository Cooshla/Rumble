using Autofac;
using System;
using System.Collections.Generic;
using RumbleApp.Core.Abstracts;
using Xamarin.Forms;
using RumbleApp.Core.Services;
using System.Threading.Tasks;
using RumbleApp.Core.Helpers;
using INavigationService = RumbleApp.Core.Interfaces.INavigationService;
using XLabs.Platform.Device;
using Xamarin.Forms.Maps;
using RumbleApp.Core.Interfaces;
using RumbleApp.Core.UI;
using RumbleApp.Core.ViewModels;
using Acr.UserDialogs;
using RumbleApp.Core.ViewModels.Map;
using RumbleApp.Core.ViewModels.Events;
using XLabs.Platform.Services.Media;
using RumbleApp.Core.Models;
using RumbleApp.Core.UI.Pages.Map;
using RumbleApp.Core.ViewModels.Guide;
using RumbleApp.Core.ViewModels.AutoComplete;
using RumbleApp.Core.ViewModels.Profile;

namespace RumbleApp.Core
{
    public partial class App : Application
    {
        public static double ScreenHeight;
        public static double ScreenWidth;

        public static User ThisUser { get; set; }
        public static string DeviceId { get; set; }
        public static string Version { get; set; }
        public static string GooglePlayCode = "";

        private static IContainer _container;
        public static IMediaPicker MediaPicker { get; set; }


        private static NavigationService NaviService;

        public static string Token { get; set; }

        public static NavigationPage _firstPage;
        public static Page StartupPage
        {
            get { return _firstPage; }
            set
            {
                _firstPage = new NavigationPage(value);
                // navigation page root should be search page
                NaviService.Navi = StartupPage.Navigation;
                NaviService.myPage = StartupPage;
            }
        }


        public static Position SearchFocus { get; set; }


        public static DatabaseManager _databaseManager;

        public static bool IgnoreSearchLogic { get; set; }

        public static DatabaseManager DatabaseManager { get; set; }

        
        public static IUserDialogs UserDialogService { get; set; }



        public App()
        {
            InitializeComponent();

            UserDialogService = UserDialogs.Instance;

            NaviService = _container.Resolve<INavigationService>() as NavigationService;

            var pageFactory = _container.Resolve<IPageFactory>();
            var home = pageFactory.GetPage(Pages.MainPage) as MasterDetailPage;
            var scan = pageFactory.GetPage(Pages.MainMapPage);
            StartupPage = scan;
            home.Detail = _firstPage;
            MainPage = home;

           // DeviceId = Acr.DeviceInfo.DeviceInfo.Hardware.DeviceId;

            SetNavService(scan);

            Authenticate();
        }

        public static async void Authenticate()
        {
            string token = Settings.Token;
            string expires = Settings.Expires;

            var pageFactory = _container.Resolve<IPageFactory>();
            if (token == String.Empty)// || string.IsNullOrEmpty(expires) || DateTime.Parse(expires) < DateTime.UtcNow)
            {
                await NaviService.PushModalAsync(pageFactory.GetPage(Pages.LoginPage));
                return;
            }
            else
            {
                var Acc = _container.Resolve<IAccountService>();
                bool LoginSuccess = await Acc.LoginAsync(Settings.UserName, Settings.Password);
                if (!LoginSuccess)
                {
                    await App.UserDialogService.AlertAsync("We could not log you in at this time. Please check your connectivity and try again.");
                    await NaviService.PushModalAsync(pageFactory.GetPage(Pages.LoginPage), true);
                }
            }
            
            App.Token = token;
        }

        public static void Init(AppSetup appSetup)
        {
            _container = appSetup.CreateContainer();

            MasterPageViewModel = _container.Resolve<MasterPageViewModel>();
            MainPageViewModel = _container.Resolve<MainPageViewModel>();
            ScanPageViewModel = _container.Resolve<ScanPageViewModel>();
            LoginViewModel = _container.Resolve<LoginViewModel>();
            RegisterViewModel = _container.Resolve<RegisterViewModel>();
            ProfileViewModel = _container.Resolve<ProfileViewModel>();

            MainMapPageViewModel = _container.Resolve<MainMapPageViewModel>();
            AddEventViewModel = _container.Resolve<AddEventViewModel>();
            EventsViewModel = _container.Resolve<EventsViewModel>();
            GuideViewModel = _container.Resolve<GuideViewModel>();
            LocationLookupViewModel = _container.Resolve<LocationLookupViewModel>();
            EventDetailViewModel = _container.Resolve<EventDetailViewModel>();
            ViewProfileViewModel = _container.Resolve<ViewProfileViewModel>();
            
            // static pages
            MainMap = new MainMapPage();
            ProfilePage = new UI.Pages.Profile.Profile();
            EventsPage = new UI.Pages.Events.Events();
            MyProfile = new UI.Pages.Profile.MyProfile();


        }


        public static IDisplay DeviceDisplay { get; set; }



        public static void SetNavService(Page page)
        {
            NaviService.Navi = page.Navigation;
            NaviService.myPage = page;
        }





        public static DateTime AppLoadedDateTime { get; set; }
        public static DateTime PageOpenedDateTime { get; set; }



        public static MasterPageViewModel MasterPageViewModel { get; set; }
        public static MainPageViewModel MainPageViewModel { get; set; }
        public static ScanPageViewModel ScanPageViewModel { get; set; }

        public static LoginViewModel LoginViewModel { get; set; }
        public static RegisterViewModel RegisterViewModel { get; set; }
        public static ProfileViewModel ProfileViewModel { get; set; }
        public static EventsViewModel EventsViewModel { get; set; }
        
        public static MainMapPageViewModel MainMapPageViewModel { get; set; }
        public static AddEventViewModel AddEventViewModel { get; set; }
        public static GuideViewModel GuideViewModel { get; set; }
        public static EventDetailViewModel EventDetailViewModel { get; set; }
        public static ViewProfileViewModel ViewProfileViewModel { get; set; }

        
        public static LocationLookupViewModel LocationLookupViewModel { get; set; }

        //public static FavouritesViewModel FavouritesViewModel { get { return Resolve<FavouritesViewModel>(); } }
        // static pages


        public static MainMapPage MainMap { get; set; }
        public static UI.Pages.Profile.Profile ProfilePage { get; set; }
        public static UI.Pages.Events.Events EventsPage { get; set; }
        public static UI.Pages.Profile.MyProfile MyProfile{ get; set; }
    }
}