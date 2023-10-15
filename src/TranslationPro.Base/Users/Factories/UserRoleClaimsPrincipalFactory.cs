#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using TranslationPro.Base.Users.Managers;
using TranslationPro.Base.Users.Entities;

namespace TranslationPro.Base.Users.Factories
{
    public class UserRoleClaimsPrincipalFactory : UserClaimsPrincipalFactory
    {
        private readonly RoleManager _roleManager;
        private readonly UserManager _userManager;

        public UserRoleClaimsPrincipalFactory(UserManager userManager, RoleManager roleManager,
            IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
        {
            var id = await base.GenerateClaimsAsync(user);

            if (_userManager.SupportsUserRole)
            {
                var roles = await _userManager.GetRolesAsync(user);
                foreach (var roleName in roles)
                {
                    id.AddClaim(new Claim(Options.ClaimsIdentity.RoleClaimType, roleName));
                    if (_roleManager.SupportsRoleClaims)
                    {
                        var role = await _roleManager.FindByNameAsync(roleName);
                        if (role != null) id.AddClaims(await _roleManager.GetClaimsAsync(role));
                    }
                }
            }

            return id;
        }
    }
}