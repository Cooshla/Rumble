﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamnationApp.Core.Models
{

    public class DistanceResult
    {
        public string[] destination_addresses { get; set; }
        public string[] origin_addresses { get; set; }
        public Row[] rows { get; set; }
        public string status { get; set; }
    }

    public class Row
    {
        public Element[] elements { get; set; }
    }

    public class Element
    {
        public GoogleDistance distance { get; set; }
        public Duration duration { get; set; }
        public string status { get; set; }
    }

    public class GoogleDistance
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class Duration
    {
        public string text { get; set; }
        public int value { get; set; }
    }



    public class GoogleAddresses
    {
        public Prediction[] predictions { get; set; }
        public string status { get; set; }
    }

    public class Prediction
    {
        public string description { get; set; }
        public string id { get; set; }
        public Matched_Substrings[] matched_substrings { get; set; }
        public string place_id { get; set; }
        public string reference { get; set; }
        public Term[] terms { get; set; }
        public string[] types { get; set; }
    }

    public class Matched_Substrings
    {
        public int length { get; set; }
        public int offset { get; set; }
    }

    public class Term
    {
        public int offset { get; set; }
        public string value { get; set; }
    }






    public class WayPoints
    {
        public Geocoded_Waypoints[] geocoded_waypoints { get; set; }
        public Route[] routes { get; set; }
        public string status { get; set; }
    }

    public class Geocoded_Waypoints
    {
        public string geocoder_status { get; set; }
        public string place_id { get; set; }
        public string[] types { get; set; }
        public bool partial_match { get; set; }
    }

    public class Route
    {
        public Bounds bounds { get; set; }
        public string copyrights { get; set; }
        public Leg[] legs { get; set; }
        public Overview_Polyline overview_polyline { get; set; }
        public string summary { get; set; }
        public object[] warnings { get; set; }
        public object[] waypoint_order { get; set; }
    }

    public class Bounds
    {
        public Northeast northeast { get; set; }
        public Southwest southwest { get; set; }
    }

    public class Northeast
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Southwest
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Overview_Polyline
    {
        public string points { get; set; }
    }

    public class Leg
    {
        public GDistance distance { get; set; }
        public Duration duration { get; set; }
        public string end_address { get; set; }
        public End_Location end_location { get; set; }
        public string start_address { get; set; }
        public Start_Location start_location { get; set; }
        public Step[] steps { get; set; }
        public object[] via_waypoint { get; set; }
    }

    public class GDistance
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class End_Location
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Start_Location
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Step
    {
        public Distance1 distance { get; set; }
        public Duration1 duration { get; set; }
        public End_Location1 end_location { get; set; }
        public string html_instructions { get; set; }
        public Polyline polyline { get; set; }
        public Start_Location1 start_location { get; set; }
        public string travel_mode { get; set; }
        public string maneuver { get; set; }
    }

    public class Distance1
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class Duration1
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class End_Location1
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Polyline
    {
        public string points { get; set; }
    }

    public class Start_Location1
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    #region point to address look up

    public class GeocodeLookUp
    {
        public GeocodeResult[] results { get; set; }
        public string status { get; set; }
    }

    public class GeocodeResult
    {
        public Address_Components[] address_components { get; set; }
        public string formatted_address { get; set; }
        public Geometry geometry { get; set; }
        public string place_id { get; set; }
        public string[] types { get; set; }
    }

    public class Geometry
    {
        public Location location { get; set; }
        public string location_type { get; set; }
        public Viewport viewport { get; set; }
    }

    


    public class Viewport
    {
        public Northeast northeast { get; set; }
        public Southwest southwest { get; set; }
    }

    public class Address_Components
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public string[] types { get; set; }
    }

    #endregion



}
