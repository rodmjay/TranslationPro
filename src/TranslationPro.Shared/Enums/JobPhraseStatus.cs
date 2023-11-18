#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

namespace TranslationPro.Shared.Enums;

public enum JobPhraseStatus
{
    Pending  = 0,
    PhraseAddedWithEmptyTranslations = 1,
    TranslationsAdded = 2,
    PhraseAddedToApplication = 3
}