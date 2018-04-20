using Autofac;
using JamnationApp.Core.ViewModels;
using JamnationApp.Core.ViewModels.AutoComplete;
using JamnationApp.Core.ViewModels.Events;
using JamnationApp.Core.ViewModels.Guide;
using JamnationApp.Core.ViewModels.Map;
using JamnationApp.Core.ViewModels.Profile;

namespace JamnationApp.Core
{
    public class ViewModelLocator
    {
        public ViewModelLocator(IContainer _container) 
        {
            MasterPage = _container.Resolve<MasterPageViewModel>();
            MainPage = _container.Resolve<MainPageViewModel>();
            Login = _container.Resolve<LoginViewModel>();
            Register = _container.Resolve<RegisterViewModel>();
            Forgot = _container.Resolve<ForgotViewModel>();
            Profile = _container.Resolve<ProfileViewModel>();

            MainMapPage = _container.Resolve<MainMapPageViewModel>();
            AddEvent = _container.Resolve<AddEventViewModel>();
            Events = _container.Resolve<EventsViewModel>();
            Guide = _container.Resolve<GuideViewModel>();
            LocationLookup = _container.Resolve<LocationLookupViewModel>();
            EventDetail = _container.Resolve<EventDetailViewModel>();
            ViewProfile = _container.Resolve<ViewProfileViewModel>();
            SearchViewModel = _container.Resolve<SearchViewModel>();

            ListViewModel = _container.Resolve<ListViewModel>();
            MapViewModel = _container.Resolve<MapViewModel>();
            FriendsViewModel = _container.Resolve<FriendsViewModel>();
            ChatHistoryViewModel = _container.Resolve<ChatHistoryViewModel>();
            ChatViewModel = _container.Resolve<ChatViewModel>();
            ChatViewModel.InitializeMock();
        }

        public  MasterPageViewModel MasterPage { get; set; }
        public  MainPageViewModel MainPage { get; set; }

        public  LoginViewModel Login { get; set; }
        public  RegisterViewModel Register { get; set; }
        public ForgotViewModel Forgot { get; set; }
        public  ProfileViewModel Profile { get; set; }
        public  EventsViewModel Events { get; set; }

        public  MainMapPageViewModel MainMapPage { get; set; }
        public  AddEventViewModel AddEvent { get; set; }
        public  GuideViewModel Guide { get; set; }
        public  EventDetailViewModel EventDetail { get; set; }
        public ViewProfileViewModel ViewProfile { get; set; }
        public SearchViewModel SearchViewModel { get; set; }
        public ListViewModel ListViewModel { get; set; }
        public MapViewModel MapViewModel { get; set; }
        public FriendsViewModel FriendsViewModel { get; set; }

        public ChatHistoryViewModel ChatHistoryViewModel { get; set; }
        public ChatViewModel ChatViewModel { get; set; }


        public  LocationLookupViewModel LocationLookup { get; set; }
    }
}
