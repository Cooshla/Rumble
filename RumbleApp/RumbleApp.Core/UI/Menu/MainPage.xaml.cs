using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RumbleApp.Core.Objects;
using Xamarin.Forms.Xaml;
using RumbleApp.Core.Models;
using Xamarin.Forms;
using RumbleApp.Core.UI.Pages.Map;
using RumbleApp.Core.UI.Pages.Events;

namespace RumbleApp.Core.UI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            masterPage.ListView.ItemSelected += OnItemSelected;

        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Models.MenuItem;

            if (item != null)
            {
                if (item.TargetType == typeof(Profile))
                {
                    Detail = new NavigationPage(App.ProfilePage);
                    MessagingCenter.Send<MainPage, bool>(this, Messages.ProfileClicked, true);
                }
                else if (item.TargetType == typeof(MainMapPage))
                {
                    Detail = new NavigationPage(App.MainMap);
                    MessagingCenter.Send<MainPage, bool>(this, Messages.HomeClicked, true);
                }
                else if (item.TargetType == typeof(Events))
                {
                    Detail = new NavigationPage(App.EventsPage);
                    MessagingCenter.Send<MainPage, bool>(this, Messages.EventsClicked, true);
                }
                else
                    Detail = item.Args != null ? new NavigationPage((Page)Activator.CreateInstance(item.TargetType, item.Args)) : new NavigationPage((Page)Activator.CreateInstance(item.TargetType));

                IsPresented = false;
                masterPage.ListView.SelectedItem = null;
                App.SetNavService(Detail);
            }
        }
    }
}
