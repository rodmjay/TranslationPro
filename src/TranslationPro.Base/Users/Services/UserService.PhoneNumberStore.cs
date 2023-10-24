#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System;
using System.Threading;
using System.Threading.Tasks;
using TranslationPro.Base.Users.Entities;

namespace TranslationPro.Base.Users.Services;

public partial class UserService
{
    public Task SetPhoneNumberAsync(User user, string phoneNumber, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ThrowIfDisposed();
        if (user == null) throw new ArgumentNullException(nameof(user));

        user.PhoneNumber = phoneNumber;
        return Task.CompletedTask;
    }

    public Task<bool> GetPhoneNumberConfirmedAsync(User user, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ThrowIfDisposed();
        if (user == null) throw new ArgumentNullException(nameof(user));

        return Task.FromResult(user.PhoneNumberConfirmed);
    }

    public Task SetPhoneNumberConfirmedAsync(User user, bool confirmed, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ThrowIfDisposed();
        if (user == null) throw new ArgumentNullException(nameof(user));

        user.PhoneNumberConfirmed = confirmed;
        return Task.CompletedTask;
    }

    public Task<string> GetPhoneNumberAsync(User user, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ThrowIfDisposed();
        if (user == null) throw new ArgumentNullException(nameof(user));

        return Task.FromResult(user.PhoneNumber);
    }
}