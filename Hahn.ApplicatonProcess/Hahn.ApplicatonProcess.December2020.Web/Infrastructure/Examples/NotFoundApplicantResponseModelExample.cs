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
                title = ExampleConstants.NotFound,
                type = ExampleConstants.ResponseType,
                status = 404,
                traceId = ExampleConstants.TraceId
            };
        }
    }
}