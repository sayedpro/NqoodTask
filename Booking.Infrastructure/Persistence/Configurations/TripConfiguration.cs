using Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Infrastructure.Persistence.Configurations
{
   public class TripConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.ToTable("Trip");
            builder.HasKey(u => u.Id)
                        .IsClustered(false);
            builder.Property(t => t.Name);
            builder.Property(t => t.CityName);
            builder.Property(t => t.Content);
            builder.Property(t => t.CreationDate);
            builder.Property(t => t.ImageUrl);
            builder.Property(t => t.Price);
            builder.HasMany(d => d.Reservations)
                    .WithOne(p => p.Trip)
                    .HasForeignKey(d => d.TripId);

        }
    }
}
