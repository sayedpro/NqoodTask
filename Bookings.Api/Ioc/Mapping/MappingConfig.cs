using AutoMapper;
using Booking.Application.Common.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.Api.Ioc.Mapping
{
    public static class MappingConfig
    {
        public static IServiceCollection AddMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            return services.AddAutoMapper(typeof(Startup))
                           .AddSingleton(new MapperConfiguration(cfg =>
                           {
                               cfg.AddProfile<MappingProfile>();
                               cfg.AddProfile<ApiMappingProfile>();
                           }).CreateMapper());
        }
    }
}
