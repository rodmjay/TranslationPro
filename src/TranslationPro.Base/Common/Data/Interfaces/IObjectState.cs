#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using TranslationPro.Base.Common.Data.Enums;

namespace TranslationPro.Base.Common.Data.Interfaces;

public interface IObjectState
{
    public ObjectState ObjectState { get; set; }
}