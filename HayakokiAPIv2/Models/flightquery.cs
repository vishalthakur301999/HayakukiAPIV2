using System;
namespace HayakokiAPIv2.Models
{
    public partial class flightquery
    {
        public string From { get; set; }
        public string To { get; set; }
        public string sortby { get; set; }
        public string sortdirection { get; set; }
    }
}
