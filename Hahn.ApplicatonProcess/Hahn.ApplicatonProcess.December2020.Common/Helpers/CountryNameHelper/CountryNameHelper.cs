using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Common.Helpers.CountryNameHelper
{
    public static class CountryNameHelper
    {
        public static bool IsValid(string name)
        {
            try
            {
                var result = SendGetRequest(string.Format(CommonConstants.CountryNameHelperUrl, name)).GetAwaiter().GetResult();
                JsonSerializer.Deserialize<CountryNameRootobject[]>(result);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static async Task<string> SendGetRequest(string url)
        {
            using var client = new HttpClient();
            return await client.GetStringAsync(url);
        }
    }
}