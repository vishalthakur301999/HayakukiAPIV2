using System;
namespace HayakokiAPIv2.Models
{
    public partial class BookingQueryReturn
    {
        public Guid bookingId { get; set; }
        public string flightNumber { get; set; }
        public int passCount { get; set; }
        public double bookingAmount { get; set; }
        public DateTime travelDate { get; set; }
    }
}
