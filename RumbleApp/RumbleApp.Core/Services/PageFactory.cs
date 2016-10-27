using System;
using RumbleApp.Core;
using RumbleApp.Core.Interfaces;
using RumbleApp.Core.UI;
using Xamarin.Forms;
using RumbleApp.Core.UI.Pages.Profile;
using RumbleApp.Core.UI.Pages.Account;
using RumbleApp.Core.UI.Pages.Map;

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
                case Pages.ProfilePage: return new Profile();
                case Pages.LoginPage: return new Login();
                case Pages.RegisterPage: return new Register();
                case Pages.MainMapPage:return new MainMapPage(); 
                case Pages.AddEventPage: return new AddEvent();

                default: throw new ArgumentException(string.Format("Unknown page type {0}", page));
			}
		}
	}
}