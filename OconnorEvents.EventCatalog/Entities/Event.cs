using OconnorEvents.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace OconnorEvents.EventCatalog.Entities
{
    public class Event : IEntity
    {
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public Guid VenueId { get; set; }
        public Venue Venue { get; set; }

    }
}
