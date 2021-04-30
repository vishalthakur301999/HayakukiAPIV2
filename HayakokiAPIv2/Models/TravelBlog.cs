using System;
using System.Collections.Generic;

#nullable disable

namespace HayakokiAPIv2.Models
{
    public partial class TravelBlog
    {
        public Guid Blogid { get; set; }
        public string Articletitle { get; set; }
        public string Articlecontents { get; set; }
        public string Author { get; set; }
        public DateTime Posteddate { get; set; }
        public string Imgurl { get; set; }
    }
}
