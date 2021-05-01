using OconnorEvents.MessagingBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OconnorEvents.Ordering.Dtos
{
    public class OrderPaymentRequestMessage : IntegrationBaseMessage
    {
        public Guid OrderId { get; set; }
        public int Total { get; set; }
        public string CardNumber { get; set; }
        public string CardName { get; set; }
        public string CardExpiration { get; set; }
    }
}
