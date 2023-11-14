#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Collections.Generic;
using System.Threading.Tasks;
using TranslationPro.Shared.Results;

namespace TranslationPro.Base.Services;

public interface ITranslationProcessor
{
    Task<Dictionary<string, List<GenericTranslationResult>>> Process(Dictionary<string, List<string>> dictionary);
}