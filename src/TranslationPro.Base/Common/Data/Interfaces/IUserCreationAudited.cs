#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using TranslationPro.Base.Users.Entities;

namespace TranslationPro.Base.Common.Data.Interfaces;

public interface IUserCreationAudited : ICreationAudited, IHasCreationTime
{
    /// <summary>Reference to the creator user of this entity.</summary>
    User CreatorUser { get; set; }
}