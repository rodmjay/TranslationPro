#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Linq;
using AutoMapper;
using TranslationPro.Base.Applications.Entities;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Applications.Projections;

public class ApplicationProjections : Profile
{
    public ApplicationProjections()
    {
        CreateMap<Application, ApplicationOutput>()
            .ForMember(x => x.SupportedLanguages, opt => opt.MapFrom(x => x.EngineLanguages.Select(l => l.LanguageId).Distinct()))
            .ForMember(x => x.PhraseCount, opt => opt.MapFrom(x => x.Phrases.Count))
            .ForMember(x=>x.Users, opt=>opt.MapFrom(x=>x.Users))
            .ForMember(x=>x.Languages, opt=>opt.MapFrom(x=>x.EngineLanguages))
            .ForMember(x => x.TranslationCount,
                opt => opt.MapFrom(x => x.Phrases.SelectMany(a => a.MachineTranslations).Count()))
            .ForMember(x => x.PendingTranslationCount,
                opt => opt.MapFrom(x => x.Phrases.SelectMany(a => a.MachineTranslations).Count(b => b.Text == null)));
    }
}