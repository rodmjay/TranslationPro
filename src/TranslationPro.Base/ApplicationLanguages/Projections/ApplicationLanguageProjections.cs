using AutoMapper;
using TranslationPro.Base.ApplicationLanguages.Entities;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.ApplicationLanguages.Projections
{
    public class ApplicationLanguageProjections : Profile
    {
        public ApplicationLanguageProjections()
        {
            CreateMap<ApplicationEngineLanguage, ApplicationEngineLanguageOutput>()
                .ForMember(x=>x.EngineId, opt=>opt.MapFrom(x=>x.EngineId))
                .ForMember(x=>x.EngineName, opt=>opt.MapFrom(x=>x.ApplicationEngine.Engine.Name))
                .ForMember(x=>x.TranslationCount, opt=>opt.MapFrom(x=>x.Translations.Count));
        }
    }
}
