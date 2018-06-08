using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JamnationApp.Core.UI.Pages.Search
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Search : ContentPage
	{
		public Search ()
		{
			InitializeComponent ();
		}

        public void InterestsFocused(object sender, FocusEventArgs e)
        {
            App.ViewModelLocator.SearchViewModel.ShowInterestsPopup();

        }
    }
}