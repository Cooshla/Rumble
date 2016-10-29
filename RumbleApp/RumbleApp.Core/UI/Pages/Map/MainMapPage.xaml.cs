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

            InitializeComponent(); MessagingCenter.Subscribe<MainMapPageViewModel,List<Pin>>(this,Messages.MapPinsReady, (sends, arg) =>
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        MainMap.Pins.Clear();
                        foreach (Pin p in arg)
                        {
                            MainMap.Pins.Add(p);
                        }
                    });
                    
                });
        }
    }
}
