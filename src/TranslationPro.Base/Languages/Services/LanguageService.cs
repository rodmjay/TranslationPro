using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Languages.Entities;
using TranslationPro.Base.Languages.Interfaces;
using TranslationPro.Base.Languages.Models;

namespace TranslationPro.Base.Languages.Services
{
    public class LanguageService : BaseService<Language>, ILanguageService
    {
        public LanguageService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public IList<T> GetLanguages<T>() where T : LanguageDto
        {
            throw new NotImplementedException();
        }
    }
}
