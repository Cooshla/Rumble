using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamnationApp.Core.Objects;
using Xamarin.Forms.Xaml;
using JamnationApp.Core.Models;
using Xamarin.Forms;
using JamnationApp.Core.UI.Pages.Map;
using JamnationApp.Core.UI.Pages.Events;
using JamnationApp.Core.UI.Pages.Profile;

namespace JamnationApp.Core.UI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            masterPage.ListView.ItemSelected += OnItemSelected;

            MessagingCenter.Subscribe<NavigationPage>(this, Messages.AddressLookupCalled, (pageItem) =>
            {
                pageItem.Parent = null; // solution
                Detail = pageItem;
                IsPresented = false;
            });

        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {


                var item = e.SelectedItem as Models.MenuItem;

                if (item != null)
                {

                    if (item.TargetType == typeof(MainMapPage))
                    {
                        Detail = new NavigationPage(UIPageLocator.MainMapPage);
                        MessagingCenter.Send<MainPage, bool>(this, Messages.HomeClicked, true);
                    }
                    else if (item.TargetType == typeof(Friends))
                    {
                        Detail = new NavigationPage(UIPageLocator.Friends);
                        MessagingCenter.Send<MainPage, bool>(this, Messages.FriendsClicked, true);
                    }
                    else if (item.TargetType == typeof(MyProfile))
                    {
                        MessagingCenter.Send<MainPage, bool>(this, Messages.ProfileClicked, true);
                        await Task.Delay(500);
                        Detail = new NavigationPage(UIPageLocator.MyProfile);
                    }
                    else
                        Detail = item.Args != null ? new NavigationPage((Page)Activator.CreateInstance(item.TargetType, item.Args)) : new NavigationPage((Page)Activator.CreateInstance(item.TargetType));

                    IsPresented = false;
                    masterPage.ListView.SelectedItem = null;
                    App.SetNavService(Detail);
                }
            }catch(Exception ex)
            {
                string s = ex.Message;
            }
        }
    }
}
