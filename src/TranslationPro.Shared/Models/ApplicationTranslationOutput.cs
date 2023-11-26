#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

namespace TranslationPro.Shared.Models;

public class ApplicationTranslationOutput
{
    public string Text { get; set; }
    public string LanguageId { get; set; }
    public string LanguageName { get; set; }
    public int MachineTranslations { get; set; }
}