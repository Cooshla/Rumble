using System;
using CoreLocation;
using UIKit;

namespace BlankXamarinApp.iOS
{
    public class LocationManager
    {

        // event for the location changing
        public event EventHandler<LocationUpdatedEventArgs> LocationUpdated = delegate { };

        public LocationManager()
        {
            this.locMgr = new CLLocationManager();
            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                locMgr.RequestAlwaysAuthorization(); // works in background
                //locMgr.RequestWhenInUseAuthorization (); // only in foreground
            }

            //LocationUpdated += PrintLocation;
        }

        // create a location manager to get system location updates to the application
        public CLLocationManager LocMgr
        {
            get
            {
                return this.locMgr;
            }
        } protected CLLocationManager locMgr;

        public void StartLocationUpdates()
        {
            // We need the user's permission for our app to use the GPS in iOS. This is done either by the user accepting
            // the popover when the app is first launched, or by changing the permissions for the app in Settings

            if (CLLocationManager.LocationServicesEnabled)
            {
				if (CLLocationManager.LocationServicesEnabled) {
					//set the desired accuracy, in meters
					LocMgr.DesiredAccuracy = 1;
					LocMgr.LocationsUpdated += (object sender, CLLocationsUpdatedEventArgs e) =>
					{
						// fire our custom Location Updated event
						LocationUpdated (this, new LocationUpdatedEventArgs (e.Locations [e.Locations.Length - 1]));
					};
					LocMgr.StartUpdatingLocation();
				}
            }
            else
            {
                //Let the user know that they need to enable LocationServices
                Console.WriteLine("Location services not enabled, please enable this in your Settings");
            }
        }

        //This will keep going in the background and the foreground
    //    public void PrintLocation(object sender, LocationUpdatedEventArgs e)
  //      {
      //      CLLocation location = e.Location;

//            Console.WriteLine("Altitude: " + location.Altitude + " meters");
//            Console.WriteLine("Longitude: " + location.Coordinate.Longitude);
//            Console.WriteLine("Latitude: " + location.Coordinate.Latitude);
//            Console.WriteLine("Course: " + location.Course);
//            Console.WriteLine("Speed: " + location.Speed);

   //     }

    }
}