using AutoMapper;
using Booking.Application.Common.Exceptions;
using Booking.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Booking.Domain.Entities;
using Booking.Application.Reservations.Queries.GetReservationsResponse;

namespace Booking.Application.Reservations.Queries.GetReservationDetailsQuery
{
   public class GetReservationsDetailsQuery : IRequest<GetReservationsResaponse>
    {
        public int ReservationsId { get; set; }

    }
    public class GetReservationsDetailsQueryHandler : IRequestHandler<GetReservationsDetailsQuery, GetReservationsResaponse>
    {
        private readonly IBookingDbReadContext _context;
        private readonly IMapper _mapper;

        public GetReservationsDetailsQueryHandler(IBookingDbReadContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetReservationsResaponse> Handle(GetReservationsDetailsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _context.Reservations.Include(e => e.Trip).Where(e => e.Id == request.ReservationsId).FirstOrDefaultAsync();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Reservation), request.ReservationsId);
                }

                return _mapper.Map<GetReservationsResaponse>(entity);
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }
    }
}
