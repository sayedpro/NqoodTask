using AutoMapper;
using Booking.Application.Common.Mappings;
using Booking.Application.Reservations.Queries.GetReservationsResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Api.Rest.Models
{
    /// <summary>
    /// Get Reservation Resaponse
    /// </summary>
    public class GetReservationResaponseDto : IMapFrom<GetReservationsResaponse>
    {
        /// <summary>
        /// Reservation Id
        /// </summary>
        public int ReservationId { get; set; }
        /// <summary>
        /// Customer Name
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// User created the reservation.
        /// </summary>
        public string ReservedBy { get; set; }
        /// <summary>
        /// Reservation Date.
        /// </summary>
        public DateTime ReservationDate { get; set; }
        /// <summary>
        /// Notes.
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// Trip Name.
        /// </summary>
        public string TripName { get; set; }
        /// <summary>
        /// Creation Date.
        /// </summary>
        public DateTime? CreationDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetReservationsResaponse, GetReservationResaponseDto>();
        }
    }
}
