using FluentValidation;
using Hahn.ApplicatonProcess.December2020.Common.Helpers.CountryNameHelper;
using Hahn.ApplicatonProcess.December2020.Web.Models.RequestModels;

namespace Hahn.ApplicatonProcess.December2020.Web.Infrastructure.Validators
{
    public class ApplicantRequestModelValidator : AbstractValidator<ApplicantRequestModel>
    {
        public ApplicantRequestModelValidator()
        {
            RuleFor(x => x.EMailAdress).EmailAddress().WithMessage("Please enter a valid email address.");
            RuleFor(x => x.CountryOfOrigin).Must(BeAValidCountry).WithMessage("Please enter a valid country name.");
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("The length of 'Name' must be 5 characters or more.");
            RuleFor(x => x.FamilyName).MinimumLength(5).WithMessage("The length of 'FamilyName' must be 5 characters or more.");
            RuleFor(x => x.Address).MinimumLength(10).WithMessage("The length of 'Address' must be 10 characters or more.");
            RuleFor(x => x.Age).InclusiveBetween(20,60).WithMessage("'Age' must be between 20 and 60 (inclusive)");
        }

        private static bool BeAValidCountry(string countryName)
        {
            return CountryNameHelper.IsValid(countryName);
        }
    }
}