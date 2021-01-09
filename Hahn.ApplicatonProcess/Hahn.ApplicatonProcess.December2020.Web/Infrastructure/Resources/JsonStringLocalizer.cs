using System;
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

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures) => _resourceItems.Values
            .Where(x => x.LocalizedValue.ContainsKey(CultureInfo.CurrentCulture.Name))
            .Select(x => new LocalizedString(x.Key, x.LocalizedValue[CultureInfo.CurrentCulture.Name], true));

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
            if (!_resourceItems.ContainsKey(name))
                return null;

            if (CultureInfo.CurrentCulture.Name == Cultures.en_US)
                return name;

            var value = _resourceItems[name].LocalizedValue.ContainsKey(CultureInfo.CurrentCulture.Name)
                ? _resourceItems[name].LocalizedValue[CultureInfo.CurrentCulture.Name]
                : null;
            return value;
        }
    }
}