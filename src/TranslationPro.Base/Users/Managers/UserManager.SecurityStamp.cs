﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TranslationPro.Base.Common.Cryptography;
using TranslationPro.Base.Users.Entities;

namespace TranslationPro.Base.Users.Managers;

public partial class UserManager
{
    public override Task<string> GetSecurityStampAsync(User user)
    {
        if (user == null) throw new ArgumentNullException(nameof(user));

        return _userService.GetSecurityStampAsync(user, CancellationToken.None);
    }

    public override Task<string> GenerateConcurrencyStampAsync(User user)
    {
        return Task.FromResult(Guid.NewGuid().ToString());
    }

    public override async Task<IdentityResult> UpdateSecurityStampAsync(User user)
    {
        ThrowIfDisposed();
        if (user == null) throw new ArgumentNullException(nameof(user));

        await UpdateSecurityStampInternal(user);
        return await UpdateUserAsync(user);
    }

    private async Task UpdateSecurityStampInternal(User user)
    {
        if (SupportsUserSecurityStamp)
            await _userService.SetSecurityStampAsync(user, NewSecurityStamp(), CancellationToken);
    }

    private static string NewSecurityStamp()
    {
        var bytes = new byte[20];
        RandomNumberGenerator.Fill(bytes);
        return CustomBase32.ToBase32(bytes);
    }
}