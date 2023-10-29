#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using IdentityModel;

namespace TranslationPro.Testing.Services;

public class SimpleProfileService : IProfileService

{
    public Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        var subject = context.Subject.Claims.First(claim => claim.Type == JwtClaimTypes.Subject).Value;

        context.IssuedClaims = new List<Claim>
        {
            new(JwtClaimTypes.Subject, subject),
            new(JwtClaimTypes.Scope, "profile"),
            new(JwtClaimTypes.Scope, "openid"),
            new(JwtClaimTypes.Scope, "api1")
        };

        return Task.CompletedTask;
    }

    public Task IsActiveAsync(IsActiveContext context)
    {
        context.IsActive = true;
        return Task.CompletedTask;
    }
}