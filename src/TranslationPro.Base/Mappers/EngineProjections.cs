using System.Linq;
using AutoMapper;
using TranslationPro.Base.Entities;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Mappers
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
