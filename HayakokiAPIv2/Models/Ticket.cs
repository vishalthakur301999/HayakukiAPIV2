using System;
using System.Collections.Generic;

#nullable disable

namespace HayakokiAPIv2.Models
{
    public partial class Ticket
    {
        public Guid TicketId { get; set; }
        public Guid BookingId { get; set; }
        public Guid UserId { get; set; }
        public string PassengerName { get; set; }
        public int PassengerAge { get; set; }
        public string PassengerGender { get; set; }
        public string FlightNumber { get; set; }
        public string SeatNumber { get; set; }
        public DateTime TravelDate { get; set; }
        public double BookingAmount { get; set; }
        public DateTime BookingTimestamp { get; set; }

        public virtual Flight FlightNumberNavigation { get; set; }
        public virtual User User { get; set; }
    }
}
