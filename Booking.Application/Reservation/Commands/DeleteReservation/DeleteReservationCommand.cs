using Booking.Application.Common.Exceptions;
using Booking.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Booking.Domain.Entities;

namespace Booking.Application.Reservations.Commands.DeleteTodoItem
{
    public class DeleteReservationsCommand : IRequest<int>
    {
        public int Id { get; set; }
    }

    public class DeleteReservationsCommandHandler : IRequestHandler<DeleteReservationsCommand, int>
    {
        private readonly IBookingDbContext _context;

        public DeleteReservationsCommandHandler(IBookingDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteReservationsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _context.Reservations.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Reservation), request.Id);
                }

                _context.Reservations.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return request.Id;
            }
            catch (System.Exception e)
            {

                throw e;
            }

        }
    }
}
