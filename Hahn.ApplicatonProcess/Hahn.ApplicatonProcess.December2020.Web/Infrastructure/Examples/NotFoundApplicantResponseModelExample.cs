using Hahn.ApplicatonProcess.December2020.Web.Infrastructure.Examples.ErrorExampleModels;
using Swashbuckle.AspNetCore.Filters;

namespace Hahn.ApplicatonProcess.December2020.Web.Infrastructure.Examples
{
    public class NotFoundApplicantResponseModelExample : IExamplesProvider<NotFoundErrorModel>
    {
        public NotFoundErrorModel GetExamples()
        {
            return new NotFoundErrorModel()
            {
                title = "Not Found",
                type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                status = 404,
                traceId = "00-52453e6fd5d39e4295ed6e2478266f06-8b980843f8c8a142-00"
            };
        }
    }
}