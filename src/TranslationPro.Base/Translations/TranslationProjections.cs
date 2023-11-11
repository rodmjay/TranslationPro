#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using AutoMapper;
using TranslationPro.Base.Translations.Entities;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Translations;

public class TranslationProjections : Profile
{
    public TranslationProjections()
    {
        CreateMap<HumanTranslation, HumanTranslationOutput>()
            .ForMember(x => x.LanguageName, opt => opt.MapFrom(x => x.Language.Name));

        CreateMap<MachineTranslation, MachineTranslationOutput>()
            .ForMember(x => x.LanguageName, opt => opt.MapFrom(x => x.Language.Language.Name));
    }
}