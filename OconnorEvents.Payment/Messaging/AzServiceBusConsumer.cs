using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using OconnorEvents.MessagingBus;
using OconnorEvents.Payment.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OconnorEvents.Payment.Messaging
{
    public class AzServiceBusConsumer : IHostedService
    {
        private const string _subscriptionName = "oconnoreventspayment";
        private ServiceBusClient _client;
        private IMessageBus _messageBus;

        private readonly string _orderPaymentRequestMessageTopic;
        private readonly string _orderPaymentUpdatedMessageTopic;
        private ServiceBusProcessor _orderPaymentRequestedProcessor;

        public AzServiceBusConsumer(IConfiguration configuration, IMessageBus messageBus)
        {
            _client = new ServiceBusClient(configuration["ServiceBusConnectionString"]);
            _messageBus = messageBus;

            _orderPaymentRequestMessageTopic = configuration.GetValue<string>("OrderPaymentRequestMessageTopic");
            _orderPaymentUpdatedMessageTopic = configuration.GetValue<string>("OrderPaymentUpdatedMessageTopic");

            _orderPaymentRequestedProcessor = _client.CreateProcessor(_orderPaymentRequestMessageTopic, _subscriptionName, new ServiceBusProcessorOptions());
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _orderPaymentRequestedProcessor.ProcessMessageAsync += ProcessMessageAsync;
            _orderPaymentRequestedProcessor.ProcessErrorAsync += ErrorHandler;

            await _orderPaymentRequestedProcessor.StartProcessingAsync();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _orderPaymentRequestedProcessor.StopProcessingAsync();
        }

        private async Task ProcessMessageAsync(ProcessMessageEventArgs args)
        {
            var messageBody = Encoding.UTF8.GetString(args.Message.Body);
            var orderPaymentRequestMessage = JsonConvert.DeserializeObject<OrderPaymentRequestMessage>(messageBody);

            var orderPaymentUpdateMessage = new OrderPaymentUpdateMessage
            {
                PaymentSuccess = true,
                OrderId = orderPaymentRequestMessage.OrderId
            };

            try
            {
                await _messageBus.PublishMessage(orderPaymentUpdateMessage, _orderPaymentUpdatedMessageTopic);
                await args.CompleteMessageAsync(args.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }
    }
}
