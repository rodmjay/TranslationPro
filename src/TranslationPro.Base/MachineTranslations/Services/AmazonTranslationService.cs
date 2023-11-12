using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.MachineTranslations.Entities;
using TranslationPro.Base.MachineTranslations.Interfaces;

namespace TranslationPro.Base.MachineTranslations.Services;

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