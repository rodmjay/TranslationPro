using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.Configuration;

namespace TranslationPro.App.MessageHandlers
{
    public class TranslationProApiAuthorizationMessageHandler : AuthorizationMessageHandler
    {
        public TranslationProApiAuthorizationMessageHandler(
            IAccessTokenProvider provider, NavigationManager navigation, IConfiguration config) 
            : base(provider, navigation)
        {
            ConfigureHandler(
                  authorizedUrls: new[] { config["ApiBase"] });
        }
    }
}
