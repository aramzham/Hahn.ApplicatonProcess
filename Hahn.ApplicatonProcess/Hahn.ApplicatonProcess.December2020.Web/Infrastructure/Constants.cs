namespace Hahn.ApplicatonProcess.December2020.Web.Infrastructure
{
    public static class Constants
    {
        public const string CorsPolicyName = "AllowAllCorsPolicy";
        public const string ContentType = "application/json";
        public const string ControllerRoute = "api/[controller]";
        public const string Microsoft = "Microsoft";
        public const string System = "System";
        public const string ResourcesPath = "Infrastructure/Resources";
        public const string ResourceJsonPath = "./infrastructure/resources/resource.json";
    }

    public static class SwaggerConstants
    {
        public const string Name = "Hahn.ApplicatonProcess.December2020.Web v1";
        public const string JsonUrl = "/swagger/v1/swagger.json";
        public const string OpenApiInfoTitle = "Hahn.ApplicatonProcess.December2020.Web";
        public const string Version = "v1";
    }

    public static class ValidatorMessages
    {
        public const string EmailAddress = "Please enter a valid email address.";
        public const string CountryOfOrigin = "Please enter a valid country name.";
        public const string Name = "The length of 'Name' must be 5 characters or more.";
        public const string FamilyName = "The length of 'FamilyName' must be 5 characters or more.";
        public const string Address = "The length of 'Address' must be 10 characters or more.";
        public const string Age = "'Age' must be between 20 and 60 (inclusive)";
    }

    public static class ExampleConstants
    {
        public const string NotFound = "Not Found";
        public const string ResponseType = "https://tools.ietf.org/html/rfc7231#section-6.5.4";
        public const string TraceId = "00-52453e6fd5d39e4295ed6e2478266f06-8b980843f8c8a142-00";
        public const string ValidationErrorsOccured = "One or more validation errors occurred.";
        public const string InternalServerErrorMessage = "Internal server error";
    }

    public static class SwaggerExampleNames
    {
        public const string NameAndAge = "name&age";
        public const string CountryAndEmail = "country&email";
        public const string InvalidUpdate = "invalid_update";
        public const string NotValidExample = "NotValidExample";
    }

    public static class Verbs
    {
        public const string Get = "Get";
        public const string Post = "Post";
        public const string Put = "Put";
        public const string Delete = "Delete";
    }

    public static class Cultures
    {
        public const string en_US = "en-US";
        public const string fr_FR = "fr-FR";
        public const string es_ES = "es-ES";
    }
}