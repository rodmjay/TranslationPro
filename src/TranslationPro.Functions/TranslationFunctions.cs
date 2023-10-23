using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using TranslationPro.Base.Applications.Interfaces;
using TranslationPro.Base.Translations.Interfaces;
using Microsoft.Azure.WebJobs.Extensions.Sql;
using TranslationPro.Base.Common.Data.Contexts;
using TranslationPro.Base.Translations.Entities;

[assembly: FunctionsStartup(typeof(TranslationPro.Functions.Startup))]

namespace TranslationPro.Functions
{
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
}
