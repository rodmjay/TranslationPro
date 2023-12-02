#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Threading.Tasks;
using TranslationPro.Shared.Models;

namespace TranslationPro.Shared.Interfaces;

public interface IUserController
{
    Task<UserOutput> GetUser();
}