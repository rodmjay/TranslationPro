#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Threading.Tasks;

namespace TranslationPro.Base.Interfaces;

public interface IPermissionService
{
    Task<bool> UserCanAccessApplication(int userId, Guid applicationId);
}