using Microsoft.Extensions.DependencyInjection;

namespace Booking.Api.Ioc.Versioning
{
    public static class VersioningStartupHelpers
    {
        public static IServiceCollection AddVersioning(this IServiceCollection services)
        {
            return services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
            });
        }
    }
}
