using Azure.Messaging.ServiceBus;
using Microsoft.EntityFrameworkCore;
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
        private readonly DbContextOptions<OrderDbContext> _options;
        private IMessageBus _messageBus;
        
        private readonly string _checkoutMessageTopic;
        private readonly string _orderPaymentRequestMessageTopic;
        private readonly string _orderPaymentUpdatedMessageTopic;
        private ServiceBusProcessor _checkoutMessageProcessor;
        private ServiceBusProcessor _orderPaymentUpdatedProcessor;

        public AzServiceBusConsumer(IConfiguration configuration, DbContextOptions<OrderDbContext> options, IMessageBus messageBus)
        {
            _client = new ServiceBusClient(configuration["ServiceBusConnectionString"]);
            _options = options;
            _messageBus = messageBus;

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

            _orderPaymentUpdatedProcessor.ProcessMessageAsync += OnOrderPaymentUpdateReceived;
            _orderPaymentUpdatedProcessor.ProcessErrorAsync += ErrorHandler;

            await _checkoutMessageProcessor.StartProcessingAsync();
            await _orderPaymentUpdatedProcessor.StartProcessingAsync();
        }

        public async void Stop()
        {
            await _checkoutMessageProcessor.StopProcessingAsync();
            await _orderPaymentUpdatedProcessor.StopProcessingAsync();
        }

        private async Task OnCheckoutMessageReceived(ProcessMessageEventArgs args)
        {
            var messageBody = Encoding.UTF8.GetString(args.Message.Body);
            var basketCheckoutMessage = JsonConvert.DeserializeObject<BasketCheckoutMessageDto>(messageBody);

            await using var _orderDbContext = new OrderDbContext(_options);
            var existingCustomer = await _orderDbContext.Customers.FindAsync(basketCheckoutMessage.UserId);

            if (existingCustomer == null)
            {
                var newCustomer = new Customer
                {
                    CustomerId = basketCheckoutMessage.UserId,
                    FirstName = basketCheckoutMessage.FirstName,
                    LastName = basketCheckoutMessage.LastName,
                    Email = basketCheckoutMessage.Email,
                    Address = basketCheckoutMessage.Address,
                    ZipCode = basketCheckoutMessage.ZipCode,
                    City = basketCheckoutMessage.City,
                    Country = basketCheckoutMessage.Country
                };

                await _orderDbContext.Customers.AddAsync(newCustomer);
            }

            Guid orderId = Guid.NewGuid();

            var order = new Order
            {
                UserId = basketCheckoutMessage.UserId,
                Id = orderId,
                OrderPaid = false,
                OrderPlaced = DateTime.Now,
                OrderTotal = basketCheckoutMessage.BasketTotal
            };

            order.OrderLines = new List<OrderLine>();

            foreach (var bLine in basketCheckoutMessage.BasketLines)
            {
                var orderLine = new OrderLine
                {
                    OrderLineId = Guid.NewGuid(),
                    Price = bLine.Price,
                    TicketAmount = bLine.TicketAmount,
                    EventId = bLine.EventId,
                    EventName = bLine.EventName,
                    EventDate = bLine.EventDate,
                    VenueName = bLine.VenueName,
                    VenueCity = bLine.VenueCity,
                    VenueCountry = bLine.VenueCountry
                };
                order.OrderLines.Add(orderLine);
            }

            await _orderDbContext.Orders.AddAsync(order);

            var orderPaymentRequestMessage = new OrderPaymentRequestMessage
            {
                CardExpiration = basketCheckoutMessage.CardExpiration,
                CardName = basketCheckoutMessage.CardName,
                CardNumber = basketCheckoutMessage.CardNumber,
                OrderId = orderId,
                Total = basketCheckoutMessage.BasketTotal
            };

            try
            {           
                await _orderDbContext.SaveChangesAsync();                

                await _messageBus.PublishMessage(orderPaymentRequestMessage, _orderPaymentRequestMessageTopic);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private async Task OnOrderPaymentUpdateReceived(ProcessMessageEventArgs args)
        {
            var messageBody = Encoding.UTF8.GetString(args.Message.Body);
            var orderPaymentUpdateMessage = JsonConvert.DeserializeObject<OrderPaymentUpdateMessage>(messageBody);

            await using var _orderDbContext = new OrderDbContext(_options);
            var order = await _orderDbContext.Orders.FindAsync(orderPaymentUpdateMessage.OrderId);
            order.OrderPaid = orderPaymentUpdateMessage.PaymentSuccess;
            await _orderDbContext.SaveChangesAsync();
        }

        private Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }
    }
}
