using Booking.Api.Rest.Models;
using Booking.Application.Reservations.Queries.GetReservationsResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Booking.Api.Rest.Mappers
{
  public static class ReservationMapper
    {
        public static List<GetReservationResaponseDto> ToReservationResponseDto(List<GetReservationsResaponse> from)
        {
            var to = new List<GetReservationResaponseDto>();
            if (from == null || from.Count == 0)
            {
                return to;
            }
            return from.Select(x => new GetReservationResaponseDto()
            {
                CustomerName = x.CustomerName,
                Notes = x.Notes,
                ReservationDate = x.ReservationDate,
                ReservationId = x.ReservationId,
                ReservedBy = x.ReservedBy,
                TripName = x.TripName,
                CreationDate = x.CreationDate
            }).ToList();
        }
    }
}
