using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OconnorEvents.Ordering.Dtos
{
    public class OrderLineDetailsDto
    {
        public Guid OrderLineId { get; set; }
        public int Price { get; set; }
        public int TicketAmount { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string VenueName { get; set; }
        public string VenueCity { get; set; }
        public string VenueCountry { get; set; }
    }
}
