using Booking.Application.Common.Interfaces;
using Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Persistence
{
    public class BookingDbReadContext : DbContext, IBookingDbReadContext
    {

        public BookingDbReadContext(
            DbContextOptions<BookingDbReadContext> options) : base(options)
        {
        }

        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public IQueryable<Reservation> FilterReservations(IQueryable<Reservation> query, string includeProperties = null, Func<IQueryable<Reservation>, IOrderedQueryable<Reservation>> orderBy = null, int? skip = null, int? take = null)
        {
            // includes
            includeProperties ??= string.Empty;
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            // ordering
            if (orderBy != null)
            {
                query = orderBy(query);
            }

            // paging
            if (skip.HasValue && skip != 0)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue && take != 0)
            {
                query = query.Take(take.Value);
            }

            // final query
            return query;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

    }
}
