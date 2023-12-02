#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Net.Http;
using System.Threading.Tasks;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Shared.Proxies;

public class UserProxy : BaseProxy, IUserController
{
    public UserProxy(HttpClient httpClient) : base(httpClient)
    {
    }

    public Task<UserOutput> GetUser()
    {
        return DoGet<UserOutput>("v1.0/user");
    }
}