#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;

namespace TranslationPro.Base.Applications.Interfaces;

public interface IApplication
{
    Guid Id { get; set; }
    string Name { get; set; }
}