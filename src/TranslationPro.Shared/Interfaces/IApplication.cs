#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion


namespace TranslationPro.Shared.Interfaces;

public interface IApplication
{
    Guid Id { get; set; }
    string Name { get; set; }
}