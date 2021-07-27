using Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Booking.Application.Common.Interfaces
{
    public interface IBookingDbReadContext
    {
        DbSet<Reservation> Reservations { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Trip> Trips { get; set; }
        IQueryable<Reservation> FilterReservations(
                                               IQueryable<Reservation> query,
                                               string includeProperties = null,
                                               Func<IQueryable<Reservation>,
                                               IOrderedQueryable<Reservation>> orderBy = null,
                                               int? skip = null,
                                               int? take = null);
    }
}
