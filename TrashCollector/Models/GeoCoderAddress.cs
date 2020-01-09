using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class GeoCoderAddress
    {
        public string address { get; set; }
        public double latitudeValue { get; set; }
        public double longitudeValue { get; set; }
    }
}