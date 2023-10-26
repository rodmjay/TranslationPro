#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using TranslationPro.Base.Common;

namespace TranslationPro.Base.Users.Managers;

public partial class SignInManager
{
    public override async Task SignOutAsync()
    {
        await Context.SignOutAsync(Constants.LocalIdentity.DefaultApplicationScheme);
        await Context.SignOutAsync(Constants.LocalIdentity.DefaultExternalScheme);
        await Context.SignOutAsync(IdentityConstants.TwoFactorUserIdScheme);
    }
}