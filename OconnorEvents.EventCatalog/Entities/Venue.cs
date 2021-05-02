using OconnorEvents.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OconnorEvents.EventCatalog.Entities
{
    public class Venue : IEntity
    {
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<Event> Events { get; set; }
    }
}
