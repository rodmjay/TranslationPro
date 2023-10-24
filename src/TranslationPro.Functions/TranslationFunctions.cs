using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using TranslationPro.Base.Applications.Interfaces;
using TranslationPro.Base.Translations.Interfaces;
using TranslationPro.Functions;

[assembly: FunctionsStartup(typeof(Startup))]

namespace TranslationPro.Functions;

public class TranslationFunctions
{
    private readonly IApplicationService _applicationService;
    private readonly ITranslationService _translationService;

    public TranslationFunctions(IApplicationService applicationService, ITranslationService translationService)
    {
        _applicationService = applicationService;
        _translationService = translationService;
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