using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslationPro.Base.Common.Models;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Translations.Entities;
using TranslationPro.Base.Translations.Interfaces;
using TranslationPro.Base.Translations.Models;

namespace TranslationPro.Base.Translations.Services
{
    public class TranslationService : BaseService<Translation>, ITranslationService
    {
        public TranslationService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public Task<Result> CreateTranslation(Guid applicationId, CreateTranslationDto input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedList<T>> GetTranslations<T>(Guid applicationId, PagingQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
