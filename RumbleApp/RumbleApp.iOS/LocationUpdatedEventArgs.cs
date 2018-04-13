using System;
using CoreLocation;
using JamnationApp.Core;

namespace JamnationApp.iOS
{
    public class LocationUpdatedEventArgs : EventArgs
    {
        CLLocation location;

        public LocationUpdatedEventArgs(CLLocation location)
        {
            this.location = location;
			
        }

        public CLLocation Location
        {
            get { return location; }
        }
    }
}