using Hahn.ApplicatonProcess.December2020.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Hahn.ApplicatonProcess.December2020.Web.Infrastructure.Services
{
    public static class BusinessLogicService
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            services.AddSingleton<ApplicatonProcessBl>();
            return services;
        }
    }
}