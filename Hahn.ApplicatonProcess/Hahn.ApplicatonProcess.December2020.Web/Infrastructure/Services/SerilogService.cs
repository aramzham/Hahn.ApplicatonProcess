using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Hahn.ApplicatonProcess.December2020.Web.Infrastructure.Services
{
    public static class SerilogService
    {
        public static IServiceCollection AddSerilog(this IServiceCollection services, IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
            services.AddSingleton(Log.Logger);
            return services;
        }
    }
}