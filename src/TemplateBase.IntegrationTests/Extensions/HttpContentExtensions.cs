#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System.Net.Http;
using Newtonsoft.Json;

namespace TemplateBase.IntegrationTests.Extensions
{
    public static class HttpContentExtensions
    {
        public static T DeserializeObject<T>(this HttpContent content)
        {
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            var jsonContent = content.ReadAsStringAsync().Result;

            var obj = JsonConvert.DeserializeObject<T>(jsonContent, settings);
            return obj;
        }
    }
}