#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;

namespace TranslationPro.Base.IntegrationTests.Services
{
    public class SimpleResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            if (context.UserName != "admin" || context.Password != "ASDFasdf!")
            {
                context.Result =
                    new GrantValidationResult(TokenRequestErrors.InvalidRequest, "Username or password is wrong!");
                return Task.CompletedTask;
            }

            context.Result = new GrantValidationResult("1", OidcConstants.AuthenticationMethods.Password,
                new List<Claim>
                {
                    new(JwtClaimTypes.Subject, "1")
                });

            return Task.CompletedTask;
        }
    }
}