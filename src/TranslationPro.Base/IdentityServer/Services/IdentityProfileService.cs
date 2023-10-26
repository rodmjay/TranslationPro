#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using TranslationPro.Base.Users.Factories;
using TranslationPro.Base.Users.Managers;

namespace TranslationPro.Base.IdentityServer.Services;

public class IdentityProfileService : IProfileService
{
    private readonly UserRoleClaimsPrincipalFactory _userClaimsFactory;
    private readonly UserManager _userManager;

    public IdentityProfileService(
        UserManager userManager,
        UserRoleClaimsPrincipalFactory userClaimsFactory)
    {
        _userManager = userManager;
        _userClaimsFactory = userClaimsFactory;
    }

    public async Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        var sub = context.Subject.GetSubjectId();
        var user = await _userManager.FindByIdAsync(sub);
        var principal = await _userClaimsFactory.CreateAsync(user);

        var claims = principal.Claims.ToList();

        claims = claims
            .Where(claim => context.RequestedClaimTypes.Contains(claim.Type)).ToList();

        claims.Add(user.TwoFactorEnabled ? new Claim("amr", "mfa") : new Claim("amr", "pwd"));

        claims.Add(new Claim(IdentityServerConstants.StandardScopes.Email, user.Email));


        context.IssuedClaims = claims;
    }


    public async Task IsActiveAsync(IsActiveContext context)
    {
        var sub = context.Subject.GetSubjectId();
        var user = await _userManager.FindByIdAsync(sub);
        context.IsActive = user != null;
    }
}