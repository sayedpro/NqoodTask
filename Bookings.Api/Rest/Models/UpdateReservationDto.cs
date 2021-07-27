using AutoMapper;
using Booking.Application.Common.Mappings;
using Booking.Application.Reservations.Commands.UpdateReservations;
using System;

namespace Booking.Api.Rest.Models
{
    /// <summary>
    /// Update Reservation Request.
    /// </summary>
    public class UpdateReservationDto : IMapFrom<UpdateReservationCommand>
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
        /// Trip Id.
        /// </summary>
        public int TripId { get; set; }
        /// <summary>
        /// Creation Date.
        /// </summary>
        public DateTime? CreationDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateReservationDto, UpdateReservationCommand>();
            profile.CreateMap<UpdateReservationCommand, UpdateReservationDto>();
        }
    }
}

