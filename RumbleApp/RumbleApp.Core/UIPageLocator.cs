﻿using JamnationApp.Core.UI;
using JamnationApp.Core.UI.Pages.Account;
using JamnationApp.Core.UI.Pages.AutoComplete;
using JamnationApp.Core.UI.Pages.Events;
using JamnationApp.Core.UI.Pages.Guide;
using JamnationApp.Core.UI.Pages.Map;
using JamnationApp.Core.UI.Pages.Profile;
using JamnationApp.Core.UI.Pages.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamnationApp.Core
{
    public class UIPageLocator
    {
        public static void Init()
        {
            MasterPage = new MasterPage();
            MainPage = new MainPage();
            Login = new Login();
            Register = new Register();
            EventDetail = new EventDetail();
            Events = new Events();
            GuidePage = new GuidePage();
            AddEvent = new AddEvent();
            MainMapPage = new MainMapPage();
            Profile = new Profile();
            MyProfile = new MyProfile();
            LocationLookup = new LocationLookup();
            Search = new Search();
            List = new ListView();
        }

        private static MasterPage _masterPage;
        private static MainPage _mainPage;
        private static Login _login;
        private static Register _register;
        private static EventDetail _eventDetail;
        private static Events _events;
        private static GuidePage _guidePage;
        private static AddEvent _addEvent;
        private static MainMapPage _mainMapPage;
        private static Profile _profile;
        private static MyProfile _myProfile;
        private static LocationLookup _locationLookup;
        private static Search _search;
        private static ListView _list;



        public static MasterPage MasterPage
        {
            get
            {
                return _masterPage;
            }
            set
            {
                _masterPage = value;
                _masterPage.BindingContext = App.ViewModelLocator.MasterPage;
            }
        }
        public static MainPage MainPage
        {
            get
            {
                return _mainPage;
            }
            set
            {
                _mainPage = value;
                _mainPage.BindingContext = App.ViewModelLocator.MainPage;
            }
        }

        public static Login Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                _login.BindingContext = App.ViewModelLocator.Login;
            }
        }
        public static Register Register
        {
            get
            {
                return _register;
            }
            set
            {
                _register = value;
               _register.BindingContext = App.ViewModelLocator.Register;
            }
        }
        public static EventDetail EventDetail
        {
            get
            {
                return _eventDetail;
            }
            set
            {
                _eventDetail = value;
               _eventDetail.BindingContext = App.ViewModelLocator.EventDetail;
            }
        }
        public static Events Events
        {
            get
            {
                return _events;
            }
            set
            {
                _events = value;
               _events.BindingContext = App.ViewModelLocator.Events;
            }
        }
        public static GuidePage GuidePage
        {
            get
            {
                return _guidePage;
            }
            set
            {
                _guidePage = value;
               _guidePage.BindingContext = App.ViewModelLocator.Guide;
            }
        }
        public static AddEvent AddEvent
        {
            get
            {
                return _addEvent;
            }
            set
            {
                _addEvent = value;
                _addEvent.BindingContext = App.ViewModelLocator.AddEvent;
            }
        }
        public static MainMapPage MainMapPage
        {
            get
            {
                return _mainMapPage;
            }
            set
            {
                _mainMapPage = value;
                _mainMapPage.BindingContext = App.ViewModelLocator.MainMapPage;
            }
        }
        public static Profile Profile
        {
            get
            {
                return _profile;
            }
            set
            {
                _profile = value;
                _profile.BindingContext = App.ViewModelLocator.ViewProfile;
            }
        }
        public static MyProfile MyProfile
        {
            get
            {
                return _myProfile;
            }
            set
            {
                _myProfile = value;
                _myProfile.BindingContext = App.ViewModelLocator.Profile;
            }
        }
        public static LocationLookup LocationLookup
        {
            get
            {
                return _locationLookup;
            }
            set
            {
                _locationLookup = value;
                _myProfile.BindingContext = App.ViewModelLocator.LocationLookup;
            }
        }

        public static Search Search
        {
            get
            {
                return _search;
            }
            set
            {
                _search = value;
                _search.BindingContext = App.ViewModelLocator.SearchViewModel;
            }
        }

        public static ListView List
        {
            get
            {
                return _list;
            }
            set
            {
                _list = value;
                //_myProfile.BindingContext = App.ViewModelLocator.LocationLookup;
            }
        }

    }
}
