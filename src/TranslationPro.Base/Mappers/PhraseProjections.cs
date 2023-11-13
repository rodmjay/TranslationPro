#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Linq;
using AutoMapper;
using TranslationPro.Base.Entities;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Mappers;

public class PhraseProjections : Profile
{
    public PhraseProjections()
    {
        CreateMap<Phrase, PhraseOutput>()
            .ForMember(x=>x.MachineTranslations, opt=>opt.MapFrom(x=>x.MachineTranslations))
            .IncludeAllDerived();

        CreateMap<ApplicationPhrase, ApplicationPhraseOutput>()
            .ForMember(x => x.Text, opt => opt.MapFrom(x => x.Phrase.Text))
            .ForMember(x => x.TranslationCount, opt => opt.MapFrom(x => x.Translations.Count))
            .ForMember(x => x.PendingTranslationCount, opt => opt.MapFrom(x => x.Phrase.MachineTranslations
                .Where(b => b.Text == null).Select(a => a.LanguageId).Distinct().Count()))
            .IncludeAllDerived();

        CreateMap<ApplicationPhrase, ApplicationPhraseDetails>()
            .ForMember(x=>x.Translations, opt=>opt.MapFrom(x=>x.Translations));


        CreateMap<ApplicationTranslation, ApplicationTranslationOutput>()
            .ForMember(x=>x.LanguageName, opt=>opt.MapFrom(x=>x.ApplicationLanguage.Language.Name))
            .IncludeAllDerived();
    }
}