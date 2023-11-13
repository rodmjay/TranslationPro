#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Linq;
using AutoMapper;
using TranslationPro.Base.Entities;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Mappers;

public class LanguageMapper : Profile
{
    public LanguageMapper()
    {
        CreateMap<Language, LanguageOutput>().IncludeAllDerived();

        CreateMap<Language, LanguagesWithEnginesOutput>()
            .ForMember(x => x.Engines, opt => opt.MapFrom(x => x.Engines.Select(a => a.Engine)))
            .IncludeAllDerived();
    }
}