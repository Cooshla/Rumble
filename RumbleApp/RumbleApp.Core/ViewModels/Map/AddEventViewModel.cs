using Acr;
using RumbleApp.Core.Interfaces;
using RumbleApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace RumbleApp.Core.ViewModels.Map
{
    public class AddEventViewModel :BaseViewModel
    {
        public string EventName { get; set; }

        public string Places { get; set; }
        public string Location { get; set; }

        public string Description { get; set; }


        private DateTime startDateTime = DateTime.Now;

        public DateTime StartDateTime
        {
            get { return startDateTime; }
            set { startDateTime = value; OnPropertyChanged("StartDateTime"); }
        }

        private DateTime endDateTime = DateTime.Now;

        public DateTime EndDateTime
        {
            get { return endDateTime; }
            set { endDateTime = value; OnPropertyChanged("EndDateTime"); }
        }


        private IPageFactory PageFac { get; set; }
        private IAppNavigation Navi { get; set; }
        private IEventService Evnt { get; set; }

        public ICommand AddEventCommand { get { return new Xamarin.Forms.Command(AddEvent); } }
        public ICommand BackCommand { get { return new Xamarin.Forms.Command(Back); } }

        public AddEventViewModel(IPageFactory _page, IAppNavigation _navi, IEventService _envt)
        {
            PageFac = _page;
            Navi = _navi;
            Evnt = _envt;

            RegisterMessaging();
        }

        private void RegisterMessaging()
        {
            MessagingCenter.Subscribe<AddEventViewModel, bool>(this, Messages.AddressLookupCalled, (sender, arg) => {
                Navi.PushModal(PageFac.GetPage(Pages.AddressLookup));
            });
        }
        

        public async void AddEvent()
        {
            App.UserDialogService.ShowLoading("Adding Event...");

            Event evt = new Event();
            evt.Name = EventName;
            evt.StartDate = StartDateTime;
            evt.Location = Location;
            evt.Places = int.Parse(Places);
            evt.ProfileId = App.ThisUser.Profile.ProfileId;
            evt.IsActive = true;
            

            await Evnt.AddEvent(evt);
            ResetForm();
            await Navi.PopModal();
            App.UserDialogService.HideLoading();

            App.UserDialogService.Toast("Event Added");
        }
        private void ResetForm()
        {

            EventName = string.Empty;
            StartDateTime = DateTime.Today;
            EndDateTime = DateTime.Today;
            Location = string.Empty;
            Places = string.Empty;
            Description = string.Empty;

            OnPropertyChanged("EventName");
            OnPropertyChanged("Location");
            OnPropertyChanged("Places");
            OnPropertyChanged("StartDateTime");
            OnPropertyChanged("EndDateTime");
            OnPropertyChanged("Description");

        }
        public async void Back()
        {
            ResetForm();
            await Navi.PopModal();
        }
    }
}
