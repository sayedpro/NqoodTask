using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.UI.Models
{
    public class ReservationModel
    {

        public List<ReservationViewModel> Reservations { get; set; }
        public int CurrentPageIndex { get; set; }
        public int PageCount { get; set; }
    }
}
