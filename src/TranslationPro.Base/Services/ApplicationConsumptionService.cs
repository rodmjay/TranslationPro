using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Entities;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Services;

public class ApplicationConsumptionService : BaseService<Application>, IApplicationConsumptionService
{
    public ApplicationConsumptionService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    private IQueryable<Application> Applications => Repository.Queryable().Include(x => x.Phrases)
        .ThenInclude(x => x.Translations).IgnoreQueryFilters();

    public async Task<Dictionary<DateTime,ConsumptionInfo>> GetConsumptionInfo(Guid applicationId, DateTime startDate, DateTime endDate)
    {
        var application = await Applications.Where(x => x.Id == applicationId).FirstAsync();

        var phrases = application.Phrases.Where(x => x.CharacterCount > 0).ToList();
        var translations = phrases.SelectMany(x => x.Translations).Where(x => x.CharacterCount > 0).ToList();

        var phraseDictionary = phrases.GroupBy(x => x.Created.Date)
            .ToDictionary(x => x.Key, ap => ap.Sum(ap1 => ap1.CharacterCount));

        var translationDictionary = translations.GroupBy(x => x.Created.Date)
            .ToDictionary(x => x.Key, at => at.Sum(at1 => at1.CharacterCount));

        var uniqueDates = phraseDictionary.Select(x => x.Key).Union(translationDictionary.Select(x => x.Key)).ToList();

        var returnDictionary = new Dictionary<DateTime, ConsumptionInfo>();

        foreach (var date in uniqueDates)
        {
            var consumptionInfo = new ConsumptionInfo();

            if (phraseDictionary.ContainsKey(date))
            {
                consumptionInfo.OutputCharacters = phraseDictionary[date];
            }

            if (translationDictionary.ContainsKey(date))
            {
                consumptionInfo.InputCharacters = translationDictionary[date];
            }

            returnDictionary.Add(date, consumptionInfo);
        }

        return returnDictionary;
    }
}