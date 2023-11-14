#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Threading.Tasks;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Entities;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Models;
using TranslationPro.Shared.Results;

namespace TranslationPro.Base.Services;

public interface IPhraseService : IService<Phrase>
{
    Task<Result> EnsurePhraseWithLanguages(PhraseCreateOptions options);
    Task<int> EnsurePhrasesWithLanguage(Guid applicationId, string languageId, int[] phraseIds);
    
}