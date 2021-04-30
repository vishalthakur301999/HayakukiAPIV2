using System;
using System.Collections.Generic;

#nullable disable

namespace HayakokiAPIv2.Models
{
    public partial class User
    {
        public User()
        {
            Sessions = new HashSet<Session>();
            Tickets = new HashSet<Ticket>();
        }

        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
