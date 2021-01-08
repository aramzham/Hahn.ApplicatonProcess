using FluentValidation;
using Hahn.ApplicatonProcess.December2020.Common.Helpers.CountryNameHelper;
using Hahn.ApplicatonProcess.December2020.Web.Models.RequestModels;
using Microsoft.Extensions.Localization;

namespace Hahn.ApplicatonProcess.December2020.Web.Infrastructure.Validators
{
    public class ApplicantUpdateRequestModelValidator : AbstractValidator<ApplicantUpdateRequestModel>
    {
        public ApplicantUpdateRequestModelValidator(IStringLocalizer localizer)
        {
            RuleFor(x => x.EMailAddress).EmailAddress().WithMessage(localizer[ValidatorMessages.EmailAddress]);
            RuleFor(x => x.CountryOfOrigin).Must(BeAValidCountry).WithMessage(ValidatorMessages.CountryOfOrigin);
            RuleFor(x => x.Name).MinimumLength(5).WithMessage(ValidatorMessages.Name);
            RuleFor(x => x.FamilyName).MinimumLength(5).WithMessage(ValidatorMessages.FamilyName);
            RuleFor(x => x.Address).MinimumLength(10).WithMessage(ValidatorMessages.Address);
            RuleFor(x => x.Age).InclusiveBetween(20, 60).WithMessage(ValidatorMessages.Age);
        }

        private static bool BeAValidCountry(string countryName)
        {
            return countryName is null || CountryNameHelper.IsValid(countryName);
        }
    }
}