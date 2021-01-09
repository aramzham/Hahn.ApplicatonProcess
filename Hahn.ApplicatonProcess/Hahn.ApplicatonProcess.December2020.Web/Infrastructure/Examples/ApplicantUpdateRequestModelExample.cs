using System.Collections.Generic;
using Hahn.ApplicatonProcess.December2020.Web.Models.RequestModels;
using Microsoft.Extensions.Localization;
using Swashbuckle.AspNetCore.Filters;

namespace Hahn.ApplicatonProcess.December2020.Web.Infrastructure.Examples
{
    public class ApplicantUpdateRequestModelExample : BaseExample, IMultipleExamplesProvider<ApplicantUpdateRequestModel>
    {
        public ApplicantUpdateRequestModelExample(IStringLocalizer localizer) : base(localizer)
        {
        }

        public IEnumerable<SwaggerExample<ApplicantUpdateRequestModel>> GetExamples()
        {
            yield return SwaggerExample.Create(_localizer[SwaggerExampleNames.NameAndAge], new ApplicantUpdateRequestModel()
            {
                Name = "Javi",
                Age = 20
            });

            yield return SwaggerExample.Create(_localizer[SwaggerExampleNames.CountryAndEmail], new ApplicantUpdateRequestModel()
            {
                CountryOfOrigin = "Colombia",
                EMailAddress = "colombia_tex@some_domain.cl"
            });

            yield return SwaggerExample.Create(_localizer[SwaggerExampleNames.InvalidUpdate], new ApplicantUpdateRequestModel()
            {
                Age = 61,
                Address = "here"
            });
        }
    }
}