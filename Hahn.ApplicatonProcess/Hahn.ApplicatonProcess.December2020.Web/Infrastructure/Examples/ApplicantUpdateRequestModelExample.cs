using System.Collections.Generic;
using Hahn.ApplicatonProcess.December2020.Web.Models.RequestModels;
using Swashbuckle.AspNetCore.Filters;

namespace Hahn.ApplicatonProcess.December2020.Web.Infrastructure.Examples
{
    public class ApplicantUpdateRequestModelExample : IMultipleExamplesProvider<ApplicantUpdateRequestModel>
    {
        public IEnumerable<SwaggerExample<ApplicantUpdateRequestModel>> GetExamples()
        {
            yield return SwaggerExample.Create("name&age", new ApplicantUpdateRequestModel()
            {
                Name = "Javi",
                Age = 20
            });

            yield return SwaggerExample.Create("country&email", new ApplicantUpdateRequestModel()
            {
                CountryOfOrigin = "Colombia",
                EMailAddress = "colombia_tex@some_domain.cl"
            });

            yield return SwaggerExample.Create("invalid_update", new ApplicantUpdateRequestModel()
            {
                Age = 61,
                Address = "here"
            });
        }
    }
}