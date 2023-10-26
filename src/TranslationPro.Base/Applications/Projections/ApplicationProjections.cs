#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Linq;
using AutoMapper;
using TranslationPro.Base.Applications.Entities;
using TranslationPro.Base.Applications.Models;

namespace TranslationPro.Base.Applications.Projections;

public class ApplicationProjections : Profile
{
    public ApplicationProjections()
    {
        CreateMap<Application, ApplicationDto>()
            .ForMember(x => x.SupportedLanguages, opt => opt.MapFrom(x => x.Languages.Select(l => l.LanguageId)))
            .ForMember(x => x.PhraseCount, opt => opt.MapFrom(x => x.Phrases.Count))
            .ForMember(x=>x.Languages, opt=>opt.MapFrom(x=>x.Languages))
            .ForMember(x => x.TranslationCount,
                opt => opt.MapFrom(x => x.Phrases.SelectMany(a => a.Translations).Count()))
            .ForMember(x => x.PendingTranslationCount,
                opt => opt.MapFrom(x => x.Phrases.SelectMany(a => a.Translations).Count(b => b.Text == null)));
    }
}