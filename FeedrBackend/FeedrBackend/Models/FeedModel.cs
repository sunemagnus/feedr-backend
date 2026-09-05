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
        public Coordinate(long x, long y, long z) { }

        private long x {  get; set; } 
        private long y { get; set; }
        private long z { get; set; }
    }

}
