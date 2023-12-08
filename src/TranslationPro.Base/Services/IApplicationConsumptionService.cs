using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Entities;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Services
{
    public interface IApplicationConsumptionService : IService<Application>
    {
        Task<Dictionary<DateTime, ConsumptionInfo>> GetConsumptionInfo(Guid applicationId, DateTime startDate,
            DateTime endDate);
    }
}
