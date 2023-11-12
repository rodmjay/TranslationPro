using System.Linq;
using AutoMapper;
using TranslationPro.Base.MachineTranslations.Entities;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.MachineTranslations
{
    public class EngineProjections : Profile
    {
        public EngineProjections()
        {
            CreateMap<Engine, EngineOutput>()
                .IncludeAllDerived();

            CreateMap<Engine, EngineWithLanguagesOutput>()
                .ForMember(x => x.Languages, opt => opt.MapFrom(x => x.Languages.Select(a => a.Language)));
        }
    }
}
