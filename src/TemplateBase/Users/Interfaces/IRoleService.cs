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
    public interface IRoleService : IService<Role>,
        IRoleStore<Role>,
        IQueryableRoleStore<Role>,
        IRoleClaimStore<Role>
    {
    }
}