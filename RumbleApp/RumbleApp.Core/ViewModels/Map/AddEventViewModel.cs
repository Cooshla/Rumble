using Acr;
using RumbleApp.Core.Interfaces;
using RumbleApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RumbleApp.Core.ViewModels.Map
{
    public class AddEventViewModel :BaseViewModel
    {
        public string EventName { get; set; }
        public DateTime Time { get; set; }
        public int Places { get; set; }
        public string Location { get; set; }



        private IPageFactory PageFac { get; set; }
        private IAppNavigation Navi { get; set; }
        private IEventService Evnt { get; set; }

        public ICommand AddEventCommand { get { return new Command(AddEvent); } }
        public ICommand BackCommand { get { return new Command(Back); } }

        public AddEventViewModel(IPageFactory _page, IAppNavigation _navi, IEventService _envt)
        {
            PageFac = _page;
            Navi = _navi;
            Evnt = _envt;

        }

        

        public async void AddEvent()
        {
            App.UserDialogService.ShowLoading("Adding Event...");

            Event evt = new Event();
            evt.Name = EventName;
            evt.StartDate = Time;
            evt.Location = Location;
            evt.Places = Places;

            await Evnt.AddEvent(evt);
            ResetForm();
            await Navi.PopModal();
            App.UserDialogService.HideLoading();

            App.UserDialogService.Toast("Event Added");
        }
        private void ResetForm()
        {

            EventName = string.Empty;
            Time = DateTime.Today;
            Location = string.Empty;
            Places = 0;

            OnPropertyChanged("EventName");
            OnPropertyChanged("Time");
            OnPropertyChanged("Location");
            OnPropertyChanged("Places");

        }
        public async void Back()
        {
            ResetForm();
            await Navi.PopModal();
        }
    }
}
