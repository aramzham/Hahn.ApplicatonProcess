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
                type = ExampleConstants.ResponseType,
                status = 400,
                title = ExampleConstants.ValidationErrorsOccured,
                traceId = ExampleConstants.TraceId,
                errors = new Errors()
                {
                    EMailAddress = new []{ ValidatorMessages.EmailAddress },
                    Age = new []{ ValidatorMessages.Age }
                }
            };
        }
    }
}