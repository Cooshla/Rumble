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
        public DateTime Time { get; set; }
        public int Places { get; set; }
        public string Location { get; set; }



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
            evt.StartDate = Time;
            evt.Location = Location;
            evt.Places = Places;
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
