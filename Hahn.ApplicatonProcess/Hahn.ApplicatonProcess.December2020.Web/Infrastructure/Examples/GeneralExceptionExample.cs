using Hahn.ApplicatonProcess.December2020.Web.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Hahn.ApplicatonProcess.December2020.Web.Infrastructure.Examples
{
    public class GeneralExceptionExample : IExamplesProvider<ErrorModel>
    {
        public ErrorModel GetExamples()
        {
            return new ErrorModel()
            {
                Error = ExampleConstants.InternalServerErrorMessage
            };
        }
    }
}