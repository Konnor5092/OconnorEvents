using System;
using System.ComponentModel.DataAnnotations;

namespace OconnorEvents.ShoppingBasket.Dtos
{
    public class BasketLineForUpdateDto
    {
        public Guid BasketLineId { get; set; }
        public int Quantity { get; set; }
    }
}
