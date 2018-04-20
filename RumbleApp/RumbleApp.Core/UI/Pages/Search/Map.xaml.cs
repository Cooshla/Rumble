using JamnationApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace JamnationApp.Core.UI.Pages.Search
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Map : ContentPage
    {
        public Map()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<SearchViewModel, List<JamnationApp.Core.Models.Profile>>(this, Messages.SearchResults, (sender, arg) => {
               
                foreach(var pin in arg)
                {
                    MyMap.Pins.Add(new Xamarin.Forms.Maps.Pin() { Position = new Xamarin.Forms.Maps.Position(52.130162, - 8.278229),
                        Address = "123 fake st", Label = "123 Fake street" });

                    this.MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(52.130162, -8.278229), Distance.FromKilometers(50)));

                    break;
                }
            });
        }
    }
}