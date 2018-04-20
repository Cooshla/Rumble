using Autofac;
using JamnationApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace JamnationApp.Core.ViewModels.Profile
{
    public class ChatHistoryViewModel : BaseViewModel
    {

        public ICommand ConnectCommand { get { return new Command(Connect); } }

        

        private IAppNavigation Navi { get; set; }
        private IPageFactory Page { get; set; }
        public bool IsBusy { get; set; }
        public List<JamnationApp.Core.Models.Profile> SearchResults { get; set; }
        public ChatHistoryViewModel(IPageFactory _page, IAppNavigation _navi)
        {
            Navi = _navi;
            Page = _page;
            List<JamnationApp.Core.Models.Profile> SearchResults = new List<Models.Profile>();
            SearchResults.Add(new Models.Profile());
            SearchResults.Add(new Models.Profile());
            SearchResults.Add(new Models.Profile());
            SearchResults.Add(new Models.Profile());
            SearchResults.Add(new Models.Profile());
            SearchResults.Add(new Models.Profile());
            SearchResults.Add(new Models.Profile());
            SearchResults.Add(new Models.Profile());
            SearchResults.Add(new Models.Profile());
            SearchResults.Add(new Models.Profile());

            
           
        }

        private async void Connect(object obj)
        {
            var success = false;
            string message = string.Empty;
            try
            {
                IsBusy = true;
                success = await App.TwilioMessenger.InitializeAsync();
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
                IsBusy = false;
            }

            if (success)
            {
                await Navi.PushModal(Page.GetPage(Pages.Chat));
            }
            else
            {
                App.UserDialogService.Alert("Sad Monkeys", $"Unable to join #general: {message}", "OK");
            }
        }
    }
}
