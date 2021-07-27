using AutoMapper;
using Booking.Application.Common.Mappings;
using Booking.Application.Employee.Commands.CreateEmployee;
using System;


namespace Booking.Api.Rest.Models
{
    /// <summary>
    /// Create Reservation Request.
    /// </summary>
   public class CreateReservationDto : IMapFrom<CreateReservationCommand>
    {
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
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateReservationDto, CreateReservationCommand>();
            profile.CreateMap<CreateReservationCommand, CreateReservationDto>();
        }
    }
}
