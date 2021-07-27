using System;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Booking.Api
{
    public static class Program
    {
        private static string MicroserviceName
        {
            get
            {
                var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;

                var serviceBaseName = string.Empty;
                var names = assemblyName.Split('.');
                if (names.Length >= 4)
                {
                    serviceBaseName = string.Join('.', names.Take(4));
                }

                return serviceBaseName;
            }
        }

        public static void Main(string[] args)
        {
            ConfigureLogging();

            CreateHost(args);
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                    });
        }

        private static void CreateHost(string[] args)
        {
            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        private static void ConfigureLogging()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .Build();
        }
    }
}
