using OconnorEvents.Core;
using System;

namespace OconnorEvents.ShoppingBasket.Entities
{
    public class Event : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string VenueName { get; set; }
        public string VenueCity { get; set; }
        public string VenueCountry { get; set; }
    }
}
