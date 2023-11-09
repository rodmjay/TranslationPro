using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TranslationPro.Base.Engines.Entities;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Engines.Projections
{
    public class EngineProjections : Profile
    {
        public EngineProjections()
        {
            CreateMap<Engine, EngineOutput>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name));

            CreateMap<Engine, EngineWithLanguagesOutput>()
                .ForMember(x => x.Languages, opt => opt.MapFrom(x => x.Languages.Select(a => a.Language)));
        }
    }
}
