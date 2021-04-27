using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OconnorEvents.MessagingBus
{
    public class AzServiceBusMessageBus : IMessageBus
    {
        private ServiceBusClient _client;

        public AzServiceBusMessageBus(string connectionString)
        {
            _client = new ServiceBusClient(connectionString);
        }

        public async Task PublishMessage(IntegrationBaseMessage message, string topicName)
        {
            ServiceBusSender sender = _client.CreateSender(topicName);

            var jsonMessage = JsonConvert.SerializeObject(message);
            var serviceBusMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(jsonMessage))
            {
                CorrelationId = Guid.NewGuid().ToString()
            };

            await sender.SendMessageAsync(serviceBusMessage);
            Console.WriteLine($"Sent message to {sender.EntityPath}");
        }
    }
}
