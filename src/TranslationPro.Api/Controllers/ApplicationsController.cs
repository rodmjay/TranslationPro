using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TranslationPro.Base.Applications.Interfaces;
using TranslationPro.Base.Applications.Models;
using TranslationPro.Base.Common.Middleware.Bases;
using TranslationPro.Base.Common.Models;
using TranslationPro.Base.Users.Services;

namespace TranslationPro.Api.Controllers;

public class ApplicationsController : BaseController
{
    private readonly IApplicationService _service;
    private readonly UserAccessor _userAccessor;

    protected ApplicationsController(IServiceProvider serviceProvider, IApplicationService service, UserAccessor userAccessor) : base(serviceProvider)
    {
        _service = service;
        _userAccessor = userAccessor;
    }

    public async Task<List<ApplicationDto>> GetApplications()
    {
        return await _service.GetApplications<ApplicationDto>(1);
    }

    public async Task<Result> CreateApplication(CreateApplicationDto input)
    {
        return await _service.CreateApplication(1, input);
    }
}