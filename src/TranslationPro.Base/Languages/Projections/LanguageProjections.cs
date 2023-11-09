#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Linq;
using AutoMapper;
using TranslationPro.Base.Languages.Entities;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Languages.Projections;

public class LanguageProjections : Profile
{
    public LanguageProjections()
    {
        CreateMap<Language, LanguageOutput>().IncludeAllDerived();

        CreateMap<Language, LanguagesWithEnginesOutput>()
            .ForMember(x=>x.Engines, opt=>opt.MapFrom(x=>x.Engines.Select(a=>a.Engine)))
            .IncludeAllDerived();
    }
}