using System.Collections.Generic;
using System.Threading.Tasks;
using TranslationPro.Base.Applications.Entities;
using TranslationPro.Base.Applications.Models;
using TranslationPro.Base.Common.Models;
using TranslationPro.Base.Common.Services.Interfaces;

namespace TranslationPro.Base.Applications.Interfaces
{
    public interface IApplicationService : IService<Application>
    {
        Task<Result> CreateApplication(int userId, CreateApplicationDto dto);
        Task<List<T>> GetApplications<T>(int userId) where T : ApplicationDto;
    }
}
