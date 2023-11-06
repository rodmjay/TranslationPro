#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using AutoMapper;
using TranslationPro.Base.Translations.Entities;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Translations.Projections;

public class TranslationProjections : Profile
{
    public TranslationProjections()
    {
        CreateMap<Translation, TranslationOutput>()
            .ForMember(x => x.LanguageName, opt => opt.MapFrom(x => x.Language.Name));
    }
}