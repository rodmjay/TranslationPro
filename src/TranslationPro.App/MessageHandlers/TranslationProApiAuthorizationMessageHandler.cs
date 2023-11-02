using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace TranslationPro.App.MessageHandlers
{
    public class TranslationProApiAuthorizationMessageHandler : AuthorizationMessageHandler
    {
        public TranslationProApiAuthorizationMessageHandler(
            IAccessTokenProvider provider, NavigationManager navigation) 
            : base(provider, navigation)
        {
            ConfigureHandler(
                  authorizedUrls: new[] { "https://localhost:44340/" });
        }
    }
}
