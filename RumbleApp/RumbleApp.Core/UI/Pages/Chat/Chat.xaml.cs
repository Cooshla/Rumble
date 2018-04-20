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
    public partial class Chat : ContentPage
    {
        public Chat()
        {
            BindingContext = App.ViewModelLocator.ChatViewModel;
            InitializeComponent();
        }

        private void MessagesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void MessagesListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}