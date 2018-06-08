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
                var lst = new List<Xamarin.Forms.Maps.Position>();
                foreach (var pin in arg)
                {
                    var pos = new Xamarin.Forms.Maps.Position(pin.Latitude, pin.Longitude);
                    lst.Add(pos);
                    var mapPin = new Xamarin.Forms.Maps.Pin()
                    {
                        Position = pos,
                        Address = pin.Location,
                        Label = pin.DisplayName
                    };

                    mapPin.Clicked += (s, e) => { MapPinClicked(pin.ProfileId); }; 
                    MyMap.Pins.Add(mapPin);
                }
                
                var center = GetCentralGeoCoordinate(lst);
                this.MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(center.Latitude, center.Longitude), Distance.FromKilometers(50)));
            });
        }

        private EventHandler MapPinClicked(int profileId)
        {
            MessagingCenter.Send<Map, int>(this, Messages.MapPinClicked, profileId);
            return null;
        }

        public static Position GetCentralGeoCoordinate(
       IList<Position> geoCoordinates)
        {
            if (geoCoordinates.Count == 1)
            {
                return geoCoordinates.Single();
            }

            double x = 0;
            double y = 0;
            double z = 0;

            foreach (var geoCoordinate in geoCoordinates)
            {
                var latitude = geoCoordinate.Latitude * Math.PI / 180;
                var longitude = geoCoordinate.Longitude * Math.PI / 180;

                x += Math.Cos(latitude) * Math.Cos(longitude);
                y += Math.Cos(latitude) * Math.Sin(longitude);
                z += Math.Sin(latitude);
            }

            var total = geoCoordinates.Count;

            x = x / total;
            y = y / total;
            z = z / total;

            var centralLongitude = Math.Atan2(y, x);
            var centralSquareRoot = Math.Sqrt(x * x + y * y);
            var centralLatitude = Math.Atan2(z, centralSquareRoot);

            return new Position(centralLatitude * 180 / Math.PI, centralLongitude * 180 / Math.PI);
        }

    }
}