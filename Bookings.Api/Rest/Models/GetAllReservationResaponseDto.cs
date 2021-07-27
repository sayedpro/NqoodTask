using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Api.Rest.Models
{
    /// <summary>
    /// Query All Reservation Response.
    /// </summary>
    public class GetAllReservationResaponseDto
    {
        /// <summary>
        /// Gets or sets result of Reservations.
        /// </summary>
        public List<GetReservationResaponseDto> Result { get; set; }

        /// <summary>
        /// Gets or sets metadata  Reservations response total pages and pagenumber.
        /// </summary>
        public MetaDataDto Metadata { get; set; }
    }

    /// <summary>
    /// Metadata of query Reservation reponse.
    /// </summary>
    public class MetaDataDto
    {
        /// <summary>
        /// Gets or sets totalpages of the result maching the critria.
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Gets or sets totalcount of the result maching the critria.
        /// </summary>
        public int TotalCount { get; set; }

    }
}