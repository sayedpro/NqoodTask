using Booking.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Domain.Entities
{
   public class Reservation : AuditedEntity
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string ReservedBy { get; set; }
        public DateTime ReservationDate { get; set; }
        public string Notes { get; set; }
        public int TripId { get; set; }
        public Trip Trip { get; set; }
    }
}
