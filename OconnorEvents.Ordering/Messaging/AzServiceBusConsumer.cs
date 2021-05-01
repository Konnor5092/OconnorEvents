using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OconnorEvents.MessagingBus;
using OconnorEvents.Ordering.Dtos;
using OconnorEvents.Ordering.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OconnorEvents.Ordering.Messaging
{
    public class AzServiceBusConsumer : IMessageBusConsumer
    {
        private const string _subscriptionName = "oconnoreventsordering";
        private ServiceBusClient _client;
        
        private readonly string _checkoutMessageTopic;
        private readonly string _orderPaymentRequestMessageTopic;
        private readonly string _orderPaymentUpdatedMessageTopic;

        private ServiceBusProcessor _checkoutMessageProcessor;
        private ServiceBusProcessor _orderPaymentUpdatedProcessor;

        public AzServiceBusConsumer(IConfiguration configuration)
        {
            _client = new ServiceBusClient(configuration["ServiceBusConnectionString"]);

            _checkoutMessageTopic = configuration.GetValue<string>("CheckoutMessageTopic");
            _orderPaymentRequestMessageTopic = configuration.GetValue<string>("OrderPaymentRequestMessageTopic");
            _orderPaymentUpdatedMessageTopic = configuration.GetValue<string>("OrderPaymentUpdatedMessageTopic");

            _checkoutMessageProcessor = _client.CreateProcessor(_checkoutMessageTopic, _subscriptionName, new ServiceBusProcessorOptions());
            _orderPaymentUpdatedProcessor = _client.CreateProcessor(_orderPaymentUpdatedMessageTopic, _subscriptionName, new ServiceBusProcessorOptions());
        }

        public async void Start()
        {
            _checkoutMessageProcessor.ProcessMessageAsync += OnCheckoutMessageReceived;
            _checkoutMessageProcessor.ProcessErrorAsync += ErrorHandler;

            await _checkoutMessageProcessor.StartProcessingAsync();
        }

        public async void Stop()
        {
            await _checkoutMessageProcessor.StopProcessingAsync();
        }

        private async Task OnCheckoutMessageReceived(ProcessMessageEventArgs args)
        {
            var body = Encoding.UTF8.GetString(args.Message.Body);

            BasketCheckoutMessageDto basketCheckoutMessage = JsonConvert.DeserializeObject<BasketCheckoutMessageDto>(body);

            Guid orderId = Guid.NewGuid();

            //Order order = new Order
            //{
            //    UserId = basketCheckoutMessage.UserId,
            //    Id = orderId,
            //    OrderPaid = false,
            //    OrderPlaced = DateTime.Now,
            //    OrderTotal = basketCheckoutMessage.BasketTotal
            //};

            //await _orderRepository.AddOrder(order);

            ////send order payment request message
            //OrderPaymentRequestMessage orderPaymentRequestMessage = new OrderPaymentRequestMessage
            //{
            //    CardExpiration = basketCheckoutMessage.CardExpiration,
            //    CardName = basketCheckoutMessage.CardName,
            //    CardNumber = basketCheckoutMessage.CardNumber,
            //    OrderId = orderId,
            //    Total = basketCheckoutMessage.BasketTotal
            //};

            try
            {
                //await _messageBus.PublishMessage(orderPaymentRequestMessage, orderPaymentRequestMessageTopic);
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
