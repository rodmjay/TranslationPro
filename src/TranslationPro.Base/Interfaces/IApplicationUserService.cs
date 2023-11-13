using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Entities;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Interfaces
{
    public interface IApplicationUserService : IService<ApplicationUser>
    {
        Task<Result> InviteUserAsync(Guid applicationId, ApplicationUserCreateOptions input);

        Task<List<T>> GetUsersForApplication<T>(Guid applicationId);
    }
}
