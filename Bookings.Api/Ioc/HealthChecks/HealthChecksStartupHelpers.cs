using Booking.Infrastructure.Persistence;
using Booking.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.Api.Ioc.HealthChecks
{
    public static class HealthChecksStartupHelpers
    {
        public static IServiceCollection AddApiHealthChecks(this IServiceCollection services)
        {
            services.AddHealthChecks().AddDbContextCheck<BookingDbContext>();
            services.AddHealthChecks().AddDbContextCheck<BookingDbReadContext>();
            return services;
        }
    }
}
