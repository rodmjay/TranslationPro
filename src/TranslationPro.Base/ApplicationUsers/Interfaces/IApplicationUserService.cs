using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TranslationPro.Base.ApplicationUsers.Entities;
using TranslationPro.Base.ApplicationUsers.Models;
using TranslationPro.Base.Common.Models;
using TranslationPro.Base.Common.Services.Interfaces;

namespace TranslationPro.Base.ApplicationUsers.Interfaces
{
    public interface IApplicationUserService : IService<ApplicationUser>
    {
        Task<Result> InviteUserAsync(Guid applicationId, CreateApplicationUser input);

        Task<List<T>> GetUsersForApplication<T>(Guid applicationId);
    }
}
