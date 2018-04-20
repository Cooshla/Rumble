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
    public partial class ChatHistory : ContentPage
    {
        public ChatHistory()
        {
            BindingContext = App.ViewModelLocator.ChatHistoryViewModel;
            InitializeComponent();
        }

        private void list_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            MessagingCenter.Send<ChatHistory, JamnationApp.Core.Models.Profile>(this, Messages.FriendsClicked, null);
        }
    }
}