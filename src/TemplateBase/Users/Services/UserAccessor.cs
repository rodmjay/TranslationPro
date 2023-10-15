#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TemplateBase.Common.Services.Bases;
using TemplateBase.Users.Entities;
using TemplateBase.Users.Interfaces;
using TemplateBase.Users.Managers;
using TemplateBase.Users.Models;

namespace TemplateBase.Users.Services
{
    public class UserAccessor : BaseService<User>, IUserAccessor
    {
        private readonly UserManager _userManager;

        public UserAccessor(
            UserManager userManager,
            IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _userManager = userManager;
        }

        public Task<IUser> GetUser(ClaimsPrincipal principal)
        {
            var id = _userManager.GetUserId(principal);

            var userId = int.Parse(id);

            return _userManager.Users.Where(x => x.Id == userId)
                .ProjectTo<UserDto>(ProjectionMapping)
                .Cast<IUser>()
                .FirstOrDefaultAsync();
        }
    }
}