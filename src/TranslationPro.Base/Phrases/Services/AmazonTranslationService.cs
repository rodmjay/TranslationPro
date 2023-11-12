using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Engines.Entities;
using TranslationPro.Base.Translations.Entities;
using TranslationPro.Base.Translations.Interfaces;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Enums;

namespace TranslationPro.Base.Phrases.Services;

public class AmazonTranslationService : BaseService<Engine>, ITranslationProcessor
{
    public AmazonTranslationService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }


    private IQueryable<Engine> Engines => Repository.Queryable().Include(x => x.Languages);


    public Task<Dictionary<string, List<GenericTranslationResult>>> Process(Dictionary<string, List<string>> dictionary)
    {
        throw new NotImplementedException();
    }
}