using FluentValidation;
using Hahn.ApplicatonProcess.December2020.Common.Helpers.CountryNameHelper;
using Hahn.ApplicatonProcess.December2020.Web.Models.RequestModels;
using Microsoft.Extensions.Localization;

namespace Hahn.ApplicatonProcess.December2020.Web.Infrastructure.Validators
{
    public class ApplicantAddRequestModelValidator : AbstractValidator<ApplicantAddRequestModel>
    {
        public ApplicantAddRequestModelValidator(IStringLocalizer localizer)
        {
            RuleFor(x => x.EMailAddress).NotNull().EmailAddress().WithMessage(localizer[ValidatorMessages.EmailAddress]);
            RuleFor(x => x.CountryOfOrigin).NotNull().Must(BeAValidCountry).WithMessage(localizer[ValidatorMessages.CountryOfOrigin]);
            RuleFor(x => x.Name).NotNull().MinimumLength(5).WithMessage(localizer[ValidatorMessages.Name]);
            RuleFor(x => x.FamilyName).NotNull().MinimumLength(5).WithMessage(localizer[ValidatorMessages.FamilyName]);
            RuleFor(x => x.Address).NotNull().MinimumLength(10).WithMessage(localizer[ValidatorMessages.Address]);
            RuleFor(x => x.Age).NotNull().InclusiveBetween(20,60).WithMessage(localizer[ValidatorMessages.Age]);
        }

        private static bool BeAValidCountry(string countryName)
        {
            return CountryNameHelper.IsValid(countryName);
        }
    }
}