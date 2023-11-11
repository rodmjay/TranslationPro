#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Threading.Tasks;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Phrases.Entities;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Phrases.Interfaces;

public interface IPhraseService : IService<Phrase>
{
    Task<Result> EnsurePhraseWithLanguages(CreatePhraseOptions options);
}