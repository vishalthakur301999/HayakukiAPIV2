using System;
using System.Collections.Generic;

#nullable disable

namespace HayakokiAPIv2.Models
{
    public partial class Airport
    {
        public Airport()
        {
            FlightDestCodeNavigations = new HashSet<Flight>();
            FlightSourceCodeNavigations = new HashSet<Flight>();
        }

        public string AirportCode { get; set; }
        public string City { get; set; }
        public string AirportName { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Flight> FlightDestCodeNavigations { get; set; }
        public virtual ICollection<Flight> FlightSourceCodeNavigations { get; set; }
    }
}
