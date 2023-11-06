using AutoMapper;
using TranslationPro.Base.ApplicationLanguages.Entities;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.ApplicationLanguages.Projections
{
    public class ApplicationLanguageProjections : Profile
    {
        public ApplicationLanguageProjections()
        {
            CreateMap<ApplicationLanguage, ApplicationLanguageOutput>()
                .ForMember(x=>x.TranslationCount, opt=>opt.MapFrom(x=>x.Translations.Count));
        }
    }
}
