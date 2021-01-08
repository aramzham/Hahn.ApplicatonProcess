using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.Extensions.Localization;

namespace Hahn.ApplicatonProcess.December2020.Web.Infrastructure.Resources
{
    public class JsonStringLocalizer : IStringLocalizer
    {
        private readonly IDictionary<string, ResourceItem> _resourceItems;

        public JsonStringLocalizer()
        {
            _resourceItems = JsonSerializer.Deserialize<IEnumerable<ResourceItem>>(File.ReadAllText(Constants.ResourceJsonPath)).ToDictionary(k => k.Key);
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            return _resourceItems.Values.Where(x => x.LocalizedValue.ContainsKey(CultureInfo.CurrentCulture.Name))
                .Select(x => new LocalizedString(x.Key, x.LocalizedValue[CultureInfo.CurrentCulture.Name], true));
        }

        public LocalizedString this[string name]
        {
            get
            {
                var value = GetString(name);
                return new LocalizedString(name, value ?? name, resourceNotFound: value == null);
            }
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                var format = GetString(name);
                var value = string.Format(format ?? name, arguments);
                return new LocalizedString(name, value, resourceNotFound: format == null);
            }
        }

        private string GetString(string name)
        {
            if (CultureInfo.CurrentCulture.Name == Cultures.en_US)
            {
                return _resourceItems.ContainsKey(name) ? name : null;
            }

            var value = _resourceItems.Values.Where(x => x.LocalizedValue.ContainsKey(CultureInfo.CurrentCulture.Name)).SelectMany(x => x.LocalizedValue.Values).FirstOrDefault(x => x == name);
            return value;
        }
    }
}