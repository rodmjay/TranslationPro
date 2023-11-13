#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using TranslationPro.Base.Interfaces;
using TranslationPro.Functions;

[assembly: FunctionsStartup(typeof(Startup))]

namespace TranslationPro.Functions;

public class TranslationFunctions
{
    private readonly IApplicationService _applicationService;
    private readonly IMachineTranslationService _machineTranslationService;

    public TranslationFunctions(IApplicationService applicationService, IMachineTranslationService machineTranslationService)
    {
        _applicationService = applicationService;
        _machineTranslationService = machineTranslationService;
    }

    //[FunctionName("ProcessTranslationsAutomatically")]
    //public async Task Run(
    //    [SqlTrigger("[dbo].[Translation]", "DefaultConnection")]
    //    IReadOnlyList<SqlChange<Translation>> changes,
    //    ILogger logger)
    //{
    //    var results = await _translationService.ProcessAllTranslationsAsync().ConfigureAwait(false);
    //}


    //[FunctionName("ProcessTranslationsManually")]
    //public async Task<IActionResult> ProcessManually(
    //    [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]
    //    HttpRequest req,
    //    ILogger log)
    //{
    //    var results = await _translationService.ProcessAllTranslationsAsync().ConfigureAwait(false);
    //    return new OkObjectResult(results);
    //}
}