using System;
using JamnationApp.Core;
using JamnationApp.Core.Interfaces;
using JamnationApp.Core.UI;
using Xamarin.Forms;
using JamnationApp.Core.UI.Pages.Profile;
using JamnationApp.Core.UI.Pages.Account;
using JamnationApp.Core.UI.Pages.Map;
using JamnationApp.Core.UI.Pages.Guide;
using JamnationApp.Core.ViewModels.AutoComplete;
using JamnationApp.Core.UI.Pages.AutoComplete;
using JamnationApp.Core.UI.Pages.Events;

namespace JamnationApp.Core.Services
{
	public class PageFactory : IPageFactory
	{
		public Page GetPage(Pages page)
		{
			switch (page)
            {
                case Pages.MainPage: return new MainPage();
                case Pages.ProfilePage: return UIPageLocator.Profile;
                case Pages.LoginPage: return  UIPageLocator.Login;
                case Pages.RegisterPage: return  UIPageLocator.Register;
                case Pages.Guide: return UIPageLocator.GuidePage;
                case Pages.MainMapPage:return UIPageLocator.MainMapPage;
                case Pages.AddEventPage: return UIPageLocator.AddEvent;
                case Pages.AddressLookup: return UIPageLocator.LocationLookup;
                case Pages.EventDetail: return UIPageLocator.EventDetail;
                case Pages.Search: return UIPageLocator.Search;
                case Pages.List: return UIPageLocator.List;
                default: throw new ArgumentException(string.Format("Unknown page type {0}", page));
			}
		}
	}
}