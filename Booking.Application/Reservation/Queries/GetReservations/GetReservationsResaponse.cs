using AutoMapper;
using Booking.Application.Common.Mappings;
using Booking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Application.Reservations.Queries.GetReservationsResponse
{
   public class GetReservationsResaponse : IMapFrom<Reservation>
    {

        public int ReservationId { get; set; }
        public string CustomerName { get; set; }
        public string ReservedBy { get; set; }
        public DateTime ReservationDate { get; set; }
        public string Notes { get; set; }
        public string TripName { get; set; }
        public DateTime? CreationDate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Reservation, GetReservationsResaponse>()
            .ForMember(d => d.TripName, opt => opt.MapFrom(s => s.Trip.Name))
            .ForMember(d => d.ReservationId, opt => opt.MapFrom(s => s.Id));
        }
    }
}
