using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace JamnationApp.Core.UI.Pages.AutoComplete
{
    public partial class LocationLookup : ContentPage
    {
        public LocationLookup()
        {
            InitializeComponent();
            Autocomplete.TextChanged += Autocomplete_TextChanged;
        }

        private void Autocomplete_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length > 3)
                App.ViewModelLocator.LocationLookup.GetItems(e.NewTextValue);
        }
    }
}
