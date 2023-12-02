#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Security.Claims;
using System.Threading.Tasks;
using TranslationPro.Shared.Interfaces;

namespace TranslationPro.Base.Users.Interfaces;

public interface IUserAccessor
{
    Task<IUser> GetUser(ClaimsPrincipal principal);
}