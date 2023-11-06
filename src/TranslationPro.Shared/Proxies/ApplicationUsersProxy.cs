using System;
using System.Net.Http;
using System.Threading.Tasks;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Shared.Proxies;

public class ApplicationUsersProxy : BaseProxy, IApplicationUsersController
{
    public Task<Result> InviteUserAsync(Guid applicationId, ApplicationUserCreateOptions input)
    {
        return DoPost<ApplicationUserCreateOptions, Result>($"{ApplicationUrl}/{applicationId}/users", input);
    }

    public ApplicationUsersProxy(HttpClient httpClient) : base(httpClient)
    {
    }
}