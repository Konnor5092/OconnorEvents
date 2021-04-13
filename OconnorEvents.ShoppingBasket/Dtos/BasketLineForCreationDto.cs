using System;
using System.ComponentModel.DataAnnotations;

namespace OconnorEvents.ShoppingBasket.Dtos
{
    public class BasketLineForCreationDto
    { 
        [Required]
        public Guid EventId { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int TicketAmount { get; set; }
    }
}
