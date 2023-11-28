#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;

namespace TranslationPro.Base.Common.Data.Interfaces;

public interface ICreated
{
    DateTimeOffset Created { get; set; }
}