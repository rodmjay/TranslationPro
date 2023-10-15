using System;
using TranslationPro.Base.Common.Middleware.Bases;

namespace TranslationPro.Api.Controllers;

public class ApplicationsController : BaseController
{
    protected ApplicationsController(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}