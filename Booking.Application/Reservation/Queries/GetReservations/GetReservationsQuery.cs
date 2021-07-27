using AutoMapper;
using AutoMapper.QueryableExtensions;
using Booking.Application.Common.Interfaces;
using Booking.Application.Common.Mappings;
using Booking.Application.Common.Models;
using Booking.Application.Reservations.Queries.GetReservationsResponse;
using Booking.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Booking.Application.Reservations.Queries.GetReservationsQuery
{
    public class GetReservationsQuery : IRequest<PaginatedList<GetReservationsResaponse>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetReservationsQueryHandler : IRequestHandler<GetReservationsQuery, PaginatedList<GetReservationsResaponse>>
    {
        private readonly IBookingDbReadContext _context;
        private readonly IMapper _mapper;

        public GetReservationsQueryHandler(IBookingDbReadContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<GetReservationsResaponse>> Handle(GetReservationsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var query = _context.Reservations.AsNoTracking();

                var orderedQuery = query.OrderBy(e => e.ReservationDate);
                return await orderedQuery.ProjectTo<GetReservationsResaponse>(_mapper.ConfigurationProvider)
                    .PaginatedListAsync(request.PageNumber, request.PageSize);
            }
            catch (System.Exception e)
            {

                throw e;
            }
            
        }

    }
}
