using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

    [HttpGet]
    public async Task<List<ApplicationDto>> GetApplicationsAsync()
    {
        return await _service.GetApplicationsForUserAsync<ApplicationDto>(1);
    }

    [HttpPost]
    public async Task<Result> CreateApplicationAsync(ApplicationInput input)
    {
        var user = await GetCurrentUser();
        
        return await _service.CreateApplicationAsync(user.Id, input).ConfigureAwait(false);
    }

    [HttpPut]
    public async Task<Result> UpdateApplicationAsync(Guid applicationId, ApplicationInput input)
    {
        await AssertUserHasAccessToApplication(applicationId);

        return await _service.UpdateApplicationAsync(applicationId, input).ConfigureAwait(false);
    }
}