#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Threading.Tasks;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Models;

namespace TranslationPro.Shared.Interfaces;

public interface IApplicationUsersController
{
    Task<Result> InviteUserAsync(Guid applicationId, ApplicationUserCreateOptions input);
}