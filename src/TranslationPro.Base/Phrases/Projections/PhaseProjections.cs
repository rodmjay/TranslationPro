#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Linq;
using AutoMapper;
using TranslationPro.Base.Phrases.Entities;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Phrases.Projections;

public class PhaseProjections : Profile
{
    public PhaseProjections()
    {
        CreateMap<Phrase, PhraseDto>()
            .ForMember(x => x.TranslationCount,
                opt => opt.MapFrom(x => x.Translations.Count))
            .ForMember(x => x.PendingTranslationCount,
                opt => opt.MapFrom(x => x.Translations.Count(t => t.Text == null)));
    }
}