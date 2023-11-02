﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using TranslationPro.Shared.ApplicationLanguages;
using TranslationPro.Shared.ApplicationUsers;

namespace TranslationPro.Shared.Applications;

public class ApplicationDto : IApplication
{
    public List<string> SupportedLanguages { get; set; }
    public int PhraseCount { get; set; }
    public int TranslationCount { get; set; }
    public int PendingTranslationCount { get; set; }
    public Guid Id { get; set; }
    public string Name { get; set; }

    public List<ApplicationLanguageDto> Languages { get; set; }
    public List<ApplicationUserDto> Users { get; set; }
}