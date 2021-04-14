using OconnorEvents.Core;
using System;

namespace OconnorEvents.ShoppingBasket.Entities
{
    public class BasketChangeEvent : IEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid EventId { get; set; }
        public DateTimeOffset InsertedAt { get; set; }
        public BasketChangeTypeEnum BasketChangeType { get; set; }
    }
}
