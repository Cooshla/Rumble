using Xamarin.Forms;

namespace BlankXamarinApp.Core.Interfaces
{
	public enum Pages
	{

        MainPage,
        LoginPage,
        RegisterPage,
        ProfilePage,
        ScanPage,
        MainMapPage,
        AddEventPage
        
    }

	public interface IPageFactory
	{
		Page GetPage(Pages page);
	}
}

