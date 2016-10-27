using System;
using CoreLocation;
using BlankXamarinApp.Core;

namespace BlankXamarinApp.iOS
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