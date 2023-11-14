#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TranslationPro.Base.Common.Data.Interfaces;
using TranslationPro.Base.Entities;
using TranslationPro.Base.Services;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Managers;

public class ApplicationTranslationManager
{
    private readonly IApplicationPhraseService _applicationPhraseService;
    private readonly IMachineTranslationService _machineTranslationService;
    private readonly IApplicationTranslationService _applicationTranslationService;
    private readonly IRepositoryAsync<ApplicationPhrase> _applicationPhraseRepository;
    private readonly IRepositoryAsync<ApplicationTranslation> _applicationTranslationRepository;

    public ApplicationTranslationManager(
        IUnitOfWorkAsync unitOfWork,
        IApplicationPhraseService applicationPhraseService,
        IMachineTranslationService machineTranslationService,
        IApplicationTranslationService applicationTranslationService)
    {
        _applicationPhraseService = applicationPhraseService;
        _machineTranslationService = machineTranslationService;
        _applicationTranslationService = applicationTranslationService;
        _applicationPhraseRepository = unitOfWork.RepositoryAsync<ApplicationPhrase>();
        _applicationTranslationRepository = unitOfWork.RepositoryAsync<ApplicationTranslation>();
    }

    public async Task<Result> ReplaceTranslation(Guid applicationId, int phraseId, TranslationReplacementOptions input)
    {
        var originalText = await _applicationTranslationRepository.Queryable()
            .Where(x => x.ApplicationId == applicationId && x.PhraseId == phraseId && x.LanguageId == input.LanguageId)
            .Select(x=>x.Text).FirstAsync();

        var result = await _applicationTranslationService.ReplaceTranslation(applicationId, phraseId, input);
        if (result.Succeeded)
        {
            var originalPhrase = await _applicationPhraseRepository.Queryable().Include(x=>x.Phrase)
                .ThenInclude(x=>x.MachineTranslations)
                .Where(x => x.ApplicationId == applicationId &&
                x.Id == phraseId).FirstOrDefaultAsync();
            
            if (originalPhrase != null)
            {
                await _machineTranslationService.AdjustWeights(originalPhrase.PhraseId, input.LanguageId, originalText,
                    input.Text);
            }
            
        }


        return result;
    }

}