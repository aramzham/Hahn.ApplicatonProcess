using Hahn.ApplicatonProcess.December2020.Web.Infrastructure.Examples.ErrorExampleModels;
using Microsoft.Extensions.Localization;
using Swashbuckle.AspNetCore.Filters;

namespace Hahn.ApplicatonProcess.December2020.Web.Infrastructure.Examples
{
    public class NotValidApplicantResponseModelExample : BaseExample, IExamplesProvider<ValidationErrorModel>
    {
        public NotValidApplicantResponseModelExample(IStringLocalizer localizer) : base(localizer)
        {
        }

        public ValidationErrorModel GetExamples()
        {
            return new ValidationErrorModel()
            {
                type = ExampleConstants.ResponseType,
                status = 400,
                title = _localizer[ExampleConstants.ValidationErrorsOccured],
                traceId = ExampleConstants.TraceId,
                errors = new Errors()
                {
                    EMailAddress = new string[]{ _localizer[ValidatorMessages.EmailAddress] },
                    Age = new string[]{ _localizer[ValidatorMessages.Age] }
                }
            };
        }
    }
}