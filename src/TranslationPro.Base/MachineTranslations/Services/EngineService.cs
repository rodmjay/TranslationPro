using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.MachineTranslations.Entities;
using TranslationPro.Base.MachineTranslations.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.MachineTranslations.Services
{
    public class EngineService : BaseService<Engine>, IEngineService
    {
        public EngineService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        private IQueryable<Engine> Engines =>
            Repository.Queryable();

        public Task<List<T>> GetEngines<T>() where T : EngineOutput
        {
            return Engines.ProjectTo<T>(ProjectionMapping).ToListAsync();
        }
    }
}
