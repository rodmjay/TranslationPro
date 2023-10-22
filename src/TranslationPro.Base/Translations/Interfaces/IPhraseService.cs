﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TranslationPro.Base.Common.Models;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Translations.Entities;
using TranslationPro.Base.Translations.Models;

namespace TranslationPro.Base.Translations.Interfaces;

public interface IPhraseService : IService<Phrase>
{
    Task<PagedList<T>> GetPhrasesForApplicationAsync<T>(Guid applicationId, PagingQuery query, PhraseFilters filters) where T : PhraseDto;
    Task<Result> CreatePhraseAsync(Guid applicationId,  CreatePhraseDto input);
    Task<Result> UpdatePhraseAsync(Guid applicationId, int phraseId, UpdatePhraseDto input);
    Task<Result> DeletePhraseAsync(Guid applicationId, int phraseId);
    Task<Dictionary<int, string>> GetApplicationPhraseList(Guid applicationId, string language);

}