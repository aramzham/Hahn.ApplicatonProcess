using Hahn.ApplicatonProcess.December2020.Web.Infrastructure.Examples.ErrorExampleModels;
using Swashbuckle.AspNetCore.Filters;

namespace Hahn.ApplicatonProcess.December2020.Web.Infrastructure.Examples
{
    public class NotValidApplicantResponseModelExample : IExamplesProvider<ValidationErrorModel>
    {
        public ValidationErrorModel GetExamples()
        {
            return new ValidationErrorModel()
            {
                type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                status = 400,
                title = "One or more validation errors occurred.",
                traceId = "00-ea380e85adc3d848b7f012db2a03a194-c770a14abdcdc149-00",
                errors = new Errors()
                {
                    EMailAddress = new []{ "Please enter a valid email address." },
                    Age = new []{ "'Age' must be between 20 and 60 (inclusive)" }
                }
            };
        }
    }
}