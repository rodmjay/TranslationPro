using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Newtonsoft.Json;
using TranslationPro.Base.Applications.Interfaces;
using TranslationPro.Base.Applications.Models;
using TranslationPro.Base.Translations.Interfaces;
using Google.Cloud.Translation.V2;
using System;
using System.Collections.Generic;
using NWebsec.Core.Common.HttpHeaders.Configuration;
using TranslationPro.Base.Common.Models;

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

        [FunctionName("ProcessTranslations")]
        public async Task<IActionResult> ProcessManually(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            List<Result> results = new List<Result>();

            // generate your own google api key for cloud translation api and store in machine's environment variables

            var apiKey = Environment.GetEnvironmentVariable("TranslationProGoogleApi");
            log.LogInformation("C# HTTP trigger function processed a request.");
            
            var missingTranslations = await _translationService.GetMissingTranslationsByApplicationByLanguage();

            var applications = await _applicationService.GetApplicationsAsync<ApplicationDto>();

            foreach (var keyValue in missingTranslations)
            {
                var application = applications.FirstOrDefault(x => x.Id == keyValue.Key);
                if (application != null)
                {
                    var client = TranslationClient.CreateFromApiKey(apiKey);

                    var languageDictionary = keyValue.Value;

                    foreach (var langKeyValue in languageDictionary)
                    {
                        var texts = langKeyValue.Value.Select(x => x.ToString()).ToList();
                        var translations = client.TranslateText(texts, langKeyValue.Key);

                        log.LogInformation(JsonConvert.SerializeObject(translations));

                        var result = await _translationService.SaveBulkTranslations(application.Id, translations.ToList());
                        results.Add(result);
                    }


                }
               
            }

            return new OkObjectResult(results);
        }

    }
}
