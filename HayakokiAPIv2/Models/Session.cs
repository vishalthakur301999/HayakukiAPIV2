using System;
using System.Collections.Generic;

#nullable disable

namespace HayakokiAPIv2.Models
{
    public partial class Session
    {
        public Guid SessionId { get; set; }
        public Guid UserId { get; set; }

        public virtual User User { get; set; }
    }
}
