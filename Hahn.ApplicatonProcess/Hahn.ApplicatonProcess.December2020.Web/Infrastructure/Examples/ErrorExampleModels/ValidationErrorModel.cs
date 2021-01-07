using Hahn.ApplicatonProcess.December2020.Web.Infrastructure.Examples.ErrorExampleModels;

namespace Hahn.ApplicatonProcess.December2020.Web.Infrastructure.Examples.ErrorExampleModels
{
    public class ValidationErrorModel : NotFoundErrorModel
    {
        public Errors errors { get; set; }
    }

    public class Errors
    {
        public string[] Age { get; set; }
        public string[] EMailAddress { get; set; }
    }
}