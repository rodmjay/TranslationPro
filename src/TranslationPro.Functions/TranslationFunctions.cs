using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using TranslationPro.Base.Applications.Interfaces;
using TranslationPro.Base.Applications.Models;

[assembly: FunctionsStartup(typeof(TranslationPro.Functions.Startup))]

namespace TranslationPro.Functions
{

    public class TranslationFunctions
    {
        private readonly IApplicationService _applicationService;

        public TranslationFunctions(IApplicationService applicationService)
        {
            _applicationService = applicationService;
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

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            var applications = await _applicationService.GetApplicationsForUserAsync<ApplicationDto>(1);
            

            return new OkObjectResult(applications);
        }

    }
}
