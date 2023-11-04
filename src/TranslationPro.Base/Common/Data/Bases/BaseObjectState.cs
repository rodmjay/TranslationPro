#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TranslationPro.Base.Common.Data.Enums;
using TranslationPro.Base.Common.Data.Interfaces;

namespace TranslationPro.Base.Common.Data.Bases;

public abstract class BaseObjectState : IObjectState
{
    [NotMapped][IgnoreDataMember] public ObjectState ObjectState { get; set; }
}