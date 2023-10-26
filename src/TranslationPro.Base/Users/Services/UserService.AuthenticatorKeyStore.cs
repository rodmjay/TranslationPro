#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Threading;
using System.Threading.Tasks;
using TranslationPro.Base.Users.Entities;

namespace TranslationPro.Base.Users.Services;

public partial class UserService
{
    public Task SetAuthenticatorKeyAsync(User user, string key, CancellationToken cancellationToken)
    {
        return SetTokenAsync(user, InternalLoginProvider, AuthenticatorKeyTokenName, key, cancellationToken);
    }

    public Task<string> GetAuthenticatorKeyAsync(User user, CancellationToken cancellationToken)
    {
        return GetTokenAsync(user, InternalLoginProvider, AuthenticatorKeyTokenName, cancellationToken);
    }
}