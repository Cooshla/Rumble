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
        private IAppNavigation Navi { get; set; }
        private IPageFactory Page { get; set; }
        public bool IsBusy { get; set; }
        public List<JamnationApp.Core.Models.Profile> SearchResults { get; set; }
        public ChatHistoryViewModel(IPageFactory _page, IAppNavigation _navi)
        {
            Navi = _navi;
            Page = _page;

            List<JamnationApp.Core.Models.Profile> SearchResults = new List<Models.Profile>();

            // get chat history from api



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
        
    }
}
