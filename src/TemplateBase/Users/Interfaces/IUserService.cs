#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using Microsoft.AspNetCore.Identity;
using TemplateBase.Common.Services.Interfaces;
using TemplateBase.Users.Entities;

namespace TemplateBase.Users.Interfaces
{
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
}