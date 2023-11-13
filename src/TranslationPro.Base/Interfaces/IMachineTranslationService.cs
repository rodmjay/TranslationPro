#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Entities;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Interfaces;

public interface IMachineTranslationService : IService<MachineTranslation>
{
    Task<Result> AdjustWeights(int phraseId, string languageId, string oldText, string newText);
    Task<int> ProcessTranslationsAsync(Guid applicationId);
}