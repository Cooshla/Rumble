using Autofac;
using JamnationApp.Core.Interfaces;
using JamnationApp.Core.Services;
using JamnationApp.Core.ViewModels;
using JamnationApp.Core.ViewModels.AutoComplete;
using JamnationApp.Core.ViewModels.Events;
using JamnationApp.Core.ViewModels.Guide;
using JamnationApp.Core.ViewModels.Map;
using JamnationApp.Core.ViewModels.Profile;

namespace JamnationApp.Core
{
    // we can inherit and override this class on each platform to make services specific
    public class AppSetup
    {

        public string PackageFolder { get; set; }
        public string ImportPackagePath { get; set; }

        /// <summary>
        /// Creates an instance of the AutoFac container
        /// </summary>
        /// <returns>A new instance of the AutoFac container</returns>
        /// <remarks>
        /// https://github.com/autofac/Autofac/wiki
        /// </remarks>
        public IContainer CreateContainer()
        {
            var cb = new ContainerBuilder();

            RegisterDepenencies(cb);

            return cb.Build();
        }

        protected virtual void RegisterDepenencies(ContainerBuilder cb)
        {
            // Services

            cb.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            cb.RegisterType<AppNavigation>().As<IAppNavigation>().SingleInstance();
            cb.RegisterType<PageFactory>().As<IPageFactory>().SingleInstance();
            cb.RegisterType<RestService>().As<IRestService>().SingleInstance();
            cb.RegisterType<AccountService>().As<IAccountService>().SingleInstance();
            cb.RegisterType<ProfileService>().As<IProfileService>().SingleInstance();
            cb.RegisterType<EventService>().As<IEventService>().SingleInstance();
            cb.RegisterType<UserService>().As<IUserService>().SingleInstance();
            cb.RegisterType<LocationServices>().As<ILocationServices>().SingleInstance();

            // View Models
            cb.RegisterType<MasterPageViewModel>().SingleInstance();
            cb.RegisterType<MainPageViewModel>().SingleInstance();
            cb.RegisterType<LoginViewModel>().SingleInstance();
            cb.RegisterType<RegisterViewModel>().SingleInstance();
            cb.RegisterType<ForgotViewModel>().SingleInstance();
            
            cb.RegisterType<ProfileViewModel>().SingleInstance();
            cb.RegisterType<MainMapPageViewModel>().SingleInstance();
            cb.RegisterType<AddEventViewModel>().SingleInstance();
            cb.RegisterType<EventsViewModel>().SingleInstance();
            cb.RegisterType<GuideViewModel>().SingleInstance();
            cb.RegisterType<LocationLookupViewModel>().SingleInstance();
            cb.RegisterType<EventDetailViewModel>().SingleInstance();
            cb.RegisterType<ViewProfileViewModel>().SingleInstance();
            cb.RegisterType<SearchViewModel>().SingleInstance();
            cb.RegisterType<ListViewModel>().SingleInstance();
            cb.RegisterType<MapViewModel>().SingleInstance();
            cb.RegisterType<FriendsViewModel>().SingleInstance();
            cb.RegisterType<ChatHistoryViewModel>().SingleInstance();
            cb.RegisterType<ChatViewModel>().SingleInstance();


        }
    }
}

