using Hahn.ApplicatonProcess.December2020.Web.Infrastructure.Examples.ErrorExampleModels;
using Microsoft.Extensions.Localization;
using Swashbuckle.AspNetCore.Filters;

namespace Hahn.ApplicatonProcess.December2020.Web.Infrastructure.Examples
{
    public class NotFoundApplicantResponseModelExample : BaseExample, IExamplesProvider<NotFoundErrorModel>
    {
        public NotFoundApplicantResponseModelExample(IStringLocalizer localizer) : base(localizer)
        {
        }

        public NotFoundErrorModel GetExamples()
        {
            return new NotFoundErrorModel()
            {
                title = _localizer[ExampleConstants.NotFound],
                type = ExampleConstants.ResponseType,
                status = 404,
                traceId = ExampleConstants.TraceId
            };
        }
    }
}