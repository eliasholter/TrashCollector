using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class GeoCoderAddress
    {
        //public Customer 
        public string address { get; set; }
        public double latitudeValue { get; set; }
        public double longitudeValue { get; set; }

        public string apiKeyString = "https://maps.googleapis.com/maps/api/js?key=" + PrivateKeys.key1 + "&callback=initializeMap";
    }
}