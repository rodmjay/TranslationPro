#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using AutoMapper;
using TranslationPro.Base.Entities;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Mappers;

public class ApplicationTranslationMapper : Profile
{
    public ApplicationTranslationMapper()
    {

        CreateMap<ApplicationTranslation, ApplicationTranslationOutput>()
            .ForMember(x => x.LanguageName, opt => opt.MapFrom(x => x.ApplicationLanguage.LanguageId))
            .IncludeAllDerived();

        CreateMap<ApplicationTranslation, ApplicationTranslationOutputWithOriginalPhrase>()
            .ForMember(x => x.Phrase,
                opt => opt.MapFrom(x => x.ApplicationPhrase.Text));
    }
}