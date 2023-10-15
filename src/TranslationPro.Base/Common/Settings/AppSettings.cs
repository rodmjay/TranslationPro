#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using TranslationPro.Base.Common.Caching;
using TranslationPro.Base.Common.Data;
using TranslationPro.Base.Email.Settings;

namespace TranslationPro.Base.Common.Settings
{
    public class AppSettings
    {
        public string ApiUrl { get; set; }
        public string JsClientUrl { get; set; }
        public string MvcClientUrl { get; set; }
        public string Name { get; set; }
        public string Authority { get; set; }
        public string Audience { get; set; }
        public DatabaseSettings Database { get; set; }
        public CacheSettings Cache { get; set; }
        public SendGridSettings SendGrid { get; set; }
        public string CodeSigningThumbprint { get; set; }

        public string IdentityEndpoint => ApiUrl + "/v1.0/identity";
    }
}