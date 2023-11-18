using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Options;
using TranslationPro.Base.Common.Settings;

namespace TranslationPro.Base.Messaging
{
    public class JobSender
    {
        private readonly ServiceBusSender _sender;
        private readonly bool _isUnderTest;
        public JobSender(ServiceBusClient client, IOptions<AppSettings> settings)
        {
            _isUnderTest = settings.Value.IsUnderTest;
            _sender = client.CreateSender("jobs");
            
        }
        

        public async Task SendJobMessage(Guid applicationId, int jobId)
        {
            var groupName = $"{applicationId}.jobs.{jobId}";

            ServiceBusMessage message = new ServiceBusMessage(groupName);

            await _sender.SendMessageAsync(message);
        }
    }
}
