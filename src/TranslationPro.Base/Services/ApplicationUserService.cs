using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TranslationPro.Base.Common.Data.Enums;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Entities;
using TranslationPro.Base.Errors;
using TranslationPro.Base.Users.Entities;
using TranslationPro.Base.Users.Managers;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Enums;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Services
{
    public class ApplicationUserService : BaseService<ApplicationUser>, IApplicationUserService
    {
        private static string GetLogMessage(string message, [CallerMemberName] string callerName = null)
        {
            return $"[{nameof(ApplicationUserService)}.{callerName}] - {message}";
        }


        private readonly UserManager _userManager;
        private readonly ApplicationUserErrorDescriber _errorDescriber;
        private readonly ILogger<ApplicationUserService> _logger;

        public ApplicationUserService(IServiceProvider serviceProvider,
            UserManager userManager,
            ApplicationUserErrorDescriber errorDescriber,
            ILogger<ApplicationUserService> logger) : base(serviceProvider)
        {
            _userManager = userManager;
            _errorDescriber = errorDescriber;
            _logger = logger;
        }

        private IQueryable<ApplicationUser> ApplicationUsers =>
            Repository.Queryable().Include(x => x.User).Include(x => x.Application);

        public async Task<Result> InviteUserAsync(Guid applicationId, ApplicationUserCreateOptions input)
        {
            _logger.LogInformation(GetLogMessage("Inviting user: {0} to application: {1}"), input.Email, applicationId);

            var applicationUser = await ApplicationUsers.Where(x => x.User.Email == input.Email && x.ApplicationId == applicationId).FirstOrDefaultAsync();

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
            if (records > 0)
                return Result.Success();

            return Result.Failed();
        }

        public Task<List<T>> GetUsersForApplication<T>(Guid applicationId)
        {
            return ApplicationUsers.Where(x => x.ApplicationId == applicationId).ProjectTo<T>(ProjectionMapping)
                .ToListAsync();

        }
    }
}
