using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup;
using Xamarin.Forms;
using Rg.Plugins.Popup.Pages;
using RumbleApp.Core.ViewModels.AutoComplete;
using RumbleApp.Core.ViewModels.Map;

namespace RumbleApp.Core.UI.Pages.Map
{
    public partial class AddEvent : ContentPage
    {
        public AddEvent()
        {
            BindingContext = App.AddEventViewModel;
            InitializeComponent();
            LocationEntry.Focused += LocationEntry_Focused;
        }

        private void LocationEntry_Focused(object sender, FocusEventArgs e)
        {
            MessagingCenter.Send<AddEventViewModel, bool>(App.AddEventViewModel, Messages.AddressLookupCalled, true);
        }
        
    }
}
