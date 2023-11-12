#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using TranslationPro.Shared.Interfaces;

namespace TranslationPro.Shared.Models;

public class PhraseOutput : IPhrase
{
    public int TranslationCount { get; set; }
    public int PendingTranslationCount { get; set; }
    public int Id { get; set; }
    public string Text { get; set; }
}