using JamnationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JamnationApp.Api.Models
{
    public class Location : BaseModel
    {
        public int Id { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double Altitude { get; set; }
        public string Address { get; set; }

    }

    public class LocationResponse
    {
        public bool success { get; set; }
    }

    public class LocationRegion
    {
        public int Id { get; set; }
        public string Region { get; set; }
        public virtual Location Location { get; set; }

    }
}