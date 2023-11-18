using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using TranslationPro.Base.Managers;

namespace TranslationPro.Jobs
{
    public class JobFunction
    {
        private readonly ILogger<JobFunction> _logger;

        public JobFunction(ILoggerFactory logger)
        {
            _logger = logger.CreateLogger<JobFunction>();
        }

        [Function(nameof(JobFunction))]
        public string Run(
            [ServiceBusTrigger("jobs", Connection = "AzureServiceBusConnection")] ServiceBusReceivedMessage message)
        {
            _logger.LogInformation("Message ID: {id}", message.MessageId);
            _logger.LogInformation("Message Body: {body}", message.Body);
            _logger.LogInformation("Message Content-Type: {contentType}", message.ContentType);
            //throw new NotImplementedException();

            return "completed";
        }
    }
}
