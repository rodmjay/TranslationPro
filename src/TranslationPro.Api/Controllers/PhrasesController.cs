using System;
using TranslationPro.Base.Common.Middleware.Bases;

namespace TranslationPro.Api.Controllers;

public class PhrasesController : BaseController
{
    protected PhrasesController(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}