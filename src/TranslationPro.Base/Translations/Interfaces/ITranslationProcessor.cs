#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Collections.Generic;
using System.Threading.Tasks;
using TranslationPro.Base.Phrases.Services;

namespace TranslationPro.Base.Translations.Interfaces;

public interface ITranslationProcessor
{
    Task<Dictionary<string, List<GenericTranslationResult>>> Process(Dictionary<string, List<string>> dictionary);
}