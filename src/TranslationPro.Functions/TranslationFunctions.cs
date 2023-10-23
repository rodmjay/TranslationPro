using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using TranslationPro.Base.Applications.Interfaces;
using TranslationPro.Base.Translations.Interfaces;

[assembly: FunctionsStartup(typeof(TranslationPro.Functions.Startup))]

namespace TranslationPro.Functions
{

    public class TranslationFunctions
    {
        private readonly ITranslationService _translationService;

        public TranslationFunctions(IApplicationService applicationService, ITranslationService translationService)
        {
            _translationService = translationService;
        }



        [FunctionName("CreateTranslation")]
        public static IActionResult Run(
                [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
                [Sql("SELECT * FROM [dbo].[table1]", connectionStringSetting: "", CommandType.Text)] IEnumerable<Object> result,
                ILogger log)
        {
            log.LogInformation("C# HTTP trigger with SQL Input Binding function processed a request.");

            return new OkObjectResult(result);
        }

        [FunctionName("HttpPostFunction")]
        public async Task<IActionResult> Run2(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            
            var missingTranslations = await _translationService.GetMissingTranslationsByApplicationByLanguage();

            return new OkObjectResult(missingTranslations);
        }

    }
}
