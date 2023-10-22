using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TranslationPro.Base.Applications.Interfaces;
using TranslationPro.Base.Applications.Models;
using TranslationPro.Base.Common.Middleware.Bases;
using TranslationPro.Base.Common.Models;

namespace TranslationPro.Api.Controllers;

public class ApplicationsController : BaseController
{
    private readonly IApplicationService _service;

    protected ApplicationsController(IServiceProvider serviceProvider, IApplicationService service) : base(serviceProvider)
    {
        _service = service;
    }

    public async Task<List<ApplicationDto>> GetApplicationsAsync()
    {
        return await _service.GetApplicationsForUserAsync<ApplicationDto>(1);
    }

    public async Task<Result> CreateApplicationAsync(ApplicationInputDto input)
    {
        var user = await GetCurrentUser();
        
        return await _service.CreateApplicationAsync(user.Id, input).ConfigureAwait(false);
    }

    public async Task<Result> UpdateApplicationAsync(Guid applicationId, ApplicationInputDto input)
    {
        await AssertUserHasAccessToApplication(applicationId);

        return await _service.UpdateApplicationAsync(applicationId, input).ConfigureAwait(false);
    }
}