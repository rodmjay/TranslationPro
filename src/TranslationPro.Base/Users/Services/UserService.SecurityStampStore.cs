#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Threading;
using System.Threading.Tasks;
using TranslationPro.Base.Users.Entities;

namespace TranslationPro.Base.Users.Services;

public partial class UserService
{
    public Task SetSecurityStampAsync(User user, string stamp, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ThrowIfDisposed();

        user.SecurityStamp = stamp;
        return Task.CompletedTask;
    }

    public Task<string> GetSecurityStampAsync(User user, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ThrowIfDisposed();

        return Task.FromResult(user.SecurityStamp);
    }
}