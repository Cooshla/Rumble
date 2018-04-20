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
            
                MyMap.Pins.Add(new Xamarin.Forms.Maps.Pin()
            {
                Position = new Xamarin.Forms.Maps.Position(52.130162, -8.278229),
                Address = "123 fake st",
                Label = "123 Fake street"
            });

            this.MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(52.130162, -8.278229), Distance.FromKilometers(50)));
            
        }
    }
}
