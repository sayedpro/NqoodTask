using Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Booking.Application.Common.Interfaces
{
    public interface IBookingDbContext
    {
        DbSet<Reservation> Reservations { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Trip> Trips { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
