using System.Linq;
using AutoMapper;
using TranslationPro.Base.Engines.Entities;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Engines
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
