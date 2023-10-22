﻿using System;
using System.Threading.Tasks;
using TranslationPro.Base.Common.Models;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Translations.Entities;
using TranslationPro.Base.Translations.Models;

namespace TranslationPro.Base.Translations.Interfaces
{
    public interface ITranslationService : IService<Translation>
    {
        Task<Result> CreateTranslation(Guid applicationId, CreateTranslationDto input);
        Task<Result> UpdateTranslation(Guid applicationId, int translationId, UpdateTranslationDto input);

        Task<PagedList<T>> GetTranslations<T>(Guid applicationId, PagingQuery query);

    }
}
