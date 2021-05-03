using System;
using OconnorEvents.MessagingBus;

namespace OconnorEvents.Payment.Messages
{
    public class OrderPaymentUpdateMessage: IntegrationBaseMessage
    {
        public Guid OrderId { get; set; }
        public bool PaymentSuccess { get; set; }
    }
}
