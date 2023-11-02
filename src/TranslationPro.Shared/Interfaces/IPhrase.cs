#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion


namespace TranslationPro.Shared.Interfaces;

public interface IPhrase
{
    int Id { get; set; }
    string Text { get; set; }
}