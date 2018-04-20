using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JamnationApp.Core.UI.Pages.Profile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Friends : ContentPage
    {
        public Friends()
        {
            BindingContext = App.ViewModelLocator.FriendsViewModel;
            InitializeComponent();
        }


        private void list_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            MessagingCenter.Send<Friends, JamnationApp.Core.Models.Profile>(this, Messages.ProfileClicked, null);
        }
    }
}