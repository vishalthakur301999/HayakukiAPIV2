using System;
using System.Collections.Generic;

#nullable disable

namespace HayakokiAPIv2.Models
{
    public partial class Flight
    {
        public Flight()
        {
            Tickets = new HashSet<Ticket>();
        }

        public string FlightNumber { get; set; }
        public string SourceCode { get; set; }
        public string DestCode { get; set; }
        public string Airline { get; set; }
        public string AircraftType { get; set; }
        public string DeptTime { get; set; }
        public string ArrivalTime { get; set; }
        public string Duration { get; set; }
        public int Fare { get; set; }

        public virtual Airport DestCodeNavigation { get; set; }
        public virtual Airport SourceCodeNavigation { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
