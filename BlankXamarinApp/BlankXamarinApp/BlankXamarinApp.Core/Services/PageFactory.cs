using System;
using BlankXamarinApp.Core;
using BlankXamarinApp.Core.Interfaces;
using BlankXamarinApp.Core.UI;
using Xamarin.Forms;
using BlankXamarinApp.Core.UI.Pages.Profile;
using BlankXamarinApp.Core.UI.Pages.Account;
using BlankXamarinApp.Core.UI.Pages.Map;

namespace BlankXamarinApp.Core.Services
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