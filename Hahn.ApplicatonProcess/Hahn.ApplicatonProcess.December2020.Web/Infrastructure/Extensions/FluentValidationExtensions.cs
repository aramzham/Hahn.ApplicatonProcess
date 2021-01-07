using FluentValidation;
using Hahn.ApplicatonProcess.December2020.Web.Infrastructure.Validators;
using Hahn.ApplicatonProcess.December2020.Web.Models.RequestModels;
using Microsoft.Extensions.DependencyInjection;

namespace Hahn.ApplicatonProcess.December2020.Web.Infrastructure.Extensions
{
    public static class FluentValidationExtensions
    {
        public static IServiceCollection AddFluentValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<ApplicantAddRequestModel>, ApplicantAddRequestModelValidator>();
            services.AddTransient<IValidator<ApplicantUpdateRequestModel>, ApplicantUpdateRequestModelValidator>();
            return services;
        }
    }
}