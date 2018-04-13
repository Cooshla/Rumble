using JamnationApp.Core.Abstracts;
using JamnationApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace JamnationApp.Core.UI.Pages.Profile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        public Profile()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<ProfileViewModel, CustomPin>(this, Messages.MapPinsReady, (sends, arg) =>
            {
                MainMap.CustomPins = new List<CustomPin>() { arg };
                MainMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(arg.Pin.Position.Longitude, arg.Pin.Position.Latitude), Distance.FromMiles(1.0)));
            });

        }
    }
}
