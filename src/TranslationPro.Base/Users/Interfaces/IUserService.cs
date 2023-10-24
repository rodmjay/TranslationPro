#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using Microsoft.AspNetCore.Identity;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Users.Entities;

namespace TranslationPro.Base.Users.Interfaces;

public interface IUserService : IService<User>,
    IQueryableUserStore<User>,
    IUserPasswordStore<User>,
    IUserRoleStore<User>,
    IUserClaimStore<User>,
    IUserLoginStore<User>,
    IUserLockoutStore<User>,
    IUserPhoneNumberStore<User>,
    IUserEmailStore<User>,
    IUserAuthenticatorKeyStore<User>,
    IUserTwoFactorStore<User>,
    IUserTwoFactorRecoveryCodeStore<User>,
    IUserSecurityStampStore<User>,
    IUserAuthenticationTokenStore<User>
{
}