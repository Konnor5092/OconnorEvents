using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using OconnorEvents.MessagingBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OconnorEvents.Ordering.Extensions
{
    public class MessageBusConsumerService : IHostedService
    {
        private IMessageBusConsumer ServiceBusConsumer { get; set; }

        public MessageBusConsumerService(IMessageBusConsumer messageBusConsumer)
        {
            ServiceBusConsumer = messageBusConsumer;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            ServiceBusConsumer.Start();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            ServiceBusConsumer.Stop();
            return Task.CompletedTask;
        }
    }
}
