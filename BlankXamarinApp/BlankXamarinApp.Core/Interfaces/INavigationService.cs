using System.Threading.Tasks;
using Xamarin.Forms;

namespace BlankXamarinApp.Core.Interfaces
{
	public interface INavigationService : INavigation
	{
		Task<bool> DisplayAlert(string title, string message, string accept = "ok", string cancel = "cancel");
		Task DisplayOkAlert(string title, string message, string accept = "ok");
	}
}

