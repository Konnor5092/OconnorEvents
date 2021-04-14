using OconnorEvents.Core;
using System;

namespace OconnorEvents.ShoppingBasket.Entities
{
    public class Event : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
