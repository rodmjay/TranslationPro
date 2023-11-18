using System;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using TranslationPro.Base.Managers;
using TranslationPro.Jobs;

[assembly: FunctionsStartup(typeof(Startup))]

namespace TranslationPro.Jobs
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;
        private readonly JobManager _jobManager;

        public Function1(ILogger<Function1> logger, JobManager jobManager)
        {
            _logger = logger;
            _jobManager = jobManager;
        }

        [FunctionName(nameof(Function1))]
        public void Run([ServiceBusTrigger("jobs", Connection = "ServiceBusConnection")] ServiceBusReceivedMessage message)
        {
            _logger.LogInformation("Message ID: {id}", message.MessageId);
            _logger.LogInformation("Message Body: {body}", message.Body);
            _logger.LogInformation("Message Content-Type: {contentType}", message.ContentType);
        }
    }
}
