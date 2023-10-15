#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace TemplateBase.IntegrationTests.Extensions
{
    public static class ObjectExtensions
    {
        public static StringContent SerializeToUTF8Json(this object model)
        {
            return new(JsonConvert.SerializeObject(model),
                Encoding.UTF8, "application/json");
        }
    }
}