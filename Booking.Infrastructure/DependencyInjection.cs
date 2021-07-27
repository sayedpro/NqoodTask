using Booking.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Booking.Application.Common.Interfaces;

namespace Booking.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBookingInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<BookingDbContext>(options =>
                options.UseSqlServer(
                    connectionString,
                    b => b.MigrationsAssembly(typeof(BookingDbContext).Assembly.FullName)));


            services.AddDbContext<BookingDbReadContext>(options =>
                options.UseSqlServer($"{connectionString}ApplicationIntent=ReadOnly;",
                    b => b.MigrationsAssembly(typeof(BookingDbReadContext).Assembly.FullName)));

            services.AddScoped<IBookingDbReadContext>(provider => provider.GetService<BookingDbReadContext>());
            services.AddScoped<IBookingDbContext>(provider => provider.GetService<BookingDbContext>());

            return services;
        }
    }
}