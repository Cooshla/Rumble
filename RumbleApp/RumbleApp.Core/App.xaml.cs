using Autofac;
using System;
using System.Collections.Generic;
using JamnationApp.Core.Abstracts;
using Xamarin.Forms;
using JamnationApp.Core.Services;
using System.Threading.Tasks;
using JamnationApp.Core.Helpers;
using INavigationService = JamnationApp.Core.Interfaces.INavigationService;
using XLabs.Platform.Device;
using Xamarin.Forms.Maps;
using JamnationApp.Core.Interfaces;
using JamnationApp.Core.UI;
using JamnationApp.Core.ViewModels;
using Acr.UserDialogs;
using JamnationApp.Core.ViewModels.Map;
using JamnationApp.Core.ViewModels.Events;
using XLabs.Platform.Services.Media;
using JamnationApp.Core.Models;
using JamnationApp.Core.UI.Pages.Map;
using JamnationApp.Core.ViewModels.Guide;
using JamnationApp.Core.ViewModels.AutoComplete;
using JamnationApp.Core.ViewModels.Profile;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace JamnationApp.Core
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

            UIPageLocator.Init();
            NaviService = _container.Resolve<INavigationService>() as NavigationService;

            var pageFactory = _container.Resolve<IPageFactory>();
            var home = pageFactory.GetPage(Pages.MainPage) as MasterDetailPage;
            var scan = pageFactory.GetPage(Pages.Search);
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
            App.ViewModelLocator = new ViewModelLocator(_container);

        }

        public static ViewModelLocator ViewModelLocator  { get; set;}
        public static IDisplay DeviceDisplay { get; set; }



        public static void SetNavService(Page page)
        {
            NaviService.Navi = page.Navigation;
            NaviService.myPage = page;
        }





        public static DateTime AppLoadedDateTime { get; set; }
        public static DateTime PageOpenedDateTime { get; set; }


        

    }
}