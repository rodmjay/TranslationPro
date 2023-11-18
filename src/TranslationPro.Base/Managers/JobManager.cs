#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Google.Cloud.Translation.V2;
using Microsoft.EntityFrameworkCore;
using TranslationPro.Base.Common.Data.Enums;
using TranslationPro.Base.Common.Data.Interfaces;
using TranslationPro.Base.Entities;
using TranslationPro.Base.Services;
using TranslationPro.Shared.Enums;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Managers;

public class JobManager
{
    private readonly IJobService _jobService;
    private readonly IPhraseService _phraseService;
    private readonly IRepositoryAsync<Job> _jobRepository;
    private static string GetLogMessage(string message, [CallerMemberName] string callerName = null)
    {
        return $"[{nameof(JobManager)}.{callerName}] - {message}";
    }

    public JobManager(
        IJobService jobService, 
        IPhraseService phraseService, 
        IUnitOfWorkAsync unitOfWork)
    {
        _jobRepository = unitOfWork.RepositoryAsync<Job>();
        _jobService = jobService;
        _phraseService = phraseService;
    }

    private IQueryable<Job> Jobs => _jobRepository.Queryable().Include(x=>x.Phrases)
        .Include(x=>x.Languages);

    public async Task ProcessJob(int jobId)
    {
        var phrasesAdded = 0;

        var job = await Jobs.Where(x => x.Id == jobId).FirstOrDefaultAsync();
        if (job != null)
        {
            job.Status = JobStatus.InProgress;
            job.ObjectState = ObjectState.Modified;

            _jobRepository.Update(job, true);

            // add empty phrase records for each phrase and language
            foreach (var phrase in job.Phrases)
            {
                if (phrase.Status == JobPhraseStatus.Pending)
                {
                    await _phraseService
                        .EnsurePhraseWithLanguages(
                            phrase.PhraseId,
                            job.Languages.Select(a => a.LanguageId).ToArray());

                    await _jobService.UpdateJobPhraseStatus(jobId, phrase.PhraseId, JobPhraseStatus.PhraseAddedToApplication);
                }

                if (phrase.Status == JobPhraseStatus.PhraseAddedToApplication)
                {
                    
                }
            }
        }
    }
}