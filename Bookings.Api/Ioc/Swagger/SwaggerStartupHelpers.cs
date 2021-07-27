using System.Collections.Generic;
using Booking.Api.Rest.Constants;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Booking.Api.Ioc.Swagger
{
    public static class SwaggerStartupHelpers
    {
        public static IServiceCollection AddSwaggerGen(this IServiceCollection services)
        {
            return services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(ApiConstants.ApiVersion, new OpenApiInfo
                {
                    Title = ApiConstants.ApiName,
                    Version = ApiConstants.ApiVersion,
                });

                options.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Scheme = "bearer"
                });

                // add auth header for [Authorize] endpoints
                options.OperationFilter<AddAuthHeaderOperationFilter>();
            });
        }

        public static IApplicationBuilder UseSwaggerUI(this IApplicationBuilder app)
        {
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "reservation/{documentName}/reservation.json";
            });
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "reservation";
                c.SwaggerEndpoint($"/reservation/{ApiConstants.ApiVersion}/reservation.json", $"{ApiConstants.ApiName} {ApiConstants.ApiVersion}");
            });
            return app;
        }

        public class AddAuthHeaderOperationFilter : IOperationFilter
        {
            public void Apply(OpenApiOperation operation, OperationFilterContext context)
            {
                if (operation.Security == null)
                {
                    operation.Security = new List<OpenApiSecurityRequirement>();
                }

                var scheme = new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearer" } };
                operation.Security.Add(new OpenApiSecurityRequirement { [scheme] = new List<string>() });
            }
        }
    }
}
