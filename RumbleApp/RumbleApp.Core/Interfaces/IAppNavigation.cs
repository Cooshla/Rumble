using Xamarin.Forms;
using System.Threading.Tasks;

namespace RumbleApp.Core.Interfaces
{
	public interface IAppNavigation
	{
		Task ShowFirstPage();
        
		
		Task PopToRoot();
		Task ClearAllModals();
		Task PushModal(Page modalPage);
		Task PushModal (Page modalPage, bool animated);
		Task PushPage(Page modalPage);
		Task PopModal();
		Task RemovePage(Page page);
		Task<bool> DisplayAlert(string title, string message, string accept = "ok", string cancel = "cancel");
		Task DisplayOkAlert (string title, string message, string accept);
		Task DisplayNetworkMessage();
		Task<bool> DisplayLoginMessage();

		Task<Page> PopPageAsync ();
	}
}
