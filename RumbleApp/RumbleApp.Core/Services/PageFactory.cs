using System;
using RumbleApp.Core;
using RumbleApp.Core.Interfaces;
using RumbleApp.Core.UI;
using Xamarin.Forms;
using RumbleApp.Core.UI.Pages.Profile;
using RumbleApp.Core.UI.Pages.Account;
using RumbleApp.Core.UI.Pages.Map;
using RumbleApp.Core.UI.Pages.Guide;

namespace RumbleApp.Core.Services
{
	public class PageFactory : IPageFactory
	{
		public Page GetPage(Pages page)
		{
			switch (page)
            {
                case Pages.MainPage: return new MainPage();
                case Pages.ScanPage: return new ScanPage();
                case Pages.ProfilePage: return App.ProfilePage;
                case Pages.LoginPage: return new Login();
                case Pages.RegisterPage: return new Register();
                case Pages.Guide: return new GuidePage();
                case Pages.MainMapPage:return App.MainMap; 
                case Pages.AddEventPage: return new AddEvent();

                default: throw new ArgumentException(string.Format("Unknown page type {0}", page));
			}
		}
	}
}