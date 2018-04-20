using Xamarin.Forms;

namespace JamnationApp.Core.Interfaces
{
	public enum Pages
	{

        MainPage,
        LoginPage,
        RegisterPage,
        Forgot,
        ProfilePage,
        ScanPage,
        MainMapPage,
        AddEventPage,
        Guide,
        AddressLookup,
        EventDetail,
        Search,
        List,
        Map,
        Chat
    }

    public interface IPageFactory
	{
		Page GetPage(Pages page);
	}
}

