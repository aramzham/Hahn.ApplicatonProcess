using Hahn.ApplicatonProcess.December2020.Web.Models.RequestModels;
using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;
using Microsoft.Extensions.Localization;

namespace Hahn.ApplicatonProcess.December2020.Web.Infrastructure.Examples
{
    public class ApplicantAddRequestModelExample : BaseExample, IMultipleExamplesProvider<ApplicantAddRequestModel>
    {
        public ApplicantAddRequestModelExample(IStringLocalizer localizer) : base(localizer)
        {
        }

        public IEnumerable<SwaggerExample<ApplicantAddRequestModel>> GetExamples()
        {
            yield return SwaggerExample.Create("Petros", new ApplicantAddRequestModel()
            {
                Name = "Petros",
                FamilyName = "Ohanyan",
                CountryOfOrigin = "Armenia",
                Age = 28,
                Address = "Armenia, Yerevan",
                EMailAddress = "some_email@tuy.am"
            });

            yield return SwaggerExample.Create("Andrew", new ApplicantAddRequestModel()
            {
                Name = "Andrew",
                FamilyName = "Robertson",
                CountryOfOrigin = "United Kingdom of Great Britain and Northern Ireland",
                Age = 30,
                Address = "Scotland, Glasgow",
                EMailAddress = "qanaqerci_tuy@list.am",
                Hired = true
            });

            yield return SwaggerExample.Create(_localizer[SwaggerExampleNames.NotValidExample], new ApplicantAddRequestModel()
            {
                Name = "Short",
                FamilyName = "Surname",
                CountryOfOrigin = "Neverland",
                Age = 19,
                Address = "short name",
                EMailAddress = "invalid_email.am",
                Hired = true
            });
        }
    }
}