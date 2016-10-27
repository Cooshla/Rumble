using System;
using TheCaravanClub.Core.Services;
using TheCaravanClub.Core;
using Android.Locations;
using Android.Content;
using Android.App;
using System.Collections.Generic;
using System.Linq;



namespace TheCaravanClub.Droid
{
	public class AndroidDeviceLocation : IGeoLocation
	{
		

		public double latitude { get; set; }
		public double longitude{ get; set; }
		public Android.Locations.Location location {get; set;}

		private static long MIN_TIME_BW_UPDATES = 5;
		private static int MIN_DISTANCE_CHANGE_FOR_UPDATES = 5;

		public static LocationManager manager = (LocationManager)Application.Context.GetSystemService (Context.LocationService);

		public static Criteria criteriaForLocationService = new Criteria {
			Accuracy = Accuracy.Fine
		};

		public DeviceLocation GetDeviceLocation()
		{
			IList<string> acceptableLocationProviders = manager.GetProviders (criteriaForLocationService, true);

			string _locationProvider = string.Empty;
			if (acceptableLocationProviders.Any ()) {
				_locationProvider = acceptableLocationProviders.First ();
			} else {
				_locationProvider = String.Empty;
			}
		

			manager.RequestLocationUpdates (_locationProvider, 5, 10, this);
			Android.Locations.Location loc = manager.GetLastKnownLocation (_locationProvider);

			if (loc != null)
				return new DeviceLocation (loc.Latitude, loc.Longitude);
			else
				return null;
		}


	}
}

