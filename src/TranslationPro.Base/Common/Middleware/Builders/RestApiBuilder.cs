#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using Microsoft.Extensions.DependencyInjection;
using TranslationPro.Base.Common.Settings;

namespace TranslationPro.Base.Common.Middleware.Builders
{
    public class RestApiBuilder
    {
        public RestApiBuilder(WebAppBuilder serviceBuilder)
        {
            Services = serviceBuilder.Services;
            AppSettings = serviceBuilder.AppSettings;
            ConnectionString = serviceBuilder.ConnectionString;
        }

        public string ConnectionString { get; set; }
        public AppSettings AppSettings { get; }
        public IServiceCollection Services { get; }
    }
}