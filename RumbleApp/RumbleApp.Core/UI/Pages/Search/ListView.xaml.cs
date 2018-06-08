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
        }

        private void list_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            JamnationApp.Core.Models.Profile obj = e.Item as JamnationApp.Core.Models.Profile;
            if (obj != null)
                MessagingCenter.Send<ListView, JamnationApp.Core.Models.Profile>(this, Messages.ProfileClicked, obj);
        }
    }
}