﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Entities;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Services
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
