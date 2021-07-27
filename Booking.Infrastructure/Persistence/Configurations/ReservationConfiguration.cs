using Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Infrastructure.Persistence.Configurations
{
   public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservation");
            builder.HasKey(u => u.Id)
                        .IsClustered(false);
            builder.Property(t => t.CreationDate);
            builder.Property(t => t.CustomerName);
            builder.Property(t => t.Notes);
            builder.Property(t => t.ReservationDate);
            builder.Property(t => t.ReservedBy);
            builder.HasOne(d => d.Trip)
                   .WithMany(p => p.Reservations)
                   .HasForeignKey(d => d.TripId);


        }
    }
}
