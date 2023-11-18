#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Entities;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Enums;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Services;

public interface IJobService : IService<Job>
{
    Task<List<T>> GetJobs<T>(Guid applicationId) where T : JobOutput;
    Task<T> GetJob<T>(Guid applicationId, int jobId) where T: JobOutput;

    Task<Result> CreateJob(Guid applicationId, JobCreateOptions options);

    Task<Result> UpdateJobPhraseStatus(int jobId, int phraseId, JobPhraseStatus status);
}