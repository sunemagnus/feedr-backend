using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FeedrBackend.Models
{
    public class FeedModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Rating { get; set; }
        public DateTime DateTime { get; set; }
        public Coordinate? GeoCoordinate { get; set; }
    }

    public class Coordinate { 
        public long Latitude {  get; set; } 
        public long Longitude { get; set; }
        public long Altitude { get; set; }
        
        public Coordinate(long latitude, long longitude, long altitude) {
            Latitude = latitude;
            Longitude = longitude;
            Altitude = altitude;
        }
    }

}
