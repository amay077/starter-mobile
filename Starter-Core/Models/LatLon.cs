using System;

namespace Starter.Core.Models
{
    public class LatLon {
        public double Lat { get; set; }
        public double Lon { get; set; }
        
        public LatLon(double lat, double lon)
        {
            this.Lat = lat;
            this.Lon = lon;
        }
    }
}

