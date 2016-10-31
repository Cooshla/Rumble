using Xamarin.Forms;

namespace RumbleApp.Core.Interfaces
{
	public enum Pages
	{

        MainPage,
        LoginPage,
        RegisterPage,
        ProfilePage,
        ScanPage,
        MainMapPage,
        AddEventPage,
        Guide,
        AddressLookup
    }

    public interface IPageFactory
	{
		Page GetPage(Pages page);
	}
}

