#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

namespace TranslationPro.Shared.Phrases;

public interface IPhrase
{
    int Id { get; set; }
    string Text { get; set; }
}