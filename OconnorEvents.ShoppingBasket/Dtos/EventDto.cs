using System;

namespace OconnorEvents.ShoppingBasket.Dtos
{
    public class EventDto
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
