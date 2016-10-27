using Autofac;
using System;
using System.Collections.Generic;
using BlankXamarinApp.Core.Abstracts;
using Xamarin.Forms;
using BlankXamarinApp.Core.Services;
using System.Threading.Tasks;
using BlankXamarinApp.Core.Helpers;
using INavigationService = BlankXamarinApp.Core.Interfaces.INavigationService;
using XLabs.Platform.Device;
using Xamarin.Forms.Maps;
using BlankXamarinApp.Core.Interfaces;
using BlankXamarinApp.Core.UI;
using BlankXamarinApp.Core.ViewModels;
using Acr.UserDialogs;
using BlankXamarinApp.Core.ViewModels.Map;
using BlankXamarinApp.Core.ViewModels.Events;
using XLabs.Platform.Services.Media;
using BlankXamarinApp.Core.Models;

namespace BlankXamarinApp.Core
{
    public partial class App : Application
    {
        public static User ThisUser { get; set; }
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

            SetNavService(scan);

            NaviService.PushModalAsync(pageFactory.GetPage(Pages.LoginPage),true);
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
    }
}