using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup;
using Xamarin.Forms;
using Rg.Plugins.Popup.Pages;
using JamnationApp.Core.ViewModels.AutoComplete;
using JamnationApp.Core.ViewModels.Map;

namespace JamnationApp.Core.UI.Pages.Map
{
    public partial class AddEvent : ContentPage
    {
        public AddEvent()
        {
            InitializeComponent();
            LocationEntry.Focused += LocationEntry_Focused;
        }

        private void LocationEntry_Focused(object sender, FocusEventArgs e)
        {
            MessagingCenter.Send<AddEventViewModel, bool>(App.ViewModelLocator.AddEvent, Messages.AddressLookupCalled, true);
        }
        
    }
}
