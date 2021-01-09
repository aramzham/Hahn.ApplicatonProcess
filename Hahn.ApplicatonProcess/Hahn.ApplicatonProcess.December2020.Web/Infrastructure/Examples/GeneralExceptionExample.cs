using Hahn.ApplicatonProcess.December2020.Web.Models;
using Microsoft.Extensions.Localization;
using Swashbuckle.AspNetCore.Filters;

namespace Hahn.ApplicatonProcess.December2020.Web.Infrastructure.Examples
{
    public class GeneralExceptionExample : BaseExample, IExamplesProvider<ErrorModel>
    {
        public GeneralExceptionExample(IStringLocalizer localizer) : base(localizer)
        {
        }

        public ErrorModel GetExamples()
        {
            return new ErrorModel()
            {
                Error = _localizer[ExampleConstants.InternalServerErrorMessage]
            };
        }
    }
}