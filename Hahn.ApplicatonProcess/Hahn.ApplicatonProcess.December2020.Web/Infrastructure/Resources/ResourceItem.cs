using System.Collections.Generic;

namespace Hahn.ApplicatonProcess.December2020.Web.Infrastructure.Resources
{
    public class ResourceItem
    {
        public string Key { get; set; }
        public IDictionary<string, string> LocalizedValue { get; set; }
    }
}