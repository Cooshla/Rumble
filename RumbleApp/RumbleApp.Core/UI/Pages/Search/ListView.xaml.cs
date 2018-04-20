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
	public partial class ListView : ContentPage
	{
		public ListView ()
		{
			InitializeComponent ();
            /*List<int> data = new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            list.ItemsSource = data;*/
        }

        private void list_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            MessagingCenter.Send<ListView, JamnationApp.Core.Models.Profile>(this, Messages.ProfileClicked, null);
        }
    }
}