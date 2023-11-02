using TranslationPro.Shared.ApplicationUsers;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Controllers;

namespace TranslationPro.App.Proxies;

public class ApplicationUsersProxy : BaseProxy, IApplicationUsersController
{
    public Task<Result> InviteUserAsync(Guid applicationId, CreateApplicationUser input)
    {
        return DoPost<CreateApplicationUser, Result>($"{ApplicationUrl}/{applicationId}/users", input);
    }

    public ApplicationUsersProxy(HttpClient httpClient) : base(httpClient)
    {
    }
}