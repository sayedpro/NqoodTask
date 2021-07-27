using System;

namespace Booking.UI.Models
{
    public class ReservationViewModel
    {
        public int ReservationId { get; set; }
        public string CustomerName { get; set; }
        public string ReservedBy { get; set; }
        public DateTime ReservationDate { get; set; }
        public string Notes { get; set; }
        public string TripName { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
