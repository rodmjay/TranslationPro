using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TranslationPro.Base.Common.Models;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Phrases.Entities;
using TranslationPro.Base.Phrases.Models;

namespace TranslationPro.Base.Phrases.Interfaces;

public interface IPhraseService : IService<Phrase>
{
    Task<PagedList<T>> GetPhrasesForApplicationAsync<T>(Guid applicationId, PagingQuery query, PhraseFilters filters)
        where T : PhraseDto;

    Task<Result> BulkUploadPhrases(Guid applicationId, List<string> phrases);
    Task<Result> CreatePhraseAsync(Guid applicationId, PhraseInput input);
    Task<Result> UpdatePhraseAsync(Guid applicationId, int phraseId, PhraseInput input);
    Task<Result> DeletePhraseAsync(Guid applicationId, int phraseId);
    Task<Dictionary<int, string>> GetApplicationPhraseList(Guid applicationId, string language);
}