using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RumbleApp.Core.UI.Pages.AutoComplete
{
    public partial class LocationLookup : ContentPage
    {
        public LocationLookup()
        {
            BindingContext = App.LocationLookupViewModel;
            InitializeComponent();
            Autocomplete.TextChanged += Autocomplete_TextChanged;
        }

        private void Autocomplete_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length > 5)
                App.LocationLookupViewModel.GetItems(e.NewTextValue);
        }
    }
}
