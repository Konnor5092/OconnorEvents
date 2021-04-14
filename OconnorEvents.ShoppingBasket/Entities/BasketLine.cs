using OconnorEvents.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace OconnorEvents.ShoppingBasket.Entities
{
    public class BasketLine : IEntity
    {
        public Guid Id { get; set; }

        [Required]
        public Guid BasketId { get; set; }

        [Required]
        public Guid EventId { get; set; }
        public Event Event { get; set; }

        [Required]
        public int TicketAmount { get; set; }

        [Required]
        public int Price { get; set; }

        public Basket Basket { get; set; }
    }
}
