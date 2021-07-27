using Booking.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using Booking.Application.Common.Mappings;
using Booking.Domain.Entities;
using AutoMapper;

namespace Booking.Application.Employee.Commands.CreateEmployee
{
    public class CreateReservationCommand : IRequest<int>, IMapFrom<Reservation>
    {
        public string CustomerName { get; set; }
        public string ReservedBy { get; set; }
        public DateTime ReservationDate { get; set; }
        public string Notes { get; set; }
        public int TripId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateReservationCommand, Reservation>();
        }
    }

    public class CreateEmployeeCommandHandler : IRequestHandler<CreateReservationCommand, int>
    {
        private readonly IBookingDbContext _context;
        private readonly IMapper _mapper;

        public CreateEmployeeCommandHandler(IBookingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<Reservation>(request);
                entity.CreationDate = DateTime.UtcNow;
                _context.Reservations.Add(entity);

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
