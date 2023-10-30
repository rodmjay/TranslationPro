using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TranslationPro.Base.ApplicationUsers.Entities;
using TranslationPro.Base.ApplicationUsers.Enums;
using TranslationPro.Base.ApplicationUsers.Interfaces;
using TranslationPro.Base.ApplicationUsers.Models;
using TranslationPro.Base.Common.Data.Enums;
using TranslationPro.Base.Common.Models;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Users.Entities;
using TranslationPro.Base.Users.Managers;

namespace TranslationPro.Base.ApplicationUsers.Services
{
    public class ApplicationUserService : BaseService<ApplicationUser>, IApplicationUserService
    {
        private readonly UserManager _userManager;
        private readonly ApplicationUserErrorDescriber _errorDescriber;

        public ApplicationUserService(IServiceProvider serviceProvider, UserManager userManager, ApplicationUserErrorDescriber errorDescriber) : base(serviceProvider)
        {
            _userManager = userManager;
            _errorDescriber = errorDescriber;
        }

        private IQueryable<ApplicationUser> ApplicationUsers =>
            Repository.Queryable().Include(x => x.User).Include(x => x.Application);

        public async Task<Result> InviteUserAsync(Guid applicationId, CreateApplicationUser input)
        {
            var applicationUser = await ApplicationUsers.Where(x=>x.User.Email == input.Email && x.ApplicationId == applicationId).FirstOrDefaultAsync();

            if (applicationUser != null)
                return Result.Failed();

            var user = await _userManager.FindByEmailAsync(input.Email);

            if (user == null)
            {
                user = new User()
                {
                    Email = input.Email,
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    ObjectState = ObjectState.Added
                };

                var identityResult = await _userManager.CreateAsync(user);
                if (!identityResult.Succeeded)
                {
                    return Result.Failed();
                }
            }
            else
            {
                user.ObjectState = ObjectState.Modified;
            }

            applicationUser = new ApplicationUser()
            {
                UserId = user.Id,
                ApplicationId = applicationId,
                InvitationDate = DateTime.UtcNow,
                ObjectState = ObjectState.Added,
                Role = ApplicationRole.Contributor
            };

            var records = Repository.InsertOrUpdateGraph(applicationUser, true);
            if(records > 0)
                return Result.Success();

            return Result.Failed();
        }

        public Task<List<T>> GetUsersForApplication<T>(Guid applicationId)
        {
            throw new NotImplementedException();
        }
    }
}
