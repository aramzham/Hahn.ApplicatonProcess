using Microsoft.Extensions.Localization;

namespace Hahn.ApplicatonProcess.December2020.Web.Infrastructure.Examples
{
    public abstract class BaseExample
    {
        protected IStringLocalizer _localizer;

        protected BaseExample(IStringLocalizer localizer)
        {
            _localizer = localizer;
        }
    }
}