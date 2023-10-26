#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;

namespace TranslationPro.Base.Common.Data.Interfaces;

public interface IHasCreationTime
{
    /// <summary>Creation time of this entity.</summary>
    DateTime Created { get; set; }
}