#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Linq;
using AutoMapper;
using TranslationPro.Base.Phrases.Entities;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Phrases;

public class PhaseProjections : Profile
{
    public PhaseProjections()
    {
        CreateMap<ApplicationPhrase, PhraseOutput>()
            .ForMember(x => x.Text, opt => opt.MapFrom(x => x.Phrase.Text))
            .ForMember(x => x.TranslationCount, opt => opt.MapFrom(x => x.Phrase.MachineTranslations
                .Where(b => b.Text != null).Select(a => a.LanguageId).Distinct().Count()))
            .ForMember(x => x.PendingTranslationCount, opt => opt.MapFrom(x => x.Phrase.MachineTranslations
                .Where(b => b.Text == null).Select(a => a.LanguageId).Distinct().Count()))
            .IncludeAllDerived();

        CreateMap<ApplicationPhrase, PhraseWithTranslationOutput>()
            .ForMember(x => x.MachineTranslations, opt => opt
                .MapFrom(x => x.Phrase.MachineTranslations.Where(mt => mt.Text != null)))
            .ForMember(x => x.HumanTranslations, opt => opt
                .MapFrom(x => x.HumanTranslations.Where(ht => ht.Text != null)));
    }
}