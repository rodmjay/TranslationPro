#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using Microsoft.AspNetCore.Identity;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Users.Entities;

namespace TranslationPro.Base.Users.Interfaces
{
    public interface IRoleService : IService<Role>,
        IRoleStore<Role>,
        IQueryableRoleStore<Role>,
        IRoleClaimStore<Role>
    {
    }
}