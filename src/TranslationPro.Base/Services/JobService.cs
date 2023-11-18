#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TranslationPro.Base.Common.Data.Enums;
using TranslationPro.Base.Common.Data.Interfaces;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Entities;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Enums;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Services;

public class JobService : BaseService<Job>, IJobService
{
    private readonly IRepositoryAsync<Phrase> _phraseRepository;
    private readonly IRepositoryAsync<JobPhrase> _jobPhraseRepository;
    private readonly IRepositoryAsync<Language> _languageRepository;
    public JobService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _phraseRepository = UnitOfWork.RepositoryAsync<Phrase>();
        _languageRepository = UnitOfWork.RepositoryAsync<Language>();
        _jobPhraseRepository = UnitOfWork.RepositoryAsync<JobPhrase>();
    }

    private IQueryable<Job> Jobs => Repository.Queryable()
        .Include(x => x.Languages)
        .Include(x => x.Phrases);

    private IQueryable<Phrase> Phrases => _phraseRepository.Queryable();
    private IQueryable<Language> Languages => _languageRepository.Queryable();
    private IQueryable<JobPhrase> JobPhrases => _jobPhraseRepository.Queryable();

    public async Task<List<T>> GetJobs<T>(Guid applicationId) where T : JobOutput
    {
        return await Jobs
            .Where(x => x.ApplicationId == applicationId)
            .ProjectTo<T>(ProjectionMapping)
            .ToListAsync();
    }

    public async Task<T> GetJob<T>(Guid applicationId, int jobId) where T : JobOutput
    {
        return await Jobs
            .Where(x => x.Id == jobId && x.ApplicationId == applicationId)
            .ProjectTo<T>(ProjectionMapping)
            .FirstAsync();
    }

    public async Task<Result> CreateJob(Guid applicationId, JobCreateOptions options)
    {
        var job = new Job()
        {
            ApplicationId = applicationId,
            ObjectState = ObjectState.Added,
            Status = JobStatus.Pending,
        };

        var phrases = await Phrases.Where(x => options.Phrases.Contains(x.Id)).ToListAsync();

        var languages = await Languages.Where(x => options.Languages.Contains(x.Id)).ToListAsync();

        foreach (var phrase in phrases)
        {
            job.Phrases.Add(new JobPhrase()
            {
                PhraseId = phrase.Id,
                ObjectState = ObjectState.Added
            });
        }

        foreach (var language in languages)
        {
            job.Languages.Add(new JobLanguage()
            {
                LanguageId = language.Id,
                ObjectState = ObjectState.Added
            });
        }

        var records = Repository.Insert(job, true);
        if (records > 0)
            return Result.Success(job.Id);

        return Result.Failed();
    }

    public async Task<Result> UpdateJobPhraseStatus(int jobId, int phraseId, JobPhraseStatus status)
    {
        var jobPhrase = await JobPhrases.Where(x => x.JobId == jobId && x.PhraseId == phraseId).FirstAsync();
        jobPhrase.Status = status;
        jobPhrase.ObjectState = ObjectState.Modified;

        var records = await _jobPhraseRepository.UpdateAsync(jobPhrase, true);
        if (records > 0)
            return Result.Success();
        return Result.Success();
    }
    
}