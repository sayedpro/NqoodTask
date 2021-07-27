using Booking.Application.Common.Exceptions;
using Booking.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using Booking.Application.Common.Mappings;
using Booking.Domain.Entities;
using AutoMapper;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Booking.Application.Reservations.Commands.UpdateReservations
{
    public class UpdateReservationCommand : IRequest<int>
    {
        public int ReservationId { get; set; }
        public string CustomerName { get; set; }
        public string ReservedBy { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Notes { get; set; }
        public int TripId { get; set; }
    }

    public class UpdateReservationsCommandHandler : IRequestHandler<UpdateReservationCommand, int>
    {
        private readonly IBookingDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;


        public UpdateReservationsCommandHandler(IBookingDbContext context, IMediator mediator, IMapper mapper)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _context.Reservations.Where(x =>x.Id == request.ReservationId).FirstOrDefaultAsync();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Reservation), request.ReservationId);
                }

                entity.CreationDate = request.CreationDate;
                entity.CustomerName = request.CustomerName;
                entity.Notes = request.Notes;
                entity.ReservationDate = request.ReservationDate;
                entity.ReservedBy = request.ReservedBy;
                entity.TripId = request.TripId;

                _context.Reservations.Update(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
            catch (Exception e)
            {

                throw e;
            }

        }
    }
}
