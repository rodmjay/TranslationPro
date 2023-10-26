#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

namespace TranslationPro.Base.Languages.Interfaces;

public interface ILanguage
{
    string Name { get; set; }
    string Id { get; set; }
}