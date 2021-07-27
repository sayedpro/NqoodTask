using Booking.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Domain.Entities
{
   public class Trip : AuditedEntity
    {
        public Trip()
        {
            Reservations = new HashSet<Reservation>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string CityName { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }

    }
}
