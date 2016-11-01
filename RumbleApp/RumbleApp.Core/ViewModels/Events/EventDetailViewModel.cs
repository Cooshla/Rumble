using RumbleApp.Core.Interfaces;
using RumbleApp.Core.Models;
using RumbleApp.Core.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RumbleApp.Core.ViewModels.Events
{
    public class EventDetailViewModel : BaseViewModel
    {
        Event Evt { get; set; }
        private IAppNavigation Navi { get; set; }
        private IPageFactory Page { get; set; }
        private IProfileService Prof { get; set; }
        private IEventService Evnt { get; set; }

        


        public EventDetailViewModel(IPageFactory _page, IAppNavigation _navi, IProfileService _prof, IEventService _evnt)
        {
            Navi = _navi;
            Page = _page;
            Prof = _prof;
            Evnt = _evnt;
            
        }

        public async Task GetData(string id)
        {
            Evt = await Evnt.GetEvent(int.Parse(id));
            OnPropertyChanged("Evt");
        }
    }
}
