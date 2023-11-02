using Microsoft.AspNetCore.Authorization;

namespace TranslationPro.Shared.Policies
{
    public static class Policies
    {
        public const string CanAccessApis = "CanAccessApi";

        public static AuthorizationPolicy CanAccessApi()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireClaim("scope", "api1")
                .Build();
        }
    }
}
