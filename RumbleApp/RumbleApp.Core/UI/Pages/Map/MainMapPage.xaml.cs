using RumbleApp.Core.Abstracts;
using RumbleApp.Core.ViewModels.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace RumbleApp.Core.UI.Pages.Map
{
    public partial class MainMapPage : ContentPage
    {
        public MainMapPage()
        {
            BindingContext = App.MainMapPageViewModel;

            InitializeComponent();


            MessagingCenter.Subscribe<MainMapPageViewModel, List<CustomPin>>(this, Messages.MapPinsReady, (sends, arg) =>
                  {
                      MainMap.CustomPins = arg;
                      MainMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(51.5074, -0.1278), Distance.FromMiles(1.0)));
                  });

        }
    }
}
