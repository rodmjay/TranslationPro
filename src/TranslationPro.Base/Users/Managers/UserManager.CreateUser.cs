#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TranslationPro.Base.Users.Entities;

namespace TranslationPro.Base.Users.Managers;

public partial class UserManager
{
    public override async Task<IdentityResult> CreateAsync(User user)
    {
        ThrowIfDisposed();
        await UpdateSecurityStampInternal(user);
        var result = await ValidateUser(user);
        if (!result.Succeeded) return result;
        if (Options.Lockout.AllowedForNewUsers && SupportsUserLockout)
            await _userService.SetLockoutEnabledAsync(user, true, CancellationToken);

        // set two-factor enabled here 

        await UpdateNormalizedUserNameAsync(user);
        await UpdateNormalizedEmailAsync(user);

        return await _userService.CreateAsync(user, CancellationToken);
    }

    public override async Task<IdentityResult> CreateAsync(User user, string password)
    {
        ThrowIfDisposed();
        if (user == null) throw new ArgumentNullException(nameof(user));
        if (password == null) throw new ArgumentNullException(nameof(password));
        var result = await UpdatePasswordHash(user, password, true);
        if (!result.Succeeded) return result;
        return await CreateAsync(user);
    }
}