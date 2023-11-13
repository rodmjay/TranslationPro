using System.Collections.Generic;
using System.Threading.Tasks;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Entities;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Interfaces
{
    public interface IEngineService : IService<Engine>
    {
        Task<List<T>> GetEngines<T>() where T : EngineOutput;
    }
}
