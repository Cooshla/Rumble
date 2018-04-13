using Xamarin.Forms;

namespace JamnationApp.Core.Interfaces
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
        AddressLookup,
        EventDetail,
        Search,
        List
    }

    public interface IPageFactory
	{
		Page GetPage(Pages page);
	}
}

