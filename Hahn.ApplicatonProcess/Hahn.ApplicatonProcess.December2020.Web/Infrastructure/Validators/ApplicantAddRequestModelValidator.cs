using FluentValidation;
using Hahn.ApplicatonProcess.December2020.Common.Helpers.CountryNameHelper;
using Hahn.ApplicatonProcess.December2020.Web.Models.RequestModels;

namespace Hahn.ApplicatonProcess.December2020.Web.Infrastructure.Validators
{
    public class ApplicantAddRequestModelValidator : AbstractValidator<ApplicantAddRequestModel>
    {
        public ApplicantAddRequestModelValidator()
        {
            RuleFor(x => x.EMailAddress).NotNull().EmailAddress().WithMessage("Please enter a valid email address.");
            RuleFor(x => x.CountryOfOrigin).NotNull().Must(BeAValidCountry).WithMessage("Please enter a valid country name.");
            RuleFor(x => x.Name).NotNull().MinimumLength(5).WithMessage("The length of 'Name' must be 5 characters or more.");
            RuleFor(x => x.FamilyName).NotNull().MinimumLength(5).WithMessage("The length of 'FamilyName' must be 5 characters or more.");
            RuleFor(x => x.Address).NotNull().MinimumLength(10).WithMessage("The length of 'Address' must be 10 characters or more.");
            RuleFor(x => x.Age).NotNull().InclusiveBetween(20,60).WithMessage("'Age' must be between 20 and 60 (inclusive)");
        }

        private static bool BeAValidCountry(string countryName)
        {
            return CountryNameHelper.IsValid(countryName);
        }
    }
}