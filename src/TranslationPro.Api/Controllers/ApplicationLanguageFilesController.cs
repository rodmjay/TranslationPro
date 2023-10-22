using System;
using TranslationPro.Base.Common.Middleware.Bases;

namespace TranslationPro.Api.Controllers;

public class ApplicationLanguageFilesController : BaseController
{
    public ApplicationLanguageFilesController(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}