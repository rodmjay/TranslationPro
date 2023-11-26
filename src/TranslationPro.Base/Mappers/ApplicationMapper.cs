#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Linq;
using AutoMapper;
using TranslationPro.Base.Entities;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Mappers;

public class ApplicationMapper : Profile
{
    public ApplicationMapper()
    {
        CreateMap<Application, ApplicationOutput>()
            .ForMember(x => x.PhraseCount, opt => opt.MapFrom(a => a.Phrases.Count))
            .ForMember(x => x.Users, opt => opt.MapFrom(a => a.Users))
            .ForMember(x => x.Languages, opt => opt.MapFrom(a => a.Languages.Select(al => al.Language)))
            .ForMember(x => x.TranslationCount,
                opt => opt.MapFrom(a => a.Phrases.SelectMany(ap => ap.Translations).Count(at => !at.IsDeleted)));
    }
}