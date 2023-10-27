#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Threading.Tasks;
using TranslationPro.Base.ApplicationUsers.Models;
using TranslationPro.Base.Common.Models;

namespace TranslationPro.Api.Interfaces;

public interface IApplicationUsersController
{
    Task<Result> InviteUserAsync(Guid applicationId, CreateApplicationUser input);
}