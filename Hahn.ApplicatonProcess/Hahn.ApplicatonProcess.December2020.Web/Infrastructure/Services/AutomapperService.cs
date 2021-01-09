using AutoMapper;
using Hahn.ApplicatonProcess.December2020.Web.Infrastructure.Automapper.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace Hahn.ApplicatonProcess.December2020.Web.Infrastructure.Services
{
    public static class AutomapperService
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var mapper = ConfigMapper();
            services.AddSingleton(mapper);

            return services;
        }

        private static IMapper ConfigMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<ApplicantBlToResponseModelProfile>();
                cfg.AddProfile<ApplicantRequestToBlModelProfile>();
            });

            return config.CreateMapper();
        }
    }
}