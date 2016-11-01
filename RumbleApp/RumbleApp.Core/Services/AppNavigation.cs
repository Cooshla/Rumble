using Xamarin;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Linq;
using RumbleApp.Core.UI;
using RumbleApp.Core.Abstracts;
using System;
using RumbleApp.Core.Interfaces;
using RumbleApp.Core.UI.Pages.Profile;
using RumbleApp.Core.UI.Pages.Events;

namespace RumbleApp.Core.Services
{
    public class AppNavigation : IAppNavigation
    {
        private readonly INavigationService _navi;
        private readonly IPageFactory _pages;

        public AppNavigation(INavigationService navi, IPageFactory pages)
        {
            _navi = navi;
            _pages = pages;
        }

        //TODO
        public Task ShowFirstPage()
        {
            throw new NotImplementedException();
        }

        public async Task GoToProfilePage(string id)
        {
            Profile prof = _pages.GetPage(Pages.ProfilePage) as Profile;
            await App.ProfileViewModel.GetData(id);
            await PushModal(prof, true);
        }

        public async Task GoToEventPage(string id)
        {
            EventDetail prof = _pages.GetPage(Pages.EventDetail) as EventDetail;
            await App.EventDetailViewModel.GetData(id);
            await PushModal(prof, true);
        }

        public async Task PopToRoot()
        {
            await _navi.PopToRootAsync(true);
        }

        public async Task PopModal()
        {
            try
            {
                if (_navi.ModalStack.Count > 0)
                {
                    await _navi.PopModalAsync(false);
                }
            }
            catch
            {
                // catching attempts here
            }
        }


		public async Task PushModal(Page modalPage)
		{
			await _navi.PushModalAsync(modalPage, true);
		}


		public async Task PushModal(Page modalPage, bool animated)
		{
			await _navi.PushModalAsync(modalPage, animated);
		}


		public async Task PushPage(Page modalPage)
		{
			await _navi.PushAsync(modalPage,false);
		}



        public async Task RemovePage(Page page)
        {
            await Task.Run(() =>
                {
                    var existingPages = _navi.NavigationStack.ToList();
                    foreach (var pag in existingPages)
                    {
                        if (pag.GetType() == page.GetType())
                        {
                            _navi.RemovePage(page);
                        }
                    }
                });
        }

        public async Task ClearAllModals()
        {
            try
            {
                for (int i = 0; i < _navi.ModalStack.Count; i++)
                {
                    await _navi.PopModalAsync();
                }
            }
            catch
            {
            }
        }

        public Task<bool> DisplayAlert(string title, string message, string accept, string cancel = null)
        {
            return _navi.DisplayAlert(title, message, accept, cancel);
        }

        public DateTime LastAlert { get; set; }
        public Task DisplayOkAlert(string title, string message, string accept)
        {
           
            if (DateTime.Now.AddSeconds(-1) > LastAlert)
            { 
                LastAlert = DateTime.Now;
                return _navi.DisplayOkAlert(title, message, accept);
            }

            return Task.FromResult<object>(null);
        }

        public Task DisplayNetworkMessage()
        {
            return _navi.DisplayOkAlert("No Connectivity", "You will need to switch on network connectivity to use this feature", "OK");
        }
        
		public Task<bool> DisplayLoginMessage()
		{
			 return _navi.DisplayAlert("Login expired", "Your login has expired, You will need to log in again before proceeding.", "Login", "Cancel");
		}


        public async Task<Page> PopPageAsync()
        {
            return await _navi.PopAsync();
        }




       
    }
}