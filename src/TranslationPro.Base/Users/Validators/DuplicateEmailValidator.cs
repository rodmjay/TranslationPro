#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TranslationPro.Base.Users.Entities;

namespace TranslationPro.Base.Users.Validators;

public class DuplicateEmailValidator : IUserValidator<User>
{
    private readonly IdentityErrorDescriber _errors;

    public DuplicateEmailValidator(IdentityErrorDescriber errors)
    {
        _errors = errors;
    }

    public async Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user)
    {
        var userByEmail = await manager.FindByEmailAsync(user.NormalizedEmail);
        if (userByEmail != null) return IdentityResult.Failed(_errors.DuplicateEmail(user.Email));
        return IdentityResult.Success;
    }
}