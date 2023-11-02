#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

namespace TranslationPro.Shared.Languages;

public interface ILanguage
{
    string Name { get; set; }
    string Id { get; set; }
}